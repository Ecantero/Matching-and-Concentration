using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MatchingGame
{
    /// <summary>
    /// Interaction logic for HowManyPlayers.xaml
    /// </summary>
    public partial class HowManyPlayers : Window
    {
        private Player currentPlayer;
        private ArrayList players = new ArrayList();
        private int count = 0;
        public HowManyPlayers()
        {
            InitializeComponent();
        }
        
        public void SetCurP(Player p)
        {
            players.Add(p);
        }

        private void SubmitNumberOfPlayers_Click(object sender, RoutedEventArgs e)
        {
            int number;
            var input = numberOfPlayers.Text;
            number = int.Parse(input);
            PlayerCreation player2 = new PlayerCreation();
            if (number > 2)
            {
                for (var i = 0; i < number; i++)
                {
                    player2.Show();

                }
            }
            else
            {
                player2.Show();
            }
        }
    }
}
