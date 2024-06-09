using Intermarché.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class DataAccess
    {
        private static DataAccess instance;
        private ObservableCollection<Client> lesClients;
        private NpgsqlConnection connexion = null;   // futur lien à la BD
        String strconnexion = "Server=localhost;" + "port=5433;" + "Database=Intermarchewpf;" + "Search Path=public;" +
                    "uid=postgres;" + "password=postgres";
        //$@"Host=localhost;Database=Intermarchewpf;Username={login};Password={mdp}";
        
        public DataAccess()
        {
            this.ConnexionBD();
        }

        public static DataAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccess();
                }
                return instance;
            }
        }
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
            ApplicationData appData = new ApplicationData();
            bool isValid = false;
            string connectionString = strconnexion;
            DataAccess da = new DataAccess();


            foreach (Employe e in appData.LesEmployes)
            {
                if (loging == e.Login && mdp == e.Mdp)
                {
                    isValid = true;
                }
                else isValid = false;
            }
            return isValid;
        }


        public void DeconnexionBD()
        {
            try
            {
                Connexion.Close();
            }
            catch (Exception e)
            { Console.WriteLine("pb à la déconnexion  : " + e); }
        }


        public DataTable GetData(string selectSQL)
        {
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(selectSQL, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception e)
            {
                Console.WriteLine("pb avec : " + selectSQL + e.ToString());
                return null;
            }
        }

        public int SetData(string setSQL)
        {

            try
            {
                NpgsqlCommand sqlCommand = new NpgsqlCommand(setSQL, Connexion);
                int nbLines = sqlCommand.ExecuteNonQuery();
                return nbLines;
            }
            catch (Exception e)
            {
                Console.WriteLine("pb avec : " + setSQL + e.ToString());
                return 0;
            }
        }

    }
}