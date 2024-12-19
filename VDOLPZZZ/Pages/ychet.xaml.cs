﻿using System;
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
    /// Логика взаимодействия для ychet.xaml
    /// </summary>
    public partial class ychet : Page
    {
        public ychet()
        {
            InitializeComponent();
            ychetLV.ItemsSource = Class1.context.Ychetnai.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            nav.MainPage.Navigate(new addYchet(null));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delClients = ychetLV.SelectedItems.Cast<Ychetnai>().ToList();
            if (MessageBox.Show($"Удалить {delClients.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Class1.context.Ychetnai.RemoveRange(delClients);
            try
            {
                Class1.context.SaveChanges();
                ychetLV.ItemsSource = Class1.context.Ychetnai.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            nav.MainPage.GoBack();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ychetLV.ItemsSource = Class1.context.Ychetnai.ToList();
        }
    }
}
