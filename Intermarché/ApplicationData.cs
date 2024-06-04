﻿using System;
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
            this.ConnexionBD();
            this.Read();
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = "Server=srv-peda-new;" + "port=5433;" + "Database=votreBase;" + "Search Path = votreSchemaPostGresql;" +
                    "uid=votreLogin;" +"password=votrePassword";

                // à compléter dans les "" 
                // @ sert à enlever tout pb avec les caractères 
                Connexion.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("pb de connexion : " + e);
                // juste pour le debug : à transformer en MsgBox 
            }
        }
        public void ConnexionBD()
        {

        }
        public int Read()
        {
            String sql = "SELECT num_client, nom_client,adresse_rue_client,adresse_cp_client,adresse_ville_client,telephone_client, mail_client FROM Client";
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                foreach (DataRow res in dataTable.Rows)
                {
                    Client nouveau = new Client(int.Parse(res["num_client"].ToString()),
                    res["nom_client"].ToString(), res["adresse_rue_client"].ToString(),
                    res["adresse_cp_client"].ToString(),(res["adresse_ville_client"].ToString()),
                    res["telephone_client"].ToString(), res["mail_client"].ToString());
                    LesClients.Add(nouveau);
                }
                return dataTable.Rows.Count;
            }
            catch (NpgsqlException e)
            { Console.WriteLine("pb de requete : " + e); return 0; }
        }
        /*
        public int Create(Client c)
        {
            String sql = $"insert into client (nom,prenom,email,genre,telephone, dateNaissance)"
            + $" values ('{c.Nom}','{c.Prenom}','{c.Email}'"
            + $",'{(char)c.Genre}','{c.Telephone}', "
            + $"'{c.DateNaissance.Year}-{c.DateNaissance.Month}-{c.DateNaissance.Day}'); ";
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
            String sql = $"insert into client (nom,prenom,email,genre,telephone, dateNaissance)"
            + $" values ('{c.Nom}','{c.Prenom}','{c.Email}'"
            + $",'{(char)c.Genre}','{c.Telephone}', "
            + $"'{c.DateNaissance.Year}-{c.DateNaissance.Month}-{c.DateNaissance.Day}'); ";
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
        }*/


    }
}
