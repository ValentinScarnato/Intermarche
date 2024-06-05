using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class Detail_reservation
    {
		private string immatriculation;

		public string Immatriculation
        {
			get { return immatriculation; }
			set {
                if (value.Length > 7)
                    throw new ArgumentException("L'immatriculation est trop longue.");
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("L'immatriculation ne peut pas être vide");
				this.immatriculation = value;
            }
		}

		private int numReservation;

        public Detail_reservation(string immatriculation, int numReservation)
        {
            this.Immatriculation = immatriculation;
            this.NumReservation = numReservation;
        }

        public int NumReservation
        {
			get { return numReservation; }
			set { numReservation = value; }
		}


	}
}
