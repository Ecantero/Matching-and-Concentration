using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace m.Difficulty
{
    class Easy_Class
    {

        private static bool allowClick = false;
        private static PictureBox firtGuess;
        private static Random rng = new Random();
        private static Timer clickTimer = new Timer();
        private static int time = 300;
        private static Timer timer = new Timer { Interval = 1000 };

        private static PictureBox[] pictureBox = new PictureBox[14];

        private static IEnumerable<Image> images
        {
            get
            {
                return new Image[]
                 {
                    Properties.Resources.AC,Properties.Resources.AD,Properties.Resources.AH,Properties.Resources.AS,
                    Properties.Resources.JC,Properties.Resources.JD,Properties.Resources.JH,Properties.Resources.JS,
                    Properties.Resources.KC,Properties.Resources.KD,Properties.Resources.KH,Properties.Resources.KS,
                    Properties.Resources.QC,Properties.Resources.QD,Properties.Resources.QH,Properties.Resources.QS,
                    Properties.Resources._2C, Properties.Resources._2D,Properties.Resources._2H,Properties.Resources._2S,
                    Properties.Resources._3C,Properties.Resources._3D,Properties.Resources._3H,Properties.Resources._3S,
                    Properties.Resources._4C,Properties.Resources._4D,Properties.Resources._4H,Properties.Resources._4S,
                    Properties.Resources._5C,Properties.Resources._5D,Properties.Resources._5H,Properties.Resources._5S,
                    Properties.Resources._6C,Properties.Resources._6D,Properties.Resources._6H,Properties.Resources._6S,
                    Properties.Resources._7C,Properties.Resources._7D,Properties.Resources._7H,Properties.Resources._7S,
                    Properties.Resources._8C,Properties.Resources._8D,Properties.Resources._8H,Properties.Resources._8S,
                    Properties.Resources._9C,Properties.Resources._9D,Properties.Resources._9H,Properties.Resources._9S,
                    Properties.Resources._10C,Properties.Resources._10D,Properties.Resources._10H,Properties.Resources._10S
                 };
            }
        }

        private static void Time()
        {
            timer.Start();
            timer.Tick += delegate
            {
                time--;
                if (time < 0)
                {
                    timer.Stop();
                    System.Windows.Forms.MessageBox.Show("Out of time");
                    RestImages();
                }

                var ssTime = TimeSpan.FromSeconds(time);
                //lblTime.Text = "00: " + time3.ToString();
            };
        }


        private static void RestImages()
        {
            foreach (var pic in pictureBox)
            {
                pic.Tag = null;
                pic.Visible = true;
            }

            HideImages();
            setRandomImages();
            time = 360;
            timer.Start();
        }

        private static void HideImages()
        {
            foreach (var pic in pictureBox)
            {
                pic.Image = Properties.Resources.gray_back;
            }
        }

        private static PictureBox getFreeSlot()
        {
            int num;

            do
            {
                num = rng.Next(0, pictureBox.Count());
            } while (pictureBox[num].Tag != null);
            return pictureBox[num];
        }

        private static void setRandomImages()
        {
            foreach (var image in images)
            {
                getFreeSlot().Tag = image;
                getFreeSlot().Tag = image;
            }
        }

        private static void ClickTimer(object sender, EventArgs e)
        {
            HideImages();

            allowClick = true;

            clickTimer.Stop();
        }

        private static void Click_Imagen(object sender, EventArgs e)
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
            System.Windows.Forms.MessageBox.Show("You win now try again");
            RestImages();
        }

        public static void Run()
        {
            allowClick = true;
            setRandomImages();
            HideImages();
            Time();
            clickTimer.Interval = 1000;
            clickTimer.Tick += ClickTimer;
        }
    }

}
