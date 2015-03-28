using System;
using System.Drawing;
using System.Windows.Forms;
using TimeTrackLibrary.Classes;

namespace WinFormsInterface
{
    public partial class MainWindow : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private TimeSpan interval = new TimeSpan(0, 0, 1);


        ProcessSessionRepository repo = new ProcessSessionRepository();
        ProcessSessionGenerator generator = new ProcessSessionGenerator();
        ProcessSessionWatcher watcher = new ProcessSessionWatcher();
        ProcessSessionProvider provider = new ProcessSessionProvider();




        public MainWindow()
        {
            InitializeComponent();         
            tabControl1.TabPages[0].Text = "Sheet view";
            tabControl1.TabPages[1].Text = "Export menu";
            ProcessSessionsImporter.DeserializeFromFile(repo, "Data");
            ShowStatisticButton_Click(new object(), new EventArgs());

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

        }
        private void ShowStatisticButton_Click(object sender, EventArgs e)
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
            saveFileDialog.Filter = "Text File|.txt| Excel File|.xls";
            saveFileDialog.Title = "Save File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        ProcessSessionExporter.ExportAsText(repo, saveFileDialog.FileName);
                        break;
                    case 2:
                        ProcessSessionExporter.ExportAsExcel(repo, saveFileDialog.FileName);
                        break;
                }
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            using (var openFile = new OpenFileDialog())
            {
                openFile.Title = "Text File";
                openFile.ShowDialog();
                if (openFile.FileName != "")
                    ProcessSessionsImporter.ImportFromText(repo, openFile.FileName);
            }
            ShowStatisticButton_Click(null,null);
        }

        private void SerializeButton_Click(object sender, EventArgs e)
        {
            ProcessSessionExporter.SerializeIntoFile(repo, "Data");

        }

        private void DeserializeButton_Click(object sender, EventArgs e)
        {
            ProcessSessionsImporter.DeserializeFromFile(repo, "Data");
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProcessSessionExporter.SerializeIntoFile(repo, "Data");
        }

    }
}
