using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        public BlankPage1()
        {
            this.InitializeComponent();
        }

        public void TimerControl(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        public int time = 60;
        public void Timer_Tick(object sender, RoutedEventArgs e)
        {
            //Use correct TextBlock name when TextBlock is fully implemented
            Countdown.Text = $"{time} seconds"

            if (time > 0)
            {
                time--;
            }
            else
            {
                CountDown.Text = "Out of Time";
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

        public void GameOver()
        {

        }


    }
}
