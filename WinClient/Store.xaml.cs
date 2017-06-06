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

namespace WinClient
{
    /// <summary>
    /// Interaction logic for Store.xaml
    /// </summary>
    public partial class Store : Window
    {
        CustomerController customerController = new CustomerController();
        ProductController productController = new ProductController();
        private IList<ProductModel> stockProducts;
        private IList<ProductModel> myProducts;
        public Store(string user)
        {
            InitializeComponent();

            LoggedUser.Content = user;
            saldoLabel.Content = customerController.GetSaldo(LoggedUser.Content.ToString());

            stockProducts = productController.GetAllProducts();
            myProducts = productController.GetMyInventory("" + LoggedUser.Content);

            foreach(ProductModel product in stockProducts)
            {
                items.Items.Add(new TextBox().Text = product.Name + "         " + product.Stock);
            }

            foreach (ProductModel product in myProducts)
            {
                myItems.Items.Add(new TextBox().Text = product.Name + "         " + product.Stock);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string item = stockProducts[items.SelectedIndex].Name;
            if (productController.BuyProduct(int.Parse(aantal.Text), item, LoggedUser.Content.ToString()))
            {
                saldoLabel.Content = customerController.GetSaldo(LoggedUser.Content.ToString());
                myProducts = productController.GetMyInventory("" + LoggedUser.Content);
            }
        }
    }
}