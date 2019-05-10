using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class
{
    public static class BoolExtensions
    {
        public static string CiviliteBool(this bool value)
        {
            switch (value)
            {
                case true:
                    return "Homme";
                case false:
                    return "Femme";
                default:
                    throw new InvalidCastException("You can't cast that value to a Civilite!");
            }
        }
    }
}
