using Intermarché.Classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindow()
        {
            ApplicationData da = new ApplicationData();
            Connexion connect = new Connexion(this);
            connect.ShowDialog();
            InitializeComponent();
            dgReservationConsulter.Items.Filter = ContientMotClef;
            dgLesVehicules.Items.Filter = ContientMotClef2;
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
        private bool ContientMotClef2(object obj)
        {
            Vehicule_table vehicule = obj as Vehicule_table;
            if (String.IsNullOrEmpty(tbRechercheNumType.Text))
                return true;
            else
                return (vehicule.NumMagasin.ToString().StartsWith(tbRechercheNumType.Text, StringComparison.OrdinalIgnoreCase) || vehicule.TypeBoite.ToString().StartsWith(tbRechercheNumType.Text, StringComparison.OrdinalIgnoreCase));
        }

        private void tbRechercheNumType_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgLesVehicules.ItemsSource).Refresh();
        }

        private void dgLesVehicules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgLesVehicules.SelectedItem != null)
            {
                Vehicule_table vehicule = (Vehicule_table)dgLesVehicules.SelectedItems;
            }
        }
    }
}
