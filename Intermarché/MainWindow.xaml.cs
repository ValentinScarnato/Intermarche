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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Intermarché
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Connexion connect = new Connexion(this);
            connect.ShowDialog();

            InitializeComponent();
        }

        private void butRecherche_Click(object sender, RoutedEventArgs e)
        {
            // Vérification de la saisie
            if (!int.TryParse(tbRecherche.Text, out int valeurRecherche) || valeurRecherche <= 0)
            {
                MessageBox.Show("Veuillez saisir un numéro supérieur à zéro.", "Erreur de saisie");
            }
        }

        private void butCreateClient_Click(object sender, RoutedEventArgs e)
        {
            ClientFormWindow clientFormWindow = new ClientFormWindow();
            clientFormWindow.ShowDialog();
        }

        private void butReserver_Click(object sender, RoutedEventArgs e)
        {
            DataAccess da = DataAccess.Instance;
            DateTime dateDebut = dpDateDebut.SelectedDate ?? DateTime.Now;
            DateTime dateFin = dpDateFin.SelectedDate ?? DateTime.Now;
            string numClient = tbNumClient.Text;
            string forfaitKm = tbForfaitKm.Text;
            //Reservation_table reservation = new Reservation_table(dateDebut, dateFin, numClient, forfaitKm);
            //int result = da.CreateReservation(dateDebut, dateFin, numClient, forfaitKm);

                MessageBox.Show("Réservation créée avec succès.");

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void reservationsDataGrid_SelectionChanged()
        {

        }
    }
}
