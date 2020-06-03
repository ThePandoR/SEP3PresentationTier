using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SEP3PresentationTier.Heartbeat
{
    public class HeartbeatClient
    {
        private readonly string address;
        private readonly int port;
        private readonly UdpClient _client;
        
        public HeartbeatClient(string address, int port)
        {
            this.address = address;
            this.port = port;
            this._client = new UdpClient();
        }

        public void Run()
        {
            byte seq = 0;
            byte[] resp;
            _client.Connect(address, port);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                _client.Send(new[] {seq}, 1);
                resp = _client.Receive(ref endPoint);
                Console.WriteLine(resp[0] != seq ? "Invalid seq number" : "App ok");

                Thread.Sleep(100 * 60);
                
                seq++;
            }
        }
    }
}