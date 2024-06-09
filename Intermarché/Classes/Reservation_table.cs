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
    public class Reservation_table
    {
        private int numReservation;

        public int NumReservation
        {
            get { return numReservation; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Le numéro de réservation doit etre superieur ou egale a 0");
                numReservation = value;
            }
        }

        private int numAssurance;

        public int NumAssurance
        {
            get { return numAssurance; }
            set { numAssurance = value; }
        }

        private int numClient;

        public int NumClient
        {
            get { return numClient; }
            set { numClient = value; }
        }

        private DateTime dateReservation;

        public DateTime DateReservation
        {
            get { return dateReservation; }
            set { dateReservation = DateTime.Today; }
        }

        private DateTime dateDebutReservation;

        public DateTime DateDebutReservation
        {
            get { return dateDebutReservation; }
            set { dateDebutReservation = value; }
        }

        private DateTime dateFinReservation;

        public DateTime DateFinReservation
        {
            get { return dateFinReservation; }
            set { dateFinReservation = value; }
        }

        private double montantReservation;

        public double MontantReservation
        {
            get { return montantReservation; }
            set { montantReservation = value; }
        }

        public Reservation_table(int numAssurance, int numClient, DateTime dateReservation, DateTime dateDebutReservation, DateTime dateFinReservation, double montantReservation, string forfaitKm)
        {
            NumAssurance = numAssurance;
            NumClient = numClient;
            DateReservation = dateReservation;
            DateDebutReservation = dateDebutReservation;
            DateFinReservation = dateFinReservation;
            MontantReservation = montantReservation;
            ForfaitKm = forfaitKm;
        }

        private string forfaitKm;
        public string ForfaitKm
        {
            get { return forfaitKm; }
            set
            {
                if (value.Length > 10)
                    throw new ArgumentException("Le forfait kilométirque à une valeur trop longue");
                forfaitKm = value;
            }
        }
        public Reservation_table(DateTime dateDebutReservation, DateTime dateFinReservation, int numClient, string forfaitKm)
        {
            DateDebutReservation = dateDebutReservation;
            DateFinReservation = dateFinReservation;
            ForfaitKm = forfaitKm;
            NumClient = numClient;
        }

        public Reservation_table(int numReservation, int numAssurance, int numClient, DateTime dateReservation, DateTime dateDebutReservation, DateTime dateFinReservation, double montantReservation, string forfaitKm)
        {
            this.NumReservation = numReservation;
            this.NumAssurance = numAssurance;
            this.NumClient = numClient;
            this.DateReservation = dateReservation;
            this.DateDebutReservation = dateDebutReservation;
            this.DateFinReservation = dateFinReservation;
            this.MontantReservation = montantReservation;
            this.ForfaitKm = forfaitKm;
        }


        public int Create()
        {
            String sql = $"insert into Reservation (num_reservation, num_assurance, num_client, date_reservation, date_debut_reservation, date_fin_reservation, montant_reservation, forfait_km )"
            + $" values ({NumReservation},{NumAssurance},{NumClient},'{DateTime.Today}','{DateDebutReservation}','{DateFinReservation}',{MontantReservation},'{ForfaitKm}');";
            return DataAccess.Instance.SetData(sql);
        }
        public int Delete()
        {
            String sql = $"delete from Reservation where num_reservation = {NumReservation};";
            return DataAccess.Instance.SetData(sql);
        }
        public int Update()
        {
            String sql = $"update Reservation set num_assurance = '{NumAssurance}', num_client='{NumClient}',date_reservation = '{DateReservation}', date_debut_reservation='{DateDebutReservation}',date_fin_reservation = '{DateFinReservation}', montant_reservation='{MontantReservation}',forfait_km = '{ForfaitKm}' where num_reservation={NumReservation});";
            return DataAccess.Instance.SetData(sql);
        }
        public static ObservableCollection<Reservation_table> ReadReservation()
        {
            String sql = "SELECT * FROM Reservation";
            DataTable dataTable = DataAccess.Instance.GetData(sql);
            ObservableCollection<Reservation_table> LesReservations = new ObservableCollection<Reservation_table>();
            foreach (DataRow res in dataTable.Rows)
            {
                Reservation_table nouveau = new Reservation_table(int.Parse(res["num_reservation"].ToString()),
                    int.Parse(res["num_assurance"].ToString()), int.Parse(res["num_client"].ToString()), DateTime.Parse(res["date_reservation"].ToString()),
                    DateTime.Parse(res["date_debut_reservation"].ToString()), DateTime.Parse(res["date_fin_reservation"].ToString()), double.Parse(res["montant_reservation"].ToString()),
                    res["forfait_km"].ToString());
                LesReservations.Add(nouveau);
            }
            return LesReservations;
        }
    }
}
