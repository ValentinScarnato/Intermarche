using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class Vehicule_table
    {
		private string immatriculation;

		public string Immatriculation
		{
			get { return immatriculation; }
			set {
                if (value.Length > 7)
                    throw new ArgumentException("L'immatriculation est trop longue.");
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("L'immatriculation ne peut pas être null.");
                this.immatriculation = value;
            }
		}

        private string type_boite;

        public string Type_boite
        {
            get { return type_boite; }
            set {
                if (value.Length > 30)
                    throw new ArgumentException("Le type de boite à une valeur trop longue.");
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Le type de boite ne peut pas être null.");
                this.type_boite = value;    
            }
        }

        private int num_magasin;

        public int Num_magasin
        {
            get { return num_magasin; }
            set { num_magasin = value; }
        }

        private string nom_categorie;

        public string Nom_categorie
        {
            get { return nom_categorie; }
            set
            {
                if (value.Length > 30)
                    throw new ArgumentException("La catégorie du véhicule est trop longue.");
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("La catégorie du véhicule ne peut pas être null.");
                this.nom_categorie = value;
            }
        }

        private string nom_vehicule;

        public string Nom_vehicule
        {
            get { return nom_vehicule; }
            set
            {
                if (value.Length > 50)
                    throw new ArgumentException("Le nom du véhicule est trop long.");
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Le nom du véhicule ne peut pas être null.");
                this.nom_vehicule = value;
            }
        }

        private string description_vehicule;

        public string Description_vehicule
        {
            get { return description_vehicule; }
            set
            {
                if (value.Length > 300)
                    throw new ArgumentException("La description du véhicule est trop longue.");
                this.description_vehicule = value;
            }
        }

        private int nombre_places;

        public int Nombre_places
        {
            get { return nombre_places; }
            set { nombre_places = value; }
        }

        private double prix_location;

        public double Prix_location
        {
            get { return prix_location; }
            set { prix_location = value; }
        }

        private bool climatisation;

        public bool Climatisation
        {
            get { return climatisation; }
            set { climatisation = value; }
        }

        private string lien_photo_url;

        public string Lien_photo_url
        {
            get { return lien_photo_url; }
            set
            {
                if (value.Length > 100)
                    throw new ArgumentException("Le lien photo du véhicule est trop long.");
                this.lien_photo_url = value;
            }
        }




    }
}
