using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché.Classes
{

    public class Vehicule_table : Icrud
    {
        public bool EstSelectionné { get; set; }

        private string immatriculation;

        public string Immatriculation
        {
            get { return immatriculation; }
            set
            {
                if (value.Length > 7)
                    throw new ArgumentException("L'immatriculation est trop longue.");
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("L'immatriculation ne peut pas être null.");
                immatriculation = value;
            }
        }

        private string typeBoite;

        public string TypeBoite
        {
            get { return typeBoite; }
            set
            {
                if (value.Length > 30)
                    throw new ArgumentException("Le type de boite à une valeur trop longue.");
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Le type de boite ne peut pas être null.");
                typeBoite = value;
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
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("La catégorie du véhicule ne peut pas être null.");
                nomCategorie = value;
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
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Le nom du véhicule ne peut pas être null.");
                nomVehicule = value;
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
                descriptionVehicule = value;
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

        public Vehicule_table() { }

        public Vehicule_table(string immatriculation, string typeBoite, int numMagasin, string nomCategorie, string nomVehicule, string descriptionVehicule, int nombrePlaces, double prixLocation, bool climatisation, string lienPhotoUrl)
        {
            Immatriculation = immatriculation;
            TypeBoite = typeBoite;
            NumMagasin = numMagasin;
            NomCategorie = nomCategorie;
            NomVehicule = nomVehicule;
            DescriptionVehicule = descriptionVehicule;
            NombrePlaces = nombrePlaces;
            PrixLocation = prixLocation;
            Climatisation = climatisation;
            LienPhotoUrl = lienPhotoUrl;
        }

        public string LienPhotoUrl
        {
            get { return lienPhotoUrl; }
            set
            {
                if (value.Length > 100)
                    throw new ArgumentException("Le lien photo du véhicule est trop long.");
                lienPhotoUrl = value;
            }
        }
        public int Create()
        {
            String sql = $"insert into Vehicule (immatriculation, type_boite,num_magasin,nom_categorie, nom_vehicule, description_vehicule, nombre_places, prix_location, climatisation, lien_photo_url)"
            + $" values ('{Immatriculation}','{TypeBoite}',{NumMagasin},'{NomCategorie}','{NomVehicule}','{DescriptionVehicule}',{NombrePlaces},{PrixLocation},{Climatisation},'{LienPhotoUrl}');";
            return DataAccess.Instance.SetData(sql);
        }
        public int Delete()
        {
            String sql = $"delete from Vehicule where immatriculation = {Immatriculation};";
            return DataAccess.Instance.SetData(sql);
        }
        public int Update()
        {
            String sql = $"update Vehicule set type_boite='{TypeBoite}',num_magasin={NumMagasin},nom_categorie='{NomCategorie}', nom_vehicule='{NomVehicule}', description_vehicule='{DescriptionVehicule}', nombre_places={NombrePlaces}, prix_location={PrixLocation}, climatisation={Climatisation}, lien_photo_url='{LienPhotoUrl}' where immatriculation='{Immatriculation}');";
            return DataAccess.Instance.SetData(sql);
        }
        public static ObservableCollection<Vehicule_table> ReadVehicule()
        {
            String sql = "SELECT * FROM Vehicule";
            DataTable dataTable = DataAccess.Instance.GetData(sql);
            ObservableCollection<Vehicule_table> LesVehicules = new ObservableCollection<Vehicule_table>();
            foreach (DataRow res in dataTable.Rows)
            {
                Vehicule_table nouveau = new Vehicule_table(res["immatriculation"].ToString(), res["type_boite"].ToString(), int.Parse(res["num_magasin"].ToString()),
                    res["nom_categorie"].ToString(), res["nom_vehicule"].ToString(), res["description_vehicule"].ToString(), int.Parse(res["nombre_places"].ToString()),
                    double.Parse(res["prix_location"].ToString()), bool.Parse(res["climatisation"].ToString()), res["lien_photo_url"].ToString());
                LesVehicules.Add(nouveau);
            }
            return LesVehicules;
        }
    }
}
