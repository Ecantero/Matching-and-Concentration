using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Medium_Match : Form
    {
        bool allowClick = false;
        PictureBox firtGuess;
        Random rng = new Random();
        Timer clickTimer = new Timer();
        int time = 5 * 60;
        Timer timer = new Timer { Interval = 1000 };

        private PictureBox[] pictureBox
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }

        private IEnumerable<Image> images
        {
            get
            {
                return new Image[]
                 {
                    MatchingGame.Properties.Resources.AC,
                    MatchingGame.Properties.Resources.JD,
                    MatchingGame.Properties.Resources.KH,
                    MatchingGame.Properties.Resources.QS,
                    MatchingGame.Properties.Resources._2C,
                    MatchingGame.Properties.Resources._3D,
                    MatchingGame.Properties.Resources._4H,
                    MatchingGame.Properties.Resources._5S,
                    MatchingGame.Properties.Resources._6C,
                    MatchingGame.Properties.Resources._7D,
                    MatchingGame.Properties.Resources._8H,
                    MatchingGame.Properties.Resources._9S,
                    MatchingGame.Properties.Resources._10C, MatchingGame.Properties.Resources._10S
                 };
            }
        }
        public Medium_Match()
        {
            InitializeComponent();
        }

        private void Time()
        {
            timer.Start();
            timer.Tick += delegate
            {
                time--;
                if (time < 0)
                {
                    timer.Stop();
                    DialogResult tm = MessageBox.Show("Bad news you don't have more time!!! Dou you want to try again", "Time", MessageBoxButtons.YesNo);
                    if(tm == DialogResult.Yes)
                    {
                        RestImages();
                    }
                    else if(tm == DialogResult.No)
                    {
                        Application.Exit();
                    }
                }

                lbl.Text = (time / 60).ToString("00") + ":" + (time % 60).ToString("00");

            };
        }


        private void RestImages()
        {
            foreach (var pic in pictureBox)
            {
                pic.Tag = null;
                pic.Visible = true;
            }

            HideImages();
            setRandomImages();
            time = 5 * 60;
            timer.Start();
        }

        private void HideImages()
        {
            foreach (var pic in pictureBox)
            {
                pic.Image = MatchingGame.Properties.Resources.gray_back;
            }
        }

        private PictureBox getFreeSlot()
        {
            int num;

            do
            {
                num = rng.Next(0, pictureBox.Count());
            } while (pictureBox[num].Tag != null);
            return pictureBox[num];
        }

        private void setRandomImages()
        {
            foreach (var image in images)
            {
                getFreeSlot().Tag = image;
                getFreeSlot().Tag = image;
            }
        }

        private void ClickTimer(object sender, EventArgs e)
        {
            HideImages();

            allowClick = true;

            clickTimer.Stop();
        }

        private void Click_Imagen(object sender, EventArgs e)
        {
            if (!allowClick) return;

            var pic = (PictureBox)sender;
            if (firtGuess == null)
            {
                firtGuess = pic;
                pic.Image = (Image)pic.Tag;
                return;
            }
            pic.Image = (Image)pic.Tag;

            if (pic.Image == firtGuess.Image && pic != firtGuess)
            {
                pic.Visible = firtGuess.Visible = false;
                {
                    firtGuess = pic;
                }

                HideImages();
            }
            else
            {
                allowClick = false;
                clickTimer.Start();
            }

            firtGuess = null;
            if (pictureBox.Any(i => i.Visible)) return;
            DialogResult newGame = MessageBox.Show("Do you want to play a new game?", "NewGame", MessageBoxButtons.YesNo);
            if(newGame == DialogResult.Yes)
            {
                RestImages();
            }
            else if (newGame == DialogResult.No)
            {
                Application.Exit();
            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            allowClick = true;
            setRandomImages();
            HideImages();
            Time();
            clickTimer.Interval = 1000;
            clickTimer.Tick += ClickTimer;
            button1.Enabled = false;
        }

        private void Medium_Match_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exit = MessageBox.Show("Are you sure that you want to live of the game?", "Exit", MessageBoxButtons.YesNo);
            if(exit == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if(exit == DialogResult.No)
            {
                e.Cancel = true;
            }

        }
    }

}
