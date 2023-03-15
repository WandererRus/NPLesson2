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
        public string messages = "";
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
                    byte[] buffer = Encoding.UTF8.GetBytes("Успешное подключение");
                    byte[] answer = new byte[1024];
                    ArraySegment<byte> segment = new ArraySegment<byte>(buffer, 0, buffer.Length);
                    clientsocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendMessageDelegate, clientsocket);
                    clientsocket.BeginReceive(answer, 0, answer.Length, SocketFlags.None, ReciveAsyncDelegate, new AnswerSocketContainer(clientsocket,Encoding.UTF8.GetString(answer)));
                    //clientsocket.SendAsync(segment, SocketFlags.None);
                    serv.BeginAccept(ServerAcceptDelegate, serv);
                }

            }
        }
        void ReciveAsyncDelegate(IAsyncResult result)
        {
            AnswerSocketContainer container = (AnswerSocketContainer)result.AsyncState;
            container.Socket.EndReceive(result);
            messages += container.Text+"\n";
            byte[] answer = new byte[1024];
            container.Socket.BeginReceive(answer, 0, answer.Length, SocketFlags.None, ReciveAsyncDelegate, new AnswerSocketContainer(container.Socket, Encoding.UTF8.GetString(answer)));
        }
        void SendMessageDelegate(IAsyncResult result)
        {
            Socket client = (Socket)result.AsyncState;
            client.EndSend(result);
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

    class AnswerSocketContainer
    {
        public Socket Socket { get; set; }
        public string Text { get; set; }

        public AnswerSocketContainer(Socket s, string t)
        {
            Socket = s;
            Text = t;
        }
    }

}
