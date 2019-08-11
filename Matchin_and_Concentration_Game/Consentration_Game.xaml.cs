using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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
using System.Numerics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Matchin_Game
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public DispatcherTimer timer = new DispatcherTimer();



        private List<Image> images = new List<Image>();

        public BlankPage1()
        {
            this.InitializeComponent();
           
            //RotateShape();
        }

        public void FillGrid()
        {
            int j = 1;
            for (int i = 0; i < 25; i++)
            {
                Image myImage = new Image();
                BitmapImage bi = new BitmapImage();
                myImage.Width = bi.DecodePixelWidth = 20;
                bi.UriSource = new Uri(myImage.BaseUri, ("Concentration/ShapeAsset " + j + ".png"));
                myImage.Source = bi;
                images.Add(myImage);
                j++;
            }

        }

        public void TimerControl(object sender, TappedRoutedEventArgs e)
        {

            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();

        }


        public int time = 60;
        private void Timer_Tick(object sender, object e)
        {
            
            Countdown.Text = $"Time:{time}";

            if (time > 0)
            {
                time--;
            }
            else
            {
                Countdown.Text = "Out of Time";
                GameOver();
                timer.Stop();
            }
        }

        public void ShuffleShapes()
        {

        }

        public void ShapeMovement()
        {

        }

        public RotateTransform rotation = new RotateTransform();
        public void RotateShape(object sender, RightTappedRoutedEventArgs e)
        {
            Image rotateImage = sender as Image;
            
            rotateImage.RenderTransform = rotation;

            rotation.CenterX = TestRotateShape.Width / 2;
            rotation.CenterY = TestRotateShape.Height / 2;
            if (rotation.Angle == 0)
            {
                rotation.Angle = 90;
            }
            else if (rotation.Angle == 90)
            {
                rotation.Angle = 180;
            }
            else if (rotation.Angle == 180)
            {
                rotation.Angle = 270;
            }
            else if (rotation.Angle == 270)
            {
                rotation.Angle = 0;
            }
        }

        public void ValidateShape()
        {

        }

        public void GameOver()
        {
            ConcentrationGrid.Children.Clear();
            TextBlock gameOver = new TextBlock();
            ConcentrationGrid.Children.Add(gameOver);
            gameOver.Text = "Game over";


        }

        private void TimerStart_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

    }
}
