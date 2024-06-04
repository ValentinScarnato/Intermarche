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
			set { immatriculation = value; }
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
			set { valeur_caracteristique = value; }
		}


	}
}
