using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp1.Class.Classe;
using WpfApp1.Class.Tarif;
using WpfApp1.Class.Vol;

namespace WpfApp1.Class.TarifVol
{
    /// <summary>
    /// Logique d'interaction pour TarifVolPage.xaml
    /// </summary>
    public partial class TarifVolPage : Page
    {
        ObservableCollection<TarifVol> ListeTarifVols;
        private int vol;
        private int IdTarifVol;

        public TarifVolPage(int _vol)
        {
            vol = _vol;
            InitializeComponent();
            AfficherTarifVol();

            this.Classe.ItemsSource = DAL_Classe.SelectNomClasses();
            this.Classe.SelectedValue = DAL_Classe.SelectNomClasses().First();

            this.Tarif.ItemsSource = DAL_Tarif.SelectNomTarifsByClasse(DAL_Classe.FindByName(this.Classe.Text).Id);
            this.Tarif.SelectedValue = DAL_Tarif.SelectNomTarifsByClasse(DAL_Classe.FindByName(this.Classe.Text).Id).First();
        }

        public void AfficherTarifVol()
        {
            ListeTarifVols = new ObservableCollection<TarifVol>();
            ListeTarifVols = DAL_TarifVol.SelectTarifVolsByVol(vol);
            this.grid.ItemsSource = ListeTarifVols;
        }

        private void Edit(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                DataGridColumn column = e.Column;
                if (column != null)
                {
                    string column_nom = (string)column.Header;
                    TextBox el = e.EditingElement as TextBox;
                    TarifVol TarifVol = DAL_TarifVol.GetTarifVol(IdTarifVol);
                    int value;

                    switch (column_nom)
                    {
                        case "Tarif":
                            if (!int.TryParse(el.Text, out value))
                            {
                                value = TarifVol.Tarif;
                            }
                            TarifVol.Tarif = value;
                            break;

                        case "Vol":
                            if(!int.TryParse(el.Text, out value))
                            {
                                value = TarifVol.Vol;
                            }
                            TarifVol.Vol = value;
                            break;

                        case "Prix":
                            float prix;
                            if (!float.TryParse(el.Text, out prix))
                            {
                                prix = TarifVol.Prix;
                            }
                            TarifVol.Prix = prix;
                            break;

                        default:
                            break;
                    }
                    DAL_TarifVol.ModifierTarifVol(TarifVol.Id, TarifVol.Tarif, TarifVol.Vol, TarifVol.Prix);
                }
            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((grid.SelectedIndex >= 0) && (grid.SelectedIndex <= ListeTarifVols.Count))
            {
                IdTarifVol = ListeTarifVols.ElementAt(grid.SelectedIndex).Id;
            }

        }

        private void Nouveau_tarifvol_click(object sender, RoutedEventArgs e)
        {
            float prix;
            if (float.TryParse(Prix.Text, out prix))
            {
                DAL_TarifVol.AjouterTarifVol(DAL_Tarif.FindByNameAndClasse(DAL_Classe.FindByName(Classe.Text).Id,Tarif.Text).Id, vol, prix);
                AfficherTarifVol();
            }
        }

        private void Supp_tarifvol_click(object sender, RoutedEventArgs e)
        {
            DAL_TarifVol.SupprimerTarifVol(IdTarifVol);
            AfficherTarifVol();
        }

        private void Classe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.Classe.Text != "")
            {
                this.Tarif.ItemsSource = DAL_Tarif.SelectNomTarifsByClasse(DAL_Classe.FindByName(this.Classe.Text).Id);
                this.Tarif.SelectedValue = DAL_Tarif.SelectNomTarifsByClasse(DAL_Classe.FindByName(this.Classe.Text).Id).First();
            }
        }
    }
}
