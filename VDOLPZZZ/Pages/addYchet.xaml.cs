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
    /// Логика взаимодействия для addYchet.xaml
    /// </summary>
    public partial class addYchet : Page
    {
        Ychetnai ytt;
        bool checknew;
        public addYchet(Ychetnai d)

        {
            InitializeComponent();
            if (d == null)
            {
                d = new Ychetnai();
                checknew = true;
            }
            else
                checknew = false;

            DataContext = ytt = d;

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checknew)
            {
                Class1.context.Ychetnai.Add(ytt);
            }
            try
            {
                Class1.context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            nav.MainPage.GoBack();
        }
        public static bool CheckAccounting(Ychetnai inf)
        {
            if (string.IsNullOrEmpty(inf.Naimenovanit_Prodykcie) || !inf.Naimenovanit_Prodykcie.Replace(" ", "").All(char.IsLetter))
                return false;
            if (inf.Kod_Predpriytie < 0)
                return false;
            if (inf.Cena < 0)
                return false;
            if (inf.Kolichestvo < 0)
                return false;
            return true;
        }




        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            nav.MainPage.GoBack();
        }
    }
}
