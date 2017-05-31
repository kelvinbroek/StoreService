using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ServiceReference1;

namespace Client
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            bool result = client.LoginUser(UsernameTextbox.Text, PasswordTextbox.Text);
            if (result)
            {
                label2.Text = "Ingelogd!";
                Items itembox = new Items();
                itembox.Show();
            }
        }
    }
}
