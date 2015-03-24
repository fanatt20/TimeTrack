﻿namespace WinFormsInterface
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
            this.BeginTrackButton = new System.Windows.Forms.Button();
            this.FinishTrackButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ExportButton = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WindowTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // HideInTrayButton
            // 
            this.HideInTrayButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HideInTrayButton.Location = new System.Drawing.Point(256, 266);
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
            this.BeginTrackButton.Location = new System.Drawing.Point(12, 266);
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
            this.FinishTrackButton.Location = new System.Drawing.Point(137, 266);
            this.FinishTrackButton.Name = "FinishTrackButton";
            this.FinishTrackButton.Size = new System.Drawing.Size(113, 39);
            this.FinishTrackButton.TabIndex = 4;
            this.FinishTrackButton.Text = "Finish Track";
            this.FinishTrackButton.UseVisualStyleBackColor = true;
            this.FinishTrackButton.Click += new System.EventHandler(this.FinishTrackButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(375, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "Show Statistic";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ExportButton);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(468, 222);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(3, 6);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(113, 39);
            this.ExportButton.TabIndex = 0;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(468, 222);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(468, 222);
            this.treeView1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(476, 248);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(468, 222);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProcessName,
            this.WindowTitle,
            this.StartAt,
            this.Duration});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(467, 221);
            this.dataGridView1.TabIndex = 0;
            // 
            // ProcessName
            // 
            this.ProcessName.HeaderText = "Process Name";
            this.ProcessName.Name = "ProcessName";
            this.ProcessName.ReadOnly = true;
            // 
            // WindowTitle
            // 
            this.WindowTitle.HeaderText = "Window Title";
            this.WindowTitle.Name = "WindowTitle";
            this.WindowTitle.ReadOnly = true;
            // 
            // StartAt
            // 
            this.StartAt.HeaderText = "Start At";
            this.StartAt.Name = "StartAt";
            this.StartAt.ReadOnly = true;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(500, 317);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FinishTrackButton);
            this.Controls.Add(this.BeginTrackButton);
            this.Controls.Add(this.HideInTrayButton);
            this.MinimumSize = new System.Drawing.Size(506, 326);
            this.Name = "MainWindow";
            this.Text = "TimeSpy";
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button HideInTrayButton;
        private System.Windows.Forms.Button BeginTrackButton;
        private System.Windows.Forms.Button FinishTrackButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WindowTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
    }
}

