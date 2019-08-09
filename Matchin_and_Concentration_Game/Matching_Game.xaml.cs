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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Matchin_Game
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        bool allowClick = false;
        ImageSource firtGuess;
        Random rng = new Random();
        private static int time = 300;
        private static int time2 = 360;
        private static int time3 = 600;
        private static Timer timer = new Timer { Interval = 1000 }; 


        public MainPage()
        {
            this.InitializeComponent();

            Image img = new Image();
            img.Source = new BitmapImage(new Uri("http://www.contoso.com/images/logo.png"));
        }


        private static IEnumerable<Image> images
        {


            get
            {
                return new Image[]
                {
                    
                };
            }
        }

        private void Easy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Medium_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Hard_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Easy_Game()
        {
            //Time_Easy();
            DispatcherTimer timer = new DispatcherTimer();

        }

        private void Medium_Game()
        {
            //Time_Medum();
        }

        private void Hard_Game()
        {
            //Time_Hard();
        }

    //    private static void time_easy()
    //    {
    //        timer.start();
    //        timer.tick += delegate
    //        {
    //            time--;
    //            if (time < 0)
    //            {
    //                timer.stop();
    //                messagebox.show("out of time");
    //            }

    //            var sstime = timespan.fromseconds(time);
    //            lbltime.text = "00: " + time.tostring();
    //        };
    //    }

    //    private static void time_medum()
    //    {
    //        timer.start();
    //        timer.tick += delegate
    //        {
    //            time2--;
    //            if (time2 < 0)
    //            {
    //                timer.stop();
    //                messagebox.show("out of time");
    //            }

    //            var sstime = timespan.fromseconds(time2);
    //            lbltime.text = "00: " + time2.tostring();
    //        };
    //    }

    //    private static void time_hard()
    //    {
    //        timer.start();
    //        timer.tick += delegate
    //        {
    //            time3--;
    //            if (time3 < 0)
    //            {
    //                timer.stop();
    //                messagebox.show("out of time");
    //            }

    //            var sstime = timespan.fromseconds(time3);
    //            lbltime.text = "00: " + time3.tostring();
    //        };
    //    }
    //}
}
