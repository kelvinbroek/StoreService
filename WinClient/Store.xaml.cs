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
            
            foreach (ProductModel product in stockProducts)
            {
                items.Items.Add(new TextBox().Text = product.Name + "         " + product.Stock);
            }


            FillMyInventory();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var item = stockProducts[items.SelectedIndex];

            if (!(int.Parse(saldoLabel.Content.ToString()) < (item.Price * int.Parse(aantal.Text))))
            {
                if (productController.BuyProduct(int.Parse(aantal.Text), item.Name, LoggedUser.Content.ToString()))
                {
                    saldoLabel.Content = customerController.GetSaldo(LoggedUser.Content.ToString());
                    FillMyInventory();
                }
            }
            else
            {
                Error.Content = "Te weinig saldo!";
            }

        }

        private void FillMyInventory()
        {
            myProducts = productController.GetMyInventory("" + LoggedUser.Content);
            myItems.Items.Clear();

            foreach (ProductModel product in myProducts)
            {
                myItems.Items.Add(new TextBox().Text = product.Name + "         " + product.Stock);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            stockProducts = productController.GetAllProducts();
            items.Items.Clear();

            foreach (ProductModel product in stockProducts)
            {
                items.Items.Add(new TextBox().Text = product.Name + "         " + product.Stock);
            }
        }
    }
}