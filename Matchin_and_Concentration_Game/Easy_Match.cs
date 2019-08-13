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
    public partial class Easy_Match : Form
    {

        bool canClick = false;
        PictureBox firtImagen;
        Random rng = new Random();
        Timer clickTime = new Timer();
        int time = 130;
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
                    MatchingGame.Properties.Resources.AD,
                    MatchingGame.Properties.Resources.KH,
                    MatchingGame.Properties.Resources._3S,
                    MatchingGame.Properties.Resources._5C,
                    MatchingGame.Properties.Resources._6D,
                    MatchingGame.Properties.Resources._7H,
                    MatchingGame.Properties.Resources._9S
                 };
            }
        }
        public Easy_Match()
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

                var ssTime = TimeSpan.FromMinutes(time);
                lbl.Text = " " + time.ToString();
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
            time = 130;
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

            canClick = true;

            clickTime.Stop();
        }

        private void Click_Imagen(object sender, EventArgs e)
        {
            if (!canClick) return;

            var pic = (PictureBox)sender;
            if (firtImagen == null)
            {
                firtImagen = pic;
                pic.Image = (Image)pic.Tag;
                return;
            }
            pic.Image = (Image)pic.Tag;

            if (pic.Image == firtImagen.Image && pic != firtImagen)
            {
                pic.Visible = firtImagen.Visible = false;
                {
                    firtImagen = pic;
                }

                HideImages();
            }
            else
            {
                canClick = false;
                clickTime.Start();
            }

            firtImagen = null;
            if (pictureBox.Any(i => i.Visible)) return;
            MessageBox.Show("You win now try again");
            RestImages();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            canClick = true;
            setRandomImages();
            HideImages();
            Time();
            clickTime.Interval = 1000;
            clickTime.Tick += ClickTimer;
            button1.Enabled = false;
        }
    }
}
