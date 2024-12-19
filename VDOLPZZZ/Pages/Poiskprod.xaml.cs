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
    /// Логика взаимодействия для Poiskprod.xaml
    /// </summary>
    public partial class Poiskprod : Page
    {
        public Poiskprod()
        {
            InitializeComponent();
            SLV.ItemsSource = Class1.context.Ychetnai.ToList();
        }

        void Update()
        {
            var ac = Class1.context.Ychetnai.ToList();

            if (!string.IsNullOrEmpty(FiOTbx.Text))
            {
                ac = ac.Where(x => x.Naimenovanit_Prodykcie.Contains(FiOTbx.Text)).ToList();
            }
            SLV.ItemsSource = ac;
        }

        private void FiOTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            nav.MainPage.GoBack();
        }
    }
}
