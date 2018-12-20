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
    /// Logique d'interaction pour NumericBox.xaml
    /// </summary>
    public partial class NumericBox : UserControl
    {
        private int number;

        public NumericBox()
        {
            InitializeComponent();
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public void ChangeValue(object sender, RoutedEventArgs e)
        {
            if (Numeric(TxtNum.Text))
            {
                number = int.Parse(TxtNum.Text);
            }
            else
            {
                TxtNum.Text = number.ToString();
            }
        }

        public void Top(object sender, RoutedEventArgs e)
        {
            if (number < 99999)
            {
                number++;
                TxtNum.Text = number.ToString();
            }
        }

        public void Bot(object sender, RoutedEventArgs e)
        {
            if(number > 0)
            {
                number--;
                TxtNum.Text = number.ToString();
            }            
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
