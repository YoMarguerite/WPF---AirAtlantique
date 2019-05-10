﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Class.Aeroport;
using WpfApp1.Class.Entity;

namespace WpfApp1.Class.Contrôleur
{
    class DAO_Maintenance
    {
        private DAL_Maintenance bdd_maintenance = new DAL_Maintenance();
        private List<Maintenance> maintenances = new List<Maintenance>();


        public DAO_Maintenance()
        {
            List<string[]> list_maintenances = bdd_maintenance.SelectMaintenances();
            Maintenance maintenance;

            foreach (string[] tab_maintenance in list_maintenances)
            {
                //maintenance = new Maintenance(int.Parse(tab_maintenance[0]), tab_maintenance[1].Split(' ')[0], tab_maintenance[2], avions.Find(int.Parse(tab_maintenance[3])), aeroports.Find(int.Parse(tab_maintenance[4])));
                //maintenances.Add(maintenance);
            }
        }


        public List<Maintenance> Maintenance
        {
            get { return maintenances; }
        }


        public ObservableCollection<Maintenance> DataMaintenances
        {
            get
            {
                ObservableCollection<Maintenance> datamaintenance = new ObservableCollection<Maintenance>();

                foreach (Maintenance maintenance in maintenances)
                {
                    datamaintenance.Add(maintenance);
                }

                return datamaintenance;
            }
        }

        public void Nouveau(Maintenance maintenance, int idavion, int idaeroport)
        {
            maintenances.Add(maintenance);

            //string date = maintenance.Date.StringFormatDate();
            //maintenance.Id = bdd_maintenance.InsertMaintenance(date, maintenance.Details, idavion, idaeroport);
        }


        public void ChangeDate(ref Maintenance maintenance, string str)
        {
            maintenance.Date = str;
            //bdd_maintenance.UpdateDate(maintenance.Id, str.StringFormatDate());
        }


        public void ChangeDetails(ref Maintenance maintenance, string str)
        {
            maintenance.Details = str;
            bdd_maintenance.UpdateDetails(maintenance.Id, str);
        }


        //public void ChangeAvion(ref Maintenance maintenance, Avion avion)
        //{
        //    //maintenance.Avion = avion.Matricule;
        //    bdd_maintenance.UpdateAvion(maintenance.Id, avion.Id);
        //}


        public void ChangeAeroport(ref Maintenance maintenance, Aeroport.Aeroport aeroport)
        {
            //maintenance.Aeroport = aeroport.AITA;
            bdd_maintenance.UpdateAeroport(maintenance.Id, aeroport.Id);
        }

        public void Supprimer(int id)
        {
            maintenances.Remove(Find(id));
            bdd_maintenance.Delete(id);
        }


        public Maintenance Find(int id)
        {
            for (int i = 0; i < maintenances.Count; i++)
            {
                if (maintenances[i].Id == id)
                {
                    return maintenances[i];
                }
            }

            return default(Maintenance);
        }
    }
}