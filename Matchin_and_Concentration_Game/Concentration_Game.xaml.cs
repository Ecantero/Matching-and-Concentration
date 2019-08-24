using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
using System.Windows.Threading;

namespace MatchingGame
{
    /// <summary>
    /// Interaction logic for Concentration_Game.xaml
    /// </summary>
    public partial class Concentration_Game : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();
        public int time;
        public Leaderboard leaderboard;
        private List<Image> images = new List<Image>();
        public Concentration_Game()
        {
            InitializeComponent();
        }
        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(MainMenu));
        }

        public void FillGrid()
        {
            //int j = 1;
            //for (int i = 0; i < 25; i++)
            //{
            //    Image myImage = new Image();
            //    BitmapImage bi = new BitmapImage();
            //    myImage.Width = bi.DecodePixelWidth = 20;
            //    bi.UriSource = new Uri(myImage.BaseUri, ("Concentration/shapeAsset " + j + ".png"));
            //    myImage.Source = bi;
            //    images.Add(myImage);
            //    j++;
            //}
            //BitmapImage bitmapImage = new BitmapImage();
            // Call BaseUri on the root Page element and combine it with a relative path
            // to consruct an absolute URI.
            //bitmapImage.UriSource = new Uri(this.BaseUri, "Concentration/shapeAsset 12.png");
            //shape1
            //shape1.Source = new BitmapImage(new Uri(("Concentration/shapeAsset " + 23 + ".png")));
            //shape2.Source = new BitmapImage(new Uri(("Concentration/shapeAsset " + 2 + ".png")));
            //shape3.Source = new BitmapImage(new Uri(("Concentration/shapeAsset " + 3 + ".png")));
        }

        private void Easy_Click(object sender, RoutedEventArgs e)
        {
            time = 60;
            Countdown.Text = $"Time:{time}";
            Easy.Visibility = Visibility.Collapsed;
            Medium.Visibility = Visibility.Collapsed;
            Hard.Visibility = Visibility.Collapsed;
            MainMenu.Visibility = Visibility.Collapsed;
            ConcentrationGrid.Visibility = Visibility.Visible;
        }

        private void Medium_Click(object sender, RoutedEventArgs e)
        {
            time = 40;
            Countdown.Text = $"Time:{time}";
            Easy.Visibility = Visibility.Collapsed;
            Medium.Visibility = Visibility.Collapsed;
            Hard.Visibility = Visibility.Collapsed;
            MainMenu.Visibility = Visibility.Collapsed;
            ConcentrationGrid.Visibility = Visibility.Visible;
        }

        private void Hard_Click(object sender, RoutedEventArgs e)
        {
            time = 20;
            Countdown.Text = $"Time:{time}";
            Easy.Visibility = Visibility.Collapsed;
            Medium.Visibility = Visibility.Collapsed;
            Hard.Visibility = Visibility.Collapsed;
            MainMenu.Visibility = Visibility.Collapsed;
            ConcentrationGrid.Visibility = Visibility.Visible;
        }

        public void TimerControl(object sender, MouseButtonEventArgs e)
        {

            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();

        }


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
        private void Image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image rotateImage = sender as Image;

            rotateImage.RenderTransform = rotation;

            rotation.CenterX = rotateImage.Width / 2;
            rotation.CenterY = rotateImage.Height / 2;
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
            showLeaderBoard();

        }

        public void Victory(string difficulty)
        {
            PlayerName.Visibility = Visibility.Visible;
            string playerName = PlayerName.Text;
            int timeRemaining = time;
            FillLeaderBoard(difficulty);
        }

        public void FillLeaderBoard(string fileName)
        {
            leaderboard = new Leaderboard();

            BinaryFormatter binForm = new BinaryFormatter();
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);

            if (binForm.Deserialize(stream) != null)
            {
                leaderboard = (Leaderboard)binForm.Deserialize(stream);
            }
        }


        public void SaveLeaderBoard(string fileName)
        {

            BinaryFormatter binForm = new BinaryFormatter();
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);

            if (binForm.Deserialize(stream) != null)
            {
                binForm.Serialize(stream, leaderboard);
            }
        }

        private void ConcentrationGrid_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
        }

        private void ConcentrationGrid_Drop(object sender, DragEventArgs e)
        {
            Countdown.Text = "hello drop";

        }

        public void showLeaderBoard()
        {
            ConcentrationGrid.Visibility = Visibility.Collapsed;
            LeaderBoardGrid.Visibility = Visibility.Visible;

            first.Text = leaderboard.LeaderboardMembers[0].ToString();
            second.Text = leaderboard.LeaderboardMembers[1].ToString();
            third.Text = leaderboard.LeaderboardMembers[2].ToString();
            fourth.Text = leaderboard.LeaderboardMembers[3].ToString();
            fifth.Text = leaderboard.LeaderboardMembers[4].ToString();
            sixth.Text = leaderboard.LeaderboardMembers[5].ToString();
            seventh.Text = leaderboard.LeaderboardMembers[6].ToString();
            eighth.Text = leaderboard.LeaderboardMembers[7].ToString();
            nineth.Text = leaderboard.LeaderboardMembers[8].ToString();
            tenth.Text = leaderboard.LeaderboardMembers[9].ToString();
        }

        



        private void ConcentrationGrid_DragEnter(object sender, DragEventArgs e)
        {

        }
        

    }


    public class Player
    {
        public String Name { get; set; }
        public int Time { get; set; }
        public int score { get; internal set; }

        public Player(string name, int time)
        {
            Name = name;
            Time = time;
        }

        public Player()
        {
        }

        public override string ToString()
        {
            return $"{Name} : {Time}";
        }
    }

    [Serializable]
    public class Leaderboard
    {

        public Player[] LeaderboardMembers { get; set; } = new Player[10];
        //public Player[] LeaderboardMembers = new Player[10];

        public void AddLeaderboardPlayer(Player player)
        {
            for (int i = 0; i < LeaderboardMembers.Length; i++)
            {
                if (player.Time > LeaderboardMembers[i].Time || LeaderboardMembers[i] == null)
                {
                    LeaderboardMembers.Append(player);

                }
            }

            Array.Sort(LeaderboardMembers);
            Array.Reverse(LeaderboardMembers);
        }

    }



}

