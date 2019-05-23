using System.Windows;
using System.Windows.Controls;
<<<<<<< HEAD
using WpfApp1.Class.Avion;
using WpfApp1.Class.Client;
using WpfApp1.Class.Maintenance;
using WpfApp1.Class.Vol;
=======
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
>>>>>>> parent of 5cb955e... ça avance

namespace WpfApp1.Class.View
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Page
    {
<<<<<<< HEAD
        private Frame frame;
        private int id;

        public Accueil(Frame _frame, int _id)
        {
            InitializeComponent();
            frame = _frame;
            id = _id;
=======
        public Accueil()
        {
            InitializeComponent();
>>>>>>> parent of 5cb955e... ça avance
        }

        private void Vols(object sender, RoutedEventArgs e) { }

        private void Maintenances(object sender, RoutedEventArgs e)
        {
            frame.Content = new MaintenancePage(id);
        }

<<<<<<< HEAD
        private void Clients(object sender, RoutedEventArgs e)
        {
            frame.Content = new ClientPage(frame);
        }

        private void Avions(object sender, RoutedEventArgs e)
        {
            frame.Content = new AvionPage();
        }

        private void Aeroports(object sender, RoutedEventArgs e)
        {
            frame.Content = new AeroportPage();
        }
=======
        private void Clients(object sender, RoutedEventArgs e) { }
>>>>>>> parent of 5cb955e... ça avance
    }
}
