using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class DataAccess
    {
        private static DataAccess instance;
        private ObservableCollection<Client> lesClients;
        private NpgsqlConnection connexion = null;   // futur lien à la BD
        String strconnexion = "Server=srv-peda.iut-acy.local;" + "port=5433;" + "Database=Intermarchewpf;" + "Search Path=intermarche;" +
                    "uid=scarnatv;" + "password=Z9O5sQ";


        public DataAccess()
        {
            this.LesClients = new ObservableCollection<Client>();
            this.LesReservations = new ObservableCollection<Reservation_table>();
            this.ConnexionBD();
            //this.ReadAll();
            this.ReadMagasin();
            this.ReadEmploye();
            this.ReadReservation();
            //this.ReadVehicule();
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

        public ObservableCollection<Client> LesClients
        {
            get
            {
                return this.lesClients;
            }

            set
            {
                this.lesClients = value;
            }
        }
        private ObservableCollection<Employe> lesEmployes;

        public ObservableCollection<Employe> LesEmployes
        {
            get
            {
                return lesEmployes;
            }
            set
            {
                this.lesEmployes = value;
            }
        }
        private ObservableCollection<Assurance> lesAssurances;

        public ObservableCollection<Assurance> LesAssurances
        {
            get
            {
                return lesAssurances;
            }
            set
            {
                this.lesAssurances = value;
            }
        }
        private ObservableCollection<Caracteristique> lesCaracteristiques;

        public ObservableCollection<Caracteristique> LesCaracteristiques
        {
            get
            {
                return lesCaracteristiques;
            }
            set
            {
                this.lesCaracteristiques = value;
            }
        }
        private ObservableCollection<Categorie_vehicule> lesCategorieVehicule;

        public ObservableCollection<Categorie_vehicule> LesCategorieVehicule
        {
            get
            {
                return lesCategorieVehicule;
            }
            set
            {
                this.lesCategorieVehicule = value;
            }
        }
        private ObservableCollection<Detail_caracteristique> lesDetailCaracteristique;

        public ObservableCollection<Detail_caracteristique> LesDetailCaracteristique
        {
            get
            {
                return lesDetailCaracteristique;
            }
            set
            {
                this.lesDetailCaracteristique = value;
            }
        }
        private ObservableCollection<Detail_reservation> lesDetailReservation;

        public ObservableCollection<Detail_reservation> LesDetailReservation
        {
            get
            {
                return lesDetailReservation;
            }
            set
            {
                this.lesDetailReservation = value;
            }
        }
        private ObservableCollection<Magasin> lesMagasin;

        public ObservableCollection<Magasin> LesMagasin
        {
            get
            {
                return lesMagasin;
            }
            set
            {
                this.lesMagasin = value;
            }
        }
        private ObservableCollection<Reservation_table> lesReservations;

        public ObservableCollection<Reservation_table> LesReservations
        {
            get
            {
                return lesReservations;
            }
            set
            {
                this.lesReservations = value;
            }
        }
        private ObservableCollection<Vehicule_table> lesVehicules;

        public ObservableCollection<Vehicule_table> LesVehicules
        {
            get
            {
                return lesVehicules;
            }
            set
            {
                this.lesVehicules = value;
            }
        }

        public void ReadAll()
        {
            ReadAssurance();
            ReadCaracteristiques();
            ReadCategorieVehicules();
            ReadClient();
            ReadDetailCaracteristiques();
            ReadDetailReservation();
            ReadEmploye();
            ReadVehicule();
            ReadMagasin();
            ReadReservation();
        }

        public int ReadClient()
        {
            String sql = "SELECT num_client, nom_client,adresse_rue_client,adrese_cp_client,adresse_ville_client,telephone_client, mail_client FROM Client";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Client nouveau = new Client(int.Parse(res["num_client"].ToString()),
                    res["nom_client"].ToString(), res["adrese_rue_client"].ToString(),
                    res["adresse_cp_client"].ToString(), (res["adresse_ville_client"].ToString()),
                    res["telephone_client"].ToString(), res["mail_client"].ToString());
                    LesClients.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int CreerClient(Client c)
        {
            this.LesClients = new ObservableCollection<Client>();
            String sql = $"insert into client (nom_client,adrese_rue_client,adresse_cp_client,adresse_ville_client,telephone_client, mail_client)"
            + $" values ('{c.NomClient}','{c.AdresseRueClient}'"
            + $",'{c.AdresseCpClient}','{c.AdresseVilleClient}', "
            + $"'{c.TelephoneClient}','{c.MailClient}'); ";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connexion);
                int nb = cmd.ExecuteNonQuery();
                return nb;
                //nb permet de connaître le nb de lignes affectées par un insert, update, delete
            }
            catch (Exception sqlE)
            {
                Console.WriteLine("pb de requete : " + sql + "" + sqlE);
                // juste pour le debug : à transformer en MsgBox 
                return 0;
            }
        }
        public int Delete(int idClient)
        {
            String sql = "delete from client where idClient = @idClient;";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connexion);
                cmd.Parameters.AddWithValue("@idClient", idClient);
                int nb = cmd.ExecuteNonQuery();
                return nb;
            }
            catch (Exception sqlE)
            {
                Console.WriteLine("Erreur de requête : " + sql + " " + sqlE);
                return 0;
            }
        }
        public int Update(Client c)
        {
            String sql = $"insert into client (num_client, nom_client,adresse_rue_client,adresse_cp_client,adresse_ville_client,telephone_client, mail_client)"
            + $" values ('{c.NumClient}','{c.NomClient}','{c.AdresseRueClient}'"
            + $",'{c.AdresseCpClient}','{c.AdresseVilleClient}', "
            + $"'{c.TelephoneClient}-{c.MailClient}'); ";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connexion);
                int nb = cmd.ExecuteNonQuery();
                return nb;
                //nb permet de connaître le nb de lignes affectées par un insert, update, delete
            }
            catch (Exception sqlE)
            {
                Console.WriteLine("pb de requete : " + sql + "" + sqlE);
                // juste pour le debug : à transformer en MsgBox 
                return 0;
            }
        }
        public int CreateReservation(Reservation_table r)
        {
            String sql = $"INSERT INTO reservation (num_assurance, num_client, date_reservation, date_debut_reservation, date_fin_reservation, montant_reservation, forfait_km)"
            + $" VALUES (1, {r.NumClient}, '{DateTime.Now}', '{r.DateDebutReservation}', '{r.DateFinReservation}', 0, '{r.ForfaitKm}');";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, Connexion);
                int nb = cmd.ExecuteNonQuery();
                return nb;
            }
            catch (Exception sqlE)
            {
                Console.WriteLine("Erreur de requête : " + sql + " " + sqlE);
                return 0;
            }
        }
        public int ReadEmploye()
        {
            this.LesEmployes = new ObservableCollection<Employe>();
            String sql = "SELECT num_employe, num_magasin,login,mdp FROM employe";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Employe nouveau = new Employe(int.Parse(res["num_employe"].ToString()),
                    int.Parse(res["num_magasin"].ToString()), res["login"].ToString(),
                    res["mdp"].ToString());
                    LesEmployes.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int ReadAssurance()
        {
            String sql = "SELECT num_assurance, description_assurance,prix_assurance FROM Assurance";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Assurance nouveau = new Assurance(int.Parse(res["num_assurance"].ToString()),
                    res["description_assurance"].ToString(), int.Parse(res["prix_assurance"].ToString()));
                    LesAssurances.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int ReadCaracteristiques()
        {
            String sql = "SELECT num_caracteristique, nom_caracteristiques FROM Caracteristique";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Caracteristique nouveau = new Caracteristique(int.Parse(res["num_caracteriqtique"].ToString()),
                    res["nom_caracteristique"].ToString());
                    LesCaracteristiques.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int ReadCategorieVehicules()
        {
            String sql = "SELECT nom_categorie FROM Categorie_vehicule";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Categorie_vehicule nouveau = new Categorie_vehicule(res["nom_categorie"].ToString());
                    LesCategorieVehicule.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int ReadDetailCaracteristiques()
        {
            String sql = "SELECT immatriculation, num_caracteristique,valeur_caracteristique FROM Detail_caracteristique";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Detail_caracteristique nouveau = new Detail_caracteristique(res["num_employe"].ToString(),
                    int.Parse(res["num_magasin"].ToString()), res["valeur_caracteristique"].ToString());
                    LesDetailCaracteristique.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int ReadDetailReservation()
        {
            String sql = "SELECT immatriculation, num_reservation FROM Detail_reservation";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Detail_reservation nouveau = new Detail_reservation(res["num_employe"].ToString(),
                    int.Parse(res["num_magasin"].ToString()));
                    LesDetailReservation.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int ReadMagasin()
        {
            this.LesMagasin = new ObservableCollection<Magasin>();
            String sql = "SELECT num_magasin,nom_magasin,adresse_rue_magasin,adresse_cp_magasin, adresse_ville_magasin,horaire_magasin FROM intermarche.magasin";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Magasin nouveau = new Magasin(int.Parse(res["num_magasin"].ToString()),
                    res["nom_magasin"].ToString(), res["adresse_rue_magasin"].ToString(),
                    res["adresse_cp_magasin"].ToString(), res["adresse_ville_magasin"].ToString(), res["horaire_magasin"].ToString());
                    LesMagasin.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int ReadReservation()
        {
            this.lesReservations = new ObservableCollection<Reservation_table>();
            String sql = "SELECT num_reservation, num_assurance,num_client,date_reservation,date_debut_reservation, date_fin_reservation, montant_reservation, forfait_km FROM Reservation";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Reservation_table nouveau = new Reservation_table(int.Parse(res["num_reservation"].ToString()),
                    int.Parse(res["num_assurance"].ToString()), int.Parse(res["num_client"].ToString()), DateTime.Parse(res["date_reservation"].ToString()),
                    DateTime.Parse(res["date_debut_reservation"].ToString()), DateTime.Parse(res["date_fin_reservation"].ToString()), double.Parse(res["montant_reservation"].ToString()),
                    res["forfait_km"].ToString());
                    LesReservations.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        public int ReadVehicule()
        {
            String sql = "SELECT immatriculation, type_boite,num_magasin,nom_categorie, nom_vehicule, description_vehicule, nombre_places, prix_location, climatisation, lien_photo_url FROM Vehicule";
            
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Vehicule_table nouveau = new Vehicule_table(res["immatriculation"].ToString(), res["type_boite"].ToString(), int.Parse(res["num_magasin"].ToString()),
                    res["nom_categorie"].ToString(), res["nom_vehicule"].ToString(), res["description_vehicule"].ToString(), int.Parse(res["nombre_places"].ToString()),
                    double.Parse(res["prix_location"].ToString()), bool.Parse(res["climatisation"].ToString()), res["lien_photo_url"].ToString());
                    LesVehicules.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
    }
}