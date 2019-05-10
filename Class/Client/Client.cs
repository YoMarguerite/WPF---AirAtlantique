using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class.Client
{
    public class Client : Utilisateur , INotifyPropertyChanged
    {
        private int fidelite;

        public event PropertyChangedEventHandler PropertyChanged;

        public Client(int _id, string _mail, bool _civilite, int _fidelite, string _nom, string _prenom, string _mdp) : base( _id, _nom, _prenom, _mail, _mdp, _civilite)
        {
            this.fidelite = _fidelite;
        }

        public Client() { }

        public int Fidelite
        {
            get { return fidelite; }
            set { fidelite = value; }
        }
    }
}
