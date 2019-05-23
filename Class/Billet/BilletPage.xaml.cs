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

namespace WpfApp1.Class.Billet
{
    /// <summary>
    /// Logique d'interaction pour BilletPage.xaml
    /// </summary>
    public partial class BilletPage : Page
    {
        ObservableCollection<Billet> ListeBillets;
        private int client;
        private int IdBillet;

        public BilletPage(int _client)
        {
            client = _client;
            InitializeComponent();
            AfficherBillet();
            
        }

        public void AfficherBillet()
        {
            ListeBillets = new ObservableCollection<Billet>();
            ListeBillets = DAL_Billet.SelectBilletsByClient(client);
            this.grid.ItemsSource = ListeBillets;
        }
        

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((grid.SelectedIndex >= 0) && (grid.SelectedIndex <= ListeBillets.Count))
            {
                IdBillet = ListeBillets.ElementAt(grid.SelectedIndex).Id;
            }

        }
        

        private void Supp_billet_click(object sender, RoutedEventArgs e)
        {
            DAL_Billet.SupprimerBillet(IdBillet);
            AfficherBillet();
        }
        
    }
}
