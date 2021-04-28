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

namespace aLotOfTests.pages
{
    /// <summary>
    /// Логика взаимодействия для FileDialog.xaml
    /// </summary>
    public partial class FileDialog : Page
    {
        public FileDialog()
        {
            InitializeComponent();
        }

        

        private void AnotherFileDialog_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                FolderPath.Text = fbd.SelectedPath;
                string bPath = $@"{fbd.SelectedPath}\okay.txt";
                File.Create(bPath).Dispose();
            }
        }

        private void FirstFileDialog_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                FilePath.Text = ofd.FileName;


                //DirectoryBox.Text = ofd.FileName;
                //TxTbox.Text = ofd.SafeFileName;
                //int removeTTF = TxTbox.Text.Length - 4; //Убирает последние 4 символа в строке (.ttf)
                //TxTbox.Text = TxTbox.Text.Remove(removeTTF);

            }
        }

        private void SaveSmth_Click(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory(@"C:\Users\Public\Documents\Hatnii");
            File.Create(@"C:\Users\Public\Documents\Hatnii\HatniiWatchingList.txt");
        }
    }
}
