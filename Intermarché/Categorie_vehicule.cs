using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class Categorie_vehicule
    {
		private string nomCategorie;

        public Categorie_vehicule(string nomCategorie)
        {
            NomCategorie = nomCategorie;
        }

        public string NomCategorie
        {
			get { return nomCategorie; }
			set {
				if (value.Length > 30)
					throw new ArgumentException("Le nom de la catégorie est trop long.");
				if (String.IsNullOrEmpty(value))
					throw new ArgumentException("Le nom de catégorie ne peut pas être vide");
				this.nomCategorie = value;
			}
		}

	}
}
