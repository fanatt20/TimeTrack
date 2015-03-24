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
using TimeTrackLibrary.Classes;
using TimeTrackLibrary.Interfaces;

namespace WinFormsInterface
{
    public partial class MainWindow : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        Charts filters;
        
        ProcessSessionRepository repo = new ProcessSessionRepository();
        ProcessSessionGenerator generator = new ProcessSessionGenerator();
        ProcessSessionWatcher watcher = new ProcessSessionWatcher();
        ProcessSessionProvider provider = new ProcessSessionProvider();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            this.Visible = false;
            filters = new Charts(repo);
            filters.Show();
            filters.FormClosed += new FormClosedEventHandler(ClosedSubForm);

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
            trayIcon.Text = "TimeTrack";
            trayIcon.Icon = new Icon(SystemIcons.Asterisk, 40, 40);


            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
            this.Visible = false;
        }


        private void BeginTrackButton_Click(object sender, EventArgs e)
        {
            watcher.StartWatch(repo, generator);
            generator.BeginGeneration(new TimeSpan(0, 0, 1), provider);
            
        }

        private void FinishTrackButton_Click(object sender, EventArgs e)
        {
            watcher.StopWatch();
        }
        private void ThreadProcSafe()
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            List<TreeNode> records = new List<TreeNode>();
            List<TreeNode> durations = new List<TreeNode>();

            foreach (var session in repo.Get())
            {
                treeView1.Nodes.Add(new TreeNode(session.ToString()));
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

            if (saveFileDialog.FileName != "")
            {
                System.IO.StreamWriter fs = new System.IO.StreamWriter(
                   (System.IO.FileStream)saveFileDialog.OpenFile());
                foreach (var record in repo.Get())
                    fs.Write(record.ToString() + "\n");
                fs.Close();
            }
        }

    }
}
