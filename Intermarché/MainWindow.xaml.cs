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
        private ObservableCollection<Employe> lesEmployes;
        private NpgsqlConnection connexion = null;   // futur lien à la BD

        public ObservableCollection<Employe> LesEmployes
        {
            get
            {
                return lesEmployes;
            }
            set
            {
                this.lesEmployes = value;
            }
        }
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private String fentreAOuvrir;
        public String FentreAOuvrir
        {
            get { return fentreAOuvrir; }
            set
            {
                if (value != "Connexion" && value != "Réservation")
                    throw new ArgumentException("Error");
                fentreAOuvrir = value;
            }
        }
        public bool quitter = false;
        public bool resa = false;


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FentreAOuvrir = "Connexion";
            OuvertureFenetre();
        }

        public void OuvertureFenetre()
        {
            resa = false;
            while (!quitter && !resa)
            {
                switch (fentreAOuvrir)
                {
                    case "Connexion":
                        {
                            Connexion connexion = new Connexion();
                            connexion.ShowDialog();
                            break;
                        }
                    case "Résa":
                        {
                            resa = true;
                            break;
                        }
                    case "Quitter":
                        {
                            quitter = true;
                            break;
                        }

                }
            }

            Console.WriteLine(fentreAOuvrir + " est ouvert");

            if (quitter)
            {
                Console.WriteLine(fentreAOuvrir + "pour quitter application");
                Application.Current.Shutdown();
            }
        }

        private void butValiderConnexion_Click(object sender, RoutedEventArgs e)
        {
            string login = txtboxIdentifiant.Text;
            string mdp = txtboxMdp.Text; 

            if (VerifierLogin(login, mdp))
            {
                MessageBox.Show("Connexion réussie!");
                //FINIR ET OUVRIR NVLLE PAGE
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect.");
            }
        }
        private bool VerifierLogin(string login, string mdp)
        {
            bool isValid = false;

            // Remplacez par votre chaîne de connexion à la base de données
            string connectionString = "Server=srv-peda-new;" + "port=5433;" +
                "Database=votreBase;" + "Search Path = votreSchemaPostGresql;" + "uid=votreLogin;" +
                "password=votrePassword;";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM Employe WHERE Login = @Login AND Mdp = @Mdp";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Mdp", mdp);

                    connection.Open();

                    int count = (int)(command.ExecuteScalar());

                    if (count == 1)
                    {
                        isValid = true;
                    }

                    connection.Close();
                }
            }

            return isValid;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
