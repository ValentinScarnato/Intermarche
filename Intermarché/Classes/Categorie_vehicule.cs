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
    public class Categorie_vehicule
    {
        private string nomCategorie;

        public Categorie_vehicule(string nomCategorie)
        {
            NomCategorie = nomCategorie;
        }

        public string NomCategorie
        {
            get { return nomCategorie; }
            set
            {
                if (value.Length > 30)
                    throw new ArgumentException("Le nom de la catégorie est trop long.");
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Le nom de catégorie ne peut pas être vide");
                nomCategorie = value;
            }
        }
        public int Create()
        {
            String sql = $"insert into Categorie_vehicule (nom_categorie)"
            + $" values ('{NomCategorie}');";
            return DataAccess.Instance.SetData(sql);
        }
        public int Delete()
        {
            String sql = $"delete from Categorie_vehicule where nom_categorie = {NomCategorie};";
            return DataAccess.Instance.SetData(sql);
        }
        public int Update()
        {
            String sql = $"update Categorie_vehicule set nom_categorie = '{NomCategorie}');";
            return DataAccess.Instance.SetData(sql);
        }

        public static ObservableCollection<Categorie_vehicule> ReadCategorieVehicules()
        {
            ObservableCollection<Categorie_vehicule> LesCategorieVehicule = new ObservableCollection<Categorie_vehicule>();

            String sql = "SELECT * FROM Categorie_vehicule";
            DataTable dataTable = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dataTable.Rows)
            {
                Categorie_vehicule nouveau = new Categorie_vehicule(res["nom_categorie"].ToString());
                LesCategorieVehicule.Add(nouveau);
            }
            return LesCategorieVehicule;

        }

    }
}
