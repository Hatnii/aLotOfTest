using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace aLotOfTests.pages
{
    /// <summary>
    /// Логика взаимодействия для AudioPlayer.xaml
    /// </summary>
    public partial class AudioPlayer : Page
    {
        DispatcherTimer timer;
        bool flagMouseDown;
        public AudioPlayer()
        {
            InitializeComponent();
            LoadAudio();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
            mainMedia.MediaOpened += MainMedia_MediaOpened;


        }

        private void MainMedia_MediaOpened(object sender, EventArgs e)
        {
            TimeSpan ts = mainMedia.NaturalDuration.TimeSpan;
            MediaSlider.Maximum = ts.TotalSeconds;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (mainMedia.Source != null)
            {
                if (mainMedia.NaturalDuration.HasTimeSpan)
                    TxtStatus.Text = String.Format("{0} / {1}", mainMedia.Position.ToString(@"mm\:ss"), mainMedia.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            }
            else
                TxtStatus.Text = "Файл не выбран...";
            MediaSlider.Value = mainMedia.Position.TotalSeconds;
        }

        MediaPlayer mainMedia = new MediaPlayer();
        
        string filename;

        private void LoadAudio()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                SongName.Text = ofd.SafeFileName;
                int removeMP3 = SongName.Text.Length - 4; //Убирает последние 4 символа в строке (.mp3)
                SongName.Text = SongName.Text.Remove(removeMP3);
                filename = ofd.FileName;
                mainMedia.Open(new Uri(filename));
                VolumeSlider.Value = 50;
                mainMedia.Volume = (double)(VolumeSlider.Value);
                mainMedia.Play();
            }
            else System.Windows.MessageBox.Show("Файл не выбран", "наблюдаю");
        }


        private void PlayBtm_Click(object sender, RoutedEventArgs e)
        {
            mainMedia.Play();
        }

        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            mainMedia.Pause();
        }

        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            mainMedia.Stop();
        }

        private void MediaSlider_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            flagMouseDown = true;
            mainMedia.Volume = 0;
        }

        private void MediaSlider_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            flagMouseDown = false;
        }

        private void MediaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            


            if (flagMouseDown == true)
            {
                if (mainMedia.Position != TimeSpan.FromSeconds(MediaSlider.Value))
                {
                    mainMedia.Pause();
                    mainMedia.Volume = 0;
                    mainMedia.Position = TimeSpan.FromSeconds(MediaSlider.Value);
                    if (mainMedia.Position == TimeSpan.FromSeconds(MediaSlider.Value))
                    {
                        mainMedia.Play();
                        mainMedia.Volume = VolumeSlider.Value;
                    }
                }
            }
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mainMedia.Volume = (double)VolumeSlider.Value;
        }
    }
}
