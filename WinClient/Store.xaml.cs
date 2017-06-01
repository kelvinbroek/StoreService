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
        public Store()
        {
            InitializeComponent();

            CustomerController customerController = new CustomerController();
            ProductController productController = new ProductController();

            List<ProductModel> stockProducts = productController.GetAllProducts();
            List<ProductModel> myProducts = productController.GetMyInventory();

            for (int i = 0; i < stockProducts.Count; i++)
            {
                items.Items.Add(new TextBox().Text = stockProducts[i].Name + "         " + stockProducts[i].Stock);
            }
        }
    }
}