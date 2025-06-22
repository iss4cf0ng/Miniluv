using Assimilation;
using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Miniluv
{
    public class TcpHandle
    {
        public Packet m_pkt;
        public stDeviceInfo m_stDeviceInfo;

        public TcpHandle(stDeviceInfo deviceInfo)
        {
            m_stDeviceInfo = deviceInfo;
        }

        public void Handle(TcpPacket pktTCP)
        {
            if (pktTCP == null)
                return;

            if (pktTCP.DestinationPort == 80)
            {
                IPv4Packet pktSrcIPv4 = pktTCP.Extract<IPv4Packet>();
                if (IsBanned(pktSrcIPv4.DestinationAddress.ToString()))
                {
                    var pkt = MakeResetPacket(pktTCP);
                    m_stDeviceInfo.device.SendPacket(pkt.Bytes);
                }
            }
        }

        public Packet MakeResetPacket(TcpPacket pktTCP)
        {
            IPv4Packet pktSrcIPv4 = pktTCP.Extract<IPv4Packet>();
            EthernetPacket pktSrcEth = pktTCP.Extract<EthernetPacket>();
            if (pktSrcIPv4 == null)
            {

                return null;
            }

            IPAddress srcIPv4 = pktSrcIPv4.SourceAddress;
            IPAddress dstIPv4 = pktSrcIPv4.DestinationAddress;

            uint uSeq = pktTCP.SequenceNumber;
            uint uAck = pktTCP.AcknowledgmentNumber;

            ushort uSrcPort = pktTCP.SourcePort;
            ushort uDstPort = pktTCP.DestinationPort;

            EthernetPacket pktEth = new EthernetPacket(pktSrcEth.DestinationHardwareAddress, pktSrcEth.SourceHardwareAddress, EthernetType.IPv4);

            IPv4Packet pktNewIpv4 = new IPv4Packet(dstIPv4, srcIPv4);
            TcpPacket pktNewTcp = new TcpPacket(uDstPort, uSrcPort)
            {
                Reset = true,
                SequenceNumber = uAck,
                AcknowledgmentNumber = uSeq + 1,
            };

            pktNewIpv4.PayloadPacket = pktNewTcp;
            pktEth.PayloadPacket = pktNewIpv4;

            return pktEth;
        }

        public bool IsBanned(string szIpAddr)
        {
            string szQuery = $"SELECT \"IPv4\",\"IPv6\" FROM \"BlackListIP\"";
            DataTable dt = Global.m_sqlConn.ExecuteQuery(szQuery);
            List<string> lsIPv4 = dt.Rows.Cast<DataRow>().Select(x => x[0].ToString()).ToList();
            List<string> lsIPv6 = dt.Rows.Cast<DataRow>().Select(x => x[1].ToString()).ToList();

            return lsIPv4.Contains(szIpAddr) || lsIPv6.Contains(szIpAddr);
        }
    }

    public class HttpHandle
    {
        public static bool IsHttpRequest(string szPayloadData)
        {
            return szPayloadData.StartsWith("GET") || szPayloadData.StartsWith("POST");
        }
    }
}
