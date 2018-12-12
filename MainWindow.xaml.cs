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

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        {
        static DAO_Utilisateur bdd_users= new DAO_Utilisateur();
        static Utilisateur user;
        static List<object> Actif_Controls = new List<object>();

        private delegate void RoutedEventHandler(object sender, RoutedEventArgs e);

        public MainWindow(){ 

            InitializeComponent();
            Accueil();
        }

        private Grid Grid_Title(string str_title)
        {
            //-----------------Label Title----------
            Label title = new Label();
            title.Content = str_title;
            title.HorizontalAlignment = HorizontalAlignment.Center;
            title.VerticalAlignment = VerticalAlignment.Top;


            //-----------------Grid Title-----------
            Grid gridtitle = new Grid();
            gridtitle.Children.Add(title);
            gridtitle.Margin = new Thickness(300, 0, 300, 0);
            DockPanel.SetDock(gridtitle, Dock.Top);

            return gridtitle;
        }

        private Grid Grid_Text(ref TextBox txt, string str_lbl, string str_txt)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------TextBox-----------------
            txt.Name = str_txt;
            txt.HorizontalAlignment = HorizontalAlignment.Left;
            txt.Margin = new Thickness(150, 0, 0, 0);
            txt.Width = 200;


            //-----------------------Grid-----------------
            Grid grid = new Grid();


            grid.Children.Add(lbl);
            grid.Children.Add(txt);
            grid.Margin = new Thickness(300, 10, 0, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        private Grid Grid_Text(ref TextBox txt, string str_lbl, string str_txt, ref Border borderror, string str_error, string str_error_txt)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------TextBox-----------------
            txt.Name = str_txt;
            txt.HorizontalAlignment = HorizontalAlignment.Left;
            txt.Margin = new Thickness(150, 0, 0, 0);
            txt.Width = 200;


            //-----------------------Grid-----------------
            Grid grid = new Grid();
            

            grid.Children.Add(lbl);
            grid.Children.Add(txt);
            grid.Children.Add(Block_Error(borderror, str_error, str_error_txt));
            grid.Margin = new Thickness(300, 10, 0, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        private Grid Grid_Pass(ref PasswordBox txt, string str_lbl, string str_txt, ref Border borderror, string str_error, string str_error_txt)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------TextBox-----------------
            txt.Name = str_txt;
            txt.HorizontalAlignment = HorizontalAlignment.Left;
            txt.Margin = new Thickness(150, 0, 0, 0);
            txt.Width = 200;


            //-----------------------Grid-----------------
            Grid grid = new Grid();


            grid.Children.Add(lbl);
            grid.Children.Add(txt);
            grid.Children.Add(Block_Error(borderror, str_error, str_error_txt));
            grid.Margin = new Thickness(300, 10, 0, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        private Border Block_Error(Border borderror, string str_error, string str_error_txt)
        {
            //--------------------Error TextBlock------------
            TextBlock error = new TextBlock();
            error.Name = str_error;
            error.Text = str_error_txt;
            error.Foreground = Brushes.Red;
            error.HorizontalAlignment = HorizontalAlignment.Center;
            error.VerticalAlignment = VerticalAlignment.Center;

            
            //--------------------Error TextBlock-------------
            borderror.BorderThickness = new Thickness(1);
            borderror.BorderBrush = Brushes.Red;
            borderror.Child = error;
            borderror.HorizontalAlignment = HorizontalAlignment.Left;
            borderror.Margin = new Thickness(400, 0, 0, 0);
            borderror.Width = 200;
            borderror.Visibility = Visibility.Collapsed;

            return borderror;
        }

        private Grid Grid_Combo(string str_lbl, string str_txt, List<string> listItems)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------ComboBox-----------------
            ComboBox combo = new ComboBox();
            combo.ItemsSource = listItems;
            combo.Name = str_txt;
            combo.HorizontalAlignment = HorizontalAlignment.Right;
            combo.Width = 200;


            //-----------------------Grid-----------------
            Grid grid = new Grid();
            grid.Children.Add(lbl);
            grid.Children.Add(combo);
            grid.Margin = new Thickness(300, 10, 300, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        private Grid Grid_Time(string str_lbl, string str_txt)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------TimeControl-----------------
            TimeControl txt = new TimeControl();
            txt.Name = str_txt;
            txt.HorizontalAlignment = HorizontalAlignment.Right;
            txt.Width = 200;


            //-----------------------Grid-----------------
            Grid grid = new Grid();
            grid.Children.Add(lbl);
            grid.Children.Add(txt);
            grid.Margin = new Thickness(300, 10, 300, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        private Grid Grid_Date(ref DatePicker date,string str_lbl, string str_txt)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------DatePicker-----------------
            date.Name = str_txt;
            date.HorizontalAlignment = HorizontalAlignment.Left;
            date.Margin = new Thickness(150, 0, 0, 0);
            date.Width = 200;


            //-----------------------Grid-----------------
            Grid grid = new Grid();
            grid.Children.Add(lbl);
            grid.Children.Add(date);
            grid.Margin = new Thickness(300, 10, 300, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        private Grid Grid_Button(string str_content, string str_name, RoutedEventHandler action)
        {
            //---------------------Button------------
            Button button = new Button();
            button.Click += new System.Windows.RoutedEventHandler(action);
            button.Content = str_content;
            button.Name = str_name;
            button.VerticalAlignment = VerticalAlignment.Top;
            button.HorizontalAlignment = HorizontalAlignment.Center;

            //--------------------Grid----------------
            Grid gridbutton = new Grid();
            gridbutton.Children.Add(button);
            gridbutton.Margin = new Thickness(400, 10, 400, 0);
            DockPanel.SetDock(gridbutton, Dock.Top);

            return gridbutton;
        }

        private Grid Grid_Btn_Link(string str_content, string str_name, RoutedEventHandler action)
        {
            //---------------------Button---------------------
            Button button = new Button();
            button.Click += new System.Windows.RoutedEventHandler(action);
            button.Content = str_content;
            button.BorderBrush = Brushes.Transparent;
            button.Background = Brushes.Transparent;
            button.Foreground = Brushes.LightSkyBlue;
            button.VerticalAlignment = VerticalAlignment.Top;
            button.HorizontalAlignment = HorizontalAlignment.Center;


            //--------------------Grid-----------------------
            Grid grid = new Grid();
            grid.Children.Add(button);
            grid.Margin = new Thickness(400, 10, 400, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        private Grid Grid_Radio(List<string> listradio, string str_name)
        {
            Grid grid = new Grid();
            grid.Margin = new Thickness(200, 10, 200, 0);
            DockPanel.SetDock(grid, Dock.Top);
            ColumnDefinition coldef;

            for (int i = 0; i < 2; i++)
            {
                coldef = new ColumnDefinition();
                coldef.Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions.Add(coldef);
            }

            RowDefinition rowdef;
            int index = 0;


            foreach (string radio_content in listradio)
            {
                RadioButton radio = new RadioButton();
                radio.Content = radio_content;
                radio.Name = str_name;
                radio.HorizontalAlignment = HorizontalAlignment.Left;

                rowdef = new RowDefinition();
                rowdef.Height = new GridLength(30);
                grid.RowDefinitions.Add(rowdef);
                Grid.SetRow(radio, index);
                Grid.SetColumn(radio, 1);
                grid.Children.Add(radio);

                index++;
            }

            return grid;
        }

        private Grid Grid_Block(string str_lbl, string str_txt)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------TextBlock-----------------
            TextBlock txt = new TextBlock();
            txt.Text = str_txt;
            txt.HorizontalAlignment = HorizontalAlignment.Left;
            txt.Margin = new Thickness(150, 0, 0, 0);
            txt.Width = 200;


            //-----------------------Grid-----------------
            Grid grid = new Grid();


            grid.Children.Add(lbl);
            grid.Children.Add(txt);
            grid.Margin = new Thickness(300, 10, 0, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        private Grid Grid_Block_Modifiable(ref TextBlock txt, string str_lbl, string str_txt, string str_nom, int index)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------TextBlock-----------------
            txt.Text = str_txt;
            txt.HorizontalAlignment = HorizontalAlignment.Left;
            txt.Margin = new Thickness(150, 0, 0, 0);
            txt.Width = 200;


            //---------------------Modifier----------------
            Button btn = new Button();
            btn.Content = "modifier";
            btn.Name = str_nom;
            btn.Tag = index;
            btn.Click += Modifier_Utilisateur;
            btn.VerticalAlignment = VerticalAlignment.Top;
            btn.HorizontalAlignment = HorizontalAlignment.Left;
            btn.Margin = new Thickness(400, 0, 0, 0);


            //-----------------------Grid-----------------
            Grid grid = new Grid();


            grid.Children.Add(lbl);
            grid.Children.Add(txt);
            grid.Children.Add(btn);
            grid.Margin = new Thickness(300, 10, 0, 0);
            DockPanel.SetDock(grid, Dock.Top);

            return grid;
        }

        private Grid Grid_Table_Page(List<TextBlock> listblocks)
        {
            Grid grid = new Grid();
            grid.Margin = new Thickness(100, 10, 100, 0);
            DockPanel.SetDock(grid, Dock.Top);
            ColumnDefinition coldef;
            RowDefinition rowdef;
            Border border;

            for (int i = 0; i < 10; i++)
            {
                rowdef = new RowDefinition();
                rowdef.Height = new GridLength(30, GridUnitType.Pixel);
                grid.RowDefinitions.Add(rowdef);

            }

            for (int i = 0; i < listblocks.Count+1; i++)
            {
                coldef = new ColumnDefinition();
                coldef.Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions.Add(coldef);

                if(i < listblocks.Count)
                {
                    border = new Border();
                    border.BorderBrush = Brushes.Black;
                    border.BorderThickness = new Thickness(1);
                    Grid.SetColumn(border, i);
                    Grid.SetRow(border, 0);

                    border.Child = listblocks[i];

                    grid.Children.Add(border);

                }
                else
                {
                    Button btn = new Button();
                    btn.Content = "modifier";
                    Grid.SetColumn(btn, i);
                    Grid.SetRow(btn, 0);
                    grid.Children.Add(btn);
                }
                
            }

            


            return grid;
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
            List<string> listradio = new List<string>();
            listradio.Add("départ à");
            listradio.Add("arrivé à");


            RoutedEventHandler action = Accueil;


            //-------------------BoxLayout-----------------
            BoxLayout.Children.Clear();
            BoxLayout.Children.Add(Grid_Title("RECHERCHER UN VOL"));
            BoxLayout.Children.Add(Grid_Combo("Départ :", "combdepart", listItems));
            BoxLayout.Children.Add(Grid_Combo("Arrivée :", "combarrive", listItems2));
            //BoxLayout.Children.Add(Grid_Date("Date :", "date"));
            BoxLayout.Children.Add(Grid_Time("Heure :", "heure"));
            BoxLayout.Children.Add(Grid_Radio(listradio, "radio"));
            BoxLayout.Children.Add(Grid_Button("Recherche", "btnrecherche", action));
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


            RoutedEventHandler action = Connexion_Utilisateur;
            RoutedEventHandler action2 = Inscription;

            
            BoxLayout.Children.Add(Grid_Title("CONNEXION"));
            BoxLayout.Children.Add(Grid_Text(ref mail, "Mail :", "txtmail", ref mailerror, "errormail", "Mail invalide"));
            BoxLayout.Children.Add(Grid_Pass(ref password, "Mot de passe :", "txtpass", ref passerror, "errorpass", "Mot de passe invalide"));
            BoxLayout.Children.Add(Grid_Button("Connexion", "btnconnexion", action));
            BoxLayout.Children.Add(Grid_Btn_Link("Inscription", "btninscription", action2));

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

            RoutedEventHandler action = Inscription_Utilisateur;
            RoutedEventHandler action2 = Connexion;

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


            BoxLayout.Children.Add(Grid_Title("INSCRIPTION"));
            BoxLayout.Children.Add(Grid_Text(ref nom, "Nom :", "txtnom", ref nomerror, "errornom", "Champs invalide"));
            BoxLayout.Children.Add(Grid_Text(ref prenom, "Prénom :", "txtprenom", ref prenomerror,  "errorprenom", "Champs invalide"));
            BoxLayout.Children.Add(Grid_Date(ref date, "Naissance :", "date"));
            BoxLayout.Children.Add(Grid_Text(ref adresse, "Adresse :", "adresse"));
            BoxLayout.Children.Add(Grid_Text(ref mail, "Mail :", "txtmail", ref mailerror, "errormail", "Mail invalide"));
            BoxLayout.Children.Add(Grid_Text(ref remail, "Confirmation :", "txtremail", ref remailerror, "errorremail", "Ne corresponds pas"));
            BoxLayout.Children.Add(Grid_Pass(ref password, "Mot de passe :", "txtpass", ref passworderror, "errorpass", "Mot de passe invalide"));
            BoxLayout.Children.Add(Grid_Pass(ref repassword, "Confirmation :", "txtrepass", ref repassworderror, "errorrepass", "Ne corresponds pas"));
            BoxLayout.Children.Add(Grid_Button("Inscription", "btninscription", action));
            BoxLayout.Children.Add(Grid_Btn_Link("Connexion", "btnconnexion", action2));
        }

        private void Profil(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Profil";
            BoxLayout.Children.Clear();
            Actif_Controls.Clear();

            TextBlock nom = new TextBlock();
            TextBlock prenom = new TextBlock();
            TextBlock adresse = new TextBlock();

            Actif_Controls.Add(nom);
            Actif_Controls.Add(prenom);
            Actif_Controls.Add(adresse);

            BoxLayout.Children.Add(Grid_Title("PROFIL"));
            BoxLayout.Children.Add(Grid_Block_Modifiable(ref nom, "Nom :", user.Nom, "Nom", 0));
            BoxLayout.Children.Add(Grid_Block_Modifiable(ref prenom, "Prenom :", user.Prenom, "Prenom", 1));
            BoxLayout.Children.Add(Grid_Block_Modifiable(ref adresse, "Adresse :", user.Adresse, "Adresse", 2));
            BoxLayout.Children.Add(Grid_Block("Mail :", user.Mail));
            BoxLayout.Children.Add(Grid_Block("Naissance :", user.Naissance));
            BoxLayout.Children.Add(Grid_Block("Fidélité :", user.Fidelite + " points"));

        }

        private void Maintenance(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Maintenance";
            BoxLayout.Children.Clear();

            List<TextBlock> listblocks = new List<TextBlock>();
            for(int i = 0; i<5; i++)
            {
                listblocks.Add(new TextBlock());
            }
            listblocks[0].Text = "Avion";
            listblocks[1].Text = "Cause";
            listblocks[2].Text = "Tâches";
            listblocks[3].Text = "Description";
            listblocks[4].Text = "Date";

            BoxLayout.Children.Add(Grid_Title("Toutes les maintenances"));
            BoxLayout.Children.Add(Grid_Table_Page(listblocks));
            BoxLayout.Children.Add(Grid_Title("Hey"));
        }

        private void Vols(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Vols";
            BoxLayout.Children.Clear();
        }

        private void Inscription_Utilisateur(object sender, RoutedEventArgs e)
        {
            TextBox nom = (TextBox)Actif_Controls[0];
            Border nomerror = (Border)Actif_Controls[1];
            TextBox prenom = (TextBox)Actif_Controls[2];
            Border prenomerror = (Border)Actif_Controls[3];
            DatePicker date = (DatePicker)Actif_Controls[4];
            TextBox adresse = (TextBox)Actif_Controls[5];
            TextBox mail = (TextBox)Actif_Controls[6];
            Border mailerror = (Border)Actif_Controls[7];
            TextBox remail = (TextBox)Actif_Controls[8];
            Border remailerror = (Border)Actif_Controls[9];
            PasswordBox password = (PasswordBox)Actif_Controls[10];
            Border passworderror = (Border)Actif_Controls[11];
            PasswordBox repassword = (PasswordBox)Actif_Controls[12];
            Border repassworderror = (Border)Actif_Controls[13];
            
            bool valid = true;

            if(nom.Text == "")
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
                    
                }
                else
                {
                    if (!bdd_users.SelectMail(mail.Text))
                    {
                        user = new Utilisateur();
                        user.Nom = nom.Text;
                        user.Prenom = prenom.Text;
                        user.Adresse = adresse.Text;
                        user.Naissance = date.Text;
                        user.Mail = mail.Text;
                        user.Fidelite = 0;
                        user.ID = bdd_users.InsertUtilisateur(user, password.Password.ToString());

                        ConnexionButton.Content = "Déconnecter";
                        ConnexionButton.Click -= Connexion;
                        ConnexionButton.Click += Deconnexion_Utilisateur;
                        ProfilButton.Visibility = Visibility.Visible;
                    }
                }
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
                    
                }
                else
                {
                    if (bdd_users.SelectMotDePasse(mail.Text, password.Password.ToString()))
                    {
                        ConnexionButton.Content = "Déconnecter";
                        ConnexionButton.Click -= Connexion;
                        ConnexionButton.Click += Deconnexion_Utilisateur;
                        ProfilButton.Visibility = Visibility.Visible;

                        string info = bdd_users.SelectUtilisateur(mail.Text);
                        if(info == null)
                        {
                            string[] infos = info.Split(';');
                            string date = infos[5].Split(' ')[0];
                            user = new Utilisateur(int.Parse(infos[0]), int.Parse(infos[6]), infos[1], infos[2], infos[3], infos[4], date, bool.Parse(infos[7]));

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
                        passerror.Visibility = Visibility.Visible;
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

            TextBox text = new TextBox();
            text.Text = block.Text;
            text.HorizontalAlignment = HorizontalAlignment.Left;
            text.Margin = new Thickness(150, 0, 0, 0);
            text.Width = 200;

            Actif_Controls.Insert((int)btn.Tag, text);
            Actif_Controls.Remove(block);

            grid.Children.Remove(block);
            grid.Children.Insert(1, text);
        }

        private void Sauvegarder_Utilisateur(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Content = "modifier";
            btn.Click -= Sauvegarder_Utilisateur;
            btn.Click += Modifier_Utilisateur;

            Grid grid = (Grid)btn.Parent;
            TextBox text = (TextBox)grid.Children[1];

            TextBlock block = new TextBlock();

            string info = null;
            
            if (text.Text != "")
            {
                block.Text = text.Text;
                if (btn.Name == "Nom")
                {
                    bdd_users.UpdateUtilisateurNom(user.ID, text.Text);
                }
                else if (btn.Name == "Prenom")
                {
                    bdd_users.UpdateUtilisateurPrenom(user.ID, text.Text);
                }
                else if (btn.Name == "Adresse")
                {
                    bdd_users.UpdateUtilisateurAdresse(user.ID, text.Text);
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
                else if (btn.Name == "Adresse")
                {
                    info = user.Adresse;
                }
                block.Text = info;
            }
            
            
            
            block.HorizontalAlignment = HorizontalAlignment.Left;
            block.Margin = new Thickness(150, 0, 0, 0);
            block.Width = 200;

            Actif_Controls.Remove(text);
            Actif_Controls.Insert((int)btn.Tag, block);

            grid.Children.Remove(text);
            grid.Children.Insert(1, block);

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
    }
}
