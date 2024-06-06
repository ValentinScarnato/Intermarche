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
using System.Windows.Shapes;

namespace Intermarché
{
    /// <summary>
    /// Logique d'interaction pour ClientFormWindow.xaml
    /// </summary>
    public partial class ClientFormWindow : Window
    {
        public ClientFormWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nomClient = txtNomClient.Text;
            string adresseRueClient = txtAdresseRueClient.Text;
            string adresseCpClient = txtAdresseCpClient.Text;
            string adresseVilleClient = txtAdresseVilleClient.Text;
            string telephoneClient = txtTelephoneClient.Text;
            string mailClient = txtMailClient.Text;

            Client newClient = new Client(0, nomClient, adresseRueClient, adresseCpClient, adresseVilleClient, telephoneClient, mailClient);

            MessageBox.Show($"Nom: {nomClient}\nAdresse: {adresseRueClient}, {adresseCpClient} {adresseVilleClient}\nTéléphone: {telephoneClient}\nEmail: {mailClient}", "Détails du client");

            this.Close();   
        }
    }
}
