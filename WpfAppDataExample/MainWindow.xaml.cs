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

namespace WpfAppDataExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //ESTOS DOS DE AQUI DEBAJO SERIAN DELEGADOS
            //EVENTO QUE OBTIENE UN PRODUCTO
            cmdGetProduct.Click += CmdGetProduct_Click;
            //EVENTO QUE ACTUALIZA UN PRODUCTO
            cmdUpdateProduct.Click += CmdUpdateProduct_Click;

        }

        private void CmdUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            //
            Product product = (Product)gridProductDetails.DataContext;
            try
            {
                App.StoreDB.UpdateProduct(product);
            }
            catch
            {
                MessageBox.Show("Error de conexion a la DB.");
            }
        }

        //EVENTO DEL BOTON
        private void CmdGetProduct_Click(object sender, RoutedEventArgs e)
        {
            int ID;
            //PARSEAMOS EL ID INTRODUCIDO, COMO SE RECIBE UN STRING
            //LO CONVERTIMOS A INT
            if (Int32.TryParse(txtProductId.Text, out ID))
            {
                try
                {
                    gridProductDetails.DataContext = App.StoreDB.GetProduct(ID);
                }
                catch
                {
                    MessageBox.Show("Error de conexion a la DB.");
                }
            }
            else
            {
                MessageBox.Show("Invalido ID.");
            }
        }
    }
}