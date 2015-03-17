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
using Interface;
using ClassLibrary1;

namespace Interface
{
    public partial class Main : Form
    {
        Spy spy = new Spy();
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        Filters filters;
        ProcessInfoStorage data= new ProcessInfoStorage();
        ProcessInfoGenerator gen=new ProcessInfoGenerator();
        ProcessInfoHandler handler= new ProcessInfoHandler();
        private BackgroundWorker backgroundWorker1;
        private Thread demoThread;

        public Main()
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
            dataGridView1.Rows.Clear();
            foreach (var item in data)
                foreach (var record in item)
                    dataGridView1.Rows.Add(record.Name, record.Duration, item.CategoryName);
        }
    }
}
