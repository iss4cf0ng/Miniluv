using Miniluv;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Assimilation
{
    public class Global
    {
        public static SqlConn m_sqlConn;
    }

    public struct stDeviceInfo
    {
        public string Description;
        public string IPv4Address;
        public IPAddress IPv4Mask;
        public ILiveDevice device;
        public NetworkInterface networkInterface;
        public IPAddress GatewayAddress;

        public int ThreadCount;
    }

    public enum TcpHandleMethod
    {
        ResetConnection,
        HttpMalJS,
    }
    public enum UdpHandleMethod
    {
        BanDnsDomain,
        DnsSpoofing,
    }
}
