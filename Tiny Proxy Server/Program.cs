using System;
using System.Net;
using System.Threading;
 
namespace ProxyServer
{
    public static class Program
    {
        static void Main(string[] args)
        {
            using(var server = new ProxyServer(IPAddress.Parse("0.0.0.0"), 40901)) 
            {
                server.Listen();
            }
        }
    }
}
