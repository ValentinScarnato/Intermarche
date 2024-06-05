using System;
using System.Collections.Generic;
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
    }
}
