using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class Magasin
    {
		private int num_vehicule;

		public int Num_vehicule
        {
			get { return num_vehicule; }
			set { num_vehicule = value; }
		}

		private string nom_vehicule;

		public string Nom_vehicule
        {
			get { return nom_vehicule; }
			set { nom_vehicule = value; }
		}

        private string adresse_rue_magasin;

        public string Adresse_rue_magasin
        {
            get { return adresse_rue_magasin; }
            set
            {
                if (value.Length > 200)
                    throw new ArgumentException("La rue de l'adresse du magasin est trop longue.");
                this.adresse_rue_magasin = value;
            }
        }

        private string adresse_cp_magasin;

        public string Adresse_cp_magasin
        {
            get { return adresse_cp_magasin; }
            set
            {
                if (value.Length > 5)
                    throw new ArgumentException("Le code postal de l'adresse du magasin est trop long.");
                this.adresse_cp_magasin = value;
            }
        }

        private string adresse_ville_magasin;

        public string Adresse_ville_magasin
        {
            get { return adresse_ville_magasin; }
            set
            {
                if (value.Length > 50)
                    throw new ArgumentException("La ville de l'adresse du magasin est trop longue.");
                this.adresse_ville_magasin = value;
            }
        }

        private string horraire_magasin;

        public string Horraire_magasin
        {
            get { return horraire_magasin; }
            set {
                if (value.Length > 20)
                    throw new ArgumentException("L'horraire du magasin à une valeur trop longue.");
                this.horraire_magasin = value;
            }
        }
    }
}
