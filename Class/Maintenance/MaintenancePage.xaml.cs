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
using WpfApp1.Class.Aeroport;
using WpfApp1.Class.Avion;

namespace WpfApp1.Class.Maintenance
{
    /// <summary>
    /// Logique d'interaction pour MaintenancePage.xaml
    /// </summary>
    public partial class MaintenancePage : Page
    {
        ObservableCollection<Maintenance> ListeMaintenances;
        private int employe;
        private int IdMaintenance;

        public MaintenancePage(int _employe)
        {
            employe = _employe;
            InitializeComponent();
            AfficherMaintenance();

            this.avion.ItemsSource = DAL_Avion.SelectMatriculeAvions();
            this.aeroport.ItemsSource = DAL_Aeroport.SelectNomAeroports();

            this.Aeroport.ItemsSource = DAL_Aeroport.SelectNomAeroports();
            this.Aeroport.SelectedValue = DAL_Aeroport.SelectNomAeroports().First();

            this.Avion.ItemsSource = DAL_Avion.SelectMatriculeAvions();
            this.Avion.SelectedValue = DAL_Avion.SelectMatriculeAvions().First();

        }

        public void AfficherMaintenance()
        {
            ListeMaintenances = new ObservableCollection<Maintenance>();
            ListeMaintenances = DAL_Maintenance.SelectMaintenancesByEmploye(employe);
            this.grid.ItemsSource = ListeMaintenances;
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
                    Maintenance maintenance = DAL_Maintenance.GetMaintenance(IdMaintenance);

                    switch (column_nom)
                    {
                        case "Avion":
                            maintenance.Avion = co.Text;
                            break;

                        case "Date":
                            DateTime date;
                            if (!DateTime.TryParse(el.Text, out date))
                            {
                                date = maintenance.Date;
                            }
                            maintenance.Date = date;
                            break;

                        case "Aéroport":
                            maintenance.Aeroport = co.Text;
                            break;

                        case "Détails":
                            maintenance.Details = el.Text;
                            break;

                        default:
                            break;
                    }
                    DAL_Maintenance.ModifierMaintenance(maintenance.Id, DAL_Avion.FindByMatricule(maintenance.Avion).Id, maintenance.Date, DAL_Aeroport.FindByName(maintenance.Aeroport).Id, maintenance.Details, employe);
                }
            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((grid.SelectedIndex >= 0) && (grid.SelectedIndex <= ListeMaintenances.Count))
            {
                IdMaintenance = ListeMaintenances.ElementAt(grid.SelectedIndex).Id;
            }

        }

        private void Nouveau_maintenance_click(object sender, RoutedEventArgs e)
        {
            DateTime date;
            if (DateTime.TryParse(Date.Text,out date))
            {
                DAL_Maintenance.AjouterMaintenance(DAL_Avion.FindByMatricule(Avion.Text).Id, date, DAL_Aeroport.FindByName(Aeroport.Text).Id, Details.Text, employe);
                AfficherMaintenance();
            }
        }

        private void Supp_maintenance_click(object sender, RoutedEventArgs e)
        {
            DAL_Maintenance.SupprimerMaintenance(IdMaintenance);
            AfficherMaintenance();
        }
    }
}
