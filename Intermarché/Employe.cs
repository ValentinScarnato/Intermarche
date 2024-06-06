using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermarché
{
    public class Employe
    {
		private int numEmploye;

		public int NumEmploye
        {
			get { return numEmploye; }
			set { numEmploye = value; }
		}

        private int numMagasin;

        public int NumMagasin
        {
            get { return numMagasin; }
            set { numMagasin = value; }
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

        public Employe(int numEmploye, int numMagasin, string login, string mdp)
        {
            NumEmploye = numEmploye;
            NumMagasin = numMagasin;
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
