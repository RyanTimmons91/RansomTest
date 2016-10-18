namespace RansomTest
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this._userPermissions = new System.Windows.Forms.ListBox();
            this._progressLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._vulFiles = new System.Windows.Forms.TreeView();
            this._log = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._startButton = new System.Windows.Forms.Button();
            this._stopButton = new System.Windows.Forms.Button();
            this._drives = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._refreshButton = new System.Windows.Forms.Button();
            this._labelTimer = new System.Windows.Forms.Timer(this.components);
            this._saveButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this._saveTimer = new System.Windows.Forms.Timer(this.components);
            this._showProgress = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this._drives)).BeginInit();
            this.SuspendLayout();
            // 
            // _userPermissions
            // 
            this._userPermissions.FormattingEnabled = true;
            this._userPermissions.IntegralHeight = false;
            this._userPermissions.Location = new System.Drawing.Point(12, 25);
            this._userPermissions.Name = "_userPermissions";
            this._userPermissions.Size = new System.Drawing.Size(165, 95);
            this._userPermissions.TabIndex = 0;
            // 
            // _progressLabel
            // 
            this._progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._progressLabel.AutoSize = true;
            this._progressLabel.Location = new System.Drawing.Point(12, 328);
            this._progressLabel.Name = "_progressLabel";
            this._progressLabel.Size = new System.Drawing.Size(79, 13);
            this._progressLabel.TabIndex = 2;
            this._progressLabel.Text = "_progressLabel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "User Permissions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Drives";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Files and Directories:";
            // 
            // _vulFiles
            // 
            this._vulFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._vulFiles.Location = new System.Drawing.Point(183, 142);
            this._vulFiles.Name = "_vulFiles";
            this._vulFiles.Size = new System.Drawing.Size(550, 153);
            this._vulFiles.TabIndex = 8;
            // 
            // _log
            // 
            this._log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._log.Location = new System.Drawing.Point(183, 25);
            this._log.Multiline = true;
            this._log.Name = "_log";
            this._log.ReadOnly = true;
            this._log.Size = new System.Drawing.Size(550, 95);
            this._log.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Log";
            // 
            // _startButton
            // 
            this._startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._startButton.Location = new System.Drawing.Point(661, 301);
            this._startButton.Name = "_startButton";
            this._startButton.Size = new System.Drawing.Size(72, 26);
            this._startButton.TabIndex = 11;
            this._startButton.Text = "Start";
            this._startButton.UseVisualStyleBackColor = true;
            this._startButton.Click += new System.EventHandler(this._startButton_Click);
            // 
            // _stopButton
            // 
            this._stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._stopButton.Location = new System.Drawing.Point(565, 301);
            this._stopButton.Name = "_stopButton";
            this._stopButton.Size = new System.Drawing.Size(72, 26);
            this._stopButton.TabIndex = 12;
            this._stopButton.Text = "Stop";
            this._stopButton.UseVisualStyleBackColor = true;
            this._stopButton.Click += new System.EventHandler(this._stopButton_Click);
            // 
            // _drives
            // 
            this._drives.AllowUserToAddRows = false;
            this._drives.AllowUserToDeleteRows = false;
            this._drives.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._drives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._drives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this._drives.Location = new System.Drawing.Point(12, 142);
            this._drives.Name = "_drives";
            this._drives.ReadOnly = true;
            this._drives.RowHeadersVisible = false;
            this._drives.Size = new System.Drawing.Size(165, 153);
            this._drives.TabIndex = 13;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Drive";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 60F;
            this.Column2.HeaderText = "Type";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // _refreshButton
            // 
            this._refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._refreshButton.Location = new System.Drawing.Point(183, 301);
            this._refreshButton.Name = "_refreshButton";
            this._refreshButton.Size = new System.Drawing.Size(75, 26);
            this._refreshButton.TabIndex = 14;
            this._refreshButton.Text = "Refresh List";
            this._refreshButton.UseVisualStyleBackColor = true;
            this._refreshButton.Click += new System.EventHandler(this._refreshButton_Click);
            // 
            // _labelTimer
            // 
            this._labelTimer.Interval = 1000;
            this._labelTimer.Tick += new System.EventHandler(this._labelTimer_Tick);
            // 
            // _saveButton
            // 
            this._saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._saveButton.Location = new System.Drawing.Point(264, 301);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 26);
            this._saveButton.TabIndex = 16;
            this._saveButton.Text = "Export CSV";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this._saveButton_Click);
            // 
            // _saveTimer
            // 
            this._saveTimer.Interval = 1000;
            this._saveTimer.Tick += new System.EventHandler(this._saveTimer_Tick);
            // 
            // _showProgress
            // 
            this._showProgress.AutoSize = true;
            this._showProgress.Location = new System.Drawing.Point(12, 301);
            this._showProgress.Name = "_showProgress";
            this._showProgress.Size = new System.Drawing.Size(97, 17);
            this._showProgress.TabIndex = 17;
            this._showProgress.Text = "Show Progress";
            this._showProgress.UseVisualStyleBackColor = true;
            this._showProgress.CheckedChanged += new System.EventHandler(this._showProgress_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 350);
            this.Controls.Add(this._showProgress);
            this.Controls.Add(this._saveButton);
            this.Controls.Add(this._refreshButton);
            this.Controls.Add(this._drives);
            this.Controls.Add(this._stopButton);
            this.Controls.Add(this._startButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._log);
            this.Controls.Add(this._vulFiles);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._progressLabel);
            this.Controls.Add(this._userPermissions);
            this.MinimumSize = new System.Drawing.Size(546, 352);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._drives)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _userPermissions;
        private System.Windows.Forms.Label _progressLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView _vulFiles;
        private System.Windows.Forms.TextBox _log;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button _startButton;
        private System.Windows.Forms.Button _stopButton;
        private System.Windows.Forms.DataGridView _drives;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button _refreshButton;
        private System.Windows.Forms.Timer _labelTimer;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Timer _saveTimer;
        private System.Windows.Forms.CheckBox _showProgress;
    }
}

