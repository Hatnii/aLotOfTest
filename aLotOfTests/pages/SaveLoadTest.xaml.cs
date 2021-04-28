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
    /// Логика взаимодействия для SaveLoadTest.xaml
    /// </summary>
    public partial class SaveLoadTest : Page
    {
        public SaveLoadTest()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Firstname = FirstName.Text;
            Properties.Settings.Default.Surname = Surname.Text;
            Properties.Settings.Default.Save();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {

            FirstName.Text = Properties.Settings.Default.Firstname;
            Surname.Text = Properties.Settings.Default.Surname;
        }
    }
}
