using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class Assurance
    {
		private int numAssurance;

		public int NumAssurance
        {
			get { return numAssurance; }
			set { numAssurance = value; }
		}

		private string descriptionAssurance;

		public string DescriptionAssurance
        {
			get { return descriptionAssurance; }
			set {
				if (value.Length > 30)
					throw new ArgumentException("La description d'assurance est trop longue.");
				this.descriptionAssurance = value;
			}
		}

		private int prixAssurance;

        public int PrixAssurance
        {
			get { return prixAssurance; }
			set { prixAssurance = value; }
		}

        public Assurance(int numAssurance, string descriptionAssurance, int prixAssurance)
        {
            NumAssurance = numAssurance;
            DescriptionAssurance = descriptionAssurance;
            PrixAssurance = prixAssurance;
        }






    }
}
