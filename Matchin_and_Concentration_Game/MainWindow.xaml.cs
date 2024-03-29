﻿using System;
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

        private void Concetration_Click(object sender, RoutedEventArgs e)
        {
            Concentration_Game concentration_Game = new Concentration_Game();
            concentration_Game.Show();
            Close();
        }

        private void MatchingGame_Click(object sender, RoutedEventArgs e)
        {
            MatchingGame_Difficulty mgd = new MatchingGame_Difficulty();
            mgd.Show();
            Close();
        }
    }
}