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
    /// Логика взаимодействия для Poisk.xaml
    /// </summary>
    public partial class Poisk : Page
    {
        public Poisk()
        {
            InitializeComponent();
            var cmFil = Class1.context.Spravochnaya.OrderBy(x => x.Naimenovani).ToList();
            Update();
        }
        void Update()
        {
            var i = Class1.context.Spravochnaya.ToList();
            if (!string.IsNullOrEmpty(MonTbx.Text))
            {
                i = i.Where(x => x.Naimenovani.ToString().ToLower().Contains(MonTbx.Text.ToLower())).ToList();
            }
            SLV.ItemsSource = i;

          
        }

        private void MonTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            nav.MainPage.GoBack();
        }
    }
}
