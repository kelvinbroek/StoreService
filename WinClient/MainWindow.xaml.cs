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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WinClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomerController customerController;
        public MainWindow()
        {
            InitializeComponent();
            customerController = new CustomerController();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool result = customerController.LoginUser(Username.Text, Password.Text);
            if (result)
            {
                Store itembox = new Store();
                itembox.LoggedUser.Content = Username.Text;
                itembox.saldoLabel.Content = customerController.GetSaldo(itembox.LoggedUser.Content.ToString());
                itembox.Show();
            }
            else
            {
                LoginFailed.Content = "Incorrect login values";
            }
        }
    }
}
