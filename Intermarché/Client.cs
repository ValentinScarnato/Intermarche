using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class Client
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
			set {
                if (value.Length > 50)
                    throw new ArgumentException("Le nom de client est trop long.");
                this.nomClient = value;
            }
		}

		private string adresseRueClient;

		public string AdresseRueClient
        {
			get { return adresseRueClient; }
			set {
                if (value.Length > 200)
                    throw new ArgumentException("La rue de l'adresse du client est trop longue.");
                this.adresseRueClient = value;
            }
		}

        private string adresseCpClient;

        public string AdresseCpClient
        {
            get { return AdresseCpClient; }
            set {
                if (value.Length > 5)
                    throw new ArgumentException("Le code postal de l'adresse du client est trop long.");
                this.AdresseCpClient = value;
            }
        }

        private string adresseVilleClient;

        public string AdresseVilleClient
        {
            get { return adresseVilleClient; }
            set {
                if (value.Length > 50)
                    throw new ArgumentException("La ville de l'adresse du client est trop longue.");
                this.adresseVilleClient = value;
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
                this.telephoneClient = value;
            }
        }

        private string mailClient;

        public string MailClient
        {
            get { return mailClient; }
            set {
                if (value.Length > 150)
                    throw new ArgumentException("Le mail du client est trop long.");
                this.mailClient = value;
            }
        }
        public Client(int numClient)
        {
            this.NumClient = numClient;
        }
        public Client(int numClient,string nomClient,string mailClient,string telephoneClient) : this(numClient)
        {
            this.NomClient = nomClient;
            this.MailClient = mailClient;
            this.TelephoneClient = telephoneClient;
        }
        public Client(int numClient, string nomClient, string adresseRueClient, string adresseCpClient, string adresseVilleClient,string telephoneClient, string mailClient) : this(numClient,nomClient,mailClient,telephoneClient)
        {
            this.AdresseRueClient = adresseRueClient;
            this.AdresseCpClient = adresseCpClient;
            this.AdresseVilleClient = adresseVilleClient;
        }




    }
}
