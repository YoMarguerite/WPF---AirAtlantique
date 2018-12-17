using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class
{
    public static class StringExtensions
    {
        public static bool ToBoolean(this string value)
        {
            switch (value.ToLower())
            {
                case "true":
                    return true;
                case "t":
                    return true;
                case "1":
                    return true;
                case "0":
                    return false;
                case "false":
                    return false;
                case "f":
                    return false;
                default:
                    throw new InvalidCastException("You can't cast that value to a bool!");
            }
        }

        public static bool CiviliteToBoolean(this string value)
        {
            switch (value)
            {
                case "Homme":
                    return true;
                case "Femme":
                    return false;
                default:
                    throw new InvalidCastException("You can't cast that value to a Boolean!");
            }
        }

        public static string StringFormatDate(this string value)
        {
            string[] tab = value.Split(' ');
            string[] date = tab[0].Split('/');
            value = date[2] + "/" + date[1] + "/" + date[0] + " " + tab[1];
            return value;
        }
    }
}
