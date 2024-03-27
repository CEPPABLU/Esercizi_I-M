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

namespace Eser_Merc
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

        private void btnOrdini_Click(object sender, RoutedEventArgs e)
        {
            Ordine finestraOrdine = new Ordine();
            finestraOrdine.Show();
            this.Close();

        }

        private void btnUtente_Click(object sender, RoutedEventArgs e)
        {
            Utente finestraUtente = new Utente();
            finestraUtente.Show();
            this.Close();

        }

        private void btnProdotti_Click(object sender, RoutedEventArgs e)
        {
            Prodotto finestraProdotto = new Prodotto();
            finestraProdotto.Show();
            this.Close();

        }
    }
}