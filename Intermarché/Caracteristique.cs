using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class Caracteristique
    {
		private int numCaracteristique;

		public int NumCaracteristique
        {
			get { return numCaracteristique; }
			set { numCaracteristique = value; }
		}

		private string nomCaracteristique;

        public string NomCaracteristique
        {
			get { return nomCaracteristique; }
			set {
				if (value.Length > 30)
					throw new ArgumentException("Le caracteristique est trop long.");
				this.nomCaracteristique = value;
			}
		}
        public Caracteristique(int numCaracteristique, string nomCaracteristique)
        {
            NumCaracteristique = numCaracteristique;
            NomCaracteristique = nomCaracteristique;
        }

    }
}
