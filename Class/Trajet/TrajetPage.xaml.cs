using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Class.Aeroport;

namespace WpfApp1.Class.Trajet
{
    /// <summary>
    /// Logique d'interaction pour TrajetPage.xaml
    /// </summary>
    public partial class TrajetPage : Page
    {

        ObservableCollection<Trajet> ListeTrajets;
        int IdTrajet;

        public TrajetPage()
        {
            InitializeComponent();
            AfficherTrajet();
        }
    
        public void AfficherTrajet()
        {
            ListeTrajets = new ObservableCollection<Trajet>();
            ListeTrajets = DAL_Trajet.SelectTrajets();
            this.grid.ItemsSource = ListeTrajets;
            this.depart.ItemsSource = DAL_Aeroport.SelectNomAeroports();
            this.arrivee.ItemsSource = DAL_Aeroport.SelectNomAeroports();

            this.Codepart.ItemsSource = DAL_Aeroport.SelectNomAeroports();
            this.Codepart.SelectedValue = DAL_Aeroport.SelectNomAeroports().First();

            this.Coarrivee.ItemsSource = DAL_Aeroport.SelectNomAeroports();
            this.Coarrivee.SelectedValue = DAL_Aeroport.SelectNomAeroports().First();
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
                    ComboBox co = e.EditingElement as ComboBox;
                    Trajet trajet = DAL_Trajet.GetTrajet(IdTrajet);

                    switch (column_nom)
                    {
                        case "Durée":
                            trajet.Duree = el.Text;
                            break;

                        case "Référence":
                            trajet.Reference = el.Text;
                            break;

                        case "Distance":
                            trajet.Distance = float.Parse(el.Text);
                            break;

                        case "Départ":
                            trajet.Depart = (string)co.SelectionBoxItem;
                            break;

                        case "Arrivée":
                            trajet.Arrivee = (string)co.SelectionBoxItem;
                            break;

                        default:
                            break;
                    }
                    DAL_Trajet.ModifierTrajet(trajet.Id, trajet.Duree, trajet.Reference, trajet.Distance, DAL_Aeroport.FindByName(trajet.Depart).Id, DAL_Aeroport.FindByName(trajet.Arrivee).Id);
                }
            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((grid.SelectedIndex >= 0) && (grid.SelectedIndex <= ListeTrajets.Count))
            {
                IdTrajet = ListeTrajets.ElementAt(grid.SelectedIndex).Id;
            }

        }

        private void Nouveau_trajet_click(object sender, RoutedEventArgs e)
        {
            //if (ville.Text != "")
            //{
            DAL_Trajet.AjouterTrajet(Duree.Text,Reference.Text, float.Parse(Distance.Text), DAL_Aeroport.FindByName(Codepart.Text).Id, DAL_Aeroport.FindByName(Codepart.Text).Id);
            AfficherTrajet();
            //}

        }

        private void Supp_trajet_click(object sender, RoutedEventArgs e)
        {
            DAL_Trajet.SupprimerTrajet(IdTrajet);
            AfficherTrajet();
        }
    }
}
