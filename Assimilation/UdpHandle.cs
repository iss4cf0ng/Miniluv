using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Miniluv
{
    public class UdpHandle
    {
        public UdpHandle()
        {

        }

        public void Handle(UdpPacket pktUDP)
        {
            if (pktUDP == null)
                return;

            if (pktUDP.DestinationPort == 53) //DNS
            {

            }
        }
    }

    public class DnsHandle
    {
        public DnsHandle()
        {

        }

        public static void ExtractQuery(byte[] abDnsPacket)
        {
            int nOffset = 12; //DNS header size: 12 bytes
            while (nOffset < abDnsPacket.Length)
            {
                
            }
        }
        public static byte[] MakeDnsResponse(byte[] abRequest, IPAddress ipClntAddr, int nClntPort)
        {
            byte[] abResposne = new byte[abRequest.Length + 16];


            return abResposne;
        }
    }
}
