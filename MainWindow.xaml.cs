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
using WpfApp1.Class;
using WpfApp1.Class.Contrôleur;
using WpfApp1.Class.Entity;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        {
        
        static CTRL_Client clients = new CTRL_Client();
        static CTRL_Employe employes = new CTRL_Employe();
        static CTRL_Aeroport aeroports = new CTRL_Aeroport();
        static CTRL_Avion avions = new CTRL_Avion();
        static CTRL_Maintenance maintenances = new CTRL_Maintenance(avions, aeroports);
        static CTRL_Trajet trajets = new CTRL_Trajet(aeroports);
        static CTRL_Vol vols = new CTRL_Vol(trajets, avions);
        static Utilisateur user;
        static List<object> Actif_Controls = new List<object>();

        public MainWindow(){ 

            InitializeComponent();
            Accueil();
        }

        private void Accueil()
        {
            //--------------------MainBox------------------
            MainBox.Header = "Accueil";
            BoxLayout.Children.Clear();


            //------------------ListItem Départ------------
            List<string> listItems = new List<string>();
            listItems.Add("Paris");
            listItems.Add("Nantes");


            //------------------ListItem Arrivée-------------
            List<string> listItems2 = new List<string>();
            listItems2.Add("Vannes");
            listItems2.Add("Marseille");


            //------------------List Radio-------------------
            List<RadioButton> listradio = new List<RadioButton>();
            RadioButton radio = new RadioButton();
            RadioButton radio2 = new RadioButton();
            radio.Content = "départ à";
            radio.IsChecked = true;
            radio2.Content = "arrivé à";
            listradio.Add(radio);
            listradio.Add(radio2);


            System.Windows.RoutedEventHandler action = Accueil;


            //-------------------BoxLayout-----------------
            BoxLayout.Children.Clear();
            BoxLayout.Children.Add(Graphics_Grid.Grid_Title("RECHERCHER UN VOL"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Combo("Départ :", "combdepart", listItems));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Combo("Arrivée :", "combarrive", listItems2));
            //BoxLayout.Children.Add(Graphics_Grid.Grid_Date("Date :", "date"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Time("Heure :", "heure"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Radio(ref listradio, "radio"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Button("Recherche", "btnrecherche", action));
        }

        private void Accueil(object sender, RoutedEventArgs e)
        {

            Accueil();
            
        }

        private void Connexion(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Connexion";
            BoxLayout.Children.Clear();
            Actif_Controls.Clear();

            TextBox mail = new TextBox();
            Border mailerror = new Border();
            PasswordBox password = new PasswordBox();
            Border passerror = new Border();

            Actif_Controls.Add(mail);
            Actif_Controls.Add(mailerror);
            Actif_Controls.Add(password);
            Actif_Controls.Add(passerror);
           
            
            BoxLayout.Children.Add(Graphics_Grid.Grid_Title("CONNEXION"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Text(ref mail, "Mail :", "txtmail", ref mailerror, "errormail", "Mail invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Pass(ref password, "Mot de passe :", "txtpass", ref passerror, "errorpass", "Mot de passe invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Button("Connexion", "btnconnexion", Connexion_Utilisateur));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Btn_Link("Inscription", "btninscription", Inscription));

        }

        private void Inscription(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Inscription";
            BoxLayout.Children.Clear();
            Actif_Controls.Clear();


            TextBox nom = new TextBox();
            Border nomerror = new Border();
            TextBox prenom = new TextBox();
            Border prenomerror = new Border();
            DatePicker date = new DatePicker();
            TextBox adresse = new TextBox();
            TextBox mail = new TextBox();
            Border mailerror = new Border();
            TextBox remail = new TextBox();
            Border remailerror = new Border();
            PasswordBox password = new PasswordBox();
            Border passworderror = new Border();
            PasswordBox repassword = new PasswordBox();
            Border repassworderror = new Border();
            RadioButton radio = new RadioButton();
            RadioButton radio2 = new RadioButton();
            

            List<RadioButton> listradio = new List<RadioButton>();
            radio.Content = "Homme";
            radio.IsChecked = true;
            radio2.Content = "Femme";
            listradio.Add(radio);
            listradio.Add(radio2);


            Actif_Controls.Add(nom);
            Actif_Controls.Add(nomerror);
            Actif_Controls.Add(prenom);
            Actif_Controls.Add(prenomerror);
            Actif_Controls.Add(date);
            Actif_Controls.Add(adresse);
            Actif_Controls.Add(mail);
            Actif_Controls.Add(mailerror);
            Actif_Controls.Add(remail);
            Actif_Controls.Add(remailerror);
            Actif_Controls.Add(password);
            Actif_Controls.Add(passworderror);
            Actif_Controls.Add(repassword);
            Actif_Controls.Add(repassworderror);
            Actif_Controls.Add(radio);
            Actif_Controls.Add(radio2);


            BoxLayout.Children.Add(Graphics_Grid.Grid_Title("INSCRIPTION"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Text(ref nom, "Nom :", "txtnom", ref nomerror, "errornom", "Champs invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Text(ref prenom, "Prénom :", "txtprenom", ref prenomerror,  "errorprenom", "Champs invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Text(ref mail, "Mail :", "txtmail", ref mailerror, "errormail", "Mail invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Text(ref remail, "Confirmation :", "txtremail", ref remailerror, "errorremail", "Ne corresponds pas"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Pass(ref password, "Mot de passe :", "txtpass", ref passworderror, "errorpass", "Mot de passe invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Pass(ref repassword, "Confirmation :", "txtrepass", ref repassworderror, "errorrepass", "Ne corresponds pas"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Radio(ref listradio, "radiocivilite"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Button("Inscription", "btninscription", Inscription_Utilisateur));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Btn_Link("Connexion", "btnconnexion", Connexion));
        }

        private void Profil(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Profil";
            BoxLayout.Children.Clear();
            Actif_Controls.Clear();

            TextBlock nom = new TextBlock();
            TextBlock prenom = new TextBlock();
            TextBlock poste = new TextBlock();
            

            Actif_Controls.Add(nom);
            Actif_Controls.Add(prenom);
            Actif_Controls.Add(poste);


            BoxLayout.Children.Add(Graphics_Grid.Grid_Title("PROFIL"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Block_Modifiable(ref nom, "Nom :", user.Nom, "Nom", 0, Modifier_Utilisateur));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Block_Modifiable(ref prenom, "Prenom :", user.Prenom, "Prenom", 1, Modifier_Utilisateur));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Block("Mail :", user.Mail));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Block("Civilité :", user.Civilite));

            if (user.Type)
            {
                Employe employe = (Employe)user;
                BoxLayout.Children.Add(Graphics_Grid.Grid_Block_Modifiable(ref poste, "Poste :", employe.Poste, "Poste", 3, Modifier_Utilisateur));
            }
            else
            {
                Client client = (Client)user;
                BoxLayout.Children.Add(Graphics_Grid.Grid_Block("Fidélité :", client.Fidelite + " points"));
            }
        }

        private void Inscription_Utilisateur(object sender, RoutedEventArgs e)
        {
            TextBox nom = (TextBox)Actif_Controls[0];
            Border nomerror = (Border)Actif_Controls[1];
            TextBox prenom = (TextBox)Actif_Controls[2];
            Border prenomerror = (Border)Actif_Controls[3];
            TextBox mail = (TextBox)Actif_Controls[6];
            Border mailerror = (Border)Actif_Controls[7];
            TextBox remail = (TextBox)Actif_Controls[8];
            Border remailerror = (Border)Actif_Controls[9];
            PasswordBox password = (PasswordBox)Actif_Controls[10];
            Border passworderror = (Border)Actif_Controls[11];
            PasswordBox repassword = (PasswordBox)Actif_Controls[12];
            Border repassworderror = (Border)Actif_Controls[13];
            RadioButton radio = (RadioButton)Actif_Controls[14];

            bool valid = true;

            if (nom.Text == "")
            {
                valid = false;
                nomerror.Visibility = Visibility.Visible;
            }
            else
            {
                nomerror.Visibility = Visibility.Collapsed;
            }

            if (prenom.Text == "")
            {
                valid = false;
                prenomerror.Visibility = Visibility.Visible;
            }
            else
            {
                prenomerror.Visibility = Visibility.Collapsed;
            }

            if (!IsValidEmail(mail.Text))
            {
                valid = false;
                mailerror.Visibility = Visibility.Visible;
            }
            else
            {
                mailerror.Visibility = Visibility.Collapsed;
            }

            if (remail.Text != mail.Text)
            {
                valid = false;
                remailerror.Visibility = Visibility.Visible;
            }
            else
            {
                remailerror.Visibility = Visibility.Collapsed;
            }

            if (password.Password.ToString().Length < 7)
            {
                valid = false;
                passworderror.Visibility = Visibility.Visible;
            }
            else
            {
                passworderror.Visibility = Visibility.Collapsed;
            }

            if (repassword.Password.ToString() != password.Password.ToString())
            {
                valid = false;
                repassworderror.Visibility = Visibility.Visible;
            }
            else
            {
                repassworderror.Visibility = Visibility.Collapsed;
            }

            if (valid)
            {
                if (IsEmploye(mail.Text))
                {
                    if (!employes.EmployeExist(mail.Text))
                    {
                        Employe employe = new Employe();
                        bool civilite = (bool)radio.IsChecked;

                        employe.Nom = nom.Text;
                        employe.Prenom = prenom.Text;
                        employe.Mail = mail.Text;
                        employe.Civilite = civilite.CiviliteBool();
                        employe.Poste = "Nouveau";
                        employe.Type = true;

                        employes.AjouterEmploye(ref employe, password.Password.ToString());
                        user = employe;

                        VolsButton.Visibility = Visibility.Visible;
                        MaintenanceButton.Visibility = Visibility.Visible;
                        ClientButton.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    if (!clients.ClientExist(mail.Text))
                    {
                        Client client = new Client();
                        bool civilite = (bool)radio.IsChecked;

                        client.Nom = nom.Text;
                        client.Prenom = prenom.Text;
                        client.Mail = mail.Text;
                        client.Fidelite = 0;
                        client.Civilite = civilite.CiviliteBool();
                        client.Type = false;

                        clients.AjouterClient(ref client, password.Password.ToString());
                        user = client;
                    }
                }

                ConnexionButton.Content = "Déconnecter";
                ConnexionButton.Click -= Connexion;
                ConnexionButton.Click += Deconnexion_Utilisateur;
                ProfilButton.Visibility = Visibility.Visible;

                Accueil();
            }
        }

        private void Connexion_Utilisateur(object sender, RoutedEventArgs e)
        {
            TextBox mail = (TextBox)Actif_Controls[0];
            Border mailerror = (Border)Actif_Controls[1];
            PasswordBox password = (PasswordBox)Actif_Controls[2];
            Border passerror = (Border)Actif_Controls[3];


            mailerror.Visibility = Visibility.Collapsed;
            passerror.Visibility = Visibility.Collapsed;

            if (IsValidEmail(mail.Text))
            {
                if (IsEmploye(mail.Text))
                {
                    if (employes.VerifierConnexion(mail.Text, password.Password.ToString()))
                    {
                        user = employes.Find(mail.Text);

                        ConnexionButton.Content = "Déconnecter";
                        ConnexionButton.Click -= Connexion;
                        ConnexionButton.Click += Deconnexion_Utilisateur;
                        ProfilButton.Visibility = Visibility.Visible;
                        VolsButton.Visibility = Visibility.Visible;
                        MaintenanceButton.Visibility = Visibility.Visible;
                        ClientButton.Visibility = Visibility.Visible;

                        Accueil();
                    }
                    else
                    {
                        passerror.Visibility = Visibility.Visible;
                        mailerror.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    if (clients.VerifierConnexion(mail.Text, password.Password.ToString()))
                    {
                        user = clients.FindbyMail(mail.Text);

                        ConnexionButton.Content = "Déconnecter";
                        ConnexionButton.Click -= Connexion;
                        ConnexionButton.Click += Deconnexion_Utilisateur;
                        ProfilButton.Visibility = Visibility.Visible;

                        Accueil();
                    }
                    else
                    {
                        passerror.Visibility = Visibility.Visible;
                        mailerror.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                mailerror.Visibility = Visibility.Visible;
            }
        }

        private void Deconnexion_Utilisateur(object sender, RoutedEventArgs e)
        {
            user = null;
            ConnexionButton.Content = "Connexion";
            ConnexionButton.Click -= Deconnexion_Utilisateur;
            ConnexionButton.Click += Connexion;
            ProfilButton.Visibility = Visibility.Collapsed;
            Accueil();
        }

        private void Modifier_Utilisateur(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Content = "sauvegarder";
            btn.Click -= Modifier_Utilisateur;
            btn.Click += Sauvegarder_Utilisateur;

            Grid grid = (Grid)btn.Parent;
            TextBlock block = (TextBlock)grid.Children[1];

            if (btn.Name != "Poste")
            {
                TextBox text = new TextBox();
                text.Text = block.Text;
                text.HorizontalAlignment = HorizontalAlignment.Left;
                text.Margin = new Thickness(150, 0, 0, 0);
                text.Width = 200;

                Actif_Controls.Insert((int)btn.Tag, text);
                grid.Children.Insert(1, text);
            }
            else
            {
                ComboBox combo = new ComboBox();
                combo.Text = block.Text;
                combo.ItemsSource = employes.Postes.Postes_Str;
                combo.SelectedIndex = employes.Postes.Find(block.Text);
                combo.VerticalAlignment = VerticalAlignment.Top;
                combo.HorizontalAlignment = HorizontalAlignment.Left;
                combo.Margin = new Thickness(150, 0, 0, 0);
                combo.Width = 200;

                Actif_Controls.Insert((int)btn.Tag, combo);
                grid.Children.Insert(1, combo);
            }


            Actif_Controls.Remove(block);
            grid.Children.Remove(block);

        }

        private void Sauvegarder_Utilisateur(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Content = "modifier";
            btn.Click -= Sauvegarder_Utilisateur;
            btn.Click += Modifier_Utilisateur;

            Grid grid = (Grid)btn.Parent;

            TextBlock block = new TextBlock();

            if (btn.Name != "Poste")
            {
                TextBox poste = (TextBox)grid.Children[1];

                string info = null;

                if (poste.Text != "")
                {

                    block.Text = poste.Text;

                    if (user.Type)
                    {
                        if (btn.Name == "Nom")
                        {
                            employes.ChangeNom(ref user, poste.Text);
                        }
                        else if (btn.Name == "Prenom")
                        {
                            employes.ChangePrenom(ref user, poste.Text);
                        }
                    }
                    else
                    {
                        if (btn.Name == "Nom")
                        {
                            clients.ChangeNom(ref user, poste.Text);
                        }
                        else if (btn.Name == "Prenom")
                        {
                            clients.ChangePrenom(ref user, poste.Text);
                        }
                    }

                }
                else
                {
                    if (btn.Name == "Nom")
                    {
                        info = user.Nom;
                    }
                    else if (btn.Name == "Prenom")
                    {
                        info = user.Prenom;
                    }

                    block.Text = info;
                }

                Actif_Controls.Insert((int)btn.Tag, block);
                Actif_Controls.Remove(poste);

                grid.Children.Remove(poste);
                grid.Children.Insert(1, block);
            }
            else
            {
                ComboBox poste = (ComboBox)grid.Children[1];

                block.Text = poste.Text;

                Employe employe = (Employe)user;

                employes.ChangePoste(ref employe, poste.Text);

                Actif_Controls.Insert((int)btn.Tag, block);
                Actif_Controls.Remove(poste);

                grid.Children.Remove(poste);
                grid.Children.Insert(1, block);
            }


            block.HorizontalAlignment = HorizontalAlignment.Left;
            block.Margin = new Thickness(150, 0, 0, 0);
            block.Width = 200;
        }

        private void Maintenances(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Maintenance";
            BoxLayout.Children.Clear();
            Actif_Controls.Clear();

            List<string> header = new List<string> { "Date", "Details", "Avion", "Aeroport" };
            DataGrid datagrid = Graphics_Grid.DataGrid<Maintenance>(maintenances.DataMaintenances, header, CellEditEndingMaintenance);
            datagrid.Columns.Add(Graphics_Grid.Column(header[0]));
            datagrid.Columns.Add(Graphics_Grid.Column(header[1]));
            datagrid.Columns.Add(Graphics_Grid.Column(header[2], "Avion", avions.Matricule));
            datagrid.Columns.Add(Graphics_Grid.Column(header[3], "Aeroport", aeroports.AITA));
            datagrid.Columns.Add(Graphics_Grid.Column("", "Supprimer", SupprimerMaintenance, Maintenances));

            Actif_Controls.Add(datagrid);

            BoxLayout.Children.Add(Graphics_Grid.Grid_Title("Maintenances"));
            BoxLayout.Children.Add(datagrid);
        }

        private void Vols(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Vols";
            BoxLayout.Children.Clear();

            List<string> header = new List<string> { "Depart", "Arrive", "Trajet", "Avion" };
            DataGrid datagrid = Graphics_Grid.DataGrid<Vol>(vols.DataVols, header, CellEditEndingVol);
            datagrid.Columns.Add(Graphics_Grid.Column(header[0]));
            datagrid.Columns.Add(Graphics_Grid.Column(header[1]));
            datagrid.Columns.Add(Graphics_Grid.Column(header[2], "Trajet_Str",trajets.Trajets_Str));
            datagrid.Columns.Add(Graphics_Grid.Column(header[3], "Avion", avions.Matricule));
            datagrid.Columns.Add(Graphics_Grid.Column("", "Supprimer", SupprimerVol, Vols));


            BoxLayout.Children.Add(Graphics_Grid.Grid_Title("Vols"));
            BoxLayout.Children.Add(datagrid);
        }

        private void Clients(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Clients";
            BoxLayout.Children.Clear();

            List<string> header = new List<string> { "Nom", "Prenom", "Mail", "Civilite", "Fidelite" };
            DataGrid datagrid = Graphics_Grid.DataGrid<Client>(clients.DataClient, header, CellEditEndingClient);
            datagrid.Columns.Add(Graphics_Grid.Column(header[0]));
            datagrid.Columns.Add(Graphics_Grid.Column(header[1]));
            datagrid.Columns.Add(Graphics_Grid.Column(header[2]));
            datagrid.Columns.Add(Graphics_Grid.Column(header[3], "Civilite", new List<string> { "Homme", "Femme" }));
            datagrid.Columns.Add(Graphics_Grid.Column(header[4]));
            datagrid.Columns.Add(Graphics_Grid.Column("", "Supprimer", SupprimerClient, Clients));


            BoxLayout.Children.Add(Graphics_Grid.Grid_Title("Clients"));
            BoxLayout.Children.Add(datagrid);
        }

        private void CellEditEndingClient(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                DataGridColumn column = e.Column;
                if (column != null)
                {
                    string column_nom = (string)column.Header;
                    int rowIndex = e.Row.GetIndex();
                    TextBox el = e.EditingElement as TextBox;

                    if (rowIndex < clients.Client.Count)
                    {
                        Utilisateur utilisateur = clients.Client[rowIndex];

                        switch (column_nom)
                        {
                            case "Nom":
                                clients.ChangeNom(ref utilisateur, el.Text);
                                break;

                            case "Prenom":
                                clients.ChangePrenom(ref utilisateur, el.Text);
                                break;

                            case "Mail":
                                if ((IsValidEmail(el.Text) && (!clients.ClientExist(el.Text))))
                                {
                                    clients.ChangeMail(ref utilisateur, el.Text);
                                }
                                else
                                {
                                    Client client = (Client)utilisateur;
                                    el.Text = client.Mail.ToString();
                                }
                                break;

                            case "Civilite":
                                ComboBox el_combo = e.EditingElement as ComboBox;
                                clients.ChangeCivilite(ref utilisateur, el_combo.Text);
                                break;

                            case "Fidelite":
                                if (Numeric(el.Text))
                                {
                                    clients.ChangeFidelite(ref utilisateur, int.Parse(el.Text));
                                }
                                else
                                {
                                    Client client = (Client)utilisateur;
                                    el.Text = client.Fidelite.ToString();
                                }
                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {

                    }

                }
            }
        }

        private void CellEditEndingVol(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                DataGridColumn column = e.Column;
                if (column != null)
                {
                    string column_nom = (string)column.Header;
                    int rowIndex = e.Row.GetIndex();
                    TextBox el = e.EditingElement as TextBox;
                    ComboBox el_combo = e.EditingElement as ComboBox;
                    Vol vol = vols.Vol[rowIndex];
                    DateTime dateTime;

                    switch (column_nom)
                    {
                        case "Depart":
                            if (DateTime.TryParse(el.Text, out dateTime))
                            {
                                vols.ChangeDepart(ref vol, el.Text);
                            }
                            else
                            {
                                el.Text = vol.Depart;
                            }
                            break;
                        case "Arrive":
                            if (DateTime.TryParse(el.Text, out dateTime))
                            {
                                vols.ChangeArrive(ref vol, el.Text);
                            }
                            else
                            {
                                el.Text = vol.Depart;
                            }
                            break;
                        case "Trajet":
                            vols.ChangeTrajet(ref vol, trajets.FindByStr(el_combo.Text));
                            break;
                        case "Avion":
                            vols.ChangeAvion(ref vol, avions.FindByMatricule(el_combo.Text));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void CellEditEndingMaintenance(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                DataGridColumn column = e.Column;
                if (column != null)
                {
                    string column_nom = (string)column.Header;
                    int rowIndex = e.Row.GetIndex();
                    TextBox el = e.EditingElement as TextBox;
                    ComboBox el_combo = e.EditingElement as ComboBox;
                    Maintenance maintenance = maintenances.Maintenance[rowIndex];
                    DateTime dateTime;

                    switch (column_nom)
                    {
                        case "Date":
                            if (DateTime.TryParse(el.Text, out dateTime))
                            {
                                maintenances.ChangeDate(ref maintenance, el.Text);
                            }
                            else
                            {
                                el.Text = maintenance.Date;
                            }
                            break;

                        case "Details":
                            if (el.Text != "")
                            {
                                maintenances.ChangeDetails(ref maintenance, el.Text);
                            }
                            else
                            {
                                el.Text = maintenance.Details;
                            }
                            break;

                        case "Avion":
                            maintenances.ChangeAvion(ref maintenance, avions.FindByMatricule(el_combo.Text));
                            break;

                        case "Aeroport":
                            maintenances.ChangeAeroport(ref maintenance, aeroports.FindByAITA(el_combo.Text));
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private void SupprimerMaintenance(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandParameter.ToString());
            maintenances.Supprimer(id);
        }

        private void SupprimerVol(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandParameter.ToString());
            vols.Supprimer(id);
        }

        private void SupprimerClient(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandParameter.ToString());
            clients.Supprimer(id);
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool IsEmploye(string email)
        {
            if ( email.Split('@')[1] == "airatlantique.fr" )
            {
                return true;
            }
            return false;
        }

        private bool Numeric(string Receive)
        {
            bool Result = false;
            if (Receive != "")
            {
                Result = true;
                foreach (char Char in Receive)
                {
                    if (char.IsDigit(Char) == false)
                    {
                        Result = false;
                    }
                }
            }

            return Result;
        }
    }
}
