using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class Reservation_table
    {
		private int num_reservation;

		public int Num_reservation
        {
			get { return num_reservation; }
			set { num_reservation = value; }
		}

		private int num_assurance;

		public int Num_assurance
        {
			get { return num_assurance; }
			set { num_assurance = value; }
		}

        private int num_client;

        public int Num_client
        {
            get { return num_client; }
            set { num_client = value; }
        }

		private DateTime date_reservation;

		public DateTime Date_reservation
        {
			get { return date_reservation; }
			set { date_reservation = value; }
		}

        private DateTime date_debut_reservation;

        public DateTime Date_debut_reservation
        {
            get { return date_debut_reservation; }
            set { date_debut_reservation = value; }
        }

        private DateTime date_fin_reservation;

        public DateTime Date_fin_reservation
        {
            get { return date_fin_reservation; }
            set { date_fin_reservation = value; }
        }

        private double montant_reservation;

        public double Montant_reservation
        {
            get { return montant_reservation; }
            set { montant_reservation = value; }
        }

        private string forfait_km;

        public string Forfait_km
        {
            get { return forfait_km; }
            set {
                if (value.Length > 10)
                    throw new ArgumentException("Le forfait kilométirque à une valeur trop longue");
                this.forfait_km = value;
            }
        }

    }
}
