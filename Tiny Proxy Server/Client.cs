using System;
using System.IO;
using System.Net.Sockets;

namespace ProxyServer
{
    public sealed class Client : IDisposable
    {
        internal NetworkStream Stream { get { return client.GetStream(); } }
        private readonly TcpClient client;
        private readonly ProxyServer server;

        public Client(TcpClient tcpClient, ProxyServer server)
        {
            client = tcpClient;
            this.server = server;
        }

        public void Process()
        {
            using(var reader = new StreamReader(client.GetStream())) 
            {
                string message = "";
                while (true)
                {
                    if (!reader.EndOfStream)
                    {
                        message = reader.ReadLine();
                        server.SendMessageFrom(this, message);
                    }
                    else 
                    {
                        break;
                    }
                }
            }
            server.RemoveClient(this);
        }

        internal void Close()
        {
            if (Stream != null) 
            {
                Stream.Close();
            }
            if (client != null) 
            {
                client.Close();
            }
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
