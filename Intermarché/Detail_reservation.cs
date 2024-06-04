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

		private int num_reservation;

		public int Num_reservation 
		{
			get { return num_reservation; }
			set { num_reservation = value; }
		}


	}
}
