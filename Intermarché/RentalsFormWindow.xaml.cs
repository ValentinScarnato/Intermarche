using Intermarché.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Intermarché
{
    /// <summary>
    /// Logique d'interaction pour RentalsFormWindow.xaml
    /// </summary>
    public partial class RentalsFormWindow : Window
    {
        public RentalsFormWindow()
        {
            InitializeComponent();
        }

        private void butValiderResa_Click(object sender, RoutedEventArgs e)
        {
            ApplicationData da = new ApplicationData();

            // Convertir les entrées de texte en entiers
            int numAssurance;
            int numClient;
            if (!int.TryParse(tbNumAssurance.Text, out numAssurance) || !int.TryParse(tbNumCLient.Text, out numClient))
            {
                System.Windows.MessageBox.Show("Veuillez entrer des numéros valides pour l'assurance et le client.");
                return;
            }

            DateTime? dateResa = dpDateReservation.SelectedDate;
            DateTime? dateDebutResa = dpDateDebutReservation.SelectedDate;
            DateTime? dateFinResa = dpDateFinReservation.SelectedDate;
            string montantResa = tbMontantReservation.Text;
            string forfaitKm = tbForfaitKm.Text;

            if (dateResa.HasValue && dateDebutResa.HasValue && dateFinResa.HasValue)
            {
                double montant;
                if (!double.TryParse(montantResa, out montant))
                {
                    System.Windows.MessageBox.Show("Le montant de la réservation n'est pas valide.");
                    return;
                }

                Reservation_table resa = new Reservation_table(
                    numAssurance,
                    numClient,
                    dateResa.Value,
                    dateDebutResa.Value,
                    dateFinResa.Value,
                    montant,
                    forfaitKm
                );

                // Ajouter la réservation à votre collection de réservations
                da.LesReservations.Add(resa);

                // Enregistrer la réservation dans la base de données
                resa.Create();

                System.Windows.MessageBox.Show("Réservation ajoutée avec succès !");
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez remplir tous les champs.");
            }
        }
    }
}
