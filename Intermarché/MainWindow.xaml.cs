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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
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

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientFormWindow clientFormWindow = new ClientFormWindow();
            clientFormWindow.ShowDialog();
        }

        private void butReserver_Click(object sender, RoutedEventArgs e)
        {
            // Générer un numéro de réservation
            int numeroReservation = GenererNumeroReservation();

            // Afficher le numéro de réservation dans un MessageBox (pour le test)
            MessageBox.Show($"Numéro de réservation créé : {numeroReservation}");

            // Vous pouvez maintenant utiliser ce numéro de réservation pour effectuer d'autres actions
        }

        private int GenererNumeroReservation()
        {
            // Implémentez votre logique de génération de numéro de réservation ici
            // Pour cet exemple, je vais simplement utiliser un numéro aléatoire.

            Random random = new Random();
            return random.Next(1, 10); // Génère un numéro entre 1000 et 9999
        }
    }
}
