using Intermarché.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    public partial class EditResaWindow : Window
    {
        public List<Reservation_table> ResaSelectionné { get; set; }
        public List<Vehicule_table> VehiculeSelectionné { get; set;}
        public EditResaWindow()
        {
            InitializeComponent();
        }

        private void butValiderResa_Click1(object sender, RoutedEventArgs e)
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
                if (ResaSelectionné != null && ResaSelectionné.Any())
                {
                    double montant = this.VehiculeSelectionné.Sum(v => v.PrixLocation);

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
                    MessageBox.Show($"Le nouveau montant total de la réservation est de {montant} euros");
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
