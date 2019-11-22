using Bank.Models.Customers;

using System.Linq;
using System.Windows;

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

            if (string.IsNullOrEmpty(TxtBoxFirstname.Text)
                || string.IsNullOrEmpty(TxtBoxLastname.Text)
                || string.IsNullOrEmpty(TxtBoxPhoneNumber.Text))
            {
                MessageBox.Show("Fyll i alla fält.");
                return;
            }

            var customer = new Customer(TxtBoxPhoneNumber.Text, TxtBoxFirstname.Text, TxtBoxLastname.Text);
            owner.CustomerList.Add(customer);

            owner.ComboBoxCustomer.SelectedItem = customer;
            Close();
        }
    }
}
