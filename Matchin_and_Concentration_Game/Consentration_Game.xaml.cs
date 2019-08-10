using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Timers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Matchin_Game
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public int time = 60;

        public BlankPage1()
        {
            this.InitializeComponent();
        }

        public void TimerControl(object sender, RoutedEventArgs e)
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += Timer_Tick;
            timer.Start();

            //Timer timer = new Timer() { Interval = 500, Enabled = true };

            //timer.Tick += new EventHandler(Timer_Tick);
            //timer.Start();

            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = new TimeSpan(0, 0, 0, 1);
            //timer.Tick += Timer_Tick;
            //timer.Start();
        }

        
        private void Timer_Tick(object sender, EventArgs e)
        {
            //Use correct TextBlock name when TextBlock is fully implemented
            Countdown.Text = $"{time} seconds";

            if (time > 0)
            {
                time--;
            }
            else
            {
                Countdown.Text = "Out of Time";
            }
        }

        public void ShuffleShapes()
        {

        }

        public void ShapeMovement()
        {

        }

        public void ValidateShape()
        {

        }

        public void GameOver(int time)
        {
            if (time == 0)
            {
                ConcentrationGrid.Children.Clear();
                Gameover.Visibility = Visibility.Visible;
                Gameover.Text = "Game over, You did not complete the board with in the time limit";
            }

        }


    }
}
