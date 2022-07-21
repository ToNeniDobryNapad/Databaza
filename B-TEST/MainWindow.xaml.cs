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
        KontaktRepository kontaktRepository;

        public MainWindow()
        {
            InitializeComponent();
            kontaktRepository = new KontaktRepository();
            PocetZoznam();
        }

        private void txtMeno_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {

            kontaktRepository.Insert(new Kontakt { Meno = txtMeno.Text, Priezvisko = txtPriezvisko.Text });

            PocetZoznam();
        }

        private void PocetZoznam()
        {
            var All = kontaktRepository.GetAll();
            Pocet.Text = All.Count.ToString();
            Vypis.ItemsSource = All;
        }
    }
}
