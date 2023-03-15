using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClientCommands
{
    public class ClientServerCommand
    {
        public Socket client { get; set; }
        public Socket server { get; set; }

        public string _answer = "";

        public string error = "";

        byte[] buffer = new byte[1024];

        Mutex mutex = new Mutex();
        public async Task ConnectServer(IPEndPoint point, Socket clientSocket)
        {
            await Task.Run(async () =>
            {                
                try
                {
                    client = clientSocket;
                    await Connect(point);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }

            });           
        }
        async Task Connect(IPEndPoint point)
        {
            await Task.Run(() =>
            {
                client.Connect(point);
                client.Receive(buffer, 0, buffer.Length,SocketFlags.None);
                _answer = Encoding.UTF8.GetString(buffer);
                //client.BeginConnect(point, ConnectDelegate, client);
            });
        }        
        void ConnectDelegate(IAsyncResult result) 
        {
            server = (Socket)result.AsyncState;
            server.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveMessage, server);
        }
        void ReceiveMessage(IAsyncResult result)
        {
            Socket server = (Socket)result.AsyncState;
            server.EndReceive(result);
            _answer = Encoding.UTF8.GetString(buffer);
        }
        public void SendMessage(string message)
        {
            if (client.Connected)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                client.Send(buffer, 0, buffer.Length, SocketFlags.None);
            }
        }
        public bool ServerIsConnected()
        {
            return server != null ? true : false;
        }

       
    }
}
