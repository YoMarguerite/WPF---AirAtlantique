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
            gridtitle.Margin = new Thickness(300, 0, 300, 0);
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


            //---------------------TextBox-----------------
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

        private Grid Grid_Date(string str_lbl, string str_txt)
        {
            //-----------------------Label----------------
            Label lbl = new Label();
            lbl.Content = str_lbl;
            lbl.HorizontalAlignment = HorizontalAlignment.Left;


            //---------------------TextBox-----------------
            DatePicker txt = new DatePicker();
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

        private Grid Grid_Radio(List<string> listradio, string str_name)
        {
            Grid grid = new Grid();
            grid.Margin = new Thickness(400, 10, 400, 0);
            DockPanel.SetDock(grid, Dock.Top);
            RowDefinition rowdef;
            int index = 0;

            foreach (string radio_content in listradio)
            {
                RadioButton radio = new RadioButton();
                radio.Content = radio_content;
                radio.Name = str_name;

                rowdef = new RowDefinition();
                rowdef.Height = new GridLength(30);
                grid.RowDefinitions.Add(rowdef);
                Grid.SetRow(radio, index);
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


            //------------------ComboBox Départ------------
            List<string> listItems = new List<string>();
            listItems.Add("Paris");
            listItems.Add("Nantes");


            //------------------ComboBox Arrivée-------------
            List<string> listItems2 = new List<string>();
            listItems2.Add("Vannes");
            listItems2.Add("Marseille");


            List<string> listradio = new List<string>();
            listradio.Add("départ à");
            listradio.Add("arrivé à");


            //-------------------BoxLayout-----------------
            BoxLayout.Children.Clear();
            BoxLayout.Children.Add(Grid_Title("RECHERCHER UN VOL"));
            BoxLayout.Children.Add(Grid_Combo("Départ :", "combdepart", listItems));
            BoxLayout.Children.Add(Grid_Combo("Arrivée :", "combarrive", listItems2));
            BoxLayout.Children.Add(Grid_Date("Date :", "date"));
            BoxLayout.Children.Add(Grid_Time("Heure :", "heure"));
            BoxLayout.Children.Add(Grid_Radio(listradio, "radio"));
            BoxLayout.Children.Add(Grid_Button("Recherche", "btnrecherche"));
            //BoxLayout.Children.Add(midgridbox);
            //BoxLayout.Children.Add(botgridbox);
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
