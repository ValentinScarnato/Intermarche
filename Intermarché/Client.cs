using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class Client
    {
		private int num_client;

		public int Num_client
		{
			get { return num_client; }
			set { num_client = value; }
		}

		private string nom_client;

		public string Nom_client
        {
			get { return nom_client; }
			set {
                if (value.Length > 50)
                    throw new ArgumentException("Le nom de client est trop long.");
                this.nom_client = value;
            }
		}

		private string adresse_rue_client;

		public string Adresse_rue_client
        {
			get { return adresse_rue_client; }
			set {
                if (value.Length > 200)
                    throw new ArgumentException("La rue de l'adresse du client est trop longue.");
                this.adresse_rue_client = value;
            }
		}

        private string adresse_cp_client;

        public string Adresse_cp_client
        {
            get { return adresse_cp_client; }
            set {
                if (value.Length > 5)
                    throw new ArgumentException("Le code postal de l'adresse du client est trop long.");
                this.adresse_cp_client  = value;
            }
        }

        private string adresse_ville_client;

        public string Adresse_ville_client
        {
            get { return adresse_ville_client; }
            set {
                if (value.Length > 50)
                    throw new ArgumentException("La ville de l'adresse du client est trop longue.");
                this.adresse_ville_client = value;
            }
        }

        private string telephone_client;

        public string Telephone_client
        {
            get { return telephone_client; }
            set
            {
                if (value.Length > 10)
                    throw new ArgumentException("Le téléphone du client est trop long.");
                this.telephone_client = value;
            }
        }

        private string mail_client;

        public string Mail_client
        {
            get { return mail_client; }
            set {
                if (value.Length > 150)
                    throw new ArgumentException("Le mail du client est trop long.");
                this.mail_client = value;
            }
        }



    }
}
