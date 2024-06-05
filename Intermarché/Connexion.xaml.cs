using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Intermarché
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {

        
        public Connexion()
        {
            InitializeComponent();
        }

        private void butValiderConnexion_Click(object sender, RoutedEventArgs e)
        {
            string login = txtboxIdentifiant.Text;
            string mdp = txtboxMdp.Text;
            ApplicationData appData = new ApplicationData();
            if (appData.VerifierLogin())
            {
                MessageBox.Show("Connexion réussie!");
                //FINIR ET OUVRIR NVLLE PAGE
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect.");
            }
            
        }
    }
}
