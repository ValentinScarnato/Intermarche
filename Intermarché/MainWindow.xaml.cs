using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
            dgReservationConsulter.Items.Filter = ContientMotClef;
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
        private Client unClient;

        public Client UnClient
        {
            get { return unClient; }
            set { unClient = value; }
        }

        private void butReserver_Click(object sender, RoutedEventArgs e)
        {
            //Penser à uniformiser les noms de famille des clients ex: full MAJ full BOOOOOOx
            DataAccess da = DataAccess.Instance;
            da.LesClients = new ObservableCollection<Client>();
            DateTime dateDebut = dpDateDebut.SelectedDate ?? DateTime.Now;
            DateTime dateFin = dpDateFin.SelectedDate ?? DateTime.Now;
            string nomClient = this.UnClient.NomClient;
            string forfaitKm = tbForfaitKm.Text;
            Client client = da.LesClients.FirstOrDefault(c => c.NomClient.Trim().ToUpper() == nomClient);

            if (client != null)
            {
                // Si le client existe, récupérer son numéro
                int numClient = client.NumClient;

                // Créer une nouvelle réservation avec les détails appropriés
                Reservation_table reservation = new Reservation_table(dateDebut, dateFin, numClient, forfaitKm);

                // Insérer cette réservation dans la base de données
                int result = da.CreateReservation(reservation);

                if (result > 0)
                {
                    MessageBox.Show("Réservation créée avec succès.");
                }
                else
                {
                    MessageBox.Show("Erreur lors de la création de la réservation.");
                }
            }
            else
            {
                // Si le client n'existe pas, afficher un message d'erreur
                MessageBox.Show("Client non trouvé. Veuillez vérifier le nom du client.");
            }

            //Reservation_table reservation = new Reservation_table(dateDebut, dateFin,int.Parse(numClient), forfaitKm);
            //da.CreateReservation(reservation);
            MessageBox.Show("Réservation créée avec succès.");

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DataAccess.Instance.DeconnexionBD();
            Application.Current.Shutdown();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vous déconnecter ?",
                "Confirmer",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Hide();
                Connexion connect = new Connexion(this);
                connect.ShowDialog();
            }
         
        }

        private void reservationsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgReservationConsulter.SelectedItem != null)
            {
                Reservation_table reservation = (Reservation_table)dgReservationConsulter.SelectedItems;
            }
        }


        private bool ContientMotClef(object obj)
        {
            Reservation_table uneReservation = obj as Reservation_table;
            if (String.IsNullOrEmpty(tbRecherche.Text))
                return true;
            else
                return (uneReservation.NumClient.ToString().StartsWith(tbRecherche.Text, StringComparison.OrdinalIgnoreCase) || uneReservation.NumReservation.ToString().StartsWith(tbRecherche.Text, StringComparison.OrdinalIgnoreCase));
        }

        private void tbRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgReservationConsulter.ItemsSource).Refresh();
        }
    }
}
