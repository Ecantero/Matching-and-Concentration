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
        public Concentration_Game()
        {
            InitializeComponent();
        }
        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
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

        public void TimerControl(object sender, RoutedEventArgs e)
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
            Player newPlayer = new Player("test", timeRemaining);
            FillLeaderBoard(difficulty, newPlayer);
            SaveLeaderBoard(difficulty);
            //showLeaderBoard();
        }

        public void FillLeaderBoard(string fileName, Player player)
        {
            leaderboard = new Leaderboard();

            BinaryFormatter binForm = new BinaryFormatter();
            FileMode mode;
            FileAccess access;
            if (File.Exists(fileName))
            {
                mode = FileMode.Open;
                access = FileAccess.Read;
            }
            else
            {
                mode = FileMode.Create;
                access = FileAccess.Write;
            }
            using (FileStream stream = new FileStream(fileName, mode, access, FileShare.None))

                if (stream.Length != 0)
                {
                    leaderboard = (Leaderboard)binForm.Deserialize(stream);
                }

            leaderboard.AddLeaderboardPlayer(player);
        }


        public void SaveLeaderBoard(string fileName)
        {

            BinaryFormatter binForm = new BinaryFormatter();
            FileMode mode;
            if (File.Exists(fileName))
            {
                mode = FileMode.Open;

            }
            else
            {
                mode = FileMode.Create;

            }
            using (FileStream stream = new FileStream(fileName, mode, FileAccess.Write, FileShare.None))

                if (stream.Length != 0)
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

            //first.Text = leaderboard.LeaderboardMembers[0].ToString();
            //second.Text = leaderboard.LeaderboardMembers[1].ToString();
            //third.Text = leaderboard.LeaderboardMembers[2].ToString();
            //fourth.Text = leaderboard.LeaderboardMembers[3].ToString();
            //fifth.Text = leaderboard.LeaderboardMembers[4].ToString();
            //sixth.Text = leaderboard.LeaderboardMembers[5].ToString();
            //seventh.Text = leaderboard.LeaderboardMembers[6].ToString();
            //eighth.Text = leaderboard.LeaderboardMembers[7].ToString();
            //nineth.Text = leaderboard.LeaderboardMembers[8].ToString();
            //tenth.Text = leaderboard.LeaderboardMembers[9].ToString();
        }






        private void ConcentrationGrid_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void Image_MouseMove(object sender, MouseEventArgs e)

        {
            Image image = sender as Image;
            if (image != null && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(image, image.Source, DragDropEffects.Move);
            }
        }

        private int num = 25;
        private void Shape_Drop(object sender, DragEventArgs e)
        {
            Image image = sender as Image;
            Image image1 = e.OriginalSource as Image;

            if (image.Source == image1.Source)
            {
                image1.Visibility = Visibility.Collapsed;
                num--;
            }
            winCondition();
        }


        private void Testleaderboard_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            Victory("test");
            //leaderboard.AddLeaderboardPlayer(new Player("test", 45));
            //Countdown.Text = leaderboard.LeaderboardMembers[0].ToString();

            
        }

        private void winCondition()
        {
            if (num == 0)
            {
                GameOver();
                timer.Stop();
            }

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
                if (LeaderboardMembers[i] == null || player.Time > LeaderboardMembers[i].Time)
                {
                    if (LeaderboardIsFull())
                    {
                        LeaderboardMembers[9] = player;
                        break;
                    }
                    else
                    {
                        LeaderboardMembers[9] = player;
                        break;
                    }

                }
            }

            Array.Sort(LeaderboardMembers);
            Array.Reverse(LeaderboardMembers);
        }

        public bool LeaderboardIsFull()
        {

            foreach (Player dude in LeaderboardMembers)
            {
                if (dude == null)
                {
                    return false;
                }

            }
            return true;
        }

    }


    public static class CompareImages
    {
        public static bool IsEqual(this BitmapImage image1, BitmapImage image2)
        {
            if (image1 == null || image2 == null)
            {
                return false;
            }
            return image1.ToBytes().SequenceEqual(image2.ToBytes());
        }

        public static byte[] ToBytes(this BitmapImage image)
        {
            byte[] data = new byte[] { };
            if (image != null)
            {
                try
                {
                    BmpBitmapEncoder bmp = new BmpBitmapEncoder();
                    bmp.Frames.Add(BitmapFrame.Create(image));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bmp.Save(ms);
                        data = ms.ToArray();
                    }
                    return data;
                }
                catch (Exception)
                {
                }
            }
            return data;
        }
    }
}

