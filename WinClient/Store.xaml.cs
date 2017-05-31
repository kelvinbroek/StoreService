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

            ServiceReference.IStoreService client = new ServiceReference.StoreServiceClient();
            
            var products = client.GetAllProducts();
            List<ProductModel> models = new List<ProductModel>();

            for (int i = 0; i < products.Length; i++)
            {
                models.Add(new ProductModel {Name = products[i].Name, Price = products[i].Price});
                items.Items.Add(new TextBox().Text = products[i].Name);
            }
            saldoLabel.Content = "300";
        }
    }
}