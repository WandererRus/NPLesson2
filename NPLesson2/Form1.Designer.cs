namespace NPLesson2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_connectServer = new System.Windows.Forms.Button();
            this.btn_sendMessage = new System.Windows.Forms.Button();
            this.btn_choiceContact = new System.Windows.Forms.Button();
            this.btn_disconnectServer = new System.Windows.Forms.Button();
            this.rtb_chat = new System.Windows.Forms.RichTextBox();
            this.tb_message = new System.Windows.Forms.TextBox();
            this.tmr_refreshConnection = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_connectServer
            // 
            this.btn_connectServer.Location = new System.Drawing.Point(13, 12);
            this.btn_connectServer.Name = "btn_connectServer";
            this.btn_connectServer.Size = new System.Drawing.Size(175, 23);
            this.btn_connectServer.TabIndex = 0;
            this.btn_connectServer.Text = "Подключиться к серверу";
            this.btn_connectServer.UseVisualStyleBackColor = true;
            this.btn_connectServer.Click += new System.EventHandler(this.btn_connectServer_Click);
            // 
            // btn_sendMessage
            // 
            this.btn_sendMessage.Location = new System.Drawing.Point(411, 12);
            this.btn_sendMessage.Name = "btn_sendMessage";
            this.btn_sendMessage.Size = new System.Drawing.Size(165, 23);
            this.btn_sendMessage.TabIndex = 1;
            this.btn_sendMessage.Text = "Отправить сообщение";
            this.btn_sendMessage.UseVisualStyleBackColor = true;
            this.btn_sendMessage.Click += new System.EventHandler(this.btn_sendMessage_Click);
            // 
            // btn_choiceContact
            // 
            this.btn_choiceContact.Location = new System.Drawing.Point(253, 12);
            this.btn_choiceContact.Name = "btn_choiceContact";
            this.btn_choiceContact.Size = new System.Drawing.Size(152, 23);
            this.btn_choiceContact.TabIndex = 2;
            this.btn_choiceContact.Text = "Выбрать собеседника";
            this.btn_choiceContact.UseVisualStyleBackColor = true;
            this.btn_choiceContact.Click += new System.EventHandler(this.btn_choiceContact_Click);
            // 
            // btn_disconnectServer
            // 
            this.btn_disconnectServer.Location = new System.Drawing.Point(615, 12);
            this.btn_disconnectServer.Name = "btn_disconnectServer";
            this.btn_disconnectServer.Size = new System.Drawing.Size(173, 23);
            this.btn_disconnectServer.TabIndex = 3;
            this.btn_disconnectServer.Text = "Отключиться от сервера";
            this.btn_disconnectServer.UseVisualStyleBackColor = true;
            this.btn_disconnectServer.Click += new System.EventHandler(this.btn_disconnectServer_Click);
            // 
            // rtb_chat
            // 
            this.rtb_chat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtb_chat.Location = new System.Drawing.Point(0, 100);
            this.rtb_chat.Name = "rtb_chat";
            this.rtb_chat.Size = new System.Drawing.Size(800, 350);
            this.rtb_chat.TabIndex = 4;
            this.rtb_chat.Text = "";
            // 
            // tb_message
            // 
            this.tb_message.Location = new System.Drawing.Point(13, 59);
            this.tb_message.Name = "tb_message";
            this.tb_message.Size = new System.Drawing.Size(775, 23);
            this.tb_message.TabIndex = 5;
            this.tb_message.TextChanged += new System.EventHandler(this.tb_message_TextChanged);
            // 
            // tmr_refreshConnection
            // 
            this.tmr_refreshConnection.Tick += new System.EventHandler(this.tmr_refreshConnection_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_message);
            this.Controls.Add(this.rtb_chat);
            this.Controls.Add(this.btn_disconnectServer);
            this.Controls.Add(this.btn_choiceContact);
            this.Controls.Add(this.btn_sendMessage);
            this.Controls.Add(this.btn_connectServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Клиент";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_connectServer;
        private Button btn_sendMessage;
        private Button btn_choiceContact;
        private Button btn_disconnectServer;
        private RichTextBox rtb_chat;
        private TextBox tb_message;
        private System.Windows.Forms.Timer tmr_refreshConnection;
    }
}