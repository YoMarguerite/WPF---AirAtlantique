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
using WpfApp1.Class.Avion;
using WpfApp1.Class.Client;
using WpfApp1.Class.Vol;

namespace WpfApp1.Class.View
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : Page
    {
        private Frame frame;

        public Accueil(Frame _frame)
        {
            InitializeComponent();
            frame = _frame;
        }

        private void Vols(object sender, RoutedEventArgs e)
        {
            frame.Content = new VolPage(frame);
        }

        private void Maintenances(object sender, RoutedEventArgs e) { }

        private void Clients(object sender, RoutedEventArgs e)
        {
            frame.Content = new ClientPage();
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
