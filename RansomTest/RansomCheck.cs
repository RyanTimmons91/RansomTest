using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace RansomTest
{
    internal static class RansomCheck
    {
        internal static List<object[]> drives = new List<object[]>();
        
        internal static TreeNode[] rootNodes;

        internal static object rootNodeLock = new object();

        internal static bool isStarted = false;
        internal static bool shouldStop = false;
        internal static bool isSaving = false;

        internal static CurrentUserSecurity CUS;

        internal static string currentFolder = "Processing...";

        internal static void Start()
        {
            if (CUS == null) CUS = new CurrentUserSecurity();

            if (isStarted) return;

            shouldStop = false;
            isStarted = true;
            
            new Thread(tStart).Start();
        }
        internal static void tStart()
        {
            TreeNode currentNode;

            lock (rootNodeLock)
            {
                rootNodes = new TreeNode[drives.Count];

                //This adds root nodes to the array
                for (int i = 0; i < drives.Count; i++)
                {
                    TreeNode root = new TreeNode((string)drives[i][0]); //Add the drive letter as the name of hte node
                    //MessageBox.Show("" + drives[i][0]);
                    root.Tag = drives[i][0]; //Add the path as the 'tag' object of the node
                    rootNodes[i] = root;
                }
            }

            //Loop through and get files / folders for each drive
            for(int i = 0; i < drives.Count; i++)
            {
                currentNode = rootNodes[i]; //set the current node to the rootNode for the current drive

                SubLoop(currentNode); //Subloop loops through all files and folders (cascading), checks their permissions and adds them to the node if they are vulnerable

                if (shouldStop) return;
            }

            currentFolder = "Done!";

            isStarted = false;
        }

        static void SubLoop(TreeNode startNode)
        {
            

            if (shouldStop) return;

            string path;
            DirectoryInfo dir;
            
            path = (string)startNode.Tag;
            dir = new DirectoryInfo(path); //Get current path

            currentFolder = ">" + path;

            IEnumerable <FileInfo> subFiles = null;
            IEnumerable<DirectoryInfo> subDirectories = null;

            try
            {
                subFiles = dir.EnumerateFiles();
            }
            catch
            {

            }

            try
            {
                subDirectories = dir.EnumerateDirectories();
            }
            catch
            {

            }


            if (subDirectories != null)
            {
                foreach (DirectoryInfo di in subDirectories)
                {
                    TreeNode node;

                    lock (rootNodeLock)
                    {
                        node = startNode.Nodes.Add(di.Name);
                        node.Tag = di.FullName;

                        if (CUS.HasDamagingPermissions(di))
                        {
                            node.BackColor = System.Drawing.Color.Salmon;
                        }
                        else
                        {
                            node.BackColor = System.Drawing.Color.LimeGreen;
                        }
                    }

                    SubLoop(node);

                    if (shouldStop) return;
                }
            }

            if (subFiles != null)
            {
                foreach(FileInfo fi in subFiles)
                {
                    TreeNode node;

                    lock (rootNodeLock)
                    {
                        if (CUS.HasDamagingPermissions(fi))
                        {
                            node = startNode.Nodes.Add(fi.Name);
                            node.Tag = fi.FullName;
                            node.BackColor = System.Drawing.Color.Salmon;
                        }
                    }
                }
            }
        }
    }
}
