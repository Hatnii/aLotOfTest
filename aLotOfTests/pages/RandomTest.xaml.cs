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

namespace aLotOfTests.pages
{
    /// <summary>
    /// Логика взаимодействия для RandomTest.xaml
    /// </summary>
    public partial class RandomTest : Page
    {
        public RandomTest()
        {
            InitializeComponent();
        }

        private void RandomButt_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            RandomText.Text = rnd.Next(0, 10).ToString();


        }

    }
}
