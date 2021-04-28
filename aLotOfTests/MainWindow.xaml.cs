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

namespace aLotOfTests
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RandomTestBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new pages.RandomTest();
        }

        private void SaveLoadTestBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new pages.SaveLoadTest();
        }

        private void ComboBoxTrashBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new pages.ComboBoxTrashStyle();

        }

        private void TimerT_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new pages.Timer();
        }

        private void DialogRequest_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new pages.FileDialog();

        }

        private void RandomGenAnimeList_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new pages.ArrayTest();
        }
    }
}
