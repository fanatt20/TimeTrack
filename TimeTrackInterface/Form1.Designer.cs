namespace WinFormsInterface
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HideInTrayButton = new System.Windows.Forms.Button();
            this.ShowStatisticButton = new System.Windows.Forms.Button();
            this.SpreadsheetTab = new System.Windows.Forms.TabPage();
            this.SessionsSpreadsheet = new System.Windows.Forms.DataGridView();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WindowTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.FiltersTab = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.SessionsSpreadsheetWithFilters = new System.Windows.Forms.DataGridView();
            this.ProcessNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WindowTitleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartAtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DurationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExportButton = new System.Windows.Forms.Button();
            this.BeginTrackButton = new System.Windows.Forms.Button();
            this.FinishTrackButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.SpreadsheetTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SessionsSpreadsheet)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.FiltersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SessionsSpreadsheetWithFilters)).BeginInit();
            this.SuspendLayout();
            // 
            // HideInTrayButton
            // 
            this.HideInTrayButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HideInTrayButton.Location = new System.Drawing.Point(307, 510);
            this.HideInTrayButton.Name = "HideInTrayButton";
            this.HideInTrayButton.Size = new System.Drawing.Size(93, 39);
            this.HideInTrayButton.TabIndex = 1;
            this.HideInTrayButton.Text = "Hide in Tray";
            this.HideInTrayButton.UseVisualStyleBackColor = true;
            this.HideInTrayButton.Click += new System.EventHandler(this.HideInTrayButton_Click);
            // 
            // ShowStatisticButton
            // 
            this.ShowStatisticButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ShowStatisticButton.Location = new System.Drawing.Point(208, 510);
            this.ShowStatisticButton.Name = "ShowStatisticButton";
            this.ShowStatisticButton.Size = new System.Drawing.Size(93, 39);
            this.ShowStatisticButton.TabIndex = 6;
            this.ShowStatisticButton.Text = "Show Statistic";
            this.ShowStatisticButton.UseVisualStyleBackColor = true;
            this.ShowStatisticButton.Click += new System.EventHandler(this.ShowStatisticButton_Click);
            // 
            // SpreadsheetTab
            // 
            this.SpreadsheetTab.Controls.Add(this.SessionsSpreadsheet);
            this.SpreadsheetTab.Cursor = System.Windows.Forms.Cursors.Default;
            this.SpreadsheetTab.Location = new System.Drawing.Point(4, 22);
            this.SpreadsheetTab.Name = "SpreadsheetTab";
            this.SpreadsheetTab.Padding = new System.Windows.Forms.Padding(3);
            this.SpreadsheetTab.Size = new System.Drawing.Size(578, 465);
            this.SpreadsheetTab.TabIndex = 2;
            this.SpreadsheetTab.Text = "Spreadsheet";
            this.SpreadsheetTab.UseVisualStyleBackColor = true;
            // 
            // SessionsSpreadsheet
            // 
            this.SessionsSpreadsheet.AllowUserToAddRows = false;
            this.SessionsSpreadsheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SessionsSpreadsheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessName,
            this.WindowTitle,
            this.StartAt,
            this.Duration});
            this.SessionsSpreadsheet.Location = new System.Drawing.Point(0, 0);
            this.SessionsSpreadsheet.Name = "SessionsSpreadsheet";
            this.SessionsSpreadsheet.ReadOnly = true;
            this.SessionsSpreadsheet.Size = new System.Drawing.Size(578, 465);
            this.SessionsSpreadsheet.TabIndex = 1;
            // 
            // ProcessName
            // 
            this.ProcessName.HeaderText = "Process Name";
            this.ProcessName.Name = "ProcessName";
            this.ProcessName.ReadOnly = true;
            this.ProcessName.Width = 121;
            // 
            // WindowTitle
            // 
            this.WindowTitle.FillWeight = 130F;
            this.WindowTitle.HeaderText = "Window Title";
            this.WindowTitle.Name = "WindowTitle";
            this.WindowTitle.ReadOnly = true;
            this.WindowTitle.Width = 180;
            // 
            // StartAt
            // 
            this.StartAt.HeaderText = "Start At";
            this.StartAt.Name = "StartAt";
            this.StartAt.ReadOnly = true;
            this.StartAt.Width = 124;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            this.Duration.Width = 109;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.SpreadsheetTab);
            this.tabControl1.Controls.Add(this.FiltersTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(586, 491);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // FiltersTab
            // 
            this.FiltersTab.Controls.Add(this.textBox1);
            this.FiltersTab.Controls.Add(this.label3);
            this.FiltersTab.Controls.Add(this.checkedListBox1);
            this.FiltersTab.Controls.Add(this.label2);
            this.FiltersTab.Controls.Add(this.label1);
            this.FiltersTab.Controls.Add(this.dateTimePicker2);
            this.FiltersTab.Controls.Add(this.dateTimePicker1);
            this.FiltersTab.Controls.Add(this.SubmitButton);
            this.FiltersTab.Controls.Add(this.SessionsSpreadsheetWithFilters);
            this.FiltersTab.Location = new System.Drawing.Point(4, 22);
            this.FiltersTab.Name = "FiltersTab";
            this.FiltersTab.Padding = new System.Windows.Forms.Padding(3);
            this.FiltersTab.Size = new System.Drawing.Size(578, 465);
            this.FiltersTab.TabIndex = 4;
            this.FiltersTab.Text = "Filters";
            this.FiltersTab.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(390, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(185, 20);
            this.textBox1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Window Title Contains Word:";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(390, 133);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(186, 259);
            this.checkedListBox1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "ending date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(421, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Track from the date of";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(390, 58);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(188, 20);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(390, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(188, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(390, 406);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(187, 57);
            this.SubmitButton.TabIndex = 3;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // SessionsSpreadsheetWithFilters
            // 
            this.SessionsSpreadsheetWithFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SessionsSpreadsheetWithFilters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessNameColumn,
            this.WindowTitleColumn,
            this.StartAtColumn,
            this.DurationColumn});
            this.SessionsSpreadsheetWithFilters.Location = new System.Drawing.Point(0, 0);
            this.SessionsSpreadsheetWithFilters.Name = "SessionsSpreadsheetWithFilters";
            this.SessionsSpreadsheetWithFilters.Size = new System.Drawing.Size(384, 464);
            this.SessionsSpreadsheetWithFilters.TabIndex = 2;
            // 
            // ProcessNameColumn
            // 
            this.ProcessNameColumn.HeaderText = "Process Name";
            this.ProcessNameColumn.Name = "ProcessNameColumn";
            // 
            // WindowTitleColumn
            // 
            this.WindowTitleColumn.HeaderText = "Window Title";
            this.WindowTitleColumn.Name = "WindowTitleColumn";
            // 
            // StartAtColumn
            // 
            this.StartAtColumn.HeaderText = "Start At";
            this.StartAtColumn.Name = "StartAtColumn";
            // 
            // DurationColumn
            // 
            this.DurationColumn.HeaderText = "Duration";
            this.DurationColumn.Name = "DurationColumn";
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(505, 509);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(93, 39);
            this.ExportButton.TabIndex = 1;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // BeginTrackButton
            // 
            this.BeginTrackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BeginTrackButton.Location = new System.Drawing.Point(12, 510);
            this.BeginTrackButton.Name = "BeginTrackButton";
            this.BeginTrackButton.Size = new System.Drawing.Size(91, 39);
            this.BeginTrackButton.TabIndex = 3;
            this.BeginTrackButton.Text = "Begin Track";
            this.BeginTrackButton.UseVisualStyleBackColor = true;
            this.BeginTrackButton.Click += new System.EventHandler(this.BeginTrackButton_Click);
            // 
            // FinishTrackButton
            // 
            this.FinishTrackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FinishTrackButton.Location = new System.Drawing.Point(109, 510);
            this.FinishTrackButton.Name = "FinishTrackButton";
            this.FinishTrackButton.Size = new System.Drawing.Size(93, 39);
            this.FinishTrackButton.TabIndex = 4;
            this.FinishTrackButton.Text = "Finish Track";
            this.FinishTrackButton.UseVisualStyleBackColor = true;
            this.FinishTrackButton.Click += new System.EventHandler(this.FinishTrackButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(406, 510);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(93, 38);
            this.ImportButton.TabIndex = 4;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(610, 560);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.ShowStatisticButton);
            this.Controls.Add(this.FinishTrackButton);
            this.Controls.Add(this.BeginTrackButton);
            this.Controls.Add(this.HideInTrayButton);
            this.MinimumSize = new System.Drawing.Size(506, 326);
            this.Name = "MainWindow";
            this.Text = "TimeTrack";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.SpreadsheetTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SessionsSpreadsheet)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.FiltersTab.ResumeLayout(false);
            this.FiltersTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SessionsSpreadsheetWithFilters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button HideInTrayButton;
        private System.Windows.Forms.Button ShowStatisticButton;
        private System.Windows.Forms.TabPage SpreadsheetTab;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridView SessionsSpreadsheet;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Button BeginTrackButton;
        private System.Windows.Forms.Button FinishTrackButton;
        private System.Windows.Forms.TabPage FiltersTab;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WindowTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.DataGridView SessionsSpreadsheetWithFilters;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WindowTitleColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartAtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DurationColumn;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}

