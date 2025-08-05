using System;
using System.Net;
using System.Net.Sockets;

public static class HelperUtilities
{
    public static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString(); // e.g., 192.168.1.x
            }
        }
        throw new Exception("No network adapters with an IPv4 address found.");
    }
}
