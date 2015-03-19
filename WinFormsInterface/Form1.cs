using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using ClassLibrary1;

namespace WinFormsInterface
{
    public partial class MainWindow : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        Filters filters;
        ProcessInfoStorage data = new ProcessInfoStorage();
        ProcessInfoGenerator gen = new ProcessInfoGenerator();
        ProcessInfoHandler handler = new ProcessInfoHandler();
        private BackgroundWorker backgroundWorker1;
        private Thread demoThread;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            filters = new Filters(data);
            filters.Show();
            filters.FormClosed += new FormClosedEventHandler(ClosedSubForm);

            //this.Visible = true;
            // Application.Run(new Filters());
        }
        private void ClosedSubForm(object sender, EventArgs e)
        {
            this.Show();
            sender = null;
        }
        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void OnRestore(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            this.Visible = true;
        }
        private void OnFinishTracking(object sender, EventArgs e)
        {
            FinishTrackButton_Click(sender, e);

        }

        private void HideInTrayButton_Click(object sender, EventArgs e)
        {

            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Exit", OnExit);
            trayMenu.MenuItems.Add("Restore", OnRestore);
            trayMenu.MenuItems.Add("Finish Tracking", OnFinishTracking);


            trayIcon = new NotifyIcon();
            trayIcon.Text = "TimeSpy";
            trayIcon.Icon = new Icon(SystemIcons.Asterisk, 40, 40);


            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
            this.Visible = false;
        }


        private void BeginTrackButton_Click(object sender, EventArgs e)
        {
            handler.StartTrack(gen, data, 1);
        }

        private void FinishTrackButton_Click(object sender, EventArgs e)
        {
            handler.FinishTrack();
        }
        private void UpdateData(object sender, ProcessInfoEventArgs e)
        {
        }


        // This method is executed on the worker thread and makes 
        // a thread-safe call on the TextBox control. 
        private void ThreadProcSafe()
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            List<TreeNode> records = new List<TreeNode>();
            List<TreeNode> durations = new List<TreeNode>();

            foreach (var category in data.GetCollection())
            {
                records.Add(new TreeNode(category.CategoryDuration.ToString()));
                foreach (var record in category)
                {
                    durations.Clear();
                    durations.Add(new TreeNode("Process duration: " + record.ProcessDuration.ToString()));
                    foreach (var duration in record.GetCollection())
                        durations.Add(new TreeNode("start in: " + duration.Key + "\t with duration: " + duration.Value));
                    records.Add(new TreeNode("Process Name:" + record.Name, durations.ToArray()));
                }
                
                treeView1.Nodes.Add(new TreeNode(category.CategoryName, records.ToArray()));
                records.Clear();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File|.txt";
            saveFileDialog.Title = "Save an Text File";
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.StreamWriter fs = new System.IO.StreamWriter(
                   (System.IO.FileStream)saveFileDialog.OpenFile());
                foreach (var record in data)
                    fs.Write(record.ToString() + "\n");
                fs.Close();
            }
        }

    }
}
