using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché.Classes
{
    public class Client : Icrud
    {
        private int numClient;

        public int NumClient
        {
            get { return numClient; }
            set { numClient = value; }
        }

        private string nomClient;

        public string NomClient
        {
            get { return nomClient; }
            set
            {
                if (value.Length > 50)
                    throw new ArgumentException("Le nom de client est trop long.");
                nomClient = value;
            }
        }

        private string adresseRueClient;

        public string AdresseRueClient
        {
            get { return adresseRueClient; }
            set
            {
                if (value.Length > 200)
                    throw new ArgumentException("La rue de l'adresse du client est trop longue.");
                adresseRueClient = value;
            }
        }

        private string adresseCpClient;

        public string AdresseCpClient
        {
            get { return adresseCpClient; }
            set
            {
                if (value.Length > 5)
                    throw new ArgumentException("Le code postal de l'adresse du client est trop long.");
                adresseCpClient = value;
            }
        }

        private string adresseVilleClient;

        public string AdresseVilleClient
        {
            get { return adresseVilleClient; }
            set
            {
                if (value.Length > 50)
                    throw new ArgumentException("La ville de l'adresse du client est trop longue.");
                adresseVilleClient = value;
            }
        }

        private string telephoneClient;

        public string TelephoneClient
        {
            get { return telephoneClient; }
            set
            {
                if (value.Length > 10)
                    throw new ArgumentException("Le téléphone du client est trop long.");
                telephoneClient = value;
            }
        }

        private string mailClient;

        public string MailClient
        {
            get { return mailClient; }
            set
            {
                if (value.Length > 150)
                    throw new ArgumentException("Le mail du client est trop long.");
                mailClient = value;
            }
        }
        public Client() { }
        public Client(string nomClient, string adresseRueClient, string adresseCpClient, string adresseVilleClient, string telephoneClient, string mailClient)
        {
            NomClient = nomClient;
            MailClient = mailClient;
            TelephoneClient = telephoneClient;
            AdresseRueClient = adresseRueClient;
            AdresseCpClient = adresseCpClient;
            AdresseVilleClient = adresseVilleClient;
        }
        public Client(int numClient, string nomClient, string adresseRueClient, string adresseCpClient, string adresseVilleClient, string telephoneClient, string mailClient)
            : this(nomClient, adresseRueClient, adresseCpClient, adresseVilleClient, telephoneClient, mailClient)
        {
            NumClient = numClient;
        }

        public static ObservableCollection<Client> ReadClient()
        {
            ObservableCollection<Client> LesClients = new ObservableCollection<Client>();
            String sql = "SELECT * FROM Client";
            DataTable dataTable = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dataTable.Rows)
            {
                Client nouveau = new Client(int.Parse(res["num_client"].ToString()),
                res["nom_client"].ToString(), res["adrese_rue_client"].ToString(),
                res["adresse_cp_client"].ToString(), (res["adresse_ville_client"].ToString()),
                res["telephone_client"].ToString(), res["mail_client"].ToString());
                LesClients.Add(nouveau);
            }
            return LesClients;
        }
        public int Create()
        {
            String sql = $"insert into client (nom_client,adrese_rue_client,adresse_cp_client,adresse_ville_client,telephone_client, mail_client)"
            + $" values ('{NomClient}','{AdresseRueClient}'"
            + $",'{AdresseCpClient}','{AdresseVilleClient}', "
            + $"'{TelephoneClient}','{MailClient}'); ";
            return DataAccess.Instance.SetData(sql);
        }
        public int Delete()
        {
            String sql = $"delete from client where num_client = {NumClient};";
            return DataAccess.Instance.SetData(sql);
        }
        public int Update()
        {
            String sql = $"update client set num_client='{NumClient}', nom_client='{NomClient}',adrese_rue_client='{AdresseRueClient}'," +
                $"adresse_cp_client='{AdresseCpClient}',adresse_ville_client='{AdresseVilleClient}',telephone_client='{TelephoneClient}', mail_client='{MailClient}' where num_client={NumClient});";
            return DataAccess.Instance.SetData(sql);
        }



    }
}
