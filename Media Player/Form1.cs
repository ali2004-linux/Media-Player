using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            axWindowsMediaPlayer1.uiMode = "none";

        }

        private void btn_mou_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.settings.volume != 0)
            {
                axWindowsMediaPlayer1.settings.volume = 0;
            }
            else if (axWindowsMediaPlayer1.settings.volume == 0)
            {
                axWindowsMediaPlayer1.settings.volume = trackBar2.Value;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                foreach (var filename in openFileDialog1.FileNames)
                {
                    axWindowsMediaPlayer1.currentPlaylist.appendItem(axWindowsMediaPlayer1.newMedia(filename));
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    trackBar1.Maximum = (int)axWindowsMediaPlayer1.currentMedia.duration;
                    trackBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
                    timer1.Enabled = true;
                }
            }
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            if(axWindowsMediaPlayer1.currentPlaylist.count >= 1)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                trackBar1.Maximum = (int)axWindowsMediaPlayer1.currentMedia.duration;
                trackBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("لطفا فایل را انتخاب کنید");
            }
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void btn_pre_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.currentPlaylist.count > 1)
            {
                axWindowsMediaPlayer1.Ctlcontrols.previous();
                trackBar1.Value = 0;
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.currentPlaylist.count > 1)
            {
                axWindowsMediaPlayer1.Ctlcontrols.next();
                trackBar1.Value = 0;
            }
        }

        private void btn_rm_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.currentPlaylist.clear();
            trackBar1.Maximum = 0;
            trackBar1.Value = 0;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //axWindowsMediaPlayer1.Ctlcontrols.currentPosition = trackBar1.Value;/
            
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar2.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                trackBar1.Maximum = (int)axWindowsMediaPlayer1.currentMedia.duration;
                trackBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            }
            catch
            {
            }
        }
    }
}
