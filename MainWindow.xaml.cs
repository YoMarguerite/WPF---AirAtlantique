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

        public delegate void RoutedEventHandler(object sender, RoutedEventArgs e);

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
            gridtitle.Margin = new Thickness(400, 0, 400, 0);
            DockPanel.SetDock(gridtitle, Dock.Top);

            return gridtitle;
        }

        private Grid Grid_Text(string str_lbl, string str_txt)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------TextBox-----------------
            TextBox txt = new TextBox();
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

        private Grid Grid_Pass(string str_lbl, string str_txt)
        {
            //-----------------------Label Pass----------------
            Label lblpass = new Label();
            lblpass.Content = str_lbl;
            lblpass.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------PassWordBox-----------------
            PasswordBox password = new PasswordBox();
            password.Name = str_txt;
            password.HorizontalAlignment = HorizontalAlignment.Right;
            password.Width = 200;


            //-----------------------Grid Pass-----------------
            Grid gridpass = new Grid();
            gridpass.Children.Add(lblpass);
            gridpass.Children.Add(password);
            gridpass.Margin = new Thickness(300, 10, 300, 0);
            DockPanel.SetDock(gridpass, Dock.Top);

            return gridpass;
        }

        private Grid Grid_Button(string str_content, string str_name)
        {
            //---------------------Button Connexion------------
            Button button = new Button();
            button.Content = str_content;
            button.Name = str_name;
            button.VerticalAlignment = VerticalAlignment.Top;
            button.HorizontalAlignment = HorizontalAlignment.Center;

            //--------------------Grid Connexion----------------
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

        private void Accueil()
        {
            //--------------------MainBox------------------
            MainBox.Header = "Accueil";
            BoxLayout.Children.Clear();


            //------------------Label Départ---------------
            Label lbldepart = new Label();
            lbldepart.Content = "Départ :";
            lbldepart.VerticalAlignment = VerticalAlignment.Center;
            lbldepart.HorizontalAlignment = HorizontalAlignment.Left;


            //------------------ComboBox Départ------------
            List<string> listItems = new List<string>();
            listItems.Add("Paris");
            listItems.Add("Nantes");
            ComboBox depart = new ComboBox();
            depart.ItemsSource = listItems;
            depart.VerticalAlignment = VerticalAlignment.Center;
            depart.HorizontalAlignment = HorizontalAlignment.Left;
            depart.Margin = new Thickness(80, 0, 0, 0);
            depart.Width = 100;


            //------------------Label Arrivée---------------
            Label lblarrive = new Label();
            lblarrive.Content = "Arrivée :";
            lblarrive.VerticalAlignment = VerticalAlignment.Center;
            lblarrive.HorizontalAlignment = HorizontalAlignment.Left;
            lblarrive.Margin = new Thickness(200, 0, 0, 0);


            //------------------ComboBox Arrivée-------------
            List<string> listItems2 = new List<string>();
            listItems2.Add("Vannes");
            listItems2.Add("Marseille");
            ComboBox arrive = new ComboBox();
            arrive.Text = "Destination";
            arrive.ItemsSource = listItems2;
            arrive.VerticalAlignment = VerticalAlignment.Center;
            arrive.HorizontalAlignment = HorizontalAlignment.Left;
            arrive.Margin = new Thickness(300, 0, 0, 0);
            arrive.Width = 100;

            //-------------------Button Envoi--------------
            Button envoi = new Button();
            envoi.Content = "Recherche";
            envoi.HorizontalContentAlignment = HorizontalAlignment.Center;
            envoi.VerticalAlignment = VerticalAlignment.Center;
            envoi.HorizontalAlignment = HorizontalAlignment.Right;
            envoi.Margin = new Thickness(0, 0, 10, 0);


            //-------------------TopGridBox----------------
            Grid topgridbox = new Grid();
            DockPanel.SetDock(topgridbox, Dock.Top);
            topgridbox.Children.Add(lbldepart);
            topgridbox.Children.Add(depart);
            topgridbox.Children.Add(lblarrive);
            topgridbox.Children.Add(arrive);
            topgridbox.Children.Add(envoi);
            topgridbox.Margin = new Thickness(200, 0, 200, 0);


            //-------------------LabelHoraire--------------
            Label lblhoraire = new Label();
            lblhoraire.Content = "Horaire:";
            lblhoraire.VerticalAlignment = VerticalAlignment.Center;
            lblhoraire.HorizontalAlignment = HorizontalAlignment.Left;
            lblhoraire.Margin = new Thickness(0, 0, 0, 0);


            //------------------TimeControl----------------
            TimeControl time = new TimeControl();
            time.VerticalAlignment = VerticalAlignment.Center;
            time.HorizontalAlignment = HorizontalAlignment.Left;
            time.Margin = new Thickness(80, 0, 0, 0);


            //------------------DatePicker----------------
            DatePicker horaire = new DatePicker();
            horaire.VerticalAlignment = VerticalAlignment.Center;
            horaire.HorizontalAlignment = HorizontalAlignment.Left;
            horaire.Margin = new Thickness(150, 0, 0, 0);


            //-------------------RadioButtons--------------
            RadioButton radio1 = new RadioButton();
            radio1.Name = "radiotime";
            radio1.Content = "partir à";
            RadioButton radio2 = new RadioButton();
            radio2.Name = "radiotime";
            radio2.Content = "arrivée à";


            //---------------------RadioPanel---------------
            StackPanel radios = new StackPanel();
            radios.Children.Add(radio1);
            radios.Children.Add(radio2);
            radios.HorizontalAlignment = HorizontalAlignment.Right;
            radios.Margin = new Thickness(0,0,10,0);


            //-------------------MidGridBox----------------
            Grid midgridbox = new Grid();
            DockPanel.SetDock(midgridbox, Dock.Top);
            midgridbox.Children.Add(lblhoraire);
            midgridbox.Children.Add(time);
            midgridbox.Children.Add(horaire);
            midgridbox.Children.Add(radios);
            midgridbox.Margin = new Thickness(200, 0, 200, 0);


            //-------------------BotGridBox----------------
            Grid botgridbox = new Grid();
            DockPanel.SetDock(botgridbox, Dock.Bottom);


            //-------------------BoxLayout-----------------
            BoxLayout.Children.Clear();
            BoxLayout.Children.Add(topgridbox);
            BoxLayout.Children.Add(midgridbox);
            BoxLayout.Children.Add(botgridbox);
        }

        private void Accueil(object sender, RoutedEventArgs e)
        {

            Accueil();
            
        }

        private void Connexion(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Connexion";
            BoxLayout.Children.Clear();

            RoutedEventHandler action = Inscription;

            BoxLayout.Children.Add(Grid_Title("CONNEXION"));
            BoxLayout.Children.Add(Grid_Text("Mail :", "txtmail"));
            BoxLayout.Children.Add(Grid_Pass("Mot de passe :", "txtpass"));
            BoxLayout.Children.Add(Grid_Button("Connexion", "btnconnexion"));
            BoxLayout.Children.Add(Grid_Btn_Link("Inscription", "btninscription", action));

        }

        private void Inscription(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Inscription";
            BoxLayout.Children.Clear();

            RoutedEventHandler action = Connexion;

            BoxLayout.Children.Add(Grid_Title("INSCRIPTION"));
            BoxLayout.Children.Add(Grid_Text("Nom :", "txtnom"));
            BoxLayout.Children.Add(Grid_Text("Prénom :", "txtprenom"));
            BoxLayout.Children.Add(Grid_Text("Mail :", "txtmail"));
            BoxLayout.Children.Add(Grid_Text("Confirmation :", "txtremail"));
            BoxLayout.Children.Add(Grid_Pass("Mot de passe :", "txtpass"));
            BoxLayout.Children.Add(Grid_Pass("Confirmation :", "txtrepass"));
            BoxLayout.Children.Add(Grid_Button("Inscription", "btninscription"));
            BoxLayout.Children.Add(Grid_Btn_Link("Connexion", "btnconnexion", action));

        }

        private void Maintenance(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Maintenance";
        }

        private void Vols(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Vols";
        }
    }
}
