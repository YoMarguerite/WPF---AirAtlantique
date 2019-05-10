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

namespace WpfApp1.Class.Avion
{
    /// <summary>
    /// Logique d'interaction pour AvionPage.xaml
    /// </summary>
    public partial class AvionPage : Page
    {
        ObservableCollection<Avion> ListeAvions;
        int IdAvion;

        public AvionPage()
        {
            InitializeComponent();
            AfficherAvion();
        }

        public void AfficherAvion()
        {
            ListeAvions = new ObservableCollection<Avion>();
            ListeAvions = DAL_Avion.SelectAvions();
            this.grid.ItemsSource = ListeAvions;
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
                    Avion avion = DAL_Avion.GetAvion(IdAvion);

                    switch (column_nom)
                    {
                        case "Matricule":
                            avion.Matricule = el.Text;
                            break;

                        case "Moteur":
                            avion.Moteur = el.Text;
                            break;

                        case "Kilometre":
                            float kilometre;
                            if(!float.TryParse(el.Text, out kilometre))
                            {
                                kilometre = avion.Kilometre;
                            }
                            avion.Kilometre = kilometre;
                            break;

                        case "Modele":
                            avion.Modele = el.Text;
                            break;

                        case "Type":
                            avion.Type = el.Text;
                            break;

                        case "Passager":
                            int passager;
                            if (!int.TryParse(el.Text, out passager))
                            {
                                passager = avion.Passager;
                            }
                            avion.Kilometre = passager;
                            break;

                        default:
                            break;
                    }
                    DAL_Avion.ModifierAvion(avion.Id, avion.Matricule, avion.Moteur, avion.Kilometre, avion.Modele, avion.Type, avion.Passager);
                }
            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((grid.SelectedIndex >= 0) && (grid.SelectedIndex <= ListeAvions.Count))
            {
                IdAvion = ListeAvions.ElementAt(grid.SelectedIndex).Id;
            }

        }

        private void Nouvel_avion_click(object sender, RoutedEventArgs e)
        {
            float kilometre;
            int passager;
            if((float.TryParse(Kilometre.Text,out kilometre))&&(int.TryParse(Passager.Text, out passager))){
                DAL_Avion.AjouterAvion(Matricule.Text, Moteur.Text, kilometre, Modele.Text, Type.Text, passager);
                AfficherAvion();
            }
            
        }

        private void Supp_avion_click(object sender, RoutedEventArgs e)
        {
            DAL_Avion.SupprimerAvion(IdAvion);
            AfficherAvion();
        }
    }
}
