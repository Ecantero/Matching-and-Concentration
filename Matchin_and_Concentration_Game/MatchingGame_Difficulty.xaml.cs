using System;
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
    /// Interaction logic for MatchingGame_Difficulty.xaml
    /// </summary>
    public partial class MatchingGame_Difficulty : Window
    {
        public MatchingGame_Difficulty()
        {
            InitializeComponent();
        }

        private void Easy_Click(object sender, RoutedEventArgs e)
        {
            Easy_Match easy_Match = new Easy_Match();
            easy_Match.Show();
        }

        private void Medium_Click(object sender, RoutedEventArgs e)
        {
            Medium_Match medium_Match = new Medium_Match();
            medium_Match.Show();
        }

        private void Hard_Click(object sender, RoutedEventArgs e)
        {
            Hard_Match hard_Match = new Hard_Match();
            hard_Match.Show();
        }

        private void Extra_Click(object sender, RoutedEventArgs e)
        {
            Extra extra = new Extra();
            extra.Show();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }
    }
}
