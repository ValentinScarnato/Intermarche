using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché.Classes
{
    public class Caracteristique : Icrud
    {
        private int numCaracteristique;

        public int NumCaracteristique
        {
            get { return numCaracteristique; }
            set { numCaracteristique = value; }
        }

        private string nomCaracteristique;

        public string NomCaracteristique
        {
            get { return nomCaracteristique; }
            set
            {
                if (value.Length > 30)
                    throw new ArgumentException("Le caracteristique est trop long.");
                nomCaracteristique = value;
            }
        }
        public Caracteristique(int numCaracteristique, string nomCaracteristique)
        {
            NumCaracteristique = numCaracteristique;
            NomCaracteristique = nomCaracteristique;
        }
        public static ObservableCollection<Caracteristique> ReadCaracteristique()
        {
            ObservableCollection<Caracteristique> LesCaracteristiques = new ObservableCollection<Caracteristique>();
            String sql = "SELECT * FROM Caracteristique";
            DataTable dataTable = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dataTable.Rows)
            {
                Caracteristique nouveau = new Caracteristique(int.Parse(res["num_caracteristique"].ToString()),
                    res["nom_caracteristique"].ToString());
                LesCaracteristiques.Add(nouveau);
            }
            return LesCaracteristiques;
        }
        public int Create()
        {
            String sql = $"insert into Caracteristique (num_caracteriqtique, nom_caracteristique )"
            + $" values ({NumCaracteristique},'{NomCaracteristique}');";
            return DataAccess.Instance.SetData(sql);
        }
        public int Delete()
        {
            String sql = $"delete from caracteristique where num_caracteriqtique = {NumCaracteristique};";
            return DataAccess.Instance.SetData(sql);
        }
        public int Update()
        {
            String sql = $"update caracteristique set num_caracteriqtique = {NumCaracteristique}, nom_caracteriqtique='{NomCaracteristique}' where num_caracteriqtique={NumCaracteristique} );";
            return DataAccess.Instance.SetData(sql);
        }

    }
}
