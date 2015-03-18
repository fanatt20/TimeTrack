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
            this.CurrentProcessButton = new System.Windows.Forms.Button();
            this.HideInTrayButton = new System.Windows.Forms.Button();
            this.BeginTrackButton = new System.Windows.Forms.Button();
            this.FinishTrackButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.CategorysGrid = new System.Windows.Forms.DataGridView();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategorysGrid)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CurrentProcessButton
            // 
            this.CurrentProcessButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CurrentProcessButton.Location = new System.Drawing.Point(12, 266);
            this.CurrentProcessButton.Name = "CurrentProcessButton";
            this.CurrentProcessButton.Size = new System.Drawing.Size(113, 39);
            this.CurrentProcessButton.TabIndex = 0;
            this.CurrentProcessButton.Text = "Chart";
            this.CurrentProcessButton.UseVisualStyleBackColor = true;
            this.CurrentProcessButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // HideInTrayButton
            // 
            this.HideInTrayButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HideInTrayButton.Location = new System.Drawing.Point(375, 266);
            this.HideInTrayButton.Name = "HideInTrayButton";
            this.HideInTrayButton.Size = new System.Drawing.Size(113, 39);
            this.HideInTrayButton.TabIndex = 1;
            this.HideInTrayButton.Text = "Hide in Tray";
            this.HideInTrayButton.UseVisualStyleBackColor = true;
            this.HideInTrayButton.Click += new System.EventHandler(this.HideInTrayButton_Click);
            // 
            // BeginTrackButton
            // 
            this.BeginTrackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BeginTrackButton.Location = new System.Drawing.Point(137, 266);
            this.BeginTrackButton.Name = "BeginTrackButton";
            this.BeginTrackButton.Size = new System.Drawing.Size(113, 39);
            this.BeginTrackButton.TabIndex = 3;
            this.BeginTrackButton.Text = "Begin Track";
            this.BeginTrackButton.UseVisualStyleBackColor = true;
            this.BeginTrackButton.Click += new System.EventHandler(this.BeginTrackButton_Click);
            // 
            // FinishTrackButton
            // 
            this.FinishTrackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FinishTrackButton.Location = new System.Drawing.Point(256, 266);
            this.FinishTrackButton.Name = "FinishTrackButton";
            this.FinishTrackButton.Size = new System.Drawing.Size(113, 39);
            this.FinishTrackButton.TabIndex = 4;
            this.FinishTrackButton.Text = "Finish Track";
            this.FinishTrackButton.UseVisualStyleBackColor = true;
            this.FinishTrackButton.Click += new System.EventHandler(this.FinishTrackButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessName,
            this.Key,
            this.Value});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(587, 222);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ProcessName
            // 
            this.ProcessName.HeaderText = "Process Name";
            this.ProcessName.Name = "ProcessName";
            // 
            // Key
            // 
            this.Key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Key.FillWeight = 300F;
            this.Key.HeaderText = "Process Title";
            this.Key.Name = "Key";
            // 
            // Value
            // 
            this.Value.HeaderText = "Wasted Time";
            this.Value.Name = "Value";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(494, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "Show Statistic";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // CategorysGrid
            // 
            this.CategorysGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CategorysGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CategorysGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Group,
            this.Time});
            this.CategorysGrid.Location = new System.Drawing.Point(0, 0);
            this.CategorysGrid.Name = "CategorysGrid";
            this.CategorysGrid.Size = new System.Drawing.Size(587, 222);
            this.CategorysGrid.TabIndex = 7;
            // 
            // Group
            // 
            this.Group.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Group.HeaderText = "Group";
            this.Group.Name = "Group";
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(595, 248);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(587, 222);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CategorysGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(587, 222);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(619, 317);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FinishTrackButton);
            this.Controls.Add(this.BeginTrackButton);
            this.Controls.Add(this.HideInTrayButton);
            this.Controls.Add(this.CurrentProcessButton);
            this.MinimumSize = new System.Drawing.Size(506, 326);
            this.Name = "MainWindow";
            this.Text = "TimeSpy";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CategorysGrid)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CurrentProcessButton;
        private System.Windows.Forms.Button HideInTrayButton;
        private System.Windows.Forms.Button BeginTrackButton;
        private System.Windows.Forms.Button FinishTrackButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridView CategorysGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

