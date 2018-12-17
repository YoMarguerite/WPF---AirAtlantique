using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Class.Contrôleur
{
    class CTRL_Client
    {
        private DAO_Client bdd_client = new DAO_Client();
        private List<Client> clients = new List<Client>();


        public CTRL_Client()
        {
            List<string[]> list_clients = bdd_client.SelectClients();
            Client client;

            foreach (string[] tab_client in list_clients)
            {
                client = new Client(int.Parse(tab_client[0]), tab_client[1], tab_client[2], tab_client[3], tab_client[5].ToBoolean().CiviliteBool(), false, int.Parse(tab_client[6]));
                clients.Add(client);
            }
        }


        public List<Client> Client
        {
            get { return clients; }
        }

        public ObservableCollection<Client> DataClient
        {
            get
            {
                ObservableCollection<Client> dataclient = new ObservableCollection<Client>();

                foreach (Client client in clients)
                {
                    dataclient.Add(client);
                }

                return dataclient;
            }
        }


        public void ChangeNom(ref Utilisateur user, string str)
        {
            user.Nom = str;
            Client client = (Client)user;
            bdd_client.UpdateClientNom(client.Id, str);
        }


        public void ChangePrenom(ref Utilisateur user, string str)
        {
            user.Prenom = str;
            Client client = (Client)user;
            bdd_client.UpdateClientPrenom(client.Id, str);
        }


        public void ChangeMail(ref Utilisateur user, string str)
        {
            user.Mail = str;
            Client client = (Client)user;
            bdd_client.UpdateClientMail(client.Id, str);
        }

        public void ChangeCivilite(ref Utilisateur user, string str)
        {
            user.Civilite = str;
            Client client = (Client)user;
            bdd_client.UpdateClientCivilite(client.Id, str.CiviliteToBoolean());
        }

        public void ChangeFidelite(ref Utilisateur user, int str)
        {
            Client client = (Client)user;
            client.Fidelite = str;
            bdd_client.UpdateClientFidelite(client.Id, str);
        }


        public bool ClientExist(string mail)
        {
            
            if(FindbyMail(mail) == default(Client))
            {
                return false;
            }

            return true;
        }


        public Client FindbyMail(string mail)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Mail == mail)
                {
                    return clients[i];
                }
            }

            return default(Client);
        }


        public void AjouterClient(ref Client client, string mdp)
        {
            clients.Add(client);
            client.Id = bdd_client.InsertClient(client, mdp);
        }


        public bool VerifierConnexion(string mail, string mdp)
        {
            return bdd_client.SelectMotDePasse(mail, mdp);
        }
    }
}
