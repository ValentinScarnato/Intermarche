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

        private string typeBoite;

        public string TypeBoite
        {
            get { return typeBoite; }
            set {
                if (value.Length > 30)
                    throw new ArgumentException("Le type de boite à une valeur trop longue.");
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Le type de boite ne peut pas être null.");
                this.typeBoite = value;    
            }
        }

        private int numMagasin;

        public int NumMagasin
        {
            get { return numMagasin; }
            set { numMagasin = value; }
        }

        private string nomCategorie;

        public string NomCategorie
        {
            get { return nomCategorie; }
            set
            {
                if (value.Length > 30)
                    throw new ArgumentException("La catégorie du véhicule est trop longue.");
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("La catégorie du véhicule ne peut pas être null.");
                this.nomCategorie = value;
            }
        }

        private string nomVehicule;

        public string NomVehicule
        {
            get { return nomVehicule; }
            set
            {
                if (value.Length > 50)
                    throw new ArgumentException("Le nom du véhicule est trop long.");
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Le nom du véhicule ne peut pas être null.");
                this.nomVehicule = value;
            }
        }

        private string descriptionVehicule;

        public string DescriptionVehicule
        {
            get { return descriptionVehicule; }
            set
            {
                if (value.Length > 300)
                    throw new ArgumentException("La description du véhicule est trop longue.");
                this.descriptionVehicule = value;
            }
        }

        private int nombrePlaces;

        public int NombrePlaces
        {
            get { return nombrePlaces; }
            set { nombrePlaces = value; }
        }

        private double prixLocation;

        public double PrixLocation
        {
            get { return prixLocation; }
            set { prixLocation = value; }
        }

        private bool climatisation;

        public bool Climatisation
        {
            get { return climatisation; }
            set { climatisation = value; }
        }

        private string lienPhotoUrl;

        public Vehicule_table(string immatriculation, string typeBoite, int numMagasin, string nomCategorie, string nomVehicule, string descriptionVehicule, int nombrePlaces, double prixLocation, bool climatisation, string lienPhotoUrl)
        {
            this.Immatriculation = immatriculation;
            this.TypeBoite = typeBoite;
            this.NumMagasin = numMagasin;
            this.NomCategorie = nomCategorie;
            this.NomVehicule = nomVehicule;
            this.DescriptionVehicule = descriptionVehicule;
            this.NombrePlaces = nombrePlaces;
            this.PrixLocation = prixLocation;
            this.Climatisation = climatisation;
            this.LienPhotoUrl = lienPhotoUrl;
        }

        public string LienPhotoUrl
        {
            get { return lienPhotoUrl; }
            set
            {
                if (value.Length > 100)
                    throw new ArgumentException("Le lien photo du véhicule est trop long.");
                this.lienPhotoUrl = value;
            }
        }




    }
}
