using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Matchin_Game.Difficulty_classes
{
    class Medium_Class
    {
        private static bool allowClick = false;
        private static PictureBox firtGuess;
        private static Random rng = new Random();
        private static Timer clickTimer = new Timer();
        private static int time = 360;
        private static DispatcherTimer timer = new DispatcherTimer();

        private static IEnumerable<Image> images
        {

            get
            {
                return new Image[]
                {

                };
            }
        }

        private static void time_medum()
        {
            timer.Start();
            timer.Tick += delegate
            {
                time--;
                if (time < 0)
                {
                    timer.Stop();
                }
            };
        }
    }
}
