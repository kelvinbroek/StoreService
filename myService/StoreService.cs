using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
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
                    int pass = rnd.Next(0, 100);
                    Customers c = new Customers
                    {
                        Username = value,
                        Password = "secret" + pass,
                        Saldo = 300
                    };
                    ctx.Customers.Add(c);
                    ctx.SaveChanges();
                    return new CustomerDTO { Username = value, Password = "secret" + pass, Saldo = 300 };
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
                               where p.Aantal > 0
                               select p;
                foreach (Products product in products)
                {
                    list.Add(new ProductDTO { Name = product.Name, Price = product.Price, Stock = product.Aantal});
                }

                return list;
            }
        }

        public bool BuyProduct(int aantal, string chosenProduct, string username)
        {
            try
            {
                using (Entities ctx = new Entities())
                {
                    Customers customer = ctx.Customers.FirstOrDefault(c => c.Username == username);
                    Products pr = ctx.Products.FirstOrDefault(c => c.Name.Equals(chosenProduct));
                    Orders orderlist =
                        ctx.Orders.FirstOrDefault(p => p.CustomerId == customer.CustomerId && p.ProductId == pr.ProductId);

                    if (orderlist != null)
                    {
                        orderlist.Aantal = orderlist.Aantal + aantal;
                    }
                    else
                    {
                        Orders newOrderList = new Orders
                        {
                            CustomerId = customer.CustomerId,
                            ProductId = pr.ProductId,
                            Aantal = aantal
                        };
                        ctx.Orders.Add(newOrderList);
                    }

                    customer.Saldo = customer.Saldo - (pr.Price * aantal);
                    pr.Aantal = pr.Aantal - aantal;

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
            List<ProductDTO> list = new List<ProductDTO>();

            using (Entities ctx = new Entities())
            {
                Customers customer = ctx.Customers.FirstOrDefault(c => c.Username == username);

                IEnumerable<ProductDTO> orders = from o in ctx.Orders
                             where o.CustomerId == customer.CustomerId
                             let pr = ctx.Products.FirstOrDefault(p => p.ProductId == o.ProductId)
                             select new ProductDTO {Name = pr.Name, Stock = o.Aantal, Price = pr.Price};
                
                list.Add(new ProductDTO { Name = "Banana", Price = 2.0, Stock = 3});
                list = orders.ToList();
            }
            return list;
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
