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
			set { nom_client = value; }
		}

		private string adresse_rue_client;

		public string Adresse_rue_client
        {
			get { return adresse_rue_client; }
			set { adresse_rue_client = value; }
		}

        private string adresse_cp_client;

        public string Adresse_cp_client
        {
            get { return adresse_cp_client; }
            set { adresse_rue_client = value; }
        }

        private string adresse_ville_client;

        public string Adresse_ville_client
        {
            get { return adresse_ville_client; }
            set { adresse_ville_client = value; }
        }

        private string telephone_client;

        public string Telephone_client
        {
            get { return telephone_client; }
            set { telephone_client = value; }
        }

        private string mail_client;

        public string Mail_client
        {
            get { return mail_client; }
            set { mail_client = value; }
        }



    }
}
