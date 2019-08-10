using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

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
                    Matching_Game.Properties.Resources.AC,Matching_Game.Properties.Resources.AD,Matching_Game.Properties.Resources.AH,Matching_Game.Properties.Resources.AS,
                    Matching_Game.Properties.Resources.JC,Matching_Game.Properties.Resources.JD,Matching_Game.Properties.Resources.JH,Matching_Game.Properties.Resources.JS,
                    Matching_Game.Properties.Resources.KC,Matching_Game.Properties.Resources.KD,Matching_Game.Properties.Resources.KH,Matching_Game.Properties.Resources.KS,
                    Matching_Game.Properties.Resources.QC,Matching_Game.Properties.Resources.QD,Matching_Game.Properties.Resources.QH,Matching_Game.Properties.Resources.QS,
                    Matching_Game.Properties.Resources._2C,Matching_Game.Properties.Resources._2D,Matching_Game.Properties.Resources._2H,Matching_Game.Properties.Resources._2S,
                    Matching_Game.Properties.Resources._3C,Matching_Game.Properties.Resources._3D,Matching_Game.Properties.Resources._3H,Matching_Game.Properties.Resources._3S,
                    Matching_Game.Properties.Resources._4C,Matching_Game.Properties.Resources._4D,Matching_Game.Properties.Resources._4H,Matching_Game.Properties.Resources._4S,
                    Matching_Game.Properties.Resources._5C,Matching_Game.Properties.Resources._5D,Matching_Game.Properties.Resources._5H,Matching_Game.Properties.Resources._5S,
                    Matching_Game.Properties.Resources._6C,Matching_Game.Properties.Resources._6D,Matching_Game.Properties.Resources._6H,Matching_Game.Properties.Resources._6S,
                    Matching_Game.Properties.Resources._7C,Matching_Game.Properties.Resources._7D,Matching_Game.Properties.Resources._7H,Matching_Game.Properties.Resources._7S,
                    Matching_Game.Properties.Resources._8C,Matching_Game.Properties.Resources._8D,Matching_Game.Properties.Resources._8H,Matching_Game.Properties.Resources._8S,
                    Matching_Game.Properties.Resources._9C,Matching_Game.Properties.Resources._9D,Matching_Game.Properties.Resources._9H,Matching_Game.Properties.Resources._9S,
                    Matching_Game.Properties.Resources._10C,Matching_Game.Properties.Resources._10D,Matching_Game.Properties.Resources._10H,Matching_Game.Properties.Resources._10S
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
                pic.Image = Matching_Game.Properties.Resources.gray_back;
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
