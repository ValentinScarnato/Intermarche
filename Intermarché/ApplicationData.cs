using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Intermarché
{
    public class ApplicationData
    {
        public ObservableCollection<Vehicule_table> LesVehicules { get; set; }
        public ObservableCollection<Reservation_table> LesReservations { get; set; }
        private ObservableCollection<Client> lesClients;
        private NpgsqlConnection connexion = null;   // futur lien à la BD
        String strconnexion = "Server=localhost;" + "port=5433;" + "Database=Intermarchewpf;" + "Search Path=public;" +
                    "uid=postgres;" + "password=postgres";
        public NpgsqlConnection Connexion
        {
            get
            {
                return this.connexion;
            }

            set
            {
                this.connexion = value;
            }
        }

        public ApplicationData()
        {
            LesVehicules = new ObservableCollection<Vehicule_table>();
            LesReservations = new ObservableCollection<Reservation_table>();
        }


        public bool VerifierLogin(string loging, string mdp)
        {
            bool isValid = false;
            string connectionString = strconnexion;
            DataAccess da = new DataAccess();
            foreach (Employe e in da.LesEmployes)
            {
                if (loging == e.Login && mdp == e.Mdp)
                {
                    isValid = true;
                }
                else isValid = false;
            }
            return isValid;
        }

    }
}
