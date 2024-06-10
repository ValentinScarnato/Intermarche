using Intermarché.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Intermarché
{
    public partial class RentalsFormWindow : Window
    {
        public List<Vehicule_table> VehiculesSelectionnés { get; set; }

        public RentalsFormWindow()
        {
            InitializeComponent();
            Refresh();
            //dgLesClients.Items.Filter = FiltreClient;

        }
        private void Refresh()
        {
            if (!this.IsInitialized) return;
            ((ICollectionView)this.dgLesClients.ItemsSource).Refresh();
        }
        private void butValiderResa_Click(object sender, RoutedEventArgs e)
        {
            int numAssurance=0;
            int numClient;
            string forfaitKm = "0";
            int nbJours;
            double PourcentageAssurance =0;
            if (rbAssurance1.IsChecked == true)
            {
                numAssurance = 1;
                PourcentageAssurance = 0.05;
            }
            else if (rbAssurance2.IsChecked == true)
            {
                numAssurance = 2;
                PourcentageAssurance = 0.07;
            }
            else if (rbAssurance3.IsChecked == true)
            {
                numAssurance = 3;
                PourcentageAssurance = 0.1;
            }
            DateTime dateResa = DateTime.Today;
            DateTime? dateDebutResa = dpDateDebutReservation.SelectedDate;
            DateTime? dateFinResa = dpDateFinReservation.SelectedDate;
            string numReservation = tbNumResa.Text; 
            DateTime dateDebut = (DateTime)dateDebutResa.Value;
            DateTime dateFin = (DateTime)dateFinResa.Value;
            nbJours = (dateFin - dateDebut).Days;
            if (!int.TryParse(tbNumCLient.Text, out numClient))
            {
                MessageBox.Show("Veuillez entrer des numéros valides pour le client.");
                return;
            }

            if (rbMoins100km.IsChecked == true) forfaitKm = "-100km";
            else if (rb_100_250km.IsChecked == true) forfaitKm = "100km-250km";
            else if (rbPlus250km.IsChecked == true) forfaitKm = "+250km";

            if (dateDebutResa.HasValue && dateFinResa.HasValue && (rbMoins100km.IsChecked == true || rb_100_250km.IsChecked == true || rbPlus250km.IsChecked == true))
            {
                if (VehiculesSelectionnés != null && VehiculesSelectionnés.Any())
                {
                    double montant = (nbJours+1) * (VehiculesSelectionnés.Sum(v => v.PrixLocation));
                    montant += Math.Round(PourcentageAssurance * montant,0); 

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
                    MessageBox.Show($"Réservation ajoutée avec succès !\nLe montant total de la réservation est de {montant} euros");
                    
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
            }
            
        }
        private bool FiltreClient(object obj)
        {
            Client unClient = obj as Client;
            if (String.IsNullOrEmpty(tbRechercherClient.Text))
                return true;
            else
                return (unClient.NumClient.ToString().StartsWith(tbRechercherClient.Text, StringComparison.OrdinalIgnoreCase) || unClient.NomClient.ToString().StartsWith(tbRechercherClient.Text, StringComparison.OrdinalIgnoreCase));
        }
        /*

        private void tbRechercherClient_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgLesClients.ItemsSource).Refresh();
        }*/
    }
}
