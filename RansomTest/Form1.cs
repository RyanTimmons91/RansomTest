using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RansomTest
{
    public partial class Form1 : Form
    {
        internal static Form1 instance;

        List<object[]> driverows;

        public Form1()
        {
            instance = this;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Log("Fetching Drive list");
            driverows = Utilities.Drives.GetDrives();

            Log("Listing Drives");
            foreach(object[] ob in driverows)
            {
                _drives.Rows.Add(ob);
            }

            Log("Listing user groups");
            _userPermissions.Items.AddRange(Utilities.UserPermissions.GetGroups());

            Log("Waiting for user Action");
        }

        internal static void Log(string s)
        {
            instance.iLog(s);
        }
        internal void iLog(string s)
        {
            _progressLabel.Text = s;
            _log.AppendText(s + Environment.NewLine);
        }

        private void _stopButton_Click(object sender, EventArgs e)
        {
            RansomCheck.shouldStop = true;
        }

        private void _startButton_Click(object sender, EventArgs e)
        {
            if (RansomCheck.isStarted)
            {
                MessageBox.Show("Scan already started, if false please restart the program.");
                return;
            }
            RansomCheck.drives = driverows;
            RansomCheck.Start();
        }

        private void _refreshButton_Click(object sender, EventArgs e)
        {
            _vulFiles.Nodes.Clear();
            
            lock(RansomCheck.rootNodeLock)
            {
                foreach(TreeNode node in RansomCheck.rootNodes)
                {
                    TreeNode node2 = (TreeNode)node.Clone();
                    _vulFiles.Nodes.Add(node2);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RansomCheck.shouldStop = true;
        }

        bool isTicking = false;
        string oldtext = "";
        private void _labelTimer_Tick(object sender, EventArgs e)
        {
            if (isTicking) return;

            isTicking = true;

            string newtext = RansomCheck.currentFolder;
            _progressLabel.Text = RansomCheck.currentFolder;

            if(oldtext != newtext)
            {
                Log(newtext);
            }

            oldtext = newtext;

            isTicking = false;
        }

        string location;

        private void _saveButton_Click(object sender, EventArgs e)
        {
            if (RansomCheck.isStarted)
            {
                MessageBox.Show("Cannot export list until after a scan has been completed.");
                return;
            }
            
            DialogResult dr = saveFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                RansomCheck.isSaving = true;

                _startButton.Enabled = false;
                _refreshButton.Enabled = false;
                _stopButton.Enabled = false;
                _saveButton.Enabled = false;

                _labelTimer.Enabled = false;
                _progressLabel.Text = "Saving data... please wait.";

                _saveTimer.Enabled = true;

                location = saveFileDialog1.FileName;

                new System.Threading.Thread(ThreadedSave).Start();
            }
        }
        
        void ThreadedSave()
        {
            StringBuilder csvData = new StringBuilder();

            TreeNode allNodes = new TreeNode();
            lock (RansomCheck.rootNodeLock)
            {
                foreach (TreeNode rnode in RansomCheck.rootNodes)
                {
                    allNodes.Nodes.Add(rnode);
                }

                BuildCSV(allNodes.Nodes, ref csvData, 0);
            }

            using (StreamWriter writer = new StreamWriter(location))
            {
                writer.Write(csvData);
            }

            RansomCheck.isSaving = false;
        }

        private void BuildCSV(TreeNodeCollection nodes, ref StringBuilder csvData, int depth)
        {
            foreach (TreeNode node in nodes)
            {
                csvData.AppendLine(new string(',', depth) + node.Text);
                
                if (node.Nodes.Count > 0)
                    BuildCSV(node.Nodes, ref csvData, depth + 1);
            }
        }

        int i = 0;
        private void _saveTimer_Tick(object sender, EventArgs e)
        {
            if(RansomCheck.isSaving)
            {
                switch(i % 3)
                {
                    case 0:
                        _progressLabel.Text = "Please wait: Saving.";
                        break;
                    case 1:
                        _progressLabel.Text = "Please wait: Saving..";
                        break;
                    case 2:
                        _progressLabel.Text = "Please wait: Saving...";
                        break;
                }
                i++;
            }
            else
            {
                RansomCheck.isSaving = false;

                _startButton.Enabled = true;
                _refreshButton.Enabled = true;
                _stopButton.Enabled = true;
                _saveButton.Enabled = true;

                _labelTimer.Enabled = _showProgress.Checked;
                _progressLabel.Text = "Saving data... Complete";
                RansomCheck.currentFolder = "Saving data... Complete";

                _saveTimer.Enabled = false;
            }
        }

        private void _showProgress_CheckedChanged(object sender, EventArgs e)
        {
            _labelTimer.Enabled = _showProgress.Checked;
        }
    }
}
