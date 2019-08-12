using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace MatchingGame
{
    public partial class Matching_Game : Form
    {
        public Matching_Game()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Easy_Match easy_Match = new Easy_Match();
            easy_Match.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Medium_Match medium_Match = new Medium_Match();
            medium_Match.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Hard_Match hard_Match = new Hard_Match();
            hard_Match.Show();
        }
    }
}
