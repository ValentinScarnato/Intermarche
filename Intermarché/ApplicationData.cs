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
            ConnexionBD();
            //this.ReadAll();
        }
        public void ConnexionBD()
        {
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = strconnexion;
                Connexion.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("pb de connexion : " + e);
                // juste pour le debug : à transformer en MsgBox  
            }
        }


        public bool VerifierLogin(string loging, string mdp)
        {
            Employe employe;
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
