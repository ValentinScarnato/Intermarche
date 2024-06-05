using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class Employe
    {
		private int num_employe;

		public int Num_employe
        {
			get { return num_employe; }
			set { num_employe = value; }
		}

        private int num_magasin;

        public int Num_magasin
        {
            get { return num_magasin; }
            set { num_magasin = value; }
        }

        private string login;

        public string Login
        {
            get { return login; }
            set {
                if (value.Length > 6)
                    throw new ArgumentException("Le login est trop long.");
                this.login = value;
            }
        }

        private string mdp;

        public Employe(int num_employe, int num_magasin, string login, string mdp)
        {
            Num_employe = num_employe;
            Num_magasin = num_magasin;
            Login = login;
            Mdp = mdp;
        }

        public string Mdp
        {
            get { return mdp; }
            set {
                if (value.Length > 10)
                    throw new ArgumentException("Le mot de passe est trop long.");
                this.mdp = value;
            }
        }



    }
}
