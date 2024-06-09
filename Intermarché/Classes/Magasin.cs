using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché.Classes
{
    public class Magasin
    {
        private int numMagasin;

        public int NumMagasin
        {
            get { return numMagasin; }
            set { numMagasin = value; }
        }

        private string nomMagasin;

        public string NomMagasin
        {
            get { return nomMagasin; }
            set { nomMagasin = value; }
        }

        private string adresseRueMagasin;

        public string AdresseRueMagasin
        {
            get { return adresseRueMagasin; }
            set
            {
                if (value.Length > 200)
                    throw new ArgumentException("La rue de l'adresse du magasin est trop longue.");
                adresseRueMagasin = value;
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
                adresseCpMagasin = value;
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
                adresseVilleMagasin = value;
            }
        }

        private string horraireMagasin;

        public Magasin(int numMagasin, string nomMagasin, string adresseRueMagasin, string adresseCpMagasin, string adresseVilleMagasin, string horraireMagasin)
        {
            NumMagasin = numMagasin;
            NomMagasin = nomMagasin;
            AdresseRueMagasin = adresseRueMagasin;
            AdresseCpMagasin = adresseCpMagasin;
            AdresseVilleMagasin = adresseVilleMagasin;
            HorraireMagasin = horraireMagasin;
        }

        public string HorraireMagasin
        {
            get { return horraireMagasin; }
            set
            {
                if (value.Length > 20)
                    throw new ArgumentException("L'horraire du magasin à une valeur trop longue.");
                horraireMagasin = value;
            }
        }
        public int Create()
        {
            String sql = $"insert into Magasin (num_magasin,nom_magasin,adresse_rue_magasin,adresse_cp_magasin, adresse_ville_magasin,horaire_magasin)"
            + $" values ({NumMagasin},'{NomMagasin},'{AdresseRueMagasin}','{AdresseCpMagasin}','{AdresseVilleMagasin}','{HorraireMagasin}');";
            return DataAccess.Instance.SetData(sql);
        }
        public int Delete()
        {
            String sql = $"delete from Magasin where num_magasin = {NumMagasin};";
            return DataAccess.Instance.SetData(sql);
        }
        public int Update()
        {
            String sql = $"update Magasin set nom_magasin = '{NomMagasin}', adresse_rue_magasin='{AdresseRueMagasin}', adresse_cp_magasin='{AdresseCpMagasin}', adresse_ville_magasin='{AdresseVilleMagasin}', horaire_magasin='{HorraireMagasin}' where num_magasin={NumMagasin});";
            return DataAccess.Instance.SetData(sql);
        }
        public static ObservableCollection<Magasin> ReadMagasin()
        {
            String sql = "SELECT * FROM Magasin";
            DataTable dataTable = DataAccess.Instance.GetData(sql);
            ObservableCollection<Magasin> LesMagasin = new ObservableCollection<Magasin>();
            foreach (DataRow res in dataTable.Rows)
            {
                Magasin nouveau = new Magasin(int.Parse(res["num_magasin"].ToString()),
                res["nom_magasin"].ToString(), res["adresse_rue_magasin"].ToString(),
                res["adresse_cp_magasin"].ToString(), res["adresse_ville_magasin"].ToString(), res["horaire_magasin"].ToString());
                LesMagasin.Add(nouveau);
            }
            return LesMagasin;
        }
    }
}
