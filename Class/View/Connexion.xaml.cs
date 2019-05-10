using System.Windows;
using System.Windows.Controls;
using WpfApp1.Class.Extensions;
using WpfApp1.Class.ViewModel;

namespace WpfApp1.Class.View
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Page
    {
        MainWindow window;
        DAO_Employe employes;

        public Connexion(MainWindow _window, DAO_Employe _employes)
        {
            InitializeComponent();
            window = _window;
            employes = _employes;
        }

        private void Connexion_Utilisateur(object sender, RoutedEventArgs e)
        {

            error.Text = "";
            
            if (StringExtensions.IsValidEmail(mail.Text))
            {
                if (employes.VerifierConnexion(mail.Text, password.Password.ToString()))
                {
                    window.ConnexionValider(employes.Find(mail.Text));
                }
                else
                {
                    error.Text = "Mail ou Mot de passe incorrect.";
                }
            }
            else
            {
                error.Text = "Mail non valide.";
            }
        }
    }
}
