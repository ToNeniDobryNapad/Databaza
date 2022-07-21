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

namespace B_TEST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            KontaktRepository kontaktRepository = new KontaktRepository();
            var All = kontaktRepository.GetAll();
            Pocet.Text = All.Count.ToString();
            Vypis.ItemsSource = All;

        }

        private void txtMeno_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            KontaktRepository kontaktRepository = new KontaktRepository();
            kontaktRepository.Insert(new Kontakt { Meno = txtMeno.Text, Priezvisko = txtPriezvisko.Text });
            Pocet.Text = kontaktRepository.GetAll().Count.ToString();

            var All = kontaktRepository.GetAll();
            Pocet.Text = All.Count.ToString();
            Vypis.ItemsSource = All;
        }
    }
}
