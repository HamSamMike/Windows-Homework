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
        {//���ţ����ļ���Ϊ����
            axWindowsMediaPlayer1.URL = filename;//��ʼ������
            string extension = Path.GetExtension(filename);//�����ļ�
            axWindowsMediaPlayer1.Ctlcontrols.play();//���� 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {//ѡ�����
            openFileDialog1.Filter = "ѡ����Ƶ|*.mp3;*.flac;*.wav";//��ʽѡ��
            openFileDialog1.Multiselect = true;//�����ѡ


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {//�û�ȷ��
                localmusic.Clear();//���
                listBox1.Items.Clear();
                if (files != null)
                {
                    Array.Clear(files, 0, files.Length);
                }
                //����װ��
                files = openFileDialog1.FileNames;
                string[] array = files;
                foreach (string x in array)
                {//���װ��
                    listBox1.Items.Add(x);
                    localmusic.Add(x);
                }

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//�����б���ʾ��
            if (localmusic.Count > 0)
            {
                axWindowsMediaPlayer1.URL = localmusic[listBox1.SelectedIndex];
                musicplay(axWindowsMediaPlayer1.URL);
                label1.Text = Path.GetFileNameWithoutExtension(axWindowsMediaPlayer1.URL);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {//��ǰ�ڷ�

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {//��������
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {//ֹͣ����
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {//��һ��
            if (localmusic.Count > 0)
            {
                int index = listBox1.SelectedIndex + 1;//��һ��

                if (index >= localmusic.Count())
                {//ʵ�ִ����һ������һ����ѭ��
                    index = 0;
                }
                axWindowsMediaPlayer1.URL = localmusic[index];
                //����
                musicplay(axWindowsMediaPlayer1.URL);
                label1.Text = Path.GetFileNameWithoutExtension(localmusic[index]);

                listBox1.SelectedIndex = index;

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {//ogg����

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "��ogg�ļ�|*.ogg";

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
        {//������

        }
    }
}