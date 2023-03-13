using System.Net;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using Contacts;

namespace NPLesson2Server
{
    public partial class Form1 : Form
    {
        Socket server;
        IPEndPoint point;
        ServerClientCommand command = new ServerClientCommand();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80);
        }

        private void btn_startServer_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                server.Bind(point);
                server.Listen(100);
                tmr_refreshConnection.Start();
            }
        }

        private void btn_stopServer_Click(object sender, EventArgs e)
        {
            try
            {
                if (server != null)
                    tmr_refreshConnection.Stop();
                server.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tmr_refreshConnection_Tick(object sender, EventArgs e)
        {
            if (command.GetClientSocket(server))
            {
                if(command.clientSockets.Count > 0) 
                {
                    foreach (Socket client in command.clientSockets) 
                    {
                        command.CommandManage(command.ReciveMessage(client),client);
                    }
                }
            }
            else
            {
                MessageBox.Show(command.error);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                server.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
               

        void RichTextBoxOutputDelegate(object obj)
        {
            rtb_clients.Text += (string)obj;
        }

        private void btn_updateClientsList_Click(object sender, EventArgs e)
        {
            foreach (ClientContacts client in command.contacts)
            {
                rtb_clients.Text += client.ToString();
            }
        }
    }

    class ServerClientCommand 
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
                text = Encoding.UTF8.GetString(segment);                
            }

            return text;            
        }

        public void CommandManage(string text, Socket client)
        {
            if(text.StartsWith("Contact"))
                AddNewContact(text.Split("|"), client);
        }

        void AddNewContact(string[] data, Socket client)
        {        
              contacts.Add(new ClientContacts(client, data[1], data[3], data[2], data[4]));
        }
    }
}