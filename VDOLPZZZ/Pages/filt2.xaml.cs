using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для filt2.xaml
    /// </summary>
    public partial class filt2 : Page
    {
        private ObservableCollection<Ychetnai> ych;
        public filt2()
        {
            InitializeComponent();
            ych = new ObservableCollection<Ychetnai>(Class1.context.Ychetnai.ToList());
            SLV.ItemsSource = ych;
            var fioList = Class1.context.Ychetnai.OrderBy(x => x.Kolichestvo).ToList();
            fioList.Insert(0, new Ychetnai { Kolichestvo = 0 });
            FiltTbx.ItemsSource = fioList;
            FiltTbx.DisplayMemberPath = "Kolichestvo";
            FiltTbx.SelectedValuePath = "Kolichestvo";
            FiltTbx.SelectedIndex = 0;
            Update();
        }
        void Update()
        {
            var selectedKolichestvo = (FiltTbx.SelectedItem as Ychetnai)?.Kolichestvo;

            SLV.ItemsSource = new ObservableCollection<Ychetnai>(ych.Where(x =>
                selectedKolichestvo == null || x.Kolichestvo == selectedKolichestvo));
        }
        private void FiltTbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            nav.MainPage.GoBack();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SLV.ItemsSource = Class1.context.Ychetnai.ToList();
        }
    }
}
