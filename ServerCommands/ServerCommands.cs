using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Contacts;
namespace ServerCommands
{
    public class ServerClientCommand
    {
        public List<Socket> clientSockets = new List<Socket>();
        public List<ClientContacts> contacts = new List<ClientContacts>();
        public string error = "";
        public bool GetClientSocket(Socket server)
        {
            try
            {
                server.BeginAccept(ServerAcceptDelegate, server);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return error.Length > 0 ? false : true;
        }
        void ServerAcceptDelegate(IAsyncResult result)
        {
            if (result != null)
            {
                Socket serv = (Socket)result.AsyncState;
                if (serv != null)
                {
                    Socket clientsocket = serv.EndAccept(result);
                    clientSockets.Add(clientsocket);
                    clientsocket.Send(Encoding.UTF8.GetBytes("Успешное подключение."));
                }

            }
        }
        public string ReciveMessage(Socket client)
        {
            string text = "";
            byte[] buffer = new byte[1024];
            ArraySegment<byte> segment = new ArraySegment<byte>(buffer, 0, buffer.Length);

            Task<int> answer = client.ReceiveAsync(segment, SocketFlags.None);

            if (answer.IsCompleted)
            {
                text = Encoding.UTF8.GetString(segment.ToArray());
            }

            return text;
        }

        public void CommandManage(string text, Socket client)
        {
            if (text.StartsWith("Contact"))
                AddNewContact(text.Split('|'), client);
        }

        void AddNewContact(string[] data, Socket client)
        {
            contacts.Add(new ClientContacts(client, data[1], data[3], data[2], data[4]));
        }
    }
}
