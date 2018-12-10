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
        static BDD bdd = new BDD();
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
            date.HorizontalAlignment = HorizontalAlignment.Right;
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


            RoutedEventHandler action = Profil;
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
            BoxLayout.Children.Add(Grid_Text(ref mail, "Mail :", "txtmail", ref mailerror, "errormail", "Mail invalide"));
            BoxLayout.Children.Add(Grid_Text(ref remail, "Confirmation :", "txtremail", ref remailerror, "errorremail", "Ne corresponds pas"));
            BoxLayout.Children.Add(Grid_Pass(ref password, "Mot de passe :", "txtpass", ref passworderror, "errorpass", "Mot de passe invalide"));
            BoxLayout.Children.Add(Grid_Pass(ref repassword, "Confirmation :", "txtrepass", ref repassworderror, "errorrepass", "Ne corresponds pas"));
            BoxLayout.Children.Add(Grid_Button("Inscription", "btninscription", action));
            BoxLayout.Children.Add(Grid_Btn_Link("Connexion", "btnconnexion", action2));
        }

        private void Profil(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            Border mailerror = Actif_Controls[1] as Border;
            mailerror.Visibility = Visibility.Visible;

        }

        private void MesVols(object sender, RoutedEventArgs e) { }

        private void Maintenance(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Maintenance";
        }

        private void Vols(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Vols";
        }

        private void Inscription_Utilisateur(object sender, RoutedEventArgs e)
        {
            TextBox nom = (TextBox)Actif_Controls[0];
            Border nomerror = (Border)Actif_Controls[1];
            TextBox prenom = (TextBox)Actif_Controls[2];
            Border prenomerror = (Border)Actif_Controls[3];
            DatePicker date = (DatePicker)Actif_Controls[4];
            TextBox mail = (TextBox)Actif_Controls[5];
            Border mailerror = (Border)Actif_Controls[6];
            TextBox remail = (TextBox)Actif_Controls[7];
            Border remailerror = (Border)Actif_Controls[8];
            PasswordBox password = (PasswordBox)Actif_Controls[9];
            Border passworderror = (Border)Actif_Controls[10];
            PasswordBox repassword = (PasswordBox)Actif_Controls[11];
            Border repassworderror = (Border)Actif_Controls[12];
            
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
                Accueil();
            }
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
    }
}
