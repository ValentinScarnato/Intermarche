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
using System.Windows.Shapes;

namespace Intermarché
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        private MainWindow mainWin;

        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private string mdp;

        public string Mdp
        {
            get { return mdp; }
            set { mdp = value; }
        }


        public MainWindow MainWin
        {
            get { return mainWin; }
            set { mainWin = value; }
        }

        private bool ClosedByConnexion = false;

        public Connexion(MainWindow mainWin)
        {
            MainWin = mainWin;
            InitializeComponent();
        }

        public Connexion(string login, string mdp)
        {
            this.Login = login;
            this.Mdp = mdp;
        }

        private void butValiderConnexion_Click(object sender, RoutedEventArgs e)
        {
            
            string login = txtboxIdentifiant.Text;
            string mdp = txtboxMdp.Password;
            DataAccess da = DataAccess.Instance;
            if (da.VerifierLogin(login,mdp))
            {
                this.MainWin.Show();
                this.ClosedByConnexion = true;
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Erreur login / password");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (!this.ClosedByConnexion)
            {
                Application.Current.Shutdown();
            }
            
        }
    }
}

