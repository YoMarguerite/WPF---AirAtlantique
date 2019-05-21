using System.Collections.Generic;
using System.Windows;
using WpfApp1.Class;
using WpfApp1.Class.Billet;
using WpfApp1.Class.TarifVol;
using WpfApp1.Class.View;
using WpfApp1.Class.Vol;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        {
        
        //static DAO_Client clients = new DAO_Client();
        //static DAO_Employe employes = new DAO_Employe();
        //static DAO_Aeroport aeroports = new DAO_Aeroport();
        //static DAO_Avion avions = new DAO_Avion();
        //static DAO_Maintenance maintenances = new DAO_Maintenance(avions, aeroports);
        //static DAO_Trajet trajets = new DAO_Trajet(aeroports);
        //static DAO_Classe classes = new DAO_Classe();
        //static DAO_Tarif tarifs = new DAO_Tarif(classes);
        //static DAO_Vol vols = new DAO_Vol();
        //static DAO_Billet billets = new DAO_Billet(classes, tarifs, vols, clients);
        //static DAO_Poste postes = new DAO_Poste();
        static Employe user;
        static List<object> Actif_Controls = new List<object>();

        public MainWindow(){ 

            InitializeComponent();
            Main.Content = new BilletPage(25);
        }

        private void Accueil(object sender, RoutedEventArgs e)
        {
            Main.Content = new Accueil(Main);
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void ConnexionValider(Employe _employe)
        {
            Main.Content = new Accueil(Main);
            user = _employe;
        }


        

        //private void Recherche(object sender, RoutedEventArgs e)
        //{
        //    ComboBox combo = (ComboBox)Actif_Controls[0];
        //    ComboBox combo2 = (ComboBox)Actif_Controls[1];
        //    DatePicker date = (DatePicker)Actif_Controls[2];
        //    Border errordate = (Border)Actif_Controls[3];
        //    TimeControl time = (TimeControl)Actif_Controls[4];
        //    ComboBox horaire = (ComboBox)Actif_Controls[5];

        //    Trajet trajet = trajets.FindByStr(aeroports.FindByNom(combo.Text).AITA + " - " + aeroports.FindByNom(combo2.Text).AITA);

        //    bool verif = true;

        //    if (trajet == default(Trajet))
        //    {
        //        verif = false;
        //    }

        //    if(date.Text == "")
        //    {
        //        errordate.Visibility = Visibility.Visible;
        //        verif = false;
        //    }
        //    else
        //    {
        //        errordate.Visibility = Visibility.Collapsed;
        //    }

        //    if (!verif)
        //    {
        //        Accueil();
        //    }
        //    else
        //    {
        //        MainBoxPresentation("Recherche Vol");


        //        BoxLayout.Children.Add(Graphics_Grid.Grid_Title("Recherche Vol"));
        //        BoxLayout.Children.Add(Graphics_Grid.Grid_Block(horaire.Text, time.Time + " le " + date.Text));
        //        BoxLayout.Children.Add(Graphics_Grid.Grid_Block("Trajet de", combo.Text + " à " + combo2.Text));

        //        List<Vol> correspond_vol = vols.Correspondance(trajet, horaire.SelectedIndex.ToString().ToBoolean(), DateTime.Parse(date.Text + " " + time.Time));

        //        if (correspond_vol.Count > 0)
        //        {
        //            ObservableCollection<Vol> list_vols = new ObservableCollection<Vol>();
        //            foreach (Vol vol in correspond_vol)
        //            {
        //                list_vols.Add(vol);
        //            }
        //            DataGrid grid = Graphics_Grid.DataGrid(list_vols, CellEditEndingBillet);

        //            Actif_Controls.Add(grid);

        //            grid.Columns.Add(Graphics_Grid.Column("Départ", "Depart", true));
        //            grid.Columns.Add(Graphics_Grid.Column("Arrivée", "Arrive", true));
        //            BoxLayout.Children.Add(grid);
        //        }
        //    }
        //}

        //private void CellEditEndingBillet(object sender, DataGridCellEditEndingEventArgs e)
        //{
        //    if (e.EditAction == DataGridEditAction.Commit)
        //    {
        //        DataGridColumn column = e.Column;
        //        if (column != null)
        //        {
        //            string column_nom = (string)column.Header;
        //            int rowIndex = e.Row.GetIndex();

        //            ComboBox el_combo = e.EditingElement as ComboBox;
        //            Maintenance maintenance = maintenances.Maintenance[rowIndex];

        //            switch (column_nom)
        //            {
        //                case "Classe":
        //                    DataGridRow rowdef = e.Row;

        //                    break;

        //                default:
        //                    break;
        //            }
        //        }
        //    }
        //}



        private void Profil(object sender, RoutedEventArgs e)
        { }
        //{
        //    MainBoxPresentation("Profil");

        //    TextBlock nom = new TextBlock();
        //    TextBlock prenom = new TextBlock();
        //    TextBlock poste = new TextBlock();


        //    Actif_Controls.Add(nom);
        //    Actif_Controls.Add(prenom);
        //    Actif_Controls.Add(poste);


        //    BoxLayout.Children.Add(Graphics_Grid.Grid_Title("PROFIL"));
        //    BoxLayout.Children.Add(Graphics_Grid.Grid_Block_Modifiable(ref nom, "Nom :", user.Nom, "Nom", 0, Modifier_Utilisateur));
        //    BoxLayout.Children.Add(Graphics_Grid.Grid_Block_Modifiable(ref prenom, "Prenom :", user.Prenom, "Prenom", 1, Modifier_Utilisateur));
        //    BoxLayout.Children.Add(Graphics_Grid.Grid_Block("Mail :", user.Mail));
        //    BoxLayout.Children.Add(Graphics_Grid.Grid_Block("Civilité :", user.Civilite.CiviliteBool()));

        //    Employe employe = (Employe)user;
        //    //BoxLayout.Children.Add(Graphics_Grid.Grid_Block_Modifiable(ref poste, "Poste :", employe.Poste, "Poste", 3, Modifier_Utilisateur));
        //}

        //private void Inscription_Utilisateur(object sender, RoutedEventArgs e)
        //{
        //    TextBox nom = (TextBox)Actif_Controls[0];
        //    Border nomerror = (Border)Actif_Controls[1];
        //    TextBox prenom = (TextBox)Actif_Controls[2];
        //    Border prenomerror = (Border)Actif_Controls[3];
        //    TextBox mail = (TextBox)Actif_Controls[6];
        //    Border mailerror = (Border)Actif_Controls[7];
        //    TextBox remail = (TextBox)Actif_Controls[8];
        //    Border remailerror = (Border)Actif_Controls[9];
        //    PasswordBox password = (PasswordBox)Actif_Controls[10];
        //    Border passworderror = (Border)Actif_Controls[11];
        //    PasswordBox repassword = (PasswordBox)Actif_Controls[12];
        //    Border repassworderror = (Border)Actif_Controls[13];
        //    ComboBox civilite = (ComboBox)Actif_Controls[14];

        //    bool valid = true;

        //    if (nom.Text == "")
        //    {
        //        valid = false;
        //        nomerror.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        nomerror.Visibility = Visibility.Collapsed;
        //    }

        //    if (prenom.Text == "")
        //    {
        //        valid = false;
        //        prenomerror.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        prenomerror.Visibility = Visibility.Collapsed;
        //    }

        //    if (!IsValidEmail(mail.Text))
        //    {
        //        valid = false;
        //        mailerror.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        mailerror.Visibility = Visibility.Collapsed;
        //    }

        //    if (remail.Text != mail.Text)
        //    {
        //        valid = false;
        //        remailerror.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        remailerror.Visibility = Visibility.Collapsed;
        //    }

        //    if (password.Password.ToString().Length < 7)
        //    {
        //        valid = false;
        //        passworderror.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        passworderror.Visibility = Visibility.Collapsed;
        //    }

        //    if (repassword.Password.ToString() != password.Password.ToString())
        //    {
        //        valid = false;
        //        repassworderror.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        repassworderror.Visibility = Visibility.Collapsed;
        //    }

        //    if (valid)
        //    {
        //        if (!employes.EmployeExist(mail.Text))
        //        {
        //            Employe employe = new Employe();

        //            employe.Nom = nom.Text;
        //            employe.Prenom = prenom.Text;
        //            employe.Mail = mail.Text;
        //            employe.Civilite = civilite.Text.CiviliteToBoolean();
        //            //employe.Poste = "indéfinis";

        //            employes.AjouterEmploye(ref employe, password.Password.ToString());
        //            user = employe;

        //            VolsButton.Visibility = Visibility.Visible;
        //            MaintenanceButton.Visibility = Visibility.Visible;
        //            ClientButton.Visibility = Visibility.Visible;
        //        }

        //        ConnexionButton.Content = "Déconnecter";
        //        ConnexionButton.Click -= Connexion;
        //        ConnexionButton.Click += Deconnexion_Utilisateur;
        //        ProfilButton.Visibility = Visibility.Visible;

        //        Accueil();
        //    }
        //}

        //private void Connexion_Utilisateur(object sender, RoutedEventArgs e)
        //{
        //    TextBox mail = (TextBox)Actif_Controls[0];
        //    Border mailerror = (Border)Actif_Controls[1];
        //    PasswordBox password = (PasswordBox)Actif_Controls[2];
        //    Border passerror = (Border)Actif_Controls[3];


        //    mailerror.Visibility = Visibility.Collapsed;
        //    passerror.Visibility = Visibility.Collapsed;

        //    if (IsValidEmail(mail.Text))
        //    {
        //        if (employes.VerifierConnexion(mail.Text, password.Password.ToString()))
        //        {
        //            user = employes.Find(mail.Text);

        //            ConnexionButton.Content = "Déconnecter";
        //            ConnexionButton.Click -= Connexion;
        //            ConnexionButton.Click += Deconnexion_Utilisateur;
        //            ProfilButton.Visibility = Visibility.Visible;
        //            VolsButton.Visibility = Visibility.Visible;
        //            MaintenanceButton.Visibility = Visibility.Visible;
        //            ClientButton.Visibility = Visibility.Visible;

        //            Accueil();
        //        }
        //        else
        //        {
        //            passerror.Visibility = Visibility.Visible;
        //            mailerror.Visibility = Visibility.Visible;
        //        }
        //    }
        //    else
        //    {
        //        mailerror.Visibility = Visibility.Visible;
        //    }
        //}

        //private void Deconnexion_Utilisateur(object sender, RoutedEventArgs e)
        //{
        //    user = null;
        //    ConnexionButton.Content = "Connexion";
        //    ConnexionButton.Click -= Deconnexion_Utilisateur;
        //    ConnexionButton.Click += Connexion;
        //    ProfilButton.Visibility = Visibility.Collapsed;
        //    Accueil();
        //}

        //private void Modifier_Utilisateur(object sender, RoutedEventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    btn.Content = "sauvegarder";
        //    btn.Click -= Modifier_Utilisateur;
        //    btn.Click += Sauvegarder_Utilisateur;

        //    Grid grid = (Grid)btn.Parent;
        //    TextBlock block = (TextBlock)grid.Children[1];

        //    if (btn.Name != "Poste")
        //    {
        //        TextBox text = new TextBox();
        //        text.Text = block.Text;
        //        text.HorizontalAlignment = HorizontalAlignment.Left;
        //        text.Margin = new Thickness(150, 0, 0, 0);
        //        text.Width = 200;

        //        Actif_Controls.Insert((int)btn.Tag, text);
        //        grid.Children.Insert(1, text);
        //    }
        //    else
        //    {
        //        ComboBox combo = new ComboBox();
        //        combo.Text = block.Text;
        //        combo.ItemsSource = postes.Postes_Str;
        //        combo.SelectedIndex = postes.Find(block.Text);
        //        combo.VerticalAlignment = VerticalAlignment.Top;
        //        combo.HorizontalAlignment = HorizontalAlignment.Left;
        //        combo.Margin = new Thickness(150, 0, 0, 0);
        //        combo.Width = 200;

        //        Actif_Controls.Insert((int)btn.Tag, combo);
        //        grid.Children.Insert(1, combo);
        //    }


        //    Actif_Controls.Remove(block);
        //    grid.Children.Remove(block);

        //}

        //private void Sauvegarder_Utilisateur(object sender, RoutedEventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    btn.Content = "modifier";
        //    btn.Click -= Sauvegarder_Utilisateur;
        //    btn.Click += Modifier_Utilisateur;

        //    Grid grid = (Grid)btn.Parent;

        //    TextBlock block = new TextBlock();

        //    if (btn.Name != "Poste")
        //    {
        //        TextBox poste = (TextBox)grid.Children[1];

        //        string info = null;

        //        if (poste.Text != "")
        //        {

        //            block.Text = poste.Text;

        //            if (btn.Name == "Nom")
        //            {
        //                employes.ChangeNom(user, poste.Text);
        //            }
        //            else if (btn.Name == "Prenom")
        //            {
        //                employes.ChangePrenom(user, poste.Text);
        //            }

        //        }
        //        else
        //        {
        //            if (btn.Name == "Nom")
        //            {
        //                info = user.Nom;
        //            }
        //            else if (btn.Name == "Prenom")
        //            {
        //                info = user.Prenom;
        //            }

        //            block.Text = info;
        //        }

        //        Actif_Controls.Insert((int)btn.Tag, block);
        //        Actif_Controls.Remove(poste);

        //        grid.Children.Remove(poste);
        //        grid.Children.Insert(1, block);
        //    }
        //    else
        //    {
        //        ComboBox poste = (ComboBox)grid.Children[1];

        //        block.Text = poste.Text;

        //        Employe employe = (Employe)user;

        //        employes.ChangePoste(employe, postes.Find(poste.Text));

        //        Actif_Controls.Insert((int)btn.Tag, block);
        //        Actif_Controls.Remove(poste);

        //        grid.Children.Remove(poste);
        //        grid.Children.Insert(1, block);
        //    }


        //    block.HorizontalAlignment = HorizontalAlignment.Left;
        //    block.Margin = new Thickness(150, 0, 0, 0);
        //    block.Width = 200;
        //}




        ////___________________________________MAINTENANCES___________________________________

        //private void Maintenances()
        //{
        //    MainBoxPresentation("Maintenance");

        //    List<string> header = new List<string> { "Date", "Details", "Avion", "Aeroport" };
        //    DataGrid datagrid = Graphics_Grid.DataGrid<Maintenance>(maintenances.DataMaintenances, CellEditEndingMaintenance);
        //    datagrid.Columns.Add(Graphics_Grid.Column(header[0], header[0], false));
        //    datagrid.Columns.Add(Graphics_Grid.Column(header[1], header[1], false));
        //    datagrid.Columns.Add(Graphics_Grid.Column(header[2], "Avion", avions.Matricule));
        //    datagrid.Columns.Add(Graphics_Grid.Column(header[3], "Aeroport", aeroports.AITA));
        //    datagrid.Columns.Add(Graphics_Grid.Column("", "Supprimer", SupprimerMaintenance));

        //    Actif_Controls.Add(datagrid);

        //    BoxLayout.Children.Add(Graphics_Grid.Grid_Title("Maintenances"));
        //    BoxLayout.Children.Add(Graphics_Grid.Grid_Button("Ajouter +", "nouveau", Ajout_Maintenance));
        //    BoxLayout.Children.Add(datagrid);
        //}

            //{
        //    Maintenances();
        //}

        //private void Ajout_Maintenance(object sender, RoutedEventArgs e)
        //{
        //    MainBoxPresentation("Nouvelle Maintenance");

        //    DatePicker date = new DatePicker();
        //    Border errordate = new Border();
        //    TextBox txt = new TextBox();
        //    Border txterror = new Border();
        //    ComboBox combo = new ComboBox();
        //    ComboBox combo2 = new ComboBox();

        //    Actif_Controls.Add(date);
        //    Actif_Controls.Add(errordate);
        //    Actif_Controls.Add(txt);
        //    Actif_Controls.Add(txterror);
        //    Actif_Controls.Add(combo);
        //    Actif_Controls.Add(combo2);

        //    BoxLayout.Children.Add(Graphics_Grid.Grid_Title("Ajout Maintenance"));
        //    BoxLayout.Children.Add(Graphics_Grid.Grid_Date(ref date, "Date :", "date", ref errordate, "errordate", "Date invalide"));
        //    BoxLayout.Children.Add(Graphics_Grid.Grid_Text(ref txt, "Details :", "details", ref txterror, "error", "Champs vide"));
        //    BoxLayout.Children.Add(Graphics_Grid.Grid_Combo(ref combo, "Avion :", "combo", avions.Matricule));
        //    BoxLayout.Children.Add(Graphics_Grid.Grid_Combo(ref combo2, "Aéroport :", "combo2", aeroports.AITA));
        //    BoxLayout.Children.Add(Graphics_Grid.Grid_Button("Ajouter", "btn", Nouvelle_Maintenance));
        //}

        //{
        //    DatePicker date = (DatePicker)Actif_Controls[0];
        //    Border errordate = (Border)Actif_Controls[1];
        //    TextBox txt = (TextBox)Actif_Controls[2];
        //    Border txterror = (Border)Actif_Controls[3];
        //    ComboBox combo = (ComboBox)Actif_Controls[4];
        //    ComboBox combo2 = (ComboBox)Actif_Controls[5];

        //    bool check = true;

        //    if (date.Text == "")
        //    {
        //        errordate.Visibility = Visibility.Visible;
        //        check = false;
        //    }
        //    else
        //    {
        //        errordate.Visibility = Visibility.Collapsed;
        //    }

        //    if (txt.Text == "")
        //    {              
        //        txterror.Visibility = Visibility.Visible;
        //        check = false;
        //    }
        //    else
        //    {
        //        errordate.Visibility = Visibility.Collapsed;
        //    }

        //    if (check)
        //    {
        //        Maintenance maintenance = new Maintenance();
        //        maintenance.Date = date.Text;
        //        maintenance.Details = txt.Text;
        //        maintenance.Avion = combo.Text;
        //        maintenance.Aeroport = combo2.Text;

        //        maintenances.Nouveau(maintenance, avions.FindByMatricule(maintenance.Avion).Id, aeroports.FindByAITA(maintenance.Aeroport).Id);
        //        Maintenances();
        //    }
        //}

        //private void CellEditEndingMaintenance(object sender, DataGridCellEditEndingEventArgs e)
        //{
        //    if (e.EditAction == DataGridEditAction.Commit)
        //    {
        //        DataGridColumn column = e.Column;
        //        if (column != null)
        //        {
        //            string column_nom = (string)column.Header;
        //            int rowIndex = e.Row.GetIndex();
        //            TextBox el = e.EditingElement as TextBox;
        //            ComboBox el_combo = e.EditingElement as ComboBox;
        //            Maintenance maintenance = maintenances.Maintenance[rowIndex];
        //            DateTime dateTime;

        //            switch (column_nom)
        //            {
        //                case "Date":
        //                    if (DateTime.TryParse(el.Text, out dateTime))
        //                    {
        //                        maintenances.ChangeDate(ref maintenance, el.Text);
        //                    }
        //                    else
        //                    {
        //                        el.Text = maintenance.Date;
        //                    }
        //                    break;

        //                case "Details":
        //                    if (el.Text != "")
        //                    {
        //                        maintenances.ChangeDetails(ref maintenance, el.Text);
        //                    }
        //                    else
        //                    {
        //                        el.Text = maintenance.Details;
        //                    }
        //                    break;

        //                case "Avion":
        //                    maintenances.ChangeAvion(ref maintenance, avions.FindByMatricule(el_combo.Text));
        //                    break;

        //                case "Aeroport":
        //                    maintenances.ChangeAeroport(ref maintenance, aeroports.FindByAITA(el_combo.Text));
        //                    break;

        //                default:
        //                    break;
        //            }
        //        }
        //    }
        //}

        //private void SupprimerMaintenance(object sender, RoutedEventArgs e)
        //{
        //    int id = int.Parse(((Button)sender).CommandParameter.ToString());
        //    maintenances.Supprimer(id);
        //    Maintenances();
        //}

        
        ////___________________________________VERIFICATIONS________________________________________

        //private bool IsValidEmail(string email)
        //{
        //    try
        //    {
        //        var addr = new System.Net.Mail.MailAddress(email);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //private bool Numeric(string Receive)
        //{
        //    bool Result = false;
        //    if (Receive != "")
        //    {
        //        Result = true;
        //        foreach (char Char in Receive)
        //        {
        //            if (char.IsDigit(Char) == false)
        //            {
        //                Result = false;
        //            }
        //        }
        //    }

        //    return Result;
        //}
    }
}
