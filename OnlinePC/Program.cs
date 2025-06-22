using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

List<string> lsOnlineDevices = new List<string>();

var devices = CaptureDeviceList.Instance;
if (devices.Count == 0)
{
    Console.WriteLine("No network interfaces found.");
    return;
}

Console.WriteLine("Available network interfaces:");
for (int i = 0; i < devices.Count; i++)
{
    Console.WriteLine($"[{i + 1}] {devices[i].Description}");
}

Console.Write("Choose >");
int nIdx = int.Parse(Console.ReadLine()) - 1;
ICaptureDevice device = devices[nIdx];
Console.WriteLine(device.Description);
device.Open(DeviceModes.Promiscuous);
device.OnPacketArrival += (sender, e) =>
{
    var pkt = Packet.ParsePacket(e.GetPacket().LinkLayerType, e.GetPacket().Data);
    var pktARP = pkt.Extract<ArpPacket>();

    if (pktARP != null && pktARP.Operation == ArpOperation.Response)
    {
        string szIP = pktARP.SenderProtocolAddress.ToString();
        string szMAC = pktARP.SenderHardwareAddress.ToString();

        lsOnlineDevices.Add($"IP: {szIP}, MAC: {szMAC}");

        Console.WriteLine(szMAC);
    }
};

device.StartCapture();

Console.Write("Local IPv4 > ");
string szLocalIPv4 = Console.ReadLine();
string[] aIP = szLocalIPv4.Split('.');
for (int i = 2; i < 255; i++)
{
    for (int j = 2; j < 255; j++)
    {
        string szTargetIP = $"{aIP[0]}.{aIP[1]}.{i}.{j}";
        SendARP((ILiveDevice)device, szTargetIP);
    }
}

Thread.Sleep(10000);
device.StopCapture();
device.Close();

foreach (string szDevice in lsOnlineDevices)
{
    Console.WriteLine(szDevice);
}

Console.ReadKey();

static void SendARP(ILiveDevice device, string szTargetIP)
{
    PhysicalAddress srcMAC = device.MacAddress;
    IPAddress srcIP = IPAddress.Parse("10.131.102.191");
    IPAddress dstIP = IPAddress.Parse(szTargetIP);

    var pktEthernet = new EthernetPacket(srcMAC, PhysicalAddress.Parse("FF-FF-FF-FF-FF-FF"), EthernetType.Arp);
    var pktARP = new ArpPacket(ArpOperation.Request, PhysicalAddress.Parse("00-00-00-00-00-00"), dstIP, srcMAC, srcIP);

    pktEthernet.PayloadPacket = pktARP;

    device.SendPacket(pktEthernet);
}

static IPAddress GetLocalIPAddress()
{
    foreach (var netIf in NetworkInterface.GetAllNetworkInterfaces())
    {
        if (netIf.OperationalStatus == OperationalStatus.Up)
        {
            foreach (var addr in netIf.GetIPProperties().UnicastAddresses)
            {
                if (addr.Address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return addr.Address;
                }
            }
        }
    }

    return null;
}