using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
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
    /// Логика взаимодействия для sprav.xaml
    /// </summary>
    public partial class sprav : Page
    {
        public sprav()
        {
            InitializeComponent();
            spravLV.ItemsSource = Class1.context.Spravochnaya.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            nav.MainPage.Navigate(new addSprav(null));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delClients = spravLV.SelectedItems.Cast<Spravochnaya>().ToList();
            foreach (var delClient in delClients)
                if (Class1.context.Ychetnai.Any(x => x.Kod_Predpriytie == delClient.Kod_Predpriytie))
                {
                    MessageBox.Show("Данные используются в таблице продаж", "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            if (MessageBox.Show($"Удалить {delClients.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Class1.context.Spravochnaya.RemoveRange(delClients);
            try
            {
                Class1.context.SaveChanges();
                spravLV.ItemsSource = Class1.context.Spravochnaya.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "оШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            nav.MainPage.GoBack();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            spravLV.ItemsSource = Class1.context.Spravochnaya.ToList();
        }
    }
}
