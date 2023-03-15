namespace NPLesson2Server
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
            this.btn_startServer = new System.Windows.Forms.Button();
            this.btn_stopServer = new System.Windows.Forms.Button();
            this.rtb_clients = new System.Windows.Forms.RichTextBox();
            this.tmr_refreshConnection = new System.Windows.Forms.Timer(this.components);
            this.btn_updateClientsList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_startServer
            // 
            this.btn_startServer.Location = new System.Drawing.Point(48, 12);
            this.btn_startServer.Name = "btn_startServer";
            this.btn_startServer.Size = new System.Drawing.Size(139, 23);
            this.btn_startServer.TabIndex = 0;
            this.btn_startServer.Text = "Запустить сервер";
            this.btn_startServer.UseVisualStyleBackColor = true;
            this.btn_startServer.Click += new System.EventHandler(this.btn_startServer_Click);
            // 
            // btn_stopServer
            // 
            this.btn_stopServer.Location = new System.Drawing.Point(244, 12);
            this.btn_stopServer.Name = "btn_stopServer";
            this.btn_stopServer.Size = new System.Drawing.Size(164, 23);
            this.btn_stopServer.TabIndex = 1;
            this.btn_stopServer.Text = "Остановить сервер";
            this.btn_stopServer.UseVisualStyleBackColor = true;
            this.btn_stopServer.Click += new System.EventHandler(this.btn_stopServer_Click);
            // 
            // rtb_clients
            // 
            this.rtb_clients.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtb_clients.Location = new System.Drawing.Point(0, 55);
            this.rtb_clients.Name = "rtb_clients";
            this.rtb_clients.Size = new System.Drawing.Size(800, 395);
            this.rtb_clients.TabIndex = 2;
            this.rtb_clients.Text = "";
            // 
            // tmr_refreshConnection
            // 
            this.tmr_refreshConnection.Interval = 500;
            this.tmr_refreshConnection.Tick += new System.EventHandler(this.tmr_refreshConnection_Tick);
            // 
            // btn_updateClientsList
            // 
            this.btn_updateClientsList.Location = new System.Drawing.Point(471, 11);
            this.btn_updateClientsList.Name = "btn_updateClientsList";
            this.btn_updateClientsList.Size = new System.Drawing.Size(221, 23);
            this.btn_updateClientsList.TabIndex = 3;
            this.btn_updateClientsList.Text = "Показать клиентов";
            this.btn_updateClientsList.UseVisualStyleBackColor = true;
            this.btn_updateClientsList.Click += new System.EventHandler(this.btn_updateClientsList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_updateClientsList);
            this.Controls.Add(this.rtb_clients);
            this.Controls.Add(this.btn_stopServer);
            this.Controls.Add(this.btn_startServer);
            this.Name = "Form1";
            this.Text = "Сервер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_startServer;
        private Button btn_stopServer;
        private RichTextBox rtb_clients;
        private System.Windows.Forms.Timer tmr_refreshConnection;
        private Button btn_updateClientsList;
    }
}