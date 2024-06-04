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
			set { immatriculation = value; }
		}

		private int num_reservation;

		public int Num_reservation 
		{
			get { return num_reservation; }
			set { num_reservation = value; }
		}


	}
}
