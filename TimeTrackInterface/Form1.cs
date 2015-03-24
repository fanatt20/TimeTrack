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
        private TimeSpan interval = new TimeSpan(0, 0, 1);
        private System.Threading.Timer timer;
        private int _countOfrepoCollection;

        ProcessSessionRepository repo = new ProcessSessionRepository();
        ProcessSessionGenerator generator = new ProcessSessionGenerator();
        ProcessSessionWatcher watcher = new ProcessSessionWatcher();
        ProcessSessionProvider provider = new ProcessSessionProvider();

        BackgroundWorker backgroundWorker;


        public MainWindow()
        {
            InitializeComponent();
            tabControl1.TabPages[0].Text = "Sheet view";
            tabControl1.TabPages[1].Text = "Export menu";
            
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
            generator.BeginGeneration(interval, provider);
            generator.ProcessChanged += Generator_ProcessChanged;

        }

        void Generator_ProcessChanged(Object state)
        {
            this.Invoke((MethodInvoker)delegate
            {
                dataGridView1.Rows.Clear();

                foreach (var session in repo.Get())
                {
                    dataGridView1.Rows.Add(session.ProcessName, session.WindowTitle, session.StartAt, session.Duration);
                }
            });
        }

        private void FinishTrackButton_Click(object sender, EventArgs e)
        {
            watcher.StopWatch();
            generator.ProcessChanged -= Generator_ProcessChanged;
            if (timer!=null)
            timer.Dispose();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (var session in repo.Get())
            {
                dataGridView1.Rows.Add(session.ProcessName, session.WindowTitle, session.StartAt, session.Duration);
            }
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

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer!=null)
            timer.Dispose();
        }

    }
}
