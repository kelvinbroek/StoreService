using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace myService
{
    public class StoreService : IStoreService
    {
        public bool LoginUser(string username, string password)
        {
            using (Entities ctx = new Entities())
            {
                var users = from n in ctx.Customers
                            select n;
                foreach (Customers c in users)
                {
                    if (c.Username.Equals(username) && c.Password.Equals(password))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public CustomerDTO InsertCustomer(string value)
        {
            Random rnd = new Random();

            using (Entities ctx = new Entities())
            {
                Customers exist = ctx.Customers.FirstOrDefault(u => u.Username == value);
                if (exist == null)
                {
                    Customers c = new Customers
                    {
                        Username = value,
                        Password = "secret" + rnd.Next(0, 100),
                        Saldo = 300
                    };
                    ctx.Customers.Add(c);
                    ctx.SaveChanges();
                    return new CustomerDTO { Username = value, Password = "secret" + rnd.Next(0, 100), Saldo = 300 };
                }
            }
            return new CustomerDTO { Username = "exists", Password = "exists", Saldo = 0 };
        }

        public List<ProductDTO> GetAllProducts()
        {
            using (Entities ctx = new Entities())
            {
                List<ProductDTO> list = new List<ProductDTO>();
                var products = from p in ctx.Products
                               select p;
                foreach (Products product in products)
                {
                    list.Add(new ProductDTO { Name = product.Name, Price = product.Price, Stock = product.Aantal});
                }

                return list;
            }
        }

        public bool BuyProduct(int aantal, int chosenProduct, string username)
        {
            try
            {
                using (Entities ctx = new Entities())
                {
                    Customers customer = ctx.Customers.FirstOrDefault(c => c.Username == username);
                    Orders orderlist =
                        ctx.Orders.FirstOrDefault(p => p.CustomerId == customer.CustomerId && p.ProductId == chosenProduct);

                    if (orderlist != null)
                    {
                        orderlist.Aantal = orderlist.Aantal + aantal;
                    }
                    else
                    {
                        Orders newOrderList = new Orders
                        {
                            CustomerId = customer.CustomerId,
                            ProductId = chosenProduct,
                            Aantal = aantal
                        };
                        ctx.Orders.Add(newOrderList);
                    }

//                    Customers customer = ctx.Customers.FirstOrDefault(p => p.CustomerId == customerId);
                    Products product = ctx.Products.FirstOrDefault(p => p.ProductId == chosenProduct);

                    customer.Saldo = customer.Saldo - (product.Price * aantal);
                    product.Aantal = product.Aantal - aantal;

                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                string error = "" + e;
                return false;
            }
        }

        public List<ProductDTO> GetMyInventory(string username)
        {
            using (Entities ctx = new Entities())
            {
                Customers customer = ctx.Customers.FirstOrDefault(c => c.Username == username);

                var orders = ctx.Orders.Where(o => o.CustomerId == customer.CustomerId);

                List<ProductDTO> list = new List<ProductDTO>();

                foreach (var product in orders)
                {
                    Products item = ctx.Products.FirstOrDefault(i => i.ProductId == product.ProductId);
                    list.Add(new ProductDTO { Name = item.Name, Price = item.Price, Stock = item.Aantal});
                }

                return list;
            }
        }

        public double GetSaldo(string username)
        {
            using (Entities ctx = new Entities())
            {
                Customers customer = ctx.Customers.FirstOrDefault(p => p.Username == username);
                return customer.Saldo;
            }
        }
    }
}
