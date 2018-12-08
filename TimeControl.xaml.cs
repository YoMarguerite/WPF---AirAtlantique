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

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour TimeControl.xaml
    /// </summary>
    public partial class TimeControl : UserControl
    {
        private int Hours;
        private int Minutes;

        public TimeControl()
        {
            Hours = 0;
            Minutes = 0;
            InitializeComponent();
        }

        public string Time
        {
            get { return Hours.ToString() + ":" + Minutes.ToString(); }
        }

        private void ChangeHours(object sender, RoutedEventArgs e)
        {
            if (Numeric(TxtHours.Text))
            {
                int verif = int.Parse(TxtHours.Text);
                if (verif > 23)
                {
                    verif = 23;
                }
                Hours = verif;
            }
            TxtHours.Text = Hours.ToString();

        }

        private void ChangeMinutes(object sender, RoutedEventArgs e)
        {
            if (Numeric(TxtMinutes.Text))
            {
                int verif = int.Parse(TxtMinutes.Text);
                if (verif > 59)
                {
                    verif = 59;
                }
                Minutes = verif;
            }
            TxtMinutes.Text = Minutes.ToString();

        }

        private bool Numeric(string Receive)
        {
            bool Result = false;
            if (Receive != "")
            {
                Result = true;
                foreach (char Char in Receive)
                {
                    if (char.IsDigit(Char) == false)
                    {
                        Result = false;
                    }
                }
            }
                
            return Result;
        }
    }
}
