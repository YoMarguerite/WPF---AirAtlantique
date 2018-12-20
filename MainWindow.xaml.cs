using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        static CTRL_Classe classes = new CTRL_Classe();
        static CTRL_Tarif tarifs = new CTRL_Tarif(classes);
        static CTRL_Vol vols = new CTRL_Vol(trajets, avions);
        static CTRL_Billet billets = new CTRL_Billet(classes, tarifs, vols, clients);
        static Utilisateur user;
        static List<object> Actif_Controls = new List<object>();

        public MainWindow(){ 

            InitializeComponent();
            Accueil();
        }

        public void MainBoxPresentation(string header)
        {
            MainBox.Header = header;
            BoxLayout.Children.Clear();
            Actif_Controls.Clear();
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Accueil()
        {
            MainBoxPresentation("Accueil");
            
            ComboBox combo = new ComboBox();
            ComboBox combo2 = new ComboBox();
            DatePicker date = new DatePicker();
            Border errordate = new Border();
            TimeControl time = new TimeControl();
            ComboBox horaire = new ComboBox();

            Actif_Controls.Add(combo);
            Actif_Controls.Add(combo2);
            Actif_Controls.Add(date);
            Actif_Controls.Add(errordate);
            Actif_Controls.Add(time);
            Actif_Controls.Add(horaire);


            //-------------------BoxLayout-----------------
            BoxLayout.Children.Clear();
            BoxLayout.Children.Add(Graphics_Grid.Grid_Title("RECHERCHER UN VOL"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Combo(ref combo, "Départ :", "combdepart", aeroports.Nom));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Combo(ref combo2, "Arrivée :", "combarrive", aeroports.Nom));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Date(ref date, "Date :", "date", ref errordate, "errordate", "Date invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Time(ref time, "Heure :", "heure"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Combo(ref horaire, "Horaire :", "horaire", new List<string> { "départ à","arrivée à"}));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Button("Recherche", "btnrecherche", Recherche));
        }

        private void Accueil(object sender, RoutedEventArgs e)
        {

            Accueil();
            
        }

        private void Recherche(object sender, RoutedEventArgs e)
        {
            ComboBox combo = (ComboBox)Actif_Controls[0];
            ComboBox combo2 = (ComboBox)Actif_Controls[1];
            DatePicker date = (DatePicker)Actif_Controls[2];
            Border errordate = (Border)Actif_Controls[3];
            TimeControl time = (TimeControl)Actif_Controls[4];
            ComboBox horaire = (ComboBox)Actif_Controls[5];

            Trajet trajet = trajets.FindByStr(aeroports.FindByNom(combo.Text).AITA + " - " + aeroports.FindByNom(combo2.Text).AITA);

            bool verif = true;

            if (trajet == default(Trajet))
            {
                verif = false;
            }

            if(date.Text == "")
            {
                errordate.Visibility = Visibility.Visible;
                verif = false;
            }
            else
            {
                errordate.Visibility = Visibility.Collapsed;
            }

            if (!verif)
            {
                Accueil();
            }
            else
            {
                MainBoxPresentation("Recherche Vol");

                
                BoxLayout.Children.Add(Graphics_Grid.Grid_Title("Recherche Vol"));
                BoxLayout.Children.Add(Graphics_Grid.Grid_Block(horaire.Text, time.Time + " le " + date.Text));
                BoxLayout.Children.Add(Graphics_Grid.Grid_Block("Trajet de", combo.Text + " à " + combo2.Text));

                List<Vol> correspond_vol = vols.Correspondance(trajet, horaire.SelectedIndex.ToString().ToBoolean(), DateTime.Parse(date.Text + " " + time.Time));

                if (correspond_vol.Count > 0)
                {
                    ObservableCollection<Billet> list_billets = new ObservableCollection<Billet>();
                    foreach (Vol vol in correspond_vol)
                    {
                        List<Tarif> list_tarif = tarifs.TarifsCorrespond(vol);

                        Billet billet = new Billet();
                        billet.Tarifs = list_tarif;
                        billet.Classes = classes.ClassesCorrespond(list_tarif);
                        billet.Classe_Str = billet.Classes[0].Nom;
                        billet.Tarif_Str = billet.Tarifs[0].Nom;
                        billet.Vol = vol;
                        list_billets.Add(billet);
                    }
                    DataGrid grid = Graphics_Grid.DataGrid(list_billets, CellEditEndingBillet);

                    Actif_Controls.Add(grid);

                    grid.Columns.Add(Graphics_Grid.Column("Départ", "Vol.Depart", true));
                    grid.Columns.Add(Graphics_Grid.Column("Arrivée", "Vol.Arrive", true));
                    grid.Columns.Add(Graphics_Grid.Column("Classe", "Classe_Str", classes.Classes_Str));
                    grid.Columns.Add(Graphics_Grid.Column("Tarif", "Tarif_Str", tarifs.FindByClasse(1)));
                    BoxLayout.Children.Add(grid);
                }
            }
        }

        private void CellEditEndingBillet(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                DataGridColumn column = e.Column;
                if (column != null)
                {
                    string column_nom = (string)column.Header;
                    int rowIndex = e.Row.GetIndex();

                    ComboBox el_combo = e.EditingElement as ComboBox;
                    Maintenance maintenance = maintenances.Maintenance[rowIndex];

                    switch (column_nom)
                    {
                        case "Classe":
                            DataGridRow rowdef = e.Row;

                            break;

                        default:
                            break;
                    }
                }
            }
        }




        //_____________________________UTILISATEURS____________________________

        private void Connexion(object sender, RoutedEventArgs e)
        {
            MainBoxPresentation("Connexion");

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
            MainBoxPresentation("Inscription");


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
            ComboBox civilite = new ComboBox();


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
            Actif_Controls.Add(civilite);


            BoxLayout.Children.Add(Graphics_Grid.Grid_Title("INSCRIPTION"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Text(ref nom, "Nom :", "txtnom", ref nomerror, "errornom", "Champs invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Text(ref prenom, "Prénom :", "txtprenom", ref prenomerror,  "errorprenom", "Champs invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Text(ref mail, "Mail :", "txtmail", ref mailerror, "errormail", "Mail invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Text(ref remail, "Confirmation :", "txtremail", ref remailerror, "errorremail", "Ne corresponds pas"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Pass(ref password, "Mot de passe :", "txtpass", ref passworderror, "errorpass", "Mot de passe invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Pass(ref repassword, "Confirmation :", "txtrepass", ref repassworderror, "errorrepass", "Ne corresponds pas"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Combo(ref civilite, "Civilite :", "civilite", new List<string> { "Homme", "Femme" }));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Button("Inscription", "btninscription", Inscription_Utilisateur));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Btn_Link("Connexion", "btnconnexion", Connexion));
        }

        private void Profil(object sender, RoutedEventArgs e)
        {
            MainBoxPresentation("Profil");

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
            ComboBox civilite = (ComboBox)Actif_Controls[14];

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

                        employe.Nom = nom.Text;
                        employe.Prenom = prenom.Text;
                        employe.Mail = mail.Text;
                        employe.Civilite = civilite.Text;
                        employe.Poste = "indéfinis";
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

                        client.Nom = nom.Text;
                        client.Prenom = prenom.Text;
                        client.Mail = mail.Text;
                        client.Civilite = civilite.Text;
                        client.Type = false;
                        client.Fidelite = 0;

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
                        user = clients.FindByMail(mail.Text);

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




        //___________________________________MAINTENANCES___________________________________

        private void Maintenances()
        {
            MainBoxPresentation("Maintenance");

            List<string> header = new List<string> { "Date", "Details", "Avion", "Aeroport" };
            DataGrid datagrid = Graphics_Grid.DataGrid<Maintenance>(maintenances.DataMaintenances, CellEditEndingMaintenance);
            datagrid.Columns.Add(Graphics_Grid.Column(header[0], header[0], false));
            datagrid.Columns.Add(Graphics_Grid.Column(header[1], header[1], false));
            datagrid.Columns.Add(Graphics_Grid.Column(header[2], "Avion", avions.Matricule));
            datagrid.Columns.Add(Graphics_Grid.Column(header[3], "Aeroport", aeroports.AITA));
            datagrid.Columns.Add(Graphics_Grid.Column("", "Supprimer", SupprimerMaintenance));

            Actif_Controls.Add(datagrid);

            BoxLayout.Children.Add(Graphics_Grid.Grid_Title("Maintenances"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Button("Ajouter +", "nouveau", Ajout_Maintenance));
            BoxLayout.Children.Add(datagrid);
        }

        private void Maintenances(object sender, RoutedEventArgs e)
        {
            Maintenances();
        }

        private void Ajout_Maintenance(object sender, RoutedEventArgs e)
        {
            MainBoxPresentation("Nouvelle Maintenance");

            DatePicker date = new DatePicker();
            Border errordate = new Border();
            TextBox txt = new TextBox();
            Border txterror = new Border();
            ComboBox combo = new ComboBox();
            ComboBox combo2 = new ComboBox();

            Actif_Controls.Add(date);
            Actif_Controls.Add(errordate);
            Actif_Controls.Add(txt);
            Actif_Controls.Add(txterror);
            Actif_Controls.Add(combo);
            Actif_Controls.Add(combo2);

            BoxLayout.Children.Add(Graphics_Grid.Grid_Title("Ajout Maintenance"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Date(ref date, "Date :", "date", ref errordate, "errordate", "Date invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Text(ref txt, "Details :", "details", ref txterror, "error", "Champs vide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Combo(ref combo, "Avion :", "combo", avions.Matricule));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Combo(ref combo2, "Aéroport :", "combo2", aeroports.AITA));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Button("Ajouter", "btn", Nouvelle_Maintenance));
        }

        private void Nouvelle_Maintenance(object sender, RoutedEventArgs e)
        {
            DatePicker date = (DatePicker)Actif_Controls[0];
            Border errordate = (Border)Actif_Controls[1];
            TextBox txt = (TextBox)Actif_Controls[2];
            Border txterror = (Border)Actif_Controls[3];
            ComboBox combo = (ComboBox)Actif_Controls[4];
            ComboBox combo2 = (ComboBox)Actif_Controls[5];

            bool check = true;

            if (date.Text == "")
            {
                errordate.Visibility = Visibility.Visible;
                check = false;
            }
            else
            {
                errordate.Visibility = Visibility.Collapsed;
            }

            if (txt.Text == "")
            {              
                txterror.Visibility = Visibility.Visible;
                check = false;
            }
            else
            {
                errordate.Visibility = Visibility.Collapsed;
            }

            if (check)
            {
                Maintenance maintenance = new Maintenance();
                maintenance.Date = date.Text;
                maintenance.Details = txt.Text;
                maintenance.Avion = combo.Text;
                maintenance.Aeroport = combo2.Text;

                maintenances.Nouveau(maintenance, avions.FindByMatricule(maintenance.Avion).Id, aeroports.FindByAITA(maintenance.Aeroport).Id);
                Maintenances();
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
            Maintenances();
        }




        //________________________________________VOLS______________________________________

        private void Vols()
        {
            MainBoxPresentation("Vols");

            List<string> header = new List<string> { "Depart", "Arrive", "Trajet", "Avion" };
            DataGrid datagrid = Graphics_Grid.DataGrid<Vol>(vols.DataVols, CellEditEndingVol);
            datagrid.Columns.Add(Graphics_Grid.Column(header[0], header[0], false));
            datagrid.Columns.Add(Graphics_Grid.Column(header[1], header[1], false));
            datagrid.Columns.Add(Graphics_Grid.Column(header[2], "Trajet_Str", trajets.Trajets_Str));
            datagrid.Columns.Add(Graphics_Grid.Column(header[3], "Avion", avions.Matricule));
            datagrid.Columns.Add(Graphics_Grid.Column("", "Supprimer", SupprimerVol));


            BoxLayout.Children.Add(Graphics_Grid.Grid_Title("Vols"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Button("Ajouter +", "btn", Ajout_Vol));
            BoxLayout.Children.Add(datagrid);
        }

        private void Vols(object sender, RoutedEventArgs e)
        {
            Vols();
        }

        private void Ajout_Vol(object sender, RoutedEventArgs e)
        {
            MainBoxPresentation("Nouveau Vol");

            DatePicker date = new DatePicker();
            Border errordate = new Border();
            TimeControl time = new TimeControl();
            DatePicker date2 = new DatePicker();
            Border date2error = new Border();
            TimeControl time2 = new TimeControl();
            ComboBox combo = new ComboBox();
            ComboBox combo2 = new ComboBox();

            Actif_Controls.Add(date);
            Actif_Controls.Add(errordate);
            Actif_Controls.Add(time);
            Actif_Controls.Add(date2);
            Actif_Controls.Add(date2error);
            Actif_Controls.Add(time2);
            Actif_Controls.Add(combo);
            Actif_Controls.Add(combo2);

            BoxLayout.Children.Add(Graphics_Grid.Grid_Title("Ajout Vol"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Date(ref date, "Départ :", "date", ref errordate, "errordate", "Date invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Time(ref time, "Horaire :", "time"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Date(ref date2, "Arrivée :", "date2", ref date2error, "errordate2", "Date invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Time(ref time2, "Horaire :", "time2"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Combo(ref combo, "Avion :", "combo", avions.Matricule));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Combo(ref combo2, "Trajet :", "combo2", trajets.Trajets_Str));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Button("Ajouter", "btn", Nouveau_Vol));
        }

        private void Nouveau_Vol(object sender, RoutedEventArgs e)
        {
            DatePicker date = (DatePicker)Actif_Controls[0];
            Border errordate = (Border)Actif_Controls[1];
            TimeControl time = (TimeControl)Actif_Controls[2];
            DatePicker date2 = (DatePicker)Actif_Controls[3];
            Border errordate2 = (Border)Actif_Controls[4];
            TimeControl time2 = (TimeControl)Actif_Controls[5];
            ComboBox combo = (ComboBox)Actif_Controls[6];
            ComboBox combo2 = (ComboBox)Actif_Controls[7];

            bool check = true;

            if (date.Text == "")
            {
                errordate.Visibility = Visibility.Visible;
                check = false;
            }
            else
            {
                errordate.Visibility = Visibility.Collapsed;
            }

            if (date2.Text == "")
            {
                errordate2.Visibility = Visibility.Visible;
                check = false;
            }
            else
            {
                errordate2.Visibility = Visibility.Collapsed;
            }

            if (check)
            {
                Vol vol = new Vol();
                vol.Depart = date.Text+" "+time.Time;
                vol.Arrive = date2.Text+" "+time2.Time;
                vol.Avion = combo.Text;
                vol.Trajet_Str = combo2.Text;

                vols.Nouveau(vol, avions.FindByMatricule(vol.Avion).Id, trajets.FindByStr(vol.Trajet_Str).Id);

                Vols();
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

        private void SupprimerVol(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandParameter.ToString());
            vols.Supprimer(id);
            Vols();
        }




        //______________________________________CLIENTS__________________________________________

        private void Clients()
        {
            MainBoxPresentation("Clients");

            List<string> header = new List<string> { "Nom", "Prenom", "Mail", "Civilite", "Fidelite" };
            DataGrid datagrid = Graphics_Grid.DataGrid<Client>(clients.DataClient, CellEditEndingClient);
            datagrid.Columns.Add(Graphics_Grid.Column(header[0], header[0], false));
            datagrid.Columns.Add(Graphics_Grid.Column(header[1], header[1], false));
            datagrid.Columns.Add(Graphics_Grid.Column(header[2], header[2], false));
            datagrid.Columns.Add(Graphics_Grid.Column(header[3], "Civilite", new List<string> { "Homme", "Femme" }));
            datagrid.Columns.Add(Graphics_Grid.Column(header[4], header[4], false));
            datagrid.Columns.Add(Graphics_Grid.Column("", "Supprimer", SupprimerClient));


            BoxLayout.Children.Add(Graphics_Grid.Grid_Title("Clients"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Button("Ajouter +", "nouveau", Ajout_Client));
            BoxLayout.Children.Add(datagrid);
        }

        private void Clients(object sender, RoutedEventArgs e)
        {
            Clients();
        }

        private void Ajout_Client(object sender, RoutedEventArgs e)
        {
            MainBoxPresentation("Nouveau Client");

            TextBox nom = new TextBox();
            Border nomerror = new Border();
            TextBox prenom = new TextBox();
            Border prenomerror = new Border();
            TextBox mail = new TextBox();
            Border mailerror = new Border();
            PasswordBox password = new PasswordBox();
            Border passerror = new Border();
            ComboBox civilite = new ComboBox();
            NumericBox fidelite = new NumericBox();

            Actif_Controls.Add(nom);
            Actif_Controls.Add(nomerror);
            Actif_Controls.Add(prenom);
            Actif_Controls.Add(prenomerror);
            Actif_Controls.Add(mail);
            Actif_Controls.Add(mailerror);
            Actif_Controls.Add(password);
            Actif_Controls.Add(passerror);
            Actif_Controls.Add(civilite);
            Actif_Controls.Add(fidelite);


            BoxLayout.Children.Add(Graphics_Grid.Grid_Title("Ajout Client"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Text(ref nom, "Nom :", "nom", ref nomerror, "nomerror", "Champs invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Text(ref prenom, "Prenom :", "prenom", ref prenomerror, "prenomerror", "Champs invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Text(ref mail, "Mail :", "mail", ref mailerror, "mailerror", "Mail invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Pass(ref password, "Mot de Passe :", "mdp", ref passerror, "passerror", "Champs invalide"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Combo(ref civilite, "Civilite :", "civilite", new List<string> { "Homme", "Femme" }));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Number(ref fidelite, "Fidélité :", "fidelite"));
            BoxLayout.Children.Add(Graphics_Grid.Grid_Button("Ajouter", "btn", Nouveau_Client));
        }

        private void Nouveau_Client(object sender, RoutedEventArgs e)
        {
            TextBox nom = (TextBox)Actif_Controls[0];
            Border nomerror = (Border)Actif_Controls[1];
            TextBox prenom = (TextBox)Actif_Controls[2];
            Border prenomerror = (Border)Actif_Controls[3];
            TextBox mail = (TextBox)Actif_Controls[4];
            Border mailerror = (Border)Actif_Controls[5];
            PasswordBox password = (PasswordBox)Actif_Controls[6];
            Border passerror = (Border)Actif_Controls[7];
            ComboBox civilite = (ComboBox)Actif_Controls[8];
            NumericBox fidelite = (NumericBox)Actif_Controls[9];

            bool check = true;

            if (nom.Text == "")
            {
                nomerror.Visibility = Visibility.Visible;
                check = false;
            }
            else
            {
                nomerror.Visibility = Visibility.Collapsed;
            }

            if (prenom.Text == "")
            {
                prenomerror.Visibility = Visibility.Visible;
                check = false;
            }
            else
            {
                prenomerror.Visibility = Visibility.Collapsed;
            }

            if (!IsValidEmail(mail.Text) && (!clients.ClientExist(mail.Text)))
            {
                mailerror.Visibility = Visibility.Visible;
                check = false;
            }
            else
            {
                mailerror.Visibility = Visibility.Collapsed;
            }

            if (password.Password.Length < 8)
            {
                passerror.Visibility = Visibility.Visible;
                check = false;
            }
            else
            {
                passerror.Visibility = Visibility.Collapsed;
            }

            if (check)
            {
                Client client = new Client();
                client.Nom = nom.Text;
                client.Prenom = prenom.Text;
                client.Mail = mail.Text;
                client.Civilite = civilite.Text;
                client.Type = false;
                client.Fidelite = fidelite.Number;

                clients.AjouterClient(ref client, password.Password.ToString());

                Clients();
            }
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

        private void SupprimerClient(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandParameter.ToString());
            clients.Supprimer(id);
            Clients();
        }




        //___________________________________VERIFICATIONS________________________________________

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
