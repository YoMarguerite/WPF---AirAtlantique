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
using WpfApp1.Class.Avion;
using WpfApp1.Class.Trajet;

namespace WpfApp1.Class.Vol
{
    /// <summary>
    /// Logique d'interaction pour Vol.xaml
    /// </summary>
    public partial class VolPage : Page
    {
        ObservableCollection<Vol> ListeVols;
        int IdVol;

        public VolPage()
        {
            InitializeComponent();
            AfficherVol();
        }

        public void AfficherVol()
        {
            ListeVols = new ObservableCollection<Vol>();
            ListeVols = DAL_Vol.SelectVols();
            this.grid.ItemsSource = ListeVols;
            this.trajet.ItemsSource = DAL_Trajet.SelectStrTrajets();
            this.avion.ItemsSource = DAL_Avion.SelectMatriculeAvions();
            this.Trajet.ItemsSource = DAL_Trajet.SelectStrTrajets();
            this.Avion.ItemsSource = DAL_Avion.SelectMatriculeAvions();
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
                    Vol Vol = DAL_Vol.GetVol(IdVol);

                    switch (column_nom)
                    {
                        case "Trajet":
                            Vol.StrTrajet = co.Text;
                            Vol.Trajet = DAL_Trajet.FindByStrTrajet(co.Text).Id;
                            break;

                        case "Avion":
                            Vol.Avion = co.Text;
                            break;
                            
                        case "Départ":
                            DateTime depart;
                            if(!DateTime.TryParse(el.Text, out depart))
                            {
                                depart = Vol.Depart;
                            }
                            Vol.Depart = depart;
                            break;

                        case "Arrivée":
                            DateTime arrivee;
                            if (!DateTime.TryParse(el.Text, out arrivee))
                            {
                                arrivee = Vol.Arrivee;
                            }
                            Vol.Arrivee = arrivee;
                            break;
                            
                        default:
                            break;
                    }
                    DAL_Vol.ModifierVol(Vol.Id, Vol.Trajet, DAL_Avion.FindByMatricule(Vol.Avion).Id, Vol.Depart, Vol.Arrivee);
                }
            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((grid.SelectedIndex >= 0) && (grid.SelectedIndex <= ListeVols.Count))
            {
                IdVol = ListeVols.ElementAt(grid.SelectedIndex).Id;
            }

        }

        private void Nouveau_vol_click(object sender, RoutedEventArgs e)
        {
            DateTime depart;
            DateTime arrivee;
            if ((DateTime.TryParse(Depart.Text, out depart)) && (DateTime.TryParse(Arrivee.Text, out arrivee)))
            {
                DAL_Vol.AjouterVol(DAL_Trajet.FindByStrTrajet(Trajet.Text).Id, DAL_Avion.FindByMatricule(Avion.Text).Id, depart, arrivee);
                AfficherVol();
            }
        }

        private void Supp_vol_click(object sender, RoutedEventArgs e)
        {
            DAL_Vol.SupprimerVol(IdVol);
            AfficherVol();
        }
    }
}
