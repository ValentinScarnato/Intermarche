using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class Reservation_table
    {
		private int numReservation;

		public int NumReservation
        {
			get { return numReservation; }
			set { numReservation = value; }
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
			set { dateReservation = value; }
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

        private string forfaitKm;

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

        public string ForfaitKm
        {
            get { return forfaitKm; }
            set {
                if (value.Length > 10)
                    throw new ArgumentException("Le forfait kilométirque à une valeur trop longue");
                this.forfaitKm = value;
            }
        }

    }
}
