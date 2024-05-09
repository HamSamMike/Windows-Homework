using NAudio;
using NAudio.Vorbis;
using NAudio.Wave;
using System;
using System.Text;

namespace Windows___
{
    public partial class Form1 : Form
    {
        string[] files;

        List<string> localmusic = new List<string> { };
        public Form1()
        {
            InitializeComponent();
        }

        private void musicplay(string filename)
        {//播放，以文件名为参数
            axWindowsMediaPlayer1.URL = filename;//初始化变量
            string extension = Path.GetExtension(filename);//传递文件
            axWindowsMediaPlayer1.Ctlcontrols.play();//播放 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {//选择歌曲
            openFileDialog1.Filter = "选择音频|*.mp3;*.flac;*.wav";//格式选择
            openFileDialog1.Multiselect = true;//允许多选


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {//用户确定
                localmusic.Clear();//清除
                listBox1.Items.Clear();
                if (files != null)
                {
                    Array.Clear(files, 0, files.Length);
                }
                //重新装填
                files = openFileDialog1.FileNames;
                string[] array = files;
                foreach (string x in array)
                {//逐个装填
                    listBox1.Items.Add(x);
                    localmusic.Add(x);
                }

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//歌曲列表显示区
            if (localmusic.Count > 0)
            {
                axWindowsMediaPlayer1.URL = localmusic[listBox1.SelectedIndex];
                musicplay(axWindowsMediaPlayer1.URL);
                label1.Text = Path.GetFileNameWithoutExtension(axWindowsMediaPlayer1.URL);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {//当前在放

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {//音量调节
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {//停止播放
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {//下一曲
            if (localmusic.Count > 0)
            {
                int index = listBox1.SelectedIndex + 1;//下一曲

                if (index >= localmusic.Count())
                {//实现从最后一曲到第一曲的循环
                    index = 0;
                }
                axWindowsMediaPlayer1.URL = localmusic[index];
                //播放
                musicplay(axWindowsMediaPlayer1.URL);
                label1.Text = Path.GetFileNameWithoutExtension(localmusic[index]);

                listBox1.SelectedIndex = index;

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {//ogg播放

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "打开ogg文件|*.ogg";

            string oggFilePath = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                oggFilePath = openFileDialog.FileName;

                using (var vorbis = new VorbisWaveReader(oggFilePath))
                {
                    using (var waveOut = new WaveOutEvent())
                    {
                        waveOut.Init(vorbis);
                        waveOut.Play();

                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            Thread.Sleep(1000);
                        }


                    }
                }

            }
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {//进度条

        }
    }
}