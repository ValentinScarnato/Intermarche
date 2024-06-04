using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    class Detail_caracteristique
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

		private int num_caracteristique;

		public int Num_caracteristique
        {
			get { return num_caracteristique; }
			set { num_caracteristique = value; }
		}

		private string valeur_caracteristique;

		public string Valeur_caracteristique
        {
			get { return valeur_caracteristique; }
			set {
                if (value.Length > 20)
                    throw new ArgumentException("La valeur est trop longue.");
				this.valeur_caracteristique = value;
            }
		}


	}
}
