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
    /// Логика взаимодействия для ComboBoxTrashStyle.xaml
    /// </summary>
    public partial class ComboBoxTrashStyle : Page
    {
        public ComboBoxTrashStyle()
        {
            InitializeComponent();
            List<string> styles = new List<string> { "light", "dark", "Hatnii" };
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = "light";
        }

        private void ChangeStyle_Click(object sender, RoutedEventArgs e)
        {
            string style = styleBox.SelectedItem as string;
            // определяем путь к файлу ресурсов
            var uri = new Uri("Themes/" + style + ".xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
