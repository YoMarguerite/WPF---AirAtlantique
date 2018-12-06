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

        public MainWindow(){ 

            InitializeComponent();
        }

        void Event(object sender, MouseButtonEventArgs e)
        {
            ListBox lboxPile = sender as ListBox;
            string texteSelectionne = lboxPile.SelectedItem as string;


            switch (texteSelectionne)
            {
                case ("Maintenance"):
                    //Maintenance();

                    break;
                case ("Vols"):
                    //Vols();

                    break;

            }
        }

        private void Accueil(object sender, RoutedEventArgs e)
        {
            //--------------------MainBox------------------
            MainBox.Header = "Accueil";
            BoxLayout.Children.Clear();


            //------------------Label Départ---------------
            Label lbldepart = new Label();
            lbldepart.Content = "Départ :";
            lbldepart.VerticalAlignment = VerticalAlignment.Top;
            lbldepart.HorizontalAlignment = HorizontalAlignment.Left;
            lbldepart.Margin = new Thickness(0, 0, 0, 0);


            //------------------ComboBox Départ------------
            List<string> listItems = new List<string>();
            listItems.Add("Paris");
            listItems.Add("Nantes");
            ComboBox depart = new ComboBox();
            depart.ItemsSource = listItems;
            depart.VerticalAlignment = VerticalAlignment.Top;
            depart.HorizontalAlignment = HorizontalAlignment.Left;
            depart.Margin = new Thickness(80, 0, 0, 0);
            depart.Width = 100;


            //------------------Label Arrivée---------------
            Label lblarrive = new Label();
            lblarrive.Content = "Arrivée :";
            lblarrive.VerticalAlignment = VerticalAlignment.Top;
            lblarrive.HorizontalAlignment = HorizontalAlignment.Left;
            lblarrive.Margin = new Thickness(200, 0, 0, 0);


            //------------------ComboBox Arrivée-------------
            List<string> listItems2 = new List<string>();
            listItems2.Add("Vannes");
            listItems2.Add("Marseille");
            ComboBox arrive = new ComboBox();
            arrive.Text = "Destination";
            arrive.ItemsSource = listItems2;
            arrive.VerticalAlignment = VerticalAlignment.Top;
            arrive.HorizontalAlignment = HorizontalAlignment.Left;
            arrive.Margin = new Thickness(300, 0, 0, 0);
            arrive.Width = 100;


            //-------------------Button Envoi--------------
            Button envoi = new Button();
            envoi.Content = "OK";
            envoi.HorizontalContentAlignment = HorizontalAlignment.Center;
            envoi.VerticalAlignment = VerticalAlignment.Top;
            envoi.HorizontalAlignment = HorizontalAlignment.Right;
            envoi.Width = 60;


            //-------------------TopGridBox----------------
            Grid topgridbox = new Grid();
            DockPanel.SetDock(topgridbox, Dock.Top);
            topgridbox.Children.Add(lbldepart);
            topgridbox.Children.Add(depart);
            topgridbox.Children.Add(lblarrive);
            topgridbox.Children.Add(arrive);
            topgridbox.Children.Add(envoi);
            topgridbox.Margin = new Thickness(200, 0, 200, 0);
            //UOHDIUHDIULHDLHILDUIDILH/DHUIDHILDHILUDHNLIDHUIHDLHDHUJLDHULIDHLDHLDLHIUDLHLIDUHUIDHIDHLIDHUIDHDUIUHD
            topgridbox.Background = Brushes.Red;


            //-------------------LabelHoraire--------------
            Label lblhoraire = new Label();
            lblhoraire.Content = "Horaire :";
            lblhoraire.VerticalAlignment = VerticalAlignment.Top;
            lblhoraire.HorizontalAlignment = HorizontalAlignment.Left;
            lblhoraire.Margin = new Thickness(0, 0, 0, 0);



            //------------------DatePicker----------------
            DatePicker horaire = new DatePicker();
            horaire.VerticalAlignment = VerticalAlignment.Top;
            horaire.HorizontalAlignment = HorizontalAlignment.Left;
            horaire.Margin = new Thickness(80, 0, 0, 0);


            //------------------TimeControl----------------
            //TimeControl time = new TimeControl();
            //time.VerticalAlignment = VerticalAlignment.Top;
            //time.HorizontalAlignment = HorizontalAlignment.Left;
            //time.Margin = new Thickness(400, 0, 0, 0);


            //-------------------MidGridBox----------------
            Grid midgridbox = new Grid();
            DockPanel.SetDock(midgridbox, Dock.Top);
            midgridbox.Children.Add(lblhoraire);
            midgridbox.Children.Add(horaire);
            //midgridbox.Children.Add(time);
            midgridbox.Margin = new Thickness(200, 0, 200, 0);
            //UOHDIUHDIULHDLHILDUIDILH/DHUIDHILDHILUDHNLIDHUIHDLHDHUJLDHULIDHLDHLDLHIUDLHLIDUHUIDHIDHLIDHUIDHDUIUHD
            midgridbox.Background = Brushes.Blue;


            //-------------------BotGridBox----------------
            Grid botgridbox = new Grid();
            DockPanel.SetDock(botgridbox, Dock.Bottom);


            //-------------------BoxLayout-----------------
            BoxLayout.Children.Clear();
            BoxLayout.Children.Add(topgridbox);
            BoxLayout.Children.Add(midgridbox);
            BoxLayout.Children.Add(botgridbox);



        }

        private void Connexion(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Connexion";
            BoxLayout.Children.Clear();
        }

        private void Inscription(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Inscription";
        }

        private void Maintenance(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Maintenance";
        }

        private void Vols(object sender, RoutedEventArgs e)
        {
            MainBox.Header = "Vols";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
