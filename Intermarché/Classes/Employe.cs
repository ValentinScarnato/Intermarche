using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché.Classes
{
    public class Employe : Icrud
    {
        private int numEmploye;

        public int NumEmploye
        {
            get { return numEmploye; }
            set { numEmploye = value; }
        }

        private int numMagasin;

        public int NumMagasin
        {
            get { return numMagasin; }
            set { numMagasin = value; }
        }

        private string login;

        public string Login
        {
            get { return login; }
            set
            {
                if (value.Length > 6)
                    throw new ArgumentException("Le login est trop long.");
                login = value;
            }
        }

        private string mdp;

        public Employe(int numEmploye, int numMagasin, string login, string mdp)
        {
            NumEmploye = numEmploye;
            NumMagasin = numMagasin;
            Login = login;
            Mdp = mdp;
        }

        public string Mdp
        {
            get { return mdp; }
            set
            {
                if (value.Length > 10)
                    throw new ArgumentException("Le mot de passe est trop long.");
                mdp = value;
            }
        }

        public int Create()
        {
            //PENSER A ENLEVER LE MDP (RESPECT RGPD)
            String sql = $"insert into Employe (num_employe, num_magasin, login)"
            + $" values ({NumEmploye},{NumMagasin},'{Login}');";
            return DataAccess.Instance.SetData(sql);
        }
        public int Delete()
        {
            String sql = $"delete from Employe where num_employe = {NumEmploye};";
            return DataAccess.Instance.SetData(sql);
        }
        public int Update()
        {
            String sql = $"update Employe set login = '{Login}', num_magasin={NumMagasin} where num_employe={NumEmploye});";
            return DataAccess.Instance.SetData(sql);
        }
        public static ObservableCollection<Employe> ReadEmploye()
        {
            String sql = "SELECT * FROM Employe";
            DataTable dataTable = DataAccess.Instance.GetData(sql);
            ObservableCollection<Employe> LesEmployes = new ObservableCollection<Employe>();
            foreach (DataRow res in dataTable.Rows)
            {
                Employe nouveau = new Employe(int.Parse(res["num_employe"].ToString()),
                int.Parse(res["num_magasin"].ToString()), res["login"].ToString(),
                res["mdp"].ToString());
                LesEmployes.Add(nouveau);
            }
            return LesEmployes;
        }
    }
}
