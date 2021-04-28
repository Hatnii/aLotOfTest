using Microsoft.Win32;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aLotOfTests.pages
{
    /// <summary>
    /// Логика взаимодействия для ArrayTest.xaml
    /// </summary>
    public partial class ArrayTest : Page
    {
        public ArrayTest()
        {
            InitializeComponent();
        }


        int rowCount = 0;
        int blyat = 0;
        List<string> series = new List<string> { "Прекол" };
        

        private void GGbutt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                {

                    while ((sr.ReadLine()) != null) //читаем по одной линии(строке) пока не вычитаем все из потока (пока не достигнем конца файла)
                    {
                        rowCount++;
                    }
                    MessageBox.Show("Line counts:" + rowCount.ToString());
                }
                
                StreamReader gsr = new StreamReader(ofd.FileName);
                while (!gsr.EndOfStream)
                {

                    
                    for (int i = 0; i != rowCount; i++)
                    {
                        string line = gsr.ReadLine(); // читаем строку   
                        series.Add(line);
                        line = ""; // обнуляем переменную 
                    }

                }
            }
            else MessageBox.Show("Файл не выбран");        
           
        }
       

        private void BGbutt_Click(object sender, RoutedEventArgs e)
        {
            
            Random rnd = new Random();
            blyat = rnd.Next(0, rowCount);
            RandomText.Text = "Данные в файле:\nЛогин: " + series[blyat];
        }

        private void gButt_Click(object sender, RoutedEventArgs e)
        {
            series.Remove("Прекол");
            rowCount = rowCount - 1;
        }
    }
}

