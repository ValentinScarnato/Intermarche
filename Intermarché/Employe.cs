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
            set { login = value; }
        }

        private string mdp;

        public string Mdp
        {
            get { return mdp; }
            set { mdp = value; }
        }


    }
}
