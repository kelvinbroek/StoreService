using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ServiceReference1;

namespace Client
{
    public partial class Items : Form
    {
        public Items()
        {
            InitializeComponent();
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            var products = client.GetAllProducts();
            for(int i=0; i < products.Length; i++)
            {
                Itembox.Items.Add(new TextBox().Text = products[i].Name);
            }
        }
    }
}
