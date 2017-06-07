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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private CustomerController controller;
        public Register()
        {
            InitializeComponent();
            controller = new CustomerController();
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ChosenUsername.Text.Equals(""))
            {
                string password = controller.RegisterCustomer(ChosenUsername.Text);
                if (password == null)
                {
                    RenderedPassword.Content = "Deze gebruikersnaam is al in gebruik!";
                }
                else
                {
                    RenderedPassword.Content = "Uw wachtwoord is: " + password;
                }
            }
        }
    }
}
