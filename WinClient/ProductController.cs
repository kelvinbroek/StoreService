using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinClient
{
    class ProductController
    {
        ServiceReference.IStoreService client = new ServiceReference.StoreServiceClient();

        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> models = new List<ProductModel>();
            var products = client.GetAllProducts();
            foreach (var product in products)
            {
                models.Add(new ProductModel{Name = product.Name, Price = product.Price, Stock = product.Stock});
            }
            return models;
        }
    }
}
