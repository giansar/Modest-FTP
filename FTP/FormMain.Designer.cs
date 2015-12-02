namespace FTP
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CommandTextBox = new System.Windows.Forms.TextBox();
            this.RemoteListFilesButton = new System.Windows.Forms.Button();
            this.RemotePathTextBox = new System.Windows.Forms.TextBox();
            this.RemoteUpButton = new System.Windows.Forms.Button();
            this.RemoteListView = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BinaryTextBox = new System.Windows.Forms.TextBox();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.FTPServerTextBox = new System.Windows.Forms.TextBox();
            this.ConsoleTextBox = new System.Windows.Forms.TextBox();
            this.LocalTreeView = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LocalListView = new System.Windows.Forms.ListView();
            this.ListFilesButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.LocalPathTextBox = new System.Windows.Forms.TextBox();
            this.FileImageList = new System.Windows.Forms.ImageList(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeleteButton);
            this.groupBox1.Controls.Add(this.CommandTextBox);
            this.groupBox1.Controls.Add(this.RemoteListFilesButton);
            this.groupBox1.Controls.Add(this.RemotePathTextBox);
            this.groupBox1.Controls.Add(this.RemoteUpButton);
            this.groupBox1.Controls.Add(this.RemoteListView);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.DownloadButton);
            this.groupBox1.Controls.Add(this.PasswordTextBox);
            this.groupBox1.Controls.Add(this.UsernameTextBox);
            this.groupBox1.Controls.Add(this.PortTextBox);
            this.groupBox1.Controls.Add(this.FTPServerTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 215);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remote";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(501, 103);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 19;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CommandTextBox
            // 
            this.CommandTextBox.Enabled = false;
            this.CommandTextBox.Location = new System.Drawing.Point(501, 19);
            this.CommandTextBox.Name = "CommandTextBox";
            this.CommandTextBox.Size = new System.Drawing.Size(75, 20);
            this.CommandTextBox.TabIndex = 18;
            // 
            // RemoteListFilesButton
            // 
            this.RemoteListFilesButton.Location = new System.Drawing.Point(501, 45);
            this.RemoteListFilesButton.Name = "RemoteListFilesButton";
            this.RemoteListFilesButton.Size = new System.Drawing.Size(75, 23);
            this.RemoteListFilesButton.TabIndex = 17;
            this.RemoteListFilesButton.Text = "List Files";
            this.RemoteListFilesButton.UseVisualStyleBackColor = true;
            this.RemoteListFilesButton.Click += new System.EventHandler(this.RemoteListFilesButton_Click);
            // 
            // RemotePathTextBox
            // 
            this.RemotePathTextBox.Location = new System.Drawing.Point(44, 47);
            this.RemotePathTextBox.Name = "RemotePathTextBox";
            this.RemotePathTextBox.Size = new System.Drawing.Size(451, 20);
            this.RemotePathTextBox.TabIndex = 16;
            this.RemotePathTextBox.Text = "/";
            // 
            // RemoteUpButton
            // 
            this.RemoteUpButton.Location = new System.Drawing.Point(6, 45);
            this.RemoteUpButton.Name = "RemoteUpButton";
            this.RemoteUpButton.Size = new System.Drawing.Size(32, 23);
            this.RemoteUpButton.TabIndex = 15;
            this.RemoteUpButton.Text = "Up";
            this.RemoteUpButton.UseVisualStyleBackColor = true;
            this.RemoteUpButton.Click += new System.EventHandler(this.RemoteUpButton_Click);
            // 
            // RemoteListView
            // 
            this.RemoteListView.Location = new System.Drawing.Point(6, 74);
            this.RemoteListView.Name = "RemoteListView";
            this.RemoteListView.Size = new System.Drawing.Size(489, 131);
            this.RemoteListView.TabIndex = 14;
            this.RemoteListView.UseCompatibleStateImageBehavior = false;
            this.RemoteListView.DoubleClick += new System.EventHandler(this.RemoteListView_DoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BinaryTextBox);
            this.groupBox3.Location = new System.Drawing.Point(501, 158);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(75, 47);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Binary Ext.";
            // 
            // BinaryTextBox
            // 
            this.BinaryTextBox.Location = new System.Drawing.Point(6, 19);
            this.BinaryTextBox.Name = "BinaryTextBox";
            this.BinaryTextBox.Size = new System.Drawing.Size(63, 20);
            this.BinaryTextBox.TabIndex = 12;
            this.BinaryTextBox.TextChanged += new System.EventHandler(this.BinaryTextBox_TextChanged);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(501, 74);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(75, 23);
            this.DownloadButton.TabIndex = 13;
            this.DownloadButton.Text = "Download";
            this.DownloadButton.UseVisualStyleBackColor = true;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(375, 19);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(120, 20);
            this.PasswordTextBox.TabIndex = 9;
            this.PasswordTextBox.Text = "Password";
            this.PasswordTextBox.Click += new System.EventHandler(this.textBoxPassword_Click);
            this.PasswordTextBox.Leave += new System.EventHandler(this.textBoxPassword_Leave);
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(249, 19);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(120, 20);
            this.UsernameTextBox.TabIndex = 8;
            this.UsernameTextBox.Text = "Username";
            this.UsernameTextBox.Click += new System.EventHandler(this.textBoxUsername_Click);
            this.UsernameTextBox.Leave += new System.EventHandler(this.textBoxUsername_Leave);
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(203, 19);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(40, 20);
            this.PortTextBox.TabIndex = 7;
            this.PortTextBox.Text = "Port";
            this.PortTextBox.Click += new System.EventHandler(this.textBoxPort_Click);
            // 
            // FTPServerTextBox
            // 
            this.FTPServerTextBox.Location = new System.Drawing.Point(6, 19);
            this.FTPServerTextBox.Name = "FTPServerTextBox";
            this.FTPServerTextBox.Size = new System.Drawing.Size(191, 20);
            this.FTPServerTextBox.TabIndex = 6;
            this.FTPServerTextBox.Text = "FTP Server";
            this.FTPServerTextBox.Leave += new System.EventHandler(this.textBoxFTPServer_Leave);
            // 
            // ConsoleTextBox
            // 
            this.ConsoleTextBox.Location = new System.Drawing.Point(12, 454);
            this.ConsoleTextBox.Multiline = true;
            this.ConsoleTextBox.Name = "ConsoleTextBox";
            this.ConsoleTextBox.ReadOnly = true;
            this.ConsoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ConsoleTextBox.Size = new System.Drawing.Size(582, 75);
            this.ConsoleTextBox.TabIndex = 1;
            this.ConsoleTextBox.WordWrap = false;
            // 
            // LocalTreeView
            // 
            this.LocalTreeView.Location = new System.Drawing.Point(6, 45);
            this.LocalTreeView.Name = "LocalTreeView";
            this.LocalTreeView.Size = new System.Drawing.Size(150, 131);
            this.LocalTreeView.TabIndex = 3;
            this.LocalTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.LocalTreeView_NodeMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LocalListView);
            this.groupBox2.Controls.Add(this.ListFilesButton);
            this.groupBox2.Controls.Add(this.UploadButton);
            this.groupBox2.Controls.Add(this.LocalTreeView);
            this.groupBox2.Controls.Add(this.LocalPathTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(582, 186);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Local";
            // 
            // LocalListView
            // 
            this.LocalListView.Location = new System.Drawing.Point(162, 45);
            this.LocalListView.Name = "LocalListView";
            this.LocalListView.Size = new System.Drawing.Size(333, 131);
            this.LocalListView.TabIndex = 6;
            this.LocalListView.UseCompatibleStateImageBehavior = false;
            // 
            // ListFilesButton
            // 
            this.ListFilesButton.Location = new System.Drawing.Point(501, 19);
            this.ListFilesButton.Name = "ListFilesButton";
            this.ListFilesButton.Size = new System.Drawing.Size(75, 23);
            this.ListFilesButton.TabIndex = 5;
            this.ListFilesButton.Text = "List Files";
            this.ListFilesButton.UseVisualStyleBackColor = true;
            this.ListFilesButton.Click += new System.EventHandler(this.ListFilesButton_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.Location = new System.Drawing.Point(501, 45);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(75, 23);
            this.UploadButton.TabIndex = 4;
            this.UploadButton.Text = "Upload";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // LocalPathTextBox
            // 
            this.LocalPathTextBox.Location = new System.Drawing.Point(6, 19);
            this.LocalPathTextBox.Name = "LocalPathTextBox";
            this.LocalPathTextBox.Size = new System.Drawing.Size(489, 20);
            this.LocalPathTextBox.TabIndex = 1;
            // 
            // FileImageList
            // 
            this.FileImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FileImageList.ImageStream")));
            this.FileImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.FileImageList.Images.SetKeyName(0, "folder");
            this.FileImageList.Images.SetKeyName(1, "file");
            this.FileImageList.Images.SetKeyName(2, "filejs");
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 233);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(582, 23);
            this.progressBar1.TabIndex = 18;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 541);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ConsoleTextBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormMain";
            this.Text = "Modest FTP";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.TextBox FTPServerTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox ConsoleTextBox;
        private System.Windows.Forms.TreeView LocalTreeView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox LocalPathTextBox;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox BinaryTextBox;
        private System.Windows.Forms.ListView RemoteListView;
        private System.Windows.Forms.Button ListFilesButton;
        private System.Windows.Forms.ListView LocalListView;
        private System.Windows.Forms.ImageList FileImageList;
        private System.Windows.Forms.Button RemoteListFilesButton;
        private System.Windows.Forms.TextBox RemotePathTextBox;
        private System.Windows.Forms.Button RemoteUpButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox CommandTextBox;
        private System.Windows.Forms.Button DeleteButton;
    }
}

