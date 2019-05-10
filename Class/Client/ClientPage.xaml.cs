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
using WpfApp1.Class.Extensions;

namespace WpfApp1.Class.Client
{
    /// <summary>
    /// Logique d'interaction pour ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        ObservableCollection<Client> ListeClients;
        int IdClient;

        public ClientPage()
        {
            InitializeComponent();
            AfficherClient();
        }

        public void AfficherClient()
        {
            ListeClients = new ObservableCollection<Client>();
            ListeClients = DAL_Client.SelectClients();
            this.grid.ItemsSource = ListeClients;
            this.civilite.ItemsSource = new string[]{ "Homme", "Femme"};
            this.Cocivilite.ItemsSource = new string[]{ "Homme", "Femme"};
            this.Cocivilite.SelectedValue = "Homme";
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
                    Client Client = DAL_Client.GetClient(IdClient);

                    switch (column_nom)
                    {
                        case "Nom":
                            Client.Nom = el.Text;
                            break;

                        case "Prénom":
                            Client.Prenom = el.Text;
                            break;

                        case "Mail":
                            Client.Mail = el.Text;
                            break;

                        case "Fidélité":
                            Client.Fidelite = int.Parse(el.Text);
                            break;

                        case "Civilité":
                            ComboBox co = e.EditingElement as ComboBox;
                            Client.Civilite = (string)co.SelectionBoxItem;
                            break;

                        case "Mot de passe":
                            Client.Mdp = BCrypt.Net.BCrypt.HashPassword(el.Text);
                            break;

                        default:
                            break;
                    }
                    DAL_Client.ModifierClient(Client.Id, Client.Mail, StringExtensions.CiviliteToBoolean(Client.Civilite), Client.Fidelite, Client.Nom, Client.Prenom, Client.Mdp);
                    AfficherClient();
                }
            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((grid.SelectedIndex >= 0) && (grid.SelectedIndex <= ListeClients.Count))
            {
                IdClient = ListeClients.ElementAt(grid.SelectedIndex).Id;
            }

        }

        private void Nouveau_client_click(object sender, RoutedEventArgs e)
        {
            DAL_Client.AjouterClient(Mail.Text, StringExtensions.CiviliteToBoolean(Cocivilite.Text), int.Parse(Fidelite.Text), Nom.Text, Prenom.Text, BCrypt.Net.BCrypt.HashPassword((string)Password.Password));
            AfficherClient();
        }

        private void Supp_client_click(object sender, RoutedEventArgs e)
        {
            DAL_Client.SupprimerClient(IdClient);
            AfficherClient();
        }
    }
}
