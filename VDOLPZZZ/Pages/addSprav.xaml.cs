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
    /// Логика взаимодействия для addSprav.xaml
    /// </summary>
    public partial class addSprav : Page
    {
        Spravochnaya sprav;
        bool checkNew;
        public addSprav(Spravochnaya e)
        {
            InitializeComponent();
            if (e == null)
            {
                e = new Spravochnaya();
                checkNew = true;
            }
            else
                checkNew = false;
            DataContext = sprav = e;
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkNew)
            {
                Class1.context.Spravochnaya.Add(sprav);

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
        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            nav.MainPage.GoBack();
        }

        public static bool CheckSpravochnaya(Spravochnaya spr)
        {
            if (string.IsNullOrEmpty(spr.Naimenovani) || !spr.Naimenovani.Replace(" ", "").All(char.IsLetter))
                return false;
            if (string.IsNullOrEmpty(spr.Adres) || !spr.Adres.Replace(" ", "").All(char.IsLetter))
                return false;
            if (string.IsNullOrEmpty(spr.FIO) || !spr.FIO.Replace(" ", "").All(char.IsLetter))
                return false;
            return true;
        }
    }
}
