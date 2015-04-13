using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TimeTrackLibrary.Classes;

namespace WinFormsInterface
{
    public partial class MainWindow : Form
    {
        private NotifyIcon _trayIcon;
        private ContextMenu _trayMenu;
        private TimeSpan _interval = new TimeSpan(0, 0, 1);


        ProcessSessionRepository _repo = new ProcessSessionRepository();
        ProcessSessionGenerator _generator = new ProcessSessionGenerator();
        ProcessSessionWatcher _watcher = new ProcessSessionWatcher();
        ProcessSessionProvider _provider = new ProcessSessionProvider();




        public MainWindow()
        {
            InitializeComponent();

            ProcessSessionsImporter.DeserializeFromFile(_repo, "Data");
            ShowStatisticButton_Click(null, null);
            BeginTrackButton_Click(null, null);
            if (_repo.Get().Count() != 0)
                dateTimePicker1.Value = _repo.Get().AsEnumerable<ProcessSession>().Min<ProcessSession>().StartAt.Date;
        }


        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void OnRestore(object sender, EventArgs e)
        {
            _trayIcon.Visible = false;
            this.Visible = true;
        }
        private void OnFinishTracking(object sender, EventArgs e)
        {
            FinishTrackButton_Click(sender, e);

        }

        private void HideInTrayButton_Click(object sender, EventArgs e)
        {

            _trayMenu = new ContextMenu();
            _trayMenu.MenuItems.Add("Exit", OnExit);
            _trayMenu.MenuItems.Add("Restore", OnRestore);
            _trayMenu.MenuItems.Add("Finish Tracking", OnFinishTracking);


            _trayIcon = new NotifyIcon();
            _trayIcon.Text = "TimeTrack";
            _trayIcon.Icon = new Icon(SystemIcons.Asterisk, 40, 40);


            _trayIcon.ContextMenu = _trayMenu;
            _trayIcon.Visible = true;
            this.Visible = false;
        }

        private void BeginTrackButton_Click(object sender, EventArgs e)
        {

            _watcher.StartWatch(_repo, _generator);
            _generator.BeginGeneration(_interval, _provider);
            _generator.ProcessChanged += Generator_ProcessChanged;

        }

        void Generator_ProcessChanged(Object state)
        {
            this.Invoke((MethodInvoker)delegate
            {
                SessionsSpreadsheet.Rows.Clear();

                foreach (var session in _repo.Get())
                    SessionsSpreadsheet.Rows.Add(session.ProcessName, session.WindowTitle, session.StartAt, session.Duration);
            });
        }

        private void FinishTrackButton_Click(object sender, EventArgs e)
        {
            _watcher.StopWatch();
            _generator.ProcessChanged -= Generator_ProcessChanged;

        }
        private void ShowStatisticButton_Click(object sender, EventArgs e)
        {
            SessionsSpreadsheet.Rows.Clear();
            foreach (var session in _repo.Get())
                SessionsSpreadsheet.Rows.Add(session.ProcessName, session.WindowTitle, session.StartAt, session.Duration);

        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TXT File|*.txt|CSV|*.csv";
            saveFileDialog.Title = "Save File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                try
                { 
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            ProcessSessionsExporter.ExportAsText(_repo, saveFileDialog.FileName);
                            break;
                        case 2:
                            ProcessSessionsExporter.ExportAsCSV(_repo, saveFileDialog.FileName);
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
                openFile.Title = "CSV File";
                openFile.Filter = "CSV|*.csv";
                openFile.ShowDialog();
                if (openFile.FileName != "")
                    ProcessSessionsImporter.ImportFromCSV(_repo, openFile.FileName);
            }
            ShowStatisticButton_Click(null, null);
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinishTrackButton_Click(null, null);
            ProcessSessionsExporter.SerializeIntoFile(_repo, "Data");
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            SessionsSpreadsheetWithFilters.Rows.Clear();
            var processFilter = checkedListBox1.CheckedItems;

            var sessions = from session in _repo.Get()
                           where session.StartAt.Date >= dateTimePicker1.Value.Date
                           && session.StartAt.Date <= dateTimePicker2.Value.Date
                           select session;

            if (processFilter.Count != 0)
                sessions = from session in sessions
                           where processFilter.Contains(session.ProcessName)
                           select session;

            if (!String.IsNullOrEmpty(textBox1.Text))
                sessions = from session in sessions
                           where session.WindowTitle.Contains(textBox1.Text)
                           select session;


            foreach (var session in sessions)
                SessionsSpreadsheetWithFilters.Rows.Add(session.ProcessName, session.WindowTitle, session.StartAt, session.Duration);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            var processNameCollection = from session in _repo.Get()
                                        group session by session.ProcessName into s
                                        select s.Key;
            checkedListBox1.Items.Clear();
            foreach (var item in processNameCollection)
                checkedListBox1.Items.Add(item);

        }
    }
}
