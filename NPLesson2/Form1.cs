using System.Net;
using System.Net.Sockets;
using System.Text;
using Contacts;
using ClientCommands;

namespace NPLesson2
{
    public partial class Form1 : Form
    {
        IPEndPoint point;
        ClientContacts contact;
        ClientServerCommand command;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_connectServer_Click(object sender, EventArgs e)
        {
            if (command.ConnectServer(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80), contact.Socket))
            { 
                if (command.ServerIsConnected())
                    rtb_chat.Text = command._answer;
            }

        }

        private void btn_disconnectServer_Click(object sender, EventArgs e)
        {

        }

        private void btn_choiceContact_Click(object sender, EventArgs e)
        {

        }

        private void btn_sendMessage_Click(object sender, EventArgs e)
        {
            if (command.ServerIsConnected())
                command.SendMessage("Contact|"+contact.SendToNetwork());   

        }

        private void tb_message_TextChanged(object sender, EventArgs e)
        {

        }

        private void tmr_refreshConnection_Tick(object sender, EventArgs e)
        {

        }
        void RichTextBoxOutputDelegate(object obj)
        {
            rtb_chat.Text += (string)obj;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contact = new ClientContacts(
            new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP),
            "Ilya"+DateTime.Now.Millisecond.ToString(),
            "123456",
            "iluxailuxa@gmail.com",
            "+79287604894"
            );
            command = new ClientServerCommand();
        }
    }    
}