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
using System.Windows.Shapes;

namespace MatchingGame
{
    /// <summary>
    /// Interaction logic for PlayerCreation.xaml
    /// </summary>
    public partial class PlayerCreation : Window
    {
        public PlayerCreation()
        {
            InitializeComponent();
        }

        private void SubmitNameOfPlayers_Click(object sender, RoutedEventArgs e)
        {
            String name = Name.Text;
            currentPlayer = new Player(name);
        }
    }
}
