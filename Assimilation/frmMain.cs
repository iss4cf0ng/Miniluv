using Miniluv;
using PacketDotNet;
using PacketDotNet.Utils;
using SharpPcap;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using static Assimilation.frmScanIP;

namespace Assimilation
{
    public partial class frmMain : Form
    {
        public delegate void NewDiscoveredDeviceEventHandler(string szMode, string szIPv4, string szMAC);
        public event NewDiscoveredDeviceEventHandler NewDiscoveredDevice;
        public delegate void ScanIpProgressEventHandler();
        public ScanIpProgressEventHandler ScanIpProgress;

        public delegate void SendPacket(IPAddress ip);

        private List<ILiveDevice> m_lsDevices;
        public stDeviceInfo m_stDeviceInfo;
        public ThoughtPolice m_tp;
        public SqlConn m_sqlConn;

        public Dictionary<string, ArpSpoofing> dicArpSpoofing = new Dictionary<string, ArpSpoofing>();
        public Dictionary<string, SynFlood> dicSynFloosing = new Dictionary<string, SynFlood>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void tpUpdateDeviceFilter()
        {
            List<string> lsFilter = listView1.Items.Cast<ListViewItem>().Select(x => $"({x.SubItems[1].Text})").ToList();
            string szFilter = string.Join(" || ", lsFilter);

            m_stDeviceInfo.device.Filter = szFilter;
        }
        private void tpClearDeviceFilter() => m_stDeviceInfo.device.Filter = "";

        private bool HasDevice() => m_stDeviceInfo.device == null;
        private bool HostExists(string szIPv4Addr)
        {
            bool bExists = false;

            try
            {
                Invoke(new Action(() =>
                {
                    foreach (TreeNode node in treeView1.Nodes)
                    {
                        foreach (TreeNode tn in node.Nodes)
                        {
                            if (tn.Text == szIPv4Addr)
                            {
                                bExists = true;
                                break;
                            }
                        }
                    }
                }));

                return bExists;
            }
            catch
            {
                return false;
            }
        }
        private void AddHostIntoTreeView(string szMode, string szIPv4Addr, string szMAC)
        {
            try
            {
                if (HostExists(szIPv4Addr))
                    return;

                Invoke(new Action(() =>
                {
                    //TreeView
                    TreeNode node = treeView1.Nodes[0];
                    TreeNode tn = new TreeNode(szIPv4Addr);
                    tn.Nodes.Add(new TreeNode(szMAC));

                    int nIdx = 0;
                    uint uIP = IPTool.IPToUInt32(IPAddress.Parse(szIPv4Addr));
                    foreach (TreeNode treeNode in node.Nodes)
                    {
                        uint uIPAddr = IPTool.IPToUInt32(IPAddress.Parse(treeNode.Text));
                        nIdx++;

                        if (uIP > uIPAddr)
                            break;
                    }

                    node.Nodes.Insert(nIdx - 1, tn);

                    //ListView2
                    ListViewItem item = new ListViewItem(szMode);
                    item.SubItems.Add(szIPv4Addr);
                    item.SubItems.Add(szMAC);
                    item.SubItems.Add("Ready");

                    listView2.Items.Add(item);
                }));
            }
            catch (Exception ex)
            {

            }
        }

        private IPAddress GetBoardcaseIPAddress(IPAddress ipAddr, IPAddress maskAddr)
        {
            byte[] abIP = ipAddr.GetAddressBytes();
            byte[] abMask = maskAddr.GetAddressBytes();

            byte[] abBoardcast = new byte[abIP.Length];

            for (int i = 0; i < abIP.Length; i++)
                abBoardcast[i] = (byte)(abIP[i] | (abMask[i] ^ 255));

            return new IPAddress(abBoardcast);
        }

        private IPAddress GetNetworkAddress(IPAddress ipAddr, IPAddress maskAddr)
        {
            byte[] abIP = ipAddr.GetAddressBytes();
            byte[] abMask = maskAddr.GetAddressBytes();
            byte[] abNetwork = new byte[abIP.Length];

            for (int i = 0; i < abIP.Length; i++)
                abNetwork[i] = (byte)(abIP[i] & abMask[i]);

            return new IPAddress(abNetwork);
        }

        /// <summary>
        /// Send ARP requests with specified ip range.
        /// </summary>
        /// <param name="ipStart"></param>
        /// <param name="ipEnd"></param>
        public void SendArpRequestWithIpRange(IPAddress ipStart, IPAddress ipEnd, SendPacket func, int nThreadCount)
        {
            uint uIpStart = IPTool.IPToUInt32(ipStart);
            uint uIpEnd = IPTool.IPToUInt32(ipEnd);

            if (uIpStart > uIpEnd)
            {
                MessageBox.Show("Invalid IP range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (m_stDeviceInfo.device == null)
            {
                MessageBox.Show("m_stDeviceInfo.device is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(nThreadCount, nThreadCount);
            for (uint i = uIpStart; i <= uIpEnd; i++)
            {
                IPAddress ipAddr = IPTool.UInt32ToIP(i);
                ThreadPool.QueueUserWorkItem(x => func(ipAddr));

                ScanIpProgress?.Invoke();
            }
        }

        public void SendArpRequest(IPAddress tgtIP)
        {
            SendArpRequest(tgtIP.ToString());
        }
        private void SendArpRequest(string szTargetIP)
        {
            var device = m_stDeviceInfo.device;
            PhysicalAddress srcMAC = device.MacAddress;
            IPAddress srcIP = IPAddress.Parse(m_stDeviceInfo.IPv4Address);
            IPAddress dstIP = IPAddress.Parse(szTargetIP);

            var pktEthernet = new EthernetPacket(srcMAC, PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"), EthernetType.Arp);
            var pktARP = new ArpPacket(ArpOperation.Request, PhysicalAddress.Parse("00-00-00-00-00-00"), dstIP, srcMAC, srcIP);

            pktEthernet.PayloadPacket = pktARP;

            device.SendPacket(pktEthernet);
        }

        public void SendPingRequest(IPAddress ip)
        {
            SendPingRequest(ip.ToString());
        }
        private void SendPingRequest(string szTargetIP)
        {
            new Thread(() =>
            {
                var device = m_stDeviceInfo.device;
                Ping ping = new Ping();
                var reply = ping.Send(IPAddress.Parse(szTargetIP));

                SendArpRequest(szTargetIP);
            }).Start();
        }

        /// <summary>
        /// Set current device.
        /// </summary>
        private void SetDevice()
        {
            frmDevice f = new frmDevice();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.m_lsDevice = m_lsDevices;

            f.ShowDialog();

            m_stDeviceInfo = f.m_stDeviceInfo;

            if (m_stDeviceInfo.device == null)
                return;

            foreach (TreeNode _node in treeView1.Nodes)
                _node.Nodes.Clear();

            m_stDeviceInfo.device.OnPacketArrival += DeviceARP_OnPacketArrival;
            m_stDeviceInfo.device.OnPacketArrival += DeviceICMP_OnPacketArrival;
            //m_stDeviceInfo.device.OnPacketArrival += DeviceAllPacket_OnPacketArrival;

            m_stDeviceInfo.device.Open();
            m_stDeviceInfo.device.StartCapture();

            TreeNode node = treeView1.Nodes[1];
            TreeNode tn = new TreeNode(m_stDeviceInfo.GatewayAddress.ToString());
            tn.Nodes.Add(new TreeNode(m_stDeviceInfo.networkInterface.GetPhysicalAddress().ToString()));
            node.Nodes.Add(tn);
        }

        private void DeviceARP_OnPacketArrival(object sender, PacketCapture e)
        {
            var pktRAW = e.GetPacket();
            var pkt = Packet.ParsePacket(pktRAW.LinkLayerType, pktRAW.Data);
            var pktARP = pkt.Extract<ArpPacket>();

            if (pktARP == null)
                return;

            if (pktARP.Operation == ArpOperation.Response)
            {
                string szIP = pktARP.SenderProtocolAddress.ToString();
                string szMAC = pktARP.SenderHardwareAddress.ToString();

                //AddHostIntoTreeView("ARP", szIP, szMAC);
                NewDiscoveredDevice?.Invoke("ARP", szIP, szMAC);
            }
        }
        private void DeviceICMP_OnPacketArrival(object sender, PacketCapture e)
        {
            var pktRAW = e.GetPacket();
            var pkt = Packet.ParsePacket(pktRAW.LinkLayerType, pktRAW.Data);
            var pktICMP = pkt.Extract<IcmpV4Packet>();

            if (pktICMP == null)
                return;

            if (pktICMP.TypeCode == IcmpV4TypeCode.EchoReply)
            {
                var pktIPv4 = pkt.Extract<IPv4Packet>();
                var pktEthernet = pkt.Extract<EthernetPacket>();

                string szIP = pktIPv4.SourceAddress.ToString();
                string szMAC = pktEthernet.SourceHardwareAddress.ToString();

                //AddHostIntoTreeView("ICMP", szIP, szMAC);
                NewDiscoveredDevice?.Invoke("ICMP", szIP, szMAC);
            }
        }
        private void DeviceAllPacket_OnPacketArrival(object sender, PacketCapture e)
        {
            if (m_tp == null)
                return;

            var pktRAW = e.GetPacket();
            var pkt = Packet.ParsePacket(pktRAW.LinkLayerType, pktRAW.Data);

            var pktTCP = pkt.Extract<TcpPacket>();
            var pktUDP = pkt.Extract<UdpPacket>();

            if (pktTCP != null)
            {
                var handle = new TcpHandle(m_stDeviceInfo);
                handle.Handle(pktTCP);
            }

            if (pktUDP != null)
            {
                
            }
        }

        void setup()
        {
            m_lsDevices = CaptureDeviceList.Instance.ToList();
            m_sqlConn = new SqlConn();
            Global.m_sqlConn = m_sqlConn;

            toolStripStatusLabel1.Text = $"Device[{m_lsDevices.Count}]";

            NewDiscoveredDevice += AddHostIntoTreeView;

            SetDevice();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            setup();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SetDevice();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmScanIP f = new frmScanIP();
            f.m_frmMain = this;

            f.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView2.CheckedItems)
            {
                item.SubItems[3].Text = "Spoofing";

                string szIPv4 = item.SubItems[1].Text;
                string szMAC = item.SubItems[2].Text;

                if (dicArpSpoofing.ContainsKey(szIPv4) && !dicArpSpoofing[szIPv4].m_bSendARP)
                {
                    dicArpSpoofing[szIPv4].m_bSendARP = true;
                    dicArpSpoofing[szIPv4].SendArpSpoof(szIPv4, szMAC);
                }
                else
                {
                    dicArpSpoofing[szIPv4] = new ArpSpoofing(m_stDeviceInfo);
                    new Thread(() => dicArpSpoofing[szIPv4].SendArpSpoof(szIPv4, szMAC)).Start();
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView2.Items)
                item.Checked = true;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView2.CheckedItems)
                item.Checked = false;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView2.CheckedItems)
            {
                string szIP = item.SubItems[1].Text;
                int nPort = 80;

                if (!dicSynFloosing.ContainsKey(szIP))
                    dicSynFloosing[szIP] = new SynFlood(m_stDeviceInfo);

                if (!dicSynFloosing[szIP].m_bFlooding)
                {
                    dicSynFloosing[szIP].Start(szIP, nPort);
                    item.SubItems[3].Text = "SYN flooding";
                }
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView2.CheckedItems)
            {
                string szIPv4 = item.SubItems[1].Text;
                if (!dicArpSpoofing.ContainsKey(szIPv4))
                    continue;

                if (dicArpSpoofing[szIPv4].m_bSendARP)
                {
                    dicArpSpoofing[szIPv4].Stop();
                    item.SubItems[3].Text = "Ready";
                    dicArpSpoofing.Remove(szIPv4);
                }
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView2.CheckedItems)
            {
                string szIP = item.SubItems[1].Text;
                int nPort = 80;

                if (!dicSynFloosing.ContainsKey(szIP))
                    continue;

                if (dicSynFloosing[szIP].m_bFlooding)
                {
                    dicSynFloosing[szIP].Stop();
                    item.SubItems[3].Text = "Ready";
                    dicSynFloosing.Remove(szIP);
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            
        }
    }
}
