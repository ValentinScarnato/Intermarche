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
        private MainWindow mainWin;

        public MainWindow MainWin
        {
            get { return mainWin; }
            set { mainWin = value; }
        }

        private bool ClosedByConnexion = false;

        public Connexion(MainWindow mainWin)
        {
            MainWin = mainWin;
            InitializeComponent();
        }
        private void butValiderConnexion_Click(object sender, RoutedEventArgs e)
        {
            string login = txtboxIdentifiant.Text;
            string mdp = txtboxMdp.Password;
            ApplicationData appData = new ApplicationData();
            if (appData.VerifierLogin(login,mdp))
            {
                this.MainWin.Show();
                this.ClosedByConnexion = true;
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Erreur login / password");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (!this.ClosedByConnexion)
            {
                Application.Current.Shutdown();
            }
            
        }
    }
}

