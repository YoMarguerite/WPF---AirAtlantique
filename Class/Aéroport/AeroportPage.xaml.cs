using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Class.Aeroport;
using WpfApp1.Class.Ville;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Aeroport.xaml
    /// </summary>
    public partial class AeroportPage : Page
    {
        ObservableCollection<Aeroport> ListeAeroports;
        int IdAeroport;

        public AeroportPage()
        {
            InitializeComponent();
            AfficherAeroport();
        }

        public void AfficherAeroport()
        {
            ListeAeroports = new ObservableCollection<Aeroport>();
            ListeAeroports = DAL_Aeroport.SelectAeroports();
            this.grid.ItemsSource = ListeAeroports;
            this.villes.ItemsSource = DAL_Ville.SelectNomVilles();
            this.ville.ItemsSource = DAL_Ville.SelectNomVilles();
            this.ville.SelectedValue = DAL_Ville.SelectNomVilles().First();
        }

        private void Edit(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                DataGridColumn column = e.Column;
                if (column != null)
                {
                    string column_nom = (string)column.Header;
                    TextBox el = e.EditingElement as TextBox;
                    Aeroport aeroport = DAL_Aeroport.GetAeroport(IdAeroport);

                    switch (column_nom)
                    {
                        case "Nom":
                            aeroport.Nom = el.Text;
                            break;

                        case "Ville":
                            ComboBox co = e.EditingElement as ComboBox;
                            aeroport.Ville = (string)co.SelectionBoxItem;
                            break;

                        case "AITA":
                            aeroport.AITA = el.Text;
                            break;

                        default:
                            break;
                    }
                    DAL_Aeroport.ModifierAeroport(aeroport.Id, aeroport.Nom, DAL_Ville.FindByName(aeroport.Ville).Id, aeroport.AITA);
                }
            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((grid.SelectedIndex >=0 ) && (grid.SelectedIndex <=ListeAeroports.Count)){
                IdAeroport = ListeAeroports.ElementAt(grid.SelectedIndex).Id;
            }
            
        }

        private void Nouvel_aeroport_click(object sender, RoutedEventArgs e)
        {
            if(ville.Text != "")
            {
                DAL_Aeroport.AjouterAeroport(Nom.Text, DAL_Ville.FindByName(ville.Text).Id, Aita.Text);
                AfficherAeroport();
            }
            
        }

        private void Supp_aeroport_click(object sender, RoutedEventArgs e)
        {
            DAL_Aeroport.SupprimerAeroport(IdAeroport);
            AfficherAeroport();
        }
    }
}
