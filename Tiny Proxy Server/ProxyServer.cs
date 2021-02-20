using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace ProxyServer
{
    public sealed class ProxyServer : IDisposable
    {
        private readonly TcpListener tcpListener;
        private readonly List<Client> clients = new List<Client>();
        
        private void AddConnection(Client client) => clients.Add(client);
        private void RemoveConnection(Client client) => clients.Remove(client);

        public ProxyServer(IPAddress ip, int port) 
        {
            tcpListener = new TcpListener(ip, port);
        }

        public void Listen()
        {
            try
            { 
                tcpListener.Start();
                Log("The server is running. Waiting for connections...");
 
                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    Log("New client connected.");
                    AddClient(tcpClient);
                }
            }
            catch(Exception ex)
            {
                Log(ex.Message);
                DisconnectAllClients();
            }
        }

        // FIXXX
        private void AddClient(TcpClient client) 
        {
            var newClient = new Client(client, this);
            AddConnection(newClient);
            Thread clientThread = new Thread(new ThreadStart(newClient.Process));
            clientThread.Start();
            SendMessageTo(newClient, "Welcome!");
        }

        internal void RemoveClient(Client client)
        {
            Log("Client disconnected.");
            RemoveConnection(client);
        }

        internal void SendMessageFrom(Client client, string message)
        {
            SendMessageTo(clients.Where(x => x != client).ToList(), message);
        }

        private void SendMessageTo(Client client, string message)
        {
            if (client is null) 
            {
                throw new ArgumentNullException("Client should be not null.");
            }
            byte[] data = Encoding.Unicode.GetBytes(message+"\r\n");
            client.Stream.Write(data, 0, data.Length);
        }

        private void SendMessageTo(List<Client> clients, string message)
        {
            foreach (var client in clients)
            {
                SendMessageTo(client, message);
            }
        }

        public void Stop() => tcpListener.Stop();

        private void Log(string message) => Console.WriteLine(message);

        private void DisconnectAllClients()
        {
            foreach (var client in clients) 
            {
                client.Close();
            }
        }

        public void Dispose()
        {
            foreach (IDisposable client in clients)
            {
                if (client != null)
                {
                    client.Dispose();
                }
            }
        }

    }
}