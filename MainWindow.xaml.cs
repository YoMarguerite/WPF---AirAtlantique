using System.Collections.Generic;
using System.Windows;
using WpfApp1.Class;
using WpfApp1.Class.Billet;
using WpfApp1.Class.Employe;
using WpfApp1.Class.Maintenance;
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

        public Employe user = null;

        public MainWindow(){ 

            InitializeComponent();
            Main.Content = new Connexion(this);
        }

        private void Accueil(object sender, RoutedEventArgs e)
        {
            if (user != null)
            {
                Main.Content = new Accueil(Main, user.Id);
            }
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void ConnexionValider(Employe _employe)
        {
            user = _employe;
            if(user != null)
            {
                Main.Content = new Accueil(Main, user.Id);
            }
        }
    }
}
