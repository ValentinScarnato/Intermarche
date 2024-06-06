using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class Detail_caracteristique
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

		private int numCaracteristique;

		public int NumCaracteristique
        {
			get { return numCaracteristique; }
			set { numCaracteristique = value; }
		}

		private string valeurCaracteristique;

        public Detail_caracteristique(string immatriculation, int numCaracteristique, string valeurCaracteristique)
        {
            this.Immatriculation = immatriculation;
            this.NumCaracteristique = numCaracteristique;
            this.ValeurCaracteristique = valeurCaracteristique;
        }

        public string ValeurCaracteristique
        {
			get { return valeurCaracteristique; }
			set {
                if (value.Length > 20)
                    throw new ArgumentException("La valeur est trop longue.");
				this.valeurCaracteristique = value;
            }
		}


	}
}
