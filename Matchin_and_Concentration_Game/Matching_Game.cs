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
    public partial class Matching_Game : Form
    {
        public Matching_Game()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Easy_Match em = new Easy_Match();
            em.Show();            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Medium_Match mm = new Medium_Match();
            mm.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Hard_Match hm = new Hard_Match();
            hm.Show();
        }
    }
}
