using System.Windows;
using System.Windows.Controls;
using WpfApp1.Class.Avion;
using WpfApp1.Class.Client;
using WpfApp1.Class.Maintenance;
using WpfApp1.Class.Vol;

namespace WpfApp1.Class.View
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Page
    {
        private Frame frame;
        private int id;

        public Accueil(Frame _frame, int _id)
        {
            InitializeComponent();
            frame = _frame;
            id = _id;
        }

        private void Vols(object sender, RoutedEventArgs e)
        {
            frame.Content = new VolPage(frame);
        }

        private void Maintenances(object sender, RoutedEventArgs e)
        {
            frame.Content = new MaintenancePage(id);
        }

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
    }
}
