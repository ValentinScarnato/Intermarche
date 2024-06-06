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

        private ObservableCollection<Client> lesClients;
        private NpgsqlConnection connexion = null;   // futur lien à la BD
        private DataAccess dataAccess;
        String strconnexion = "Server=srv-peda-new;" + "port=5433;" + "Database=Intermarchewpf;" + "Search Path=intermarche;" +
                    "uid=scarnatv;" + "password=Z9O5sQ";
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
            dataAccess = DataAccess.Instance;
        }


        public bool VerifierLogin(string loging, string mdp)
        {
            Employe employe;
            bool isValid = false;
            string connectionString = strconnexion;
            foreach (Employe e in dataAccess.LesEmployes)
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
