using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WinClient.Models;

namespace WinClient
{
    class CustomerController
    {
        ServiceReference.IStoreService client = new ServiceReference.StoreServiceClient();

        public string RegisterCustomer(string username)
        {
            var newCustomer = client.InsertCustomer(username);

            if (!newCustomer.Username.Equals("exists"))
            {
                return newCustomer.Password;
            }

            return null;
        }

        public bool LoginUser(string username, string password)
        {
            bool loggedIn = client.LoginUser(username, password);
            if (loggedIn)
            {
                return true;
            }

            return false;
        }

        public double GetSaldo(string username)
        {
            return client.GetSaldo(username);
        }
    }
}
