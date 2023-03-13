using System.Net;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using Contacts;
using ServerCommands;
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
}