using Bank.Models.Customers;
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

namespace Bank
{
    /// <summary>
    /// Interaction logic for NewCustomerWindow.xaml
    /// </summary>
    public partial class NewCustomerWindow : Window
    {
        public NewCustomerWindow()
        {
            InitializeComponent();
        }

        private void BtnSaveCustomer_Click(object sender, RoutedEventArgs e)
        {
            var owner = (Owner as MainWindow);
            if (owner.CustomerList.FirstOrDefault() == null)
            {
                owner.CustomerList.Remove(null);
            }

            var customer = new Customer("0123", "Erik", "Öberg");
            owner.CustomerList.Add(customer);

            owner.ComboBoxCustomer.SelectedItem = customer;
            Close();
        }
    }
}
