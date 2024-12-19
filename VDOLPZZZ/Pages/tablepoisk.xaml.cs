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
using VDOLPZZZ.AppData;

namespace VDOLPZZZ.Pages
{
    /// <summary>
    /// Логика взаимодействия для tablepoisk.xaml
    /// </summary>
    public partial class tablepoisk : Page
    {
        public tablepoisk()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            nav.MainPage.Navigate(new Poiskprod());
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            nav.MainPage.Navigate(new Poisk());
        }

        private void RefBtn_Click(object sender, RoutedEventArgs e)
        {
            nav.MainPage.GoBack();
        }
    }
}
