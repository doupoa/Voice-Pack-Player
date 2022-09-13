using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace KeyMusic
{
    public partial class 轻音 : Form
    {

        IList<Info> OutputDevice = new List<Info>(); //设置音频驱动列表
        BindingList<MusicInfo> MusicList = new BindingList<MusicInfo>(); //音频列表
        WaveOutEvent waveOutEvent = new WaveOutEvent() { DeviceNumber = -1 }; //注册音频输出事件
        int fileTime = 0; //当前选中文件的总时长
        String NowPlayPath = ""; // 现在播放音频的目录
        private const int WM_HOTKEY = 0x312; //窗口消息：热键
        private const int WM_CREATE = 0x1; //窗口消息：创建
        private const int WM_DESTROY = 0x2; //窗口消息：销毁
        private const int PlaySound = 0x1111; //热键ID（播放音乐）
        private const int StopSound = 0x2222; //热键ID （停止音乐）

        public 轻音()
        {
            InitializeComponent();
            BindDevice();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public class Info
        {
            public string Id { get; set; }
            public string Name { get; set; }

        }

        public class MusicInfo
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string FilePath { get; set; }
        }


        private string Sec2Min(Int64 sec)
        {
            Int64 fen;
            Int64 miao;
            String sMin;
            String sSec;
            if (sec < 0)
                sec = 0;
            miao = sec % 60;
            sec = sec - miao;
            sec /= 60;
            fen = sec % 60;
            sec -= fen;
            if (fen < 10) { sMin = "0" + fen; } else { sMin = fen.ToString(); }
            if (miao < 10) { sSec = "0" + miao; } else { sSec = miao.ToString(); }
            return sMin + ":" + sSec;
        }

        private void BindDevice()
        {
            for (int n = 0; n < WaveOut.DeviceCount; n++)
            {
                var caps = WaveOut.GetCapabilities(n);
                OutputDevice.Add(new Info() { Id = n.ToString(), Name = caps.ProductName });
            }
            OutputDeviceList.DataSource = OutputDevice;
            OutputDeviceList.ValueMember = "Id";
            OutputDeviceList.DisplayMember = "Name";
        }




        private void OnPlaying()
        {
            while (true)
            {
                if (waveOutEvent.PlaybackState == PlaybackState.Playing)
                {
                    int sec = (int)(waveOutEvent.GetPosition() / waveOutEvent.OutputWaveFormat.BitsPerSample / waveOutEvent.OutputWaveFormat.Channels * 8.0 / waveOutEvent.OutputWaveFormat.SampleRate);
                    try
                    {
                        Invoke(new updateProgressDelegate(updateProgress), new Object[] { sec });
                    }
                    catch
                    {
                        return;
                    }

                }
                else
                {

                    try { Invoke(new updateProgressDelegate(updateProgress), new Object[] { -1 }); }
                    catch { return; }
                }
                Thread.Sleep(100);
            }
        }


        delegate void updateProgressDelegate(int current);

        void updateProgress(int current)
        {
            if (current == -1)
            {
                PlaybackProgress.Value = 0;
                AudioStaus.Text = "00:00/00:00";
                return;
            }
            int staus = (int)((current * 100 / fileTime));
            PlaybackProgress.Value = staus;
            AudioStaus.Text = Sec2Min(current) + "/" + Sec2Min(fileTime);
        }

        private void StartPlay()
        {
            if (NowPlayPath == "")
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "MP3|*.mp3";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    NowPlayPath = dialog.FileName;
                }
                else
                {
                    MessageBox.Show("未指定音频文件");
                    return;
                }
            }
            if (isRandom.Checked && FileList.Items.Count > 0)
            {
                Random rd = new Random();
                int i = rd.Next(0, FileList.Items.Count);
                FileList.SelectedIndex = i;
            }

            waveOutEvent.DeviceNumber = OutputDeviceList.SelectedIndex;
            //文件访问对象
            AudioFileReader waveReader = new AudioFileReader(NowPlayPath);
            fileTime = (int)waveReader.TotalTime.TotalSeconds;
            if (waveOutEvent.PlaybackState == PlaybackState.Playing)
            {
                waveOutEvent.Stop();
            }
            waveOutEvent.Init(waveReader);
            waveOutEvent.Play();
            Thread thread = new Thread(new ThreadStart(OnPlaying));
            thread.Start();
        }

        private void PlayMusic_Click(object sender, EventArgs e)
        {
            StartPlay();
        }

        private void StopMusic_Click(object sender, EventArgs e)
        {
            waveOutEvent.Stop();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result = MessageBox.Show("确认退出吗？", "退出询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (result == DialogResult.Cancel) { waveOutEvent.Stop(); e.Cancel = true; }
            //else { e.Cancel = false; }
            waveOutEvent.Stop();
        }



        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_HOTKEY: //窗口消息-热键ID
                    switch (m.WParam.ToInt32())
                    {
                        case PlaySound:
                            StartPlay();
                            break;
                        case StopSound:
                            waveOutEvent.Stop();
                            break;
                        default:
                            break;
                    }
                    break;
                case WM_CREATE: //窗口消息-创建
                    AppHotKey.RegKey(Handle, StopSound, AppHotKey.KeyModifiers.Alt, Keys.Subtract);
                    AppHotKey.RegKey(Handle, PlaySound, AppHotKey.KeyModifiers.Alt, Keys.Add);
                    break;
                case WM_DESTROY: //窗口消息-销毁
                    AppHotKey.UnRegKey(Handle, StopSound); //销毁热键
                    AppHotKey.UnRegKey(Handle, PlaySound); //销毁热键
                    break;
                default:
                    break;
            }
        }

        private void ScanDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                string[] files = Directory.GetFiles(dialog.SelectedPath, "*.mp3", SearchOption.AllDirectories);    //从“路径”中搜索所有的指定文件
                SortedList<string, FileInfo> fileList = new SortedList<string, FileInfo>();
                if (files.Length > 0)
                {
                    //搜索到了文件，继续执行

                    foreach (string f in files)    //把文件夹中搜索到文件信息全部存储到刚才声明的字典中
                    {
                        FileInfo fi = new FileInfo(f);  //根据路径获取文件信息
                        fileList.Add(fi.LastWriteTime.Ticks.ToString() + fi.Name, fi);  //存储文件信息到字典中
                    }
                    //把存储到文件信息字典中的数据显示到listview中
                    int i = 0;
                    MusicList.Clear();
                    foreach (string item in fileList.Keys)
                    {
                        MusicList.Add(new MusicInfo() { Id = i.ToString(), Name = fileList[item].Name, FilePath = fileList[item].FullName });
                        i++;
                    }
                    FileList.DataSource = MusicList;
                    FileList.ValueMember = "Id";
                    FileList.DisplayMember = "Name";

                }
            }
            else
            {
                MessageBox.Show("未查找到文件");
            }
        }

        private void FileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            NowPlayPath = MusicList[FileList.SelectedIndex].FilePath.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Application.Restart();
        }

        private void PlayMusic_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(PlayMusic, "快捷键:Alt键+加号键");
        }

        private void StopMusic_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip2.SetToolTip(StopMusic, "快捷键:Alt键+减号键");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://github.com/doupoa/Voice-Pack-Player");
        }
    }
}