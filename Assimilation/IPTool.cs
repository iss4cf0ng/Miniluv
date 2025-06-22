using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Assimilation
{
    public class IPTool
    {
        public static IPAddress RandomIPv4Address()
        {
            Random rand = new Random();
            return IPAddress.Parse(string.Join(".", new int[]
            {
                rand.Next(0, 255),
                rand.Next(0, 255),
                rand.Next(0, 255),
            }.Select(x => x.ToString())));
        }
        public static PhysicalAddress RandomMacAddress()
        {
            Random random = new Random();
            byte[] abMacAddr = new byte[6];
            random.NextBytes(abMacAddr);
            abMacAddr[0] = (byte)(abMacAddr[0] & 0xfe);

            return PhysicalAddress.Parse(BitConverter.ToString(abMacAddr));
        }

        public static uint IPToUInt32(IPAddress ip)
        {
            byte[] abBuffer = ip.GetAddressBytes();
            Array.Reverse(abBuffer); //Get Big-Endian

            return BitConverter.ToUInt32(abBuffer, 0);
        }
        public static IPAddress UInt32ToIP(uint uIP)
        {
            byte[] abBuffer = BitConverter.GetBytes(uIP);
            Array.Reverse(abBuffer); //Get Little-Endian

            return new IPAddress(abBuffer);
        }

        public static (IPAddress ipStart, IPAddress ipEnd) CIDR2IpRange(string szCIDR)
        {
            try
            {
                string[] aPart = szCIDR.Split('/');
                string ipAddr = aPart[0];
                int nSubnetMaskLength = int.Parse(aPart[1]);

                uint uIpAddr = IPToUInt32(IPAddress.Parse(ipAddr));
                uint uSubnetMask = uint.MaxValue << (32 - nSubnetMaskLength);

                uint netAddr = uIpAddr & uSubnetMask;
                uint boardcastAddr = netAddr | ~uSubnetMask;

                IPAddress ipStart = UInt32ToIP(netAddr);
                IPAddress ipEnd = UInt32ToIP(boardcastAddr);

                return (ipStart, ipEnd);
            }
            catch (Exception ex)
            {
                return (null, null);
            }
        }
        public static uint SubnetMask2CIDR(IPAddress ipSubnetMask)
        {
            if (ipSubnetMask == null)
            {
                MessageBox.Show("ipSubnetMask is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            return SubnetMask2CIDR(ipSubnetMask.ToString());
        }
        public static uint SubnetMask2CIDR(string szSubnetMask)
        {
            byte[] abMask = IPAddress.Parse(szSubnetMask).GetAddressBytes();
            uint CIDR = 0;
            
            foreach (byte b in abMask)
            {
                for (int i = 7; i >= 0; i--)
                {
                    if ((b & (1 << i)) != 0)
                        CIDR++;
                }
            }

            return CIDR;
        }
        public (IPAddress ipStart, IPAddress ipEnd) GetIpRangeFromSubnetMask(string szIPv4, string szSubnetMask)
            => CIDR2IpRange($"{szIPv4}/{SubnetMask2CIDR(szSubnetMask)}");
    }

    public class Tools
    {
        public static bool IsMethodSubscribed(Delegate del, string szMethodName)
        {
            if (del == null)
                return false;

            foreach (Delegate d in del.GetInvocationList())
            {
                if (d.Method.Name == szMethodName)
                    return true;
            }

            return false;
        }
    }
}
