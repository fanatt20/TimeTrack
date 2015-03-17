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
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CurrentProcessButton
            // 
            this.CurrentProcessButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CurrentProcessButton.Location = new System.Drawing.Point(12, 236);
            this.CurrentProcessButton.Name = "CurrentProcessButton";
            this.CurrentProcessButton.Size = new System.Drawing.Size(113, 39);
            this.CurrentProcessButton.TabIndex = 0;
            this.CurrentProcessButton.Text = "Categories";
            this.CurrentProcessButton.UseVisualStyleBackColor = true;
            this.CurrentProcessButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // HideInTrayButton
            // 
            this.HideInTrayButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HideInTrayButton.Location = new System.Drawing.Point(369, 236);
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
            this.BeginTrackButton.Location = new System.Drawing.Point(131, 236);
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
            this.FinishTrackButton.Location = new System.Drawing.Point(250, 236);
            this.FinishTrackButton.Name = "FinishTrackButton";
            this.FinishTrackButton.Size = new System.Drawing.Size(113, 39);
            this.FinishTrackButton.TabIndex = 4;
            this.FinishTrackButton.Text = "Finish Track";
            this.FinishTrackButton.UseVisualStyleBackColor = true;
            this.FinishTrackButton.Click += new System.EventHandler(this.FinishTrackButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Value,
            this.ProcessName});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(591, 218);
            this.dataGridView1.TabIndex = 5;
            // 
            // Key
            // 
            this.Key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Key.FillWeight = 300F;
            this.Key.HeaderText = "Name";
            this.Key.Name = "Key";
            // 
            // Value
            // 
            this.Value.HeaderText = "Wasted Time";
            this.Value.Name = "Value";
            // 
            // ProcessName
            // 
            this.ProcessName.HeaderText = "Process Name";
            this.ProcessName.Name = "ProcessName";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(490, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 39);
            this.button1.TabIndex = 6;
            this.button1.Text = "Show Statistic";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(615, 287);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.FinishTrackButton);
            this.Controls.Add(this.BeginTrackButton);
            this.Controls.Add(this.HideInTrayButton);
            this.Controls.Add(this.CurrentProcessButton);
            this.MinimumSize = new System.Drawing.Size(506, 326);
            this.Name = "Main";
            this.Text = "TimeSpy";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CurrentProcessButton;
        private System.Windows.Forms.Button HideInTrayButton;
        private System.Windows.Forms.Button BeginTrackButton;
        private System.Windows.Forms.Button FinishTrackButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessName;
        private System.Windows.Forms.Button button1;
    }
}

