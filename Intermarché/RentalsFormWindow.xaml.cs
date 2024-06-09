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

        private void butValiderResa_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            ApplicationData da = new ApplicationData();
            int numAssurance;
            int numClient;
            string forfaitKm = "0";
            if (!int.TryParse(tbNumAssurance.Text, out numAssurance) || !int.TryParse(tbNumCLient.Text, out numClient))
            {
                System.Windows.MessageBox.Show("Veuillez entrer des numéros valides pour l'assurance et le client.");
                return;
            }
            if (rbMoins100km.IsChecked == true) forfaitKm = "-100km";
            else if (rb_100_250km.IsChecked == true) forfaitKm = "100km - 250km";
            else if (rb_100_250km.IsChecked == true) forfaitKm = "+250km";
            DateTime dateResa = DateTime.Today;
            DateTime? dateDebutResa = dpDateDebutReservation.SelectedDate;
            DateTime? dateFinResa = dpDateFinReservation.SelectedDate;
            string montantResa;
            double montant = 0;

            if (dateDebutResa.HasValue && dateFinResa.HasValue && (rbMoins100km.IsChecked == true || rb_100_250km.IsChecked == true || rbPlus250km.IsChecked == true))
            {
                

                Reservation_table resa = new Reservation_table(
                    numAssurance,
                    numClient,
                    dateResa,
                    dateDebutResa.Value,
                    dateFinResa.Value,
                    montant,
                    forfaitKm
                );
                da.LesReservations.Add(resa);
                resa.Create();
                System.Windows.MessageBox.Show("Réservation ajoutée avec succès !");
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez remplir tous les champs.");
            }
            if(mw.dgLesVehicules)
            System.Windows.MessageBox.Show($"Le montant total de la réservation est de {montant} euros");

            
        }

    }
}
