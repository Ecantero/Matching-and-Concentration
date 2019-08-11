using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Hard_Match : Form
    {

        bool allowClick = false;
        PictureBox firtGuess;
        Random rng = new Random();
        Timer clickTimer = new Timer();
        int time = 600;
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
                    Properties.Resources.AH, Properties.Resources.AS,
                    Properties.Resources.JC, Properties.Resources.JS,
                    Properties.Resources.KC, Properties.Resources.KD,
                    Properties.Resources.QD, Properties.Resources.QS,
                    Properties.Resources._2C, Properties.Resources._2H, 
                    Properties.Resources._3D, Properties.Resources._3H,
                    Properties.Resources._4C, Properties.Resources._4H,
                    Properties.Resources._5C, Properties.Resources._5D, 
                    Properties.Resources._6H, Properties.Resources._6S,
                    Properties.Resources._7D, Properties.Resources._7H, 
                    Properties.Resources._8C, Properties.Resources._8H,
                    Properties.Resources._9D, Properties.Resources._9S,
                    Properties.Resources._10D, Properties.Resources._10H
                 };
            }
        }
        public Hard_Match()
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
                    MessageBox.Show("Out of time");
                    RestImages();
                }

                var ssTime = TimeSpan.FromSeconds(time);
                //lblTime.text = "00: " + time.toString();
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
            time = 600;
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
            MessageBox.Show("You win now try again");
            RestImages();
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
    }
}
