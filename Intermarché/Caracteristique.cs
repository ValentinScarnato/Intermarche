﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class Caracteristique
    {
		private int num_caracteristique;

		public int Num_caracteristique
        {
			get { return num_caracteristique; }
			set { num_caracteristique = value; }
		}

		private string nom_caracteristique;

		public string Nom_caracteristique
        {
			get { return nom_caracteristique; }
			set {
				if (value.Length > 30)
					throw new ArgumentException("Le caracteristique est trop long.");
				this.nom_caracteristique = value;
			}
		}

	}
}
