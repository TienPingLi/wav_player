using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SoundPlayer player;

        public Form1()
        {
            InitializeComponent();
        }

        private bool CheckWAVFile()
        {
            if (txtPath.Text == "")
            {
                MessageBox.Show("請先選擇 WAV 音效檔。", "提醒",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!File.Exists(txtPath.Text))
            {
                MessageBox.Show("找不到指定的音效檔。", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdWAVFile.Filter = "WAV Files (*.wav)|*.wav";
            ofdWAVFile.DefaultExt = "wav";
            ofdWAVFile.FileName = "";

            if (ofdWAVFile.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofdWAVFile.FileName;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!CheckWAVFile())
                return;

            try
            {
                if (player != null)
                {
                    player.Stop();
                    player.Dispose();
                }

                player = new SoundPlayer(txtPath.Text);
                player.Load();
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("播放失敗：" + ex.Message, "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoop_Click(object sender, EventArgs e)
        {
            if (!CheckWAVFile())
                return;

            try
            {
                if (player != null)
                {
                    player.Stop();
                    player.Dispose();
                }

                player = new SoundPlayer(txtPath.Text);
                player.Load();
                player.PlayLooping();
            }
            catch (Exception ex)
            {
                MessageBox.Show("播放失敗：" + ex.Message, "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (player != null)
            {
                player.Stop();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "確定要關閉應用程式嗎？",
                "關閉確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            if (player != null)
            {
                player.Stop();
                player.Dispose();
            }
        }
    }
}