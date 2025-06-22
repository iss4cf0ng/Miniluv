using SharpPcap;
using SharpPcap.LibPcap;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Assimilation
{
    public partial class frmDevice : Form
    {
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(int iDestIp, int iSrcIp, byte[] abMacAddr, ref int iMacAddrLen);

        public List<ILiveDevice> m_lsDevice;
        public List<NetworkInterface> m_lsNetworkInterface;

        public stDeviceInfo m_stDeviceInfo;

        public frmDevice()
        {
            InitializeComponent();
        }

        private (string szIPv4Addr, NetworkInterface netif, IPAddress mask, IPAddress gate) GetDeviceIPv4Address(ILiveDevice device)
        {
            string szIPv4Addr = null;
            NetworkInterface netIf = null;
            IPAddress maskAddr = null;
            IPAddress gatewayAddr = null;

            foreach (var netif in m_lsNetworkInterface)
            {
                if (netif.Description == device.Description)
                {
                    var ipProperties = netif.GetIPProperties();
                    UnicastIPAddressInformationCollection coll = ipProperties.UnicastAddresses;
                    foreach (var ip in coll)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            szIPv4Addr = ip.Address.ToString();
                            netIf = netif;
                            maskAddr = ip.IPv4Mask;
                            break;
                        }
                    }

                    foreach (var ip in ipProperties.GatewayAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            gatewayAddr = ip.Address;
                            break;
                        }
                    }
                }
            }

            return (szIPv4Addr, netIf, maskAddr, gatewayAddr);
        }

        void setup()
        {
            if (m_lsDevice == null)
            {

                return;
            }

            listView1.FullRowSelect = true;

            m_lsNetworkInterface = NetworkInterface.GetAllNetworkInterfaces().ToList();

            for (int i = 0; i < m_lsDevice.Count; i++)
            {
                var device = m_lsDevice[i];
                var x = GetDeviceIPv4Address(device);
                string szIPv4Addr = x.szIPv4Addr;
                if (string.IsNullOrEmpty(szIPv4Addr))
                    continue;

                byte[] abMacAddr = new byte[6];
                int iMacAddrLen = abMacAddr.Length;

                ListViewItem item = new ListViewItem(device.Description);
                item.SubItems.Add(szIPv4Addr);
                item.SubItems.Add(device.MacAddress.ToString());
                item.SubItems.Add(x.gate == null ? "X" : x.gate.ToString());
                item.SubItems.Add("todo");

                item.Tag = new stDeviceInfo()
                {
                    Description = device.Description,
                    IPv4Address = szIPv4Addr,
                    IPv4Mask = x.mask,
                    device = device,
                    networkInterface = x.netif,
                    GatewayAddress = x.gate,
                };

                listView1.Items.Add(item);
            }
        }

        private void frmDevice_Load(object sender, EventArgs e)
        {
            setup();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            var st = (stDeviceInfo)listView1.SelectedItems[0].Tag;
            m_stDeviceInfo = st;

            Close();
        }
    }
}
