using System;
using System.Collections;
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
    public partial class Easy_Match : Form
    {
        Random rng = new Random();
        Timer startTime = new Timer();
        int time = 2 * 60;
        Timer timer = new Timer { Interval = 1000 };
        bool canClick = false;
        PictureBox firtmagen;
        int score = 0;
        private static int count = 0;
        /*array of players*/
        public static Player[] playerz = new Player[3];
        /*current player*/
        private Player currentPlayer;

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
                    Properties.Resources.AD,
                    Properties.Resources.KH,
                    Properties.Resources._3S,
                    Properties.Resources._5C,
                    Properties.Resources._6D,
                    Properties.Resources._7H,
                    Properties.Resources._9S
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
                    DialogResult tm = MessageBox.Show("Bad news you don't have more time!!! Dou you want to try again", "Time", MessageBoxButtons.YesNo);
                    if (tm == DialogResult.Yes)
                    {
                        RestImages();
                    }
                    else if (tm == DialogResult.No)
                    {
                        timer.Stop();
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
            time = 2 * 60;
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


            /*current player label*/
            

                /*after this then the next current player is turn is taken*/
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
                currentPlayer.score++;
                Console.WriteLine(currentPlayer.Name);
                pic.Visible = firtmagen.Visible = false;
                {
                    firtmagen = pic;
                }
                
                count++;
                HideImages();
                /*guessed incorrectly-->change player aqui*/
                /*highlight currentplayers name on label*/
            }
            else
            {
                count++;
                canClick = false;
                startTime.Start();
            }

            currentPlayer = playerz[(count) % playerz.Length];
            firtmagen = null;
            Console.WriteLine(currentPlayer.Name);
            if (pictureBox.Any(i => i.Visible))
            {
                return;
            }
            DialogResult newGame = MessageBox.Show("!Gongratulation you win!!! Do you want to play a new game?", "New Game", MessageBoxButtons.YesNo);
            if (newGame == DialogResult.Yes)
            {
                RestImages();
            }
            else if (newGame == DialogResult.No)
            {
                timer.Stop();
                Application.Exit();
            }
        }

        private void Easy_Match_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exit = MessageBox.Show("Are you sure that you want to live of the game?", "Exit", MessageBoxButtons.YesNo);
            if (exit == DialogResult.Yes)
            {
                timer.Stop();
                Application.Exit();
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
            else
            {
                timer.Stop();
            }
        }
        private void Button4_Click(object sender, EventArgs e)
        {           
            Label label = new Label();

    /*      int count = this.Controls.OfType<Label>().ToList().Count;       */
            Player p = new Player();
            p.Name = textBox1.Text;
            playerz[count] = p;
          currentPlayer = playerz[(count) % playerz.Length];     

            for (var i = 0; i < playerz.Length; i++)
            {
                label.Name = "Player " + (count + 1);
                label.Top = count * 23;
                label.Left = 30;
                label.Text = textBox1.Text + " score: ";
                label.AutoSize = true;               
            }
            
            this.Controls.Add(label);
            textBox1.Clear();
            count++;
            Console.WriteLine(p.Name);
            
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;

            canClick = true;
            setRandomImages();
            HideImages();
            Time();
            startTime.Interval = 1000;
            startTime.Tick += StartTime;
            button3.Enabled = false;
        }
    }
}
