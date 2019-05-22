using System.Windows;
using System.Windows.Controls;
using WpfApp1.Class.Employe;
using WpfApp1.Class.Extensions;

namespace WpfApp1.Class.View
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Page
    {
        MainWindow window;

        public Connexion(MainWindow _window)
        {
            InitializeComponent();
            window = _window;
        }

        private void Connexion_Utilisateur(object sender, RoutedEventArgs e)
        {

            error.Text = "";
            
            if (StringExtensions.IsValidEmail(mail.Text))
            {
                Employe.Employe user = DAL_Employe.GetEmploye(mail.Text, password.Password);
                if (user == null)
                {
                    error.Text = "Mail ou Mot de passe incorrect.";
                }
                else
                {
                    window.ConnexionValider(user);
                }
            }
            else
            {
                error.Text = "Mail non valide.";
            }
        }
    }
}
