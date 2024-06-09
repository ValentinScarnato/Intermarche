using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermarché.Classes;
using Npgsql;

namespace Intermarché
{
    public class ApplicationData
    {
        private ObservableCollection<Client> lesClients;
        private ObservableCollection<Assurance> lesAssurances;
        private ObservableCollection<Caracteristique> lesCaracteristiques;
        private ObservableCollection<Employe> lesEmployes;
        private ObservableCollection<Categorie_vehicule> lesCategorieVehicule;
        private ObservableCollection<Detail_caracteristique> lesDetailCaracteristique;
        private ObservableCollection<Detail_reservation> lesDetailReservation;
        private ObservableCollection<Magasin> lesMagasin;
        private ObservableCollection<Reservation_table> lesReservations;
        private ObservableCollection<Vehicule_table> lesVehicules;


        public ObservableCollection<Client> LesClients { get => lesClients; set => lesClients = value; }
        public ObservableCollection<Assurance> LesAssurances { get => lesAssurances; set => lesAssurances = value; }
        public ObservableCollection<Caracteristique> LesCaracteristiques { get => lesCaracteristiques; set => lesCaracteristiques = value; }
        public ObservableCollection<Employe> LesEmployes { get => lesEmployes; set => lesEmployes = value; }
        public ObservableCollection<Categorie_vehicule> LesCategorieVehicule { get => lesCategorieVehicule; set => lesCategorieVehicule = value; }
        public ObservableCollection<Detail_caracteristique> LesDetailCaracteristique { get => lesDetailCaracteristique; set => lesDetailCaracteristique = value; }
        public ObservableCollection<Detail_reservation> LesDetailReservation { get => lesDetailReservation; set => lesDetailReservation = value; }
        public ObservableCollection<Magasin> LesMagasin { get => lesMagasin; set => lesMagasin = value; }
        public ObservableCollection<Reservation_table> LesReservations { get => lesReservations; set => lesReservations = value; }
        public ObservableCollection<Vehicule_table> LesVehicules { get => lesVehicules; set => lesVehicules = value; }


        public ApplicationData()
        {
            this.LesAssurances = Assurance.ReadAssurance();
            this.LesCaracteristiques = Caracteristique.ReadCaracteristique();
            this.LesCategorieVehicule = Categorie_vehicule.ReadCategorieVehicules();
            this.LesClients = Client.ReadClient();
            this.LesDetailCaracteristique = Detail_caracteristique.ReadDetailCaracteristiques();
            this.LesEmployes = Employe.ReadEmploye();
            this.LesMagasin = Magasin.ReadMagasin();
            this.LesReservations = Reservation_table.ReadReservation();
            this.LesVehicules = Vehicule_table.ReadVehicule();
            
        }

    }
}
