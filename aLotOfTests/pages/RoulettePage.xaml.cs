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
    /// Логика взаимодействия для RoulettePage.xaml
    /// </summary>
    public partial class RoulettePage : Page
    {
        public RoulettePage()
        {
            InitializeComponent();
            LoadData();
        }

        List<KeyValuePair<string, int>> series = new List<KeyValuePair<string, int>>();

        private void LoadData()
        {
            int rowCount = 0;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                {

                    while (!sr.EndOfStream)
                    {
                        rowCount++;
                        series.Add(new KeyValuePair<string, int>(sr.ReadLine(), 1));
                    }
                    pieChart.DataContext = series;
                }

            }
            else System.Windows.MessageBox.Show("Файл не выбран", "*наблюдаю с грозной любовью*");
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
           
        }
           
        }
    }

