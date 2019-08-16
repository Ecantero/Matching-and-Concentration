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

        Random rng = new Random();
        Timer startTime = new Timer();
        int time = 5 * 60;
        Timer timer = new Timer { Interval = 1000 };
        bool canClick = false;
        PictureBox firtmagen;

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
                    Properties.Resources.AC,
                    Properties.Resources.JD,
                    Properties.Resources.KH,
                    Properties.Resources.QS,
                    Properties.Resources._2C,
                    Properties.Resources._3D,
                    Properties.Resources._4H,
                    Properties.Resources._5S,
                    Properties.Resources._6C,
                    Properties.Resources._7D,
                    Properties.Resources._8H,
                    Properties.Resources._9S,
                    Properties.Resources._10C, Properties.Resources._10S
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
                    if (tm == DialogResult.Yes)
                    {
                        RestImages();
                    }
                    else if (tm == DialogResult.No)
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
                pic.Image = Properties.Resources.gray_back;
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

        private void StartTime(object sender, EventArgs e)
        {
            HideImages();

            canClick = true;

            startTime.Stop();
        }

        private void Click_Imagen(object sender, EventArgs e)
        {
            if (!canClick)
            {
                return;
            }

            var pic = (PictureBox)sender;
            if (firtmagen == null)
            {
                firtmagen = pic;
                pic.Image = (Image)pic.Tag;
                return;
            }
            pic.Image = (Image)pic.Tag;

            if (pic.Image == firtmagen.Image && pic != firtmagen)
            {
                pic.Visible = firtmagen.Visible = false;
                {
                    firtmagen = pic;
                }

                HideImages();
            }
            else
            {
                canClick = false;
                startTime.Start();
            }

            firtmagen = null;
            if (pictureBox.Any(i => i.Visible))
            {
                return;
            }
            DialogResult newGame = MessageBox.Show("Do you want to play a new game?", "New Game", MessageBoxButtons.YesNo);
            if (newGame == DialogResult.Yes)
            {
                RestImages();
            }
            else if (newGame == DialogResult.No)
            {
                Application.Exit();
                timer.Stop();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            canClick = true;
            setRandomImages();
            HideImages();
            Time();
            startTime.Interval = 1000;
            startTime.Tick += StartTime;
            button1.Enabled = false;
        }

        private void Medium_Match_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exit = MessageBox.Show("Are you sure that you want to live of the game?", "Exit", MessageBoxButtons.YesNo);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
                timer.Stop();
            }
            else if (exit == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult newGame = MessageBox.Show("Are you shore that you want leave this game and start another game?", "New Game", MessageBoxButtons.YesNo);
            if (newGame == DialogResult.Yes)
            {
                RestImages();
            }
        }
    }
}
