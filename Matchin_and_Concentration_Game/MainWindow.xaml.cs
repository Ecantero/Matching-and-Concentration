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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsFormsApp1;

namespace MatchingGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
    }
}