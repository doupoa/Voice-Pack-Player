namespace KeyMusic
{
    partial class 轻音
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(轻音));
            this.OutputDeviceList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.isRandom = new System.Windows.Forms.CheckBox();
            this.PlayMusic = new System.Windows.Forms.Button();
            this.StopMusic = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.PlaybackProgress = new System.Windows.Forms.ProgressBar();
            this.AudioStaus = new System.Windows.Forms.Label();
            this.ScanDir = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.FileList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // OutputDeviceList
            // 
            this.OutputDeviceList.FormattingEnabled = true;
            this.OutputDeviceList.Location = new System.Drawing.Point(9, 24);
            this.OutputDeviceList.Margin = new System.Windows.Forms.Padding(2);
            this.OutputDeviceList.Name = "OutputDeviceList";
            this.OutputDeviceList.Size = new System.Drawing.Size(257, 20);
            this.OutputDeviceList.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "音频输出至:";
            // 
            // isRandom
            // 
            this.isRandom.AutoSize = true;
            this.isRandom.Checked = true;
            this.isRandom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isRandom.Location = new System.Drawing.Point(198, 6);
            this.isRandom.Margin = new System.Windows.Forms.Padding(2);
            this.isRandom.Name = "isRandom";
            this.isRandom.Size = new System.Drawing.Size(72, 16);
            this.isRandom.TabIndex = 4;
            this.isRandom.Text = "随机播放";
            this.isRandom.UseVisualStyleBackColor = true;
            // 
            // PlayMusic
            // 
            this.PlayMusic.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PlayMusic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.PlayMusic.Location = new System.Drawing.Point(141, 46);
            this.PlayMusic.Margin = new System.Windows.Forms.Padding(2);
            this.PlayMusic.Name = "PlayMusic";
            this.PlayMusic.Size = new System.Drawing.Size(57, 22);
            this.PlayMusic.TabIndex = 6;
            this.PlayMusic.Text = "▶️播放";
            this.PlayMusic.UseVisualStyleBackColor = true;
            this.PlayMusic.Click += new System.EventHandler(this.PlayMusic_Click);
            this.PlayMusic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PlayMusic_MouseMove);
            // 
            // StopMusic
            // 
            this.StopMusic.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StopMusic.ForeColor = System.Drawing.Color.Red;
            this.StopMusic.Location = new System.Drawing.Point(207, 46);
            this.StopMusic.Margin = new System.Windows.Forms.Padding(2);
            this.StopMusic.Name = "StopMusic";
            this.StopMusic.Size = new System.Drawing.Size(59, 22);
            this.StopMusic.TabIndex = 7;
            this.StopMusic.Text = "■停止";
            this.StopMusic.UseVisualStyleBackColor = true;
            this.StopMusic.Click += new System.EventHandler(this.StopMusic_Click);
            this.StopMusic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StopMusic_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "播放列表";
            // 
            // PlaybackProgress
            // 
            this.PlaybackProgress.Location = new System.Drawing.Point(9, 186);
            this.PlaybackProgress.Name = "PlaybackProgress";
            this.PlaybackProgress.Size = new System.Drawing.Size(176, 12);
            this.PlaybackProgress.TabIndex = 1;
            // 
            // AudioStaus
            // 
            this.AudioStaus.AutoSize = true;
            this.AudioStaus.Location = new System.Drawing.Point(193, 186);
            this.AudioStaus.Name = "AudioStaus";
            this.AudioStaus.Size = new System.Drawing.Size(71, 12);
            this.AudioStaus.TabIndex = 12;
            this.AudioStaus.Text = "00:00/00:00";
            // 
            // ScanDir
            // 
            this.ScanDir.Location = new System.Drawing.Point(68, 46);
            this.ScanDir.Margin = new System.Windows.Forms.Padding(2);
            this.ScanDir.Name = "ScanDir";
            this.ScanDir.Size = new System.Drawing.Size(64, 21);
            this.ScanDir.TabIndex = 13;
            this.ScanDir.Text = "扫描目录";
            this.ScanDir.UseVisualStyleBackColor = true;
            this.ScanDir.Click += new System.EventHandler(this.ScanDir_Click);
            // 
            // FileList
            // 
            this.FileList.FormattingEnabled = true;
            this.FileList.ItemHeight = 12;
            this.FileList.Location = new System.Drawing.Point(9, 70);
            this.FileList.Margin = new System.Windows.Forms.Padding(2);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(257, 112);
            this.FileList.TabIndex = 14;
            this.FileList.SelectedIndexChanged += new System.EventHandler(this.FileList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 20);
            this.button1.TabIndex = 17;
            this.button1.Text = "关于 && 帮助";
            this.button1.UseVisualStyleBackColor = true;
<<<<<<< HEAD
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
=======
>>>>>>> ae22585e39c640574190b30abecde9d83e543ce8
            // 
            // 轻音
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(274, 202);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileList);
            this.Controls.Add(this.ScanDir);
            this.Controls.Add(this.AudioStaus);
            this.Controls.Add(this.PlaybackProgress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StopMusic);
            this.Controls.Add(this.PlayMusic);
            this.Controls.Add(this.isRandom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OutputDeviceList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "轻音";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "轻音";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox OutputDeviceList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox isRandom;
        private System.Windows.Forms.Button PlayMusic;
        private System.Windows.Forms.Button StopMusic;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar PlaybackProgress;
        private System.Windows.Forms.Label AudioStaus;
        private System.Windows.Forms.Button ScanDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox FileList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
    }
}

