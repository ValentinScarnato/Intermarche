using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché.Classes
{
    public class Detail_reservation
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

        private int numReservation;

        public Detail_reservation(string immatriculation, int numReservation)
        {
            Immatriculation = immatriculation;
            NumReservation = numReservation;
        }

        public int NumReservation
        {
            get { return numReservation; }
            set { numReservation = value; }
        }
        public int Create()
        {
            String sql = $"insert into Detail_reservation (num_reservation, immatriculation )"
            + $" values ({NumReservation},'{Immatriculation}');";
            return DataAccess.Instance.SetData(sql);
        }
        public int Delete()
        {
            String sql = $"delete from Detail_reservation where num_reservation={NumReservation} and immatriculation='{Immatriculation}';";
            return DataAccess.Instance.SetData(sql);
        }
        public int Update()
        {
            String sql = $"update Detail_reservation set immatriculation='{Immatriculation}' where immatriculation = '{Immatriculation}');";
            return DataAccess.Instance.SetData(sql);
        }
        public static ObservableCollection<Detail_reservation> ReadDetailREservation()
        {
            String sql = "SELECT * FROM Detail_reservation";
            DataTable dataTable = DataAccess.Instance.GetData(sql);
            ObservableCollection<Detail_reservation> LesDetailReservation = new ObservableCollection<Detail_reservation>();
            foreach (DataRow res in dataTable.Rows)
            {
                Detail_reservation nouveau = new Detail_reservation(res["immatriculation"].ToString(),
                int.Parse(res["num_reservation"].ToString()));
                LesDetailReservation.Add(nouveau);
            }
            return LesDetailReservation;
        }


    }
}
