using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intermarché.Classes
{
    public class Assurance : Icrud
    {
        private int numAssurance;

        public int NumAssurance
        {
            get { return numAssurance; }
            set { numAssurance = value; }
        }

        private string descriptionAssurance;

        public string DescriptionAssurance
        {
            get { return descriptionAssurance; }
            set
            {
                if (value.Length > 30)
                    throw new ArgumentException("La description d'assurance est trop longue.");
                descriptionAssurance = value;
            }
        }

        private int prixAssurance;

        public int PrixAssurance
        {
            get { return prixAssurance; }
            set { prixAssurance = value; }
        }

        public Assurance(int numAssurance, string descriptionAssurance, int prixAssurance)
        {
            NumAssurance = numAssurance;
            DescriptionAssurance = descriptionAssurance;
            PrixAssurance = prixAssurance;
        }

        public static ObservableCollection<Assurance> ReadAssurance()
        {
            ObservableCollection<Assurance> Assurances = new ObservableCollection<Assurance>();
            String sql = "SELECT * FROM Assurance";
            DataTable dataTable = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dataTable.Rows)
            {
                Assurance nouveau = new Assurance(int.Parse(res["num_assurance"].ToString()),
                res["description_assurance"].ToString(), int.Parse(res["prix_assurance"].ToString()));
                Assurances.Add(nouveau);
            }
            return Assurances;
        }
        public int Create()
        {
            String sql = $"insert into Assurance (num_assurance, description_assurance,prix_assurance )"
            + $" values ({NumAssurance},'{DescriptionAssurance}'"
            + $",{PrixAssurance});";
            return DataAccess.Instance.SetData(sql);
        }
        public int Delete()
        {
            String sql = $"delete from assurance where num_assurance = {NumAssurance};";
            return DataAccess.Instance.SetData(sql);
        }
        public int Update()
        {
            String sql = $"update assurance set description_assurance='{DescriptionAssurance}',prix_assurance={PrixAssurance} where num_assurance='{NumAssurance}');";
            return DataAccess.Instance.SetData(sql);
        }



    }
}
