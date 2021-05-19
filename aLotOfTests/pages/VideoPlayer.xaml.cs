using System;
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
using System.Windows.Threading;

namespace aLotOfTests.pages
{
    /// <summary>
    /// Логика взаимодействия для VideoPlayer.xaml
    /// </summary>
    public partial class VideoPlayer : Page
    {
        DispatcherTimer timer;
        bool flagMouseDown;
        public VideoPlayer()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (mainMedia.Source != null)
            {
                if (mainMedia.NaturalDuration.HasTimeSpan)
                    lblStatus.Text = String.Format("{0} / {1}", mainMedia.Position.ToString(@"mm\:ss"), mainMedia.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            }
            else
                lblStatus.Text = "Файл не выбран...";
            MediaSlider.Value = mainMedia.Position.TotalSeconds;
        }

        private void Page_Drop(object sender, DragEventArgs e)
        {
            string filename = (string)((DataObject)e.Data).GetFileDropList()[0];
            mainMedia.Source = new Uri(filename);
            mainMedia.LoadedBehavior = MediaState.Manual;
            mainMedia.UnloadedBehavior = MediaState.Manual;
            VolumeSlider.Value = 100;
            mainMedia.Volume = (double)(VolumeSlider.Value);
            mainMedia.Play();
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

        private void MediaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoTimeProgress.Value = mainMedia.Position.TotalSeconds;


            if (flagMouseDown == true)
            {
                if(mainMedia.Position != TimeSpan.FromSeconds(MediaSlider.Value))
                {
                    mainMedia.Pause();
                     mainMedia.Position = TimeSpan.FromSeconds(MediaSlider.Value);
                    if(mainMedia.Position == TimeSpan.FromSeconds(MediaSlider.Value)) 
                    {
                        mainMedia.Play(); 
                    }
                }
            }
           
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mainMedia.Volume = (double)VolumeSlider.Value;
        }

        private void mainMedia_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = mainMedia.NaturalDuration.TimeSpan;
            VideoTimeProgress.Maximum = ts.TotalSeconds;
            MediaSlider.Maximum = ts.TotalSeconds;
            timer.Start();
        }

        private void MediaSlider_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            flagMouseDown = true;
        }

        private void MediaSlider_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            flagMouseDown = false;
        }
    }
}
