using System;
using System.Drawing;
using System.Linq;
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
                SessionsSpreadsheet.Rows.Clear();

                foreach (var session in repo.Get())
                    SessionsSpreadsheet.Rows.Add(session.ProcessName, session.WindowTitle, session.StartAt, session.Duration);
            });
        }

        private void FinishTrackButton_Click(object sender, EventArgs e)
        {
            watcher.StopWatch();
            generator.ProcessChanged -= Generator_ProcessChanged;

        }
        private void ShowStatisticButton_Click(object sender, EventArgs e)
        {
            SessionsSpreadsheet.Rows.Clear();
            foreach (var session in repo.Get())
                SessionsSpreadsheet.Rows.Add(session.ProcessName, session.WindowTitle, session.StartAt, session.Duration);

        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File|.txt|Excel File 1999-2003|.xls|CSV|.csv";
            saveFileDialog.Title = "Save File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                try
                {
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            ProcessSessionsExporter.ExportAsText(repo, saveFileDialog.FileName);
                            break;
                        case 2:
                            ProcessSessionsExporter.ExportAsExcel(repo, saveFileDialog.FileName);
                            break;
                        case 3:
                            ProcessSessionsExporter.ExportAsCSV(repo, saveFileDialog.FileName);
                            break;
                    }
                }
                catch (System.IO.IOException excepction)
                {
                    MessageBox.Show(excepction.Message);
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
            ShowStatisticButton_Click(null, null);
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProcessSessionsExporter.SerializeIntoFile(repo, "Data");
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            SessionsSpreadsheetWithFilters.Rows.Clear();
            var processFilter = checkedListBox1.CheckedItems;

            var sessions = from session in repo.Get()
                           where processFilter.Contains(session.ProcessName) &&
                                 (dateTimePicker1.Value < session.StartAt && dateTimePicker2.Value >= session.StartAt)
                           select session;

            foreach (var session in sessions)
                SessionsSpreadsheetWithFilters.Rows.Add(session.ProcessName, session.WindowTitle, session.StartAt, session.Duration);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            var processNameCollection = from session in repo.Get()
                                        group session by session.ProcessName into s
                                        select s.Key;

            foreach (var item in processNameCollection)
                checkedListBox1.Items.Add(item);

        }
    }
}
