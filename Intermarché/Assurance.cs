using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class Assurance
    {
		private int num_assurance;

		public int Num_assurance
        {
			get { return num_assurance; }
			set { num_assurance = value; }
		}

		private string description_assurance;

		public string Description_assurance
        {
			get { return description_assurance; }
			set {
				if (value.Length > 30)
					throw new ArgumentException("La description d'assurance est trop longue.");
				this.description_assurance = value;
			}
		}

		private int prix_assurance;

		public int Prix_assurance
        {
			get { return prix_assurance; }
			set { prix_assurance = value; }
		}




	}
}
