using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            FTPServerTextBox.Text = Properties.Settings.Default.FTPServer;
            PortTextBox.Text = Properties.Settings.Default.Port;
            UsernameTextBox.Text = Properties.Settings.Default.Username;
            PasswordTextBox.Text = Properties.Settings.Default.Password;
            LocalPathTextBox.Text = Properties.Settings.Default.LastPathLocal;
            if ("".Equals(Properties.Settings.Default.BinaryExt))
            {
                BinaryTextBox.Text = "exe, zip";
            }
            else
            {
                BinaryTextBox.Text = Properties.Settings.Default.BinaryExt;
            }
        }

        private CommandResponse sendFTPCommand(string remotePath, FileInfo file, string command)
        {
            string path = (remotePath.Replace("/", "/%2f")).Replace("..", "%2e%2e");
            string uri = FTPServerTextBox.Text + ":" + PortTextBox.Text + path;
            CommandTextBox.Text = command;
            CommandResponse commandResponse = new CommandResponse();
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + uri);
                request.Credentials = new NetworkCredential(UsernameTextBox.Text, PasswordTextBox.Text);
                request.UsePassive = true;
                switch (command)
                {
                    case "DELE":
                        ConsoleTextBox.AppendText(uri + "\r\n");
                        request.Method = WebRequestMethods.Ftp.DeleteFile;
                        break;
                    case "LIST":
                        request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                        break;
                    case "PWD":
                        request.Method = WebRequestMethods.Ftp.PrintWorkingDirectory;
                        break;
                    case "STOR":
                        request.Method = WebRequestMethods.Ftp.UploadFile;
                        if (!BinaryTextBox.Text.Contains(file.Extension))
                        {
                            request.UseBinary = false;
                            ConsoleTextBox.AppendText("Not Using Binary" + "\r\n");
                        }
                        byte[] fileContents;
                        using (StreamReader sourceStream = new StreamReader(file.FullName))
                        {
                            fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                        }
                        request.ContentLength = fileContents.Length;
                        using (Stream requestStream = request.GetRequestStream())
                        {
                            requestStream.Write(fileContents, 0, fileContents.Length);
                        }
                        break;
                    default:
                        break;
                }

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        commandResponse.lines = reader.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                        commandResponse.bannerMessage = response.BannerMessage;
                        commandResponse.welcomeMessage = response.WelcomeMessage;
                        commandResponse.statusCode = response.StatusCode;
                        commandResponse.statusDescription = response.StatusDescription;

                        ConsoleTextBox.AppendText(commandResponse.bannerMessage + "\r\n");
                        ConsoleTextBox.AppendText(commandResponse.welcomeMessage + "\r\n");
                        foreach (string line in commandResponse.lines)
                        {
                            ConsoleTextBox.AppendText(line + "\r\n");
                        }
                        ConsoleTextBox.AppendText(commandResponse.statusDescription + "\r\n");
                    }
                }
            }
            catch (Exception e)
            {
                ConsoleTextBox.AppendText(e.Message);
                //throw;
            }
            return commandResponse;
        }

        private void refreshRemoteListView(string path)
        {
            try
            {
                CommandResponse commandResponse = sendFTPCommand(path, null, "LIST");
                if (commandResponse.statusCode == FtpStatusCode.ClosingData)
                {
                    RemoteListView.Clear();
                    RemoteListView.LargeImageList = FileImageList;
                    if (commandResponse.lines.Length > 0 && Regex.IsMatch(commandResponse.lines[0].Substring(0, 8), "[0-9][0-9]-[0-9][0-9]-[0-9][0-9]"))
                    {
                        foreach (string line in commandResponse.lines)
                        {
                            DirectoryItems dirItems = new DirectoryItems("W", path, line);
                            ListViewItem item = new ListViewItem(dirItems.name);
                            item.Tag = dirItems;
                            switch (dirItems.isDirectory)
                            {
                                case true:
                                    item.ImageKey = "folder";
                                    break;
                                default:
                                    switch (dirItems.ext)
                                    {
                                        case "js":
                                            item.ImageKey = "filejs";
                                            break;
                                        default:
                                            item.ImageKey = "file";
                                            break;
                                    }
                                    break;
                            }
                            RemoteListView.Items.Add(item);
                        }
                    }
                }
            }
            catch (WebException e)
            {
                ConsoleTextBox.AppendText(e.Message + "\r\n");
                //throw;
            }
        }

        private void textBoxFTPServer_Click(object sender, EventArgs e)
        {
            if ("FTP Server".Equals(FTPServerTextBox.Text))
            {
                FTPServerTextBox.Text = "";
            }
        }

        private void textBoxFTPServer_Leave(object sender, EventArgs e)
        {
            if ("".Equals(FTPServerTextBox.Text))
            {
                FTPServerTextBox.Text = "FTP Server";
            }
        }

        private void textBoxPort_Click(object sender, EventArgs e)
        {
            if ("Port".Equals(PortTextBox.Text))
            {
                PortTextBox.Text = "21";
            }
        }

        private void textBoxPort_Leave(object sender, EventArgs e)
        {
            if ("".Equals(PortTextBox.Text))
            {
                PortTextBox.Text = "Port";
            }
        }

        private void textBoxUsername_Click(object sender, EventArgs e)
        {
            if ("Username".Equals(UsernameTextBox.Text))
            {
                UsernameTextBox.Text = "";
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            if ("".Equals(UsernameTextBox.Text))
            {
                UsernameTextBox.Text = "Username";
            }
        }

        private void textBoxPassword_Click(object sender, EventArgs e)
        {
            if ("Password".Equals(PasswordTextBox.Text))
            {
                PasswordTextBox.Text = "";
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if ("".Equals(PasswordTextBox.Text))
            {
                PasswordTextBox.Text = "Password";
            }
        }

        private void BinaryTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.BinaryExt = BinaryTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);
            }
        }

        private void ListFilesButton_Click(object sender, EventArgs e)
        {
            LocalTreeView.Nodes.Clear();
            TreeNode rootNode;
            DirectoryInfo info = new DirectoryInfo(LocalPathTextBox.Text);
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                LocalTreeView.Nodes.Add(rootNode);
            }
        }

        private void LocalTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            LocalListView.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            LocalPathTextBox.Text = nodeDirInfo.FullName;
            //ListViewItem.ListViewSubItem[] subItems;

            Icon iconForFile = SystemIcons.WinLogo;
            LocalListView.View = View.Details;
            if (LocalListView.Columns.Count == 0)
            {
                LocalListView.Columns.Add("Name", -2, HorizontalAlignment.Left);
                LocalListView.Columns.Add("Date modified", -2, HorizontalAlignment.Left);
                LocalListView.Columns.Add("Type", -2, HorizontalAlignment.Left);
                LocalListView.Columns.Add("Size", -2, HorizontalAlignment.Center);
                LocalListView.Columns.Add("Status", -2, HorizontalAlignment.Center);
            }

            ListViewItem item = null;
            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                /*iconForFile = Icon.ExtractAssociatedIcon(dir.FullName);
                if (!FileImageList.Images.ContainsKey(dir.Extension))
                {
                    // If not, add the image to the image list.
                    iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(dir.FullName);
                    FileImageList.Images.Add(dir.Extension, iconForFile);
                }*/
                item = new ListViewItem(dir.Name);
                item.Name = "folder";
                item.Tag = dir;
                item.Checked = true;
                item.SubItems.Add(dir.LastWriteTime.ToShortDateString() + " " + dir.LastWriteTime.ToShortTimeString());
                item.SubItems.Add(dir.Extension);
                LocalListView.Items.Add(item);
            }
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name);
                item.Name = "file";
                item.Tag = file;
                item.Checked = true;
                item.SubItems.Add(file.LastWriteTime.ToShortDateString() + " " + file.LastWriteTime.ToShortTimeString());
                item.SubItems.Add(file.Extension);
                LocalListView.Items.Add(item);
            }

            /*foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 0);
                subItems = new ListViewItem.ListViewSubItem[]
                          {new ListViewItem.ListViewSubItem(item, "Directory"),
                   new ListViewItem.ListViewSubItem(item,
                dir.LastAccessTime.ToShortDateString())};
                item.SubItems.AddRange(subItems);
                LocalListView.Items.Add(item);
            }

            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                          { new ListViewItem.ListViewSubItem(item, "File"),
                   new ListViewItem.ListViewSubItem(item,
                file.LastAccessTime.ToShortDateString())};

                item.SubItems.AddRange(subItems);
                LocalListView.Items.Add(item);
            }*/

            LocalListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void RemoteListFilesButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FTPServer = FTPServerTextBox.Text;
            Properties.Settings.Default.Port = PortTextBox.Text;
            Properties.Settings.Default.Username = UsernameTextBox.Text;
            Properties.Settings.Default.Password = PasswordTextBox.Text;
            Properties.Settings.Default.Save();

            CommandResponse commandResponse = new CommandResponse();
            commandResponse = sendFTPCommand(
                RemotePathTextBox.Text,
                null,
                "PWD");
            try
            {
                if (commandResponse.statusCode == FtpStatusCode.PathnameCreated)
                {
                    RemotePathTextBox.Text = Regex.Match(commandResponse.statusDescription, "\"(.*?)\"").ToString().Trim(new char[] { '"' });
                }
                refreshRemoteListView(RemotePathTextBox.Text);
            }
            catch (Exception ex)
            {
                ConsoleTextBox.AppendText(ex.Message + "\r\n");
            }
        }

        private void RemoteListView_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedIitem in RemoteListView.SelectedItems)
            {
                string path = RemotePathTextBox.Text + "/" + selectedIitem.Text;
                try
                {
                    refreshRemoteListView(path);
                    RemotePathTextBox.Text = path;
                }
                catch (Exception ex)
                {
                    ConsoleTextBox.AppendText(ex.Message + "\r\n");
                    //throw;
                }
            }
        }

        private void RemoteUpButton_Click(object sender, EventArgs e)
        {
            string path = RemotePathTextBox.Text + "/..";
            try
            {
                refreshRemoteListView(path);
                int lastSlash = RemotePathTextBox.Text.LastIndexOf('/');
                //ConsoleTextBox.AppendText(lastSlash.ToString());
                RemotePathTextBox.Text = RemotePathTextBox.Text.Remove(lastSlash, RemotePathTextBox.Text.Length - lastSlash);
            }
            catch (Exception ex)
            {
                ConsoleTextBox.AppendText(ex.Message + "\r\n");
                throw;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in RemoteListView.SelectedItems)
            {
                DirectoryItems dirItems = (DirectoryItems)item.Tag;
                ConsoleTextBox.AppendText("Deleting " + dirItems.nameFull + "\r\n");
                CommandResponse commandResponse = sendFTPCommand(dirItems.nameFull, null, "DELE");
                if (commandResponse.statusCode == FtpStatusCode.FileActionOK)
                {
                    try
                    {
                        refreshRemoteListView(RemotePathTextBox.Text);
                    }
                    catch (Exception ex)
                    {
                        ConsoleTextBox.AppendText(ex.Message + "\r\n");
                    }
                }
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            CommandResponse commandResponse = new CommandResponse();
            foreach (ListViewItem item in LocalListView.SelectedItems)
            {
                if ("folder".Equals(item.Name))
                {
                    DirectoryInfo dir = (DirectoryInfo)item.Tag;
                    string parentPath = dir.FullName;
                    ConsoleTextBox.AppendText("Uploading " + dir.FullName + "\r\n");
                }
                else if ("file".Equals(item.Name))
                {
                    FileInfo file = (FileInfo)item.Tag;
                    ConsoleTextBox.AppendText("Uploading " + file.FullName + "\r\n");
                    commandResponse = sendFTPCommand(RemotePathTextBox.Text + "/" + file.Name, (FileInfo)item.Tag, "STOR");
                    if (commandResponse.statusCode == FtpStatusCode.ClosingData)
                    {
                        refreshRemoteListView(RemotePathTextBox.Text);
                    }
                }
            }
            //string path = LocalTreeView.SelectedNode.FullPath;
            //LocalTreeView.SelectedNode.BackColor = SystemColors.Highlight;
            //LocalTreeView.SelectedNode.ForeColor = SystemColors.HighlightText;
            //TreeNode selectedNode = LocalTreeView.SelectedNode;
            //int child = selectedNode.GetNodeCount(false);
            //if (child > 0)
            //{
            //    ConsoleTextBox.Text = child.ToString();
            //    selectedNode.Expand();
            //    TreeNode childNode = LocalTreeView.SelectedNode.FirstNode;
            //}
        }


    }
}
