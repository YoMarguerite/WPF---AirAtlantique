using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Class.Billet
{
    class Billet
    {
        private int id;
        private int client;
        private int vol;
        private string date;


        public Billet( int _id, int _client, int _vol, string _date)
        {
            this.id = _id;
            this.client = _client;            
            this.vol = _vol;
            this.date = _date;
        }


        public Billet() { }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public int Client
        {
            get { return client; }
            set { client = value; }
        }
        

        public int Vol
        {
            get { return vol; }
            set { vol = value; }
        }


        public string Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
