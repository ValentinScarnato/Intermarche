using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class Magasin
    {
		private int numVehicule;

		public int NumVehicule
        {
			get { return numVehicule; }
			set { numVehicule = value; }
		}

		private string nomVehicule;

		public string NomVehicule
        {
			get { return nomVehicule; }
			set { nomVehicule = value; }
		}

        private string adresseRueMagasin;

        public string AdresseRueMagasin
        {
            get { return adresseRueMagasin; }
            set
            {
                if (value.Length > 200)
                    throw new ArgumentException("La rue de l'adresse du magasin est trop longue.");
                this.adresseRueMagasin = value;
            }
        }

        private string adresseCpMagasin;

        public string AdresseCpMagasin
        {
            get { return adresseCpMagasin; }
            set
            {
                if (value.Length > 5)
                    throw new ArgumentException("Le code postal de l'adresse du magasin est trop long.");
                this.adresseCpMagasin = value;
            }
        }

        private string adresseVilleMagasin;

        public string AdresseVilleMagasin
        {
            get { return adresseVilleMagasin; }
            set
            {
                if (value.Length > 50)
                    throw new ArgumentException("La ville de l'adresse du magasin est trop longue.");
                this.adresseVilleMagasin = value;
            }
        }

        private string horraireMagasin;

        public Magasin(int numVehicule, string nomVehicule, string adresseRueMagasin, string adresseCpMagasin, string adresseVilleMagasin, string horraireMagasin)
        {
            this.NumVehicule = numVehicule;
            this.NomVehicule = nomVehicule;
            this.AdresseRueMagasin = adresseRueMagasin;
            this.AdresseCpMagasin = adresseCpMagasin;
            this.AdresseVilleMagasin = adresseVilleMagasin;
            this.HorraireMagasin = horraireMagasin;
        }

        public string HorraireMagasin
        {
            get { return horraireMagasin; }
            set {
                if (value.Length > 20)
                    throw new ArgumentException("L'horraire du magasin à une valeur trop longue.");
                this.horraireMagasin = value;
            }
        }
    }
}
