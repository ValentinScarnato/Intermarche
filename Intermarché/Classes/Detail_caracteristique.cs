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
    public class Detail_caracteristique : Icrud
    {
        private string immatriculation;

        public string Immatriculation
        {
            get { return immatriculation; }
            set
            {
                if (value.Length > 7)
                    throw new ArgumentException("L'immatriculation est trop longue.");
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("L'immatriculation ne peut pas être vide");
                immatriculation = value;
            }
        }

        private int numCaracteristique;

        public int NumCaracteristique
        {
            get { return numCaracteristique; }
            set { numCaracteristique = value; }
        }

        private string valeurCaracteristique;

        public Detail_caracteristique(string immatriculation, int numCaracteristique, string valeurCaracteristique)
        {
            Immatriculation = immatriculation;
            NumCaracteristique = numCaracteristique;
            ValeurCaracteristique = valeurCaracteristique;
        }

        public string ValeurCaracteristique
        {
            get { return valeurCaracteristique; }
            set
            {
                if (value.Length > 20)
                    throw new ArgumentException("La valeur est trop longue.");
                valeurCaracteristique = value;
            }
        }
        public int Create()
        {
            String sql = $"insert into Detail_caracteristique (immatriculation, num_caracteristique,valeur_caracteristique)"
            + $" values ('{Immatriculation}',{NumCaracteristique},'{ValeurCaracteristique}');";
            return DataAccess.Instance.SetData(sql);
        }
        public int Delete()
        {
            String sql = $"delete from Detail_caracteristique where num_caracteristique = {NumCaracteristique};";
            return DataAccess.Instance.SetData(sql);
        }
        public int Update()
        {
            String sql = $"update Detail_caracteristique set valeur_caracteristique='{ValeurCaracteristique}' Where num_caracteriqtique = '{NumCaracteristique}' and Immatriculation='{Immatriculation}');";
            return DataAccess.Instance.SetData(sql);
        }

        public static ObservableCollection<Detail_caracteristique> ReadDetailCaracteristiques()
        {
            String sql = "SELECT * FROM Detail_caracteristique";
            DataTable dataTable = DataAccess.Instance.GetData(sql);
            ObservableCollection<Detail_caracteristique> LesDetailCaracteristique = new ObservableCollection<Detail_caracteristique>();
            foreach (DataRow res in dataTable.Rows)
            {
                Detail_caracteristique nouveau = new Detail_caracteristique(res["immatriculation"].ToString(),
                    int.Parse(res["num_caracteristique"].ToString()), res["valeur_caracteristique"].ToString());
                LesDetailCaracteristique.Add(nouveau);
            }
            return LesDetailCaracteristique;
        }


    }
}
