﻿using System;
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
    public partial class Hard_Match : Form
    {
       
        Random rng = new Random();
        Timer startTime = new Timer();
        int time = 9 * 60;
        Timer timer = new Timer { Interval = 1000 };
        bool canClick = false;
        PictureBox firtmagen;
        int score = 0;
        int count = 0;
        Label label = new Label();

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
                    DialogResult tm = MessageBox.Show("Bad news you don't have more time!!! Dou you want to try again", "Time", MessageBoxButtons.YesNo);
                    if (tm == DialogResult.Yes)
                    {
                        RestImages();
                    }
                    else if (tm == DialogResult.No)
                    {
                        Application.Exit();
                        timer.Stop();
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
            time = 9 * 60;
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
                score++;
                label1.Text = label.Text + " score: " + score.ToString();


                pic.Visible = firtmagen.Visible = false;
                {
                    firtmagen = pic;
                }

                count++;
                HideImages();
            }
            else
            {
                count++;
                canClick = false;
                startTime.Start();
            }

            firtmagen = null;
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
                Application.Exit();
                timer.Stop();
            }
        }

        private void Hard_Match_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Button4_Click(object sender, EventArgs e)
        {

            label.Name = "Player " + (count + 1);
            label.Top = count * 23;
            label.Left = 30;
            label.Text = textBox1.Text;
            label.AutoSize = true;

            textBox1.Clear();
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
