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
    /// Логика взаимодействия для filt.xaml
    /// </summary>
    public partial class filt : Page
    {

        private ObservableCollection<Ychetnai> ych;
        public filt()
        {
            InitializeComponent();
            ych = new ObservableCollection<Ychetnai>(Class1.context.Ychetnai.ToList());
            SLV.ItemsSource = ych;
            var fioList = Class1.context.Ychetnai.OrderBy(x => x.Naimenovanit_Prodykcie).ToList();
            fioList.Insert(0, new Ychetnai { Naimenovanit_Prodykcie = "По умолчанию" });
            FiltTbx.ItemsSource = fioList;
            FiltTbx.DisplayMemberPath = "Naimenovanit_Prodykcie";
            FiltTbx.SelectedValuePath = "Naimenovanit_Prodykcie";
            FiltTbx.SelectedIndex = 0;
            Update();
        }
        void Update()
        {
            var selectedFIO = (FiltTbx.SelectedItem as Ychetnai).Naimenovanit_Prodykcie;
            SLV.ItemsSource = new ObservableCollection<Ychetnai>(ych.Where(x =>
                 string.IsNullOrEmpty(selectedFIO) || x.Naimenovanit_Prodykcie.ToLower().Contains(selectedFIO.ToLower())));
        }
        private void FiltTbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            nav.MainPage.GoBack();
        }
    }
}
