using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gestione_Negozio_Abbigliamento
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

        private void btnUtente_Click(object sender, RoutedEventArgs e)
        {
            Utente finestraUtente= new Utente();
            finestraUtente.Show();
            this.Close();
        }

        private void btnRicerca_Click(object sender, RoutedEventArgs e)
        {
           Prodotti finestraProdotti = new Prodotti();
            finestraProdotti.Show();
            this.Close();   
        }

        private void btnOrdini_Click(object sender, RoutedEventArgs e)
        {
            Ordini finestraOrdini = new Ordini();
            finestraOrdini.Show();
            this.Close();
        }
    }
}