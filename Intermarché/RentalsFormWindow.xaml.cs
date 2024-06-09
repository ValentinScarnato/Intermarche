using Intermarché.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Intermarché
{
    /// <summary>
    /// Logique d'interaction pour RentalsFormWindow.xaml
    /// </summary>
    public partial class RentalsFormWindow : Window
    {
        public List<Vehicule_table> VehiculesSelectionnés { get; set; }

        public RentalsFormWindow()
        {
            InitializeComponent();
        }

        private void butValiderResa_Click(object sender, RoutedEventArgs e)
        {
            int numAssurance;
            int numClient;
            string forfaitKm = "0";
            DateTime dateResa = DateTime.Today;
            DateTime? dateDebutResa = dpDateDebutReservation.SelectedDate;
            DateTime? dateFinResa = dpDateFinReservation.SelectedDate;
            string numReservation = tbNumResa.Text; 

            if (!int.TryParse(tbNumAssurance.Text, out numAssurance) || !int.TryParse(tbNumCLient.Text, out numClient))
            {
                MessageBox.Show("Veuillez entrer des numéros valides pour l'assurance et le client.");
                return;
            }

            if (rbMoins100km.IsChecked == true) forfaitKm = "-100km";
            else if (rb_100_250km.IsChecked == true) forfaitKm = "100km-250km";
            else if (rbPlus250km.IsChecked == true) forfaitKm = "+250km";

            if (dateDebutResa.HasValue && dateFinResa.HasValue && (rbMoins100km.IsChecked == true || rb_100_250km.IsChecked == true || rbPlus250km.IsChecked == true))
            {
                if (VehiculesSelectionnés != null && VehiculesSelectionnés.Any())
                {
                    double montant = VehiculesSelectionnés.Sum(v => v.PrixLocation);

                    Reservation_table resa = new Reservation_table(
                        int.Parse(numReservation),
                        numAssurance,
                        numClient,
                        dateResa,
                        dateDebutResa.Value,
                        dateFinResa.Value,
                        montant,
                        forfaitKm
                    );

                    ((ApplicationData)this.DataContext).LesReservations.Add(resa);
                    resa.Create();

                    MessageBox.Show("Réservation ajoutée avec succès !");
                    MessageBox.Show($"Le montant total de la réservation est de {montant} euros");
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner au moins un véhicule.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
            }
        }
    }
}
