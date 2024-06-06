﻿using Npgsql;
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
        private static int numeroReservationCourant = 0;

        public MainWindow()
        {
            Connexion connect = new Connexion();
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

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void butReserver_Click(object sender, RoutedEventArgs e)
        {
            numeroReservationCourant++;
            int numeroReservation = numeroReservationCourant;
            MessageBox.Show($"Numéro de réservation créé : {numeroReservation}");
        }

        private void butCreateClent_Click(object sender, RoutedEventArgs e)
        {
            ClientFormWindow clientFormWindow = new ClientFormWindow();
            clientFormWindow.ShowDialog();
        }
    }
}
