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

       
        private bool VerifierLogin()
        {
            bool isValid = false;

            // Remplacez par votre chaîne de connexion à la base de données
            string connectionString = "Server=srv-peda-new;" + "port=5433;" +
                "Database=votreBase;" + "Search Path = votreSchemaPostGresql;" + "uid=votreLogin;" +
                "password=votrePassword;";

            return isValid;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
