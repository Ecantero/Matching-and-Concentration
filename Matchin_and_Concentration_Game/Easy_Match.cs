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
        bool allowClick = false;
        PictureBox firtGuess;
        Random rng = new Random();
        Timer clickTimer = new Timer();
        int time = 60;
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
                    Matching_Game.Properties.Resources.AD,
                    Matching_Game.Properties.Resources.KH,
                    Matching_Game.Properties.Resources._3S,
                    Matching_Game.Properties.Resources._5C,
                    Matching_Game.Properties.Resources._6D,
                    Matching_Game.Properties.Resources._7H,
                    Matching_Game.Properties.Resources._9S
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

                var ssTime = TimeSpan.FromSeconds(time);
                //lbltime.text = "00: " + time.tostring();
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
            time = 60;
            timer.Start();
        }

        private void HideImages()
        {
            foreach (var pic in pictureBox)
            {
                pic.Image = Matching_Game.Properties.Resources.gray_back;
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
