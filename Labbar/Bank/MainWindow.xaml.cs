using Bank.Models.Accounts;
using Bank.Models.Customers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NewCustomerWindow newCustomerWindow;
        private NewAccountWindow newAccountWindow;

        public Customer ActiveCustomer { get; private set; }
        public BankAccount ActiveAccount { get; private set; }

        public readonly ObservableCollection<Customer> CustomerList = new ObservableCollection<Customer> { null };
        public ObservableCollection<BankAccount> AccountList { get; private set; } = new ObservableCollection<BankAccount> { null };

        public MainWindow()
        {
            InitializeComponent();
            
            ComboBoxCustomer.ItemsSource = CustomerList;
            ComboBoxCustomer.DisplayMemberPath = nameof(Customer.FullName);

            ComboBoxAccount.ItemsSource = AccountList;
            ComboBoxAccount.DisplayMemberPath = nameof(BankAccount.Id);
        }

        private void BtnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (newCustomerWindow == null || newCustomerWindow.IsLoaded == false)
            {
                newCustomerWindow = new NewCustomerWindow();
                newCustomerWindow.Owner = this;
                newCustomerWindow.Show();
            }

            newCustomerWindow.Activate();
        }

        private void BtnNewAccount_Click(object sender, RoutedEventArgs e)
        {
            if (newAccountWindow == null || newAccountWindow.IsLoaded == false)
            {
                newAccountWindow = new NewAccountWindow();
                newAccountWindow.Owner = this;
                newAccountWindow.Show();
            }

            newAccountWindow.Activate();
        }

        private void ComboBoxCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems?[0] == null)
            {
                GridSelectCustomer.IsEnabled = false;
                return;
            }

            ActiveCustomer = (sender as ComboBox).SelectedItem as Customer;
            AccountList = new ObservableCollection<BankAccount>(ActiveCustomer.BankAccounts);

            GridSelectCustomer.IsEnabled = true;
        }

        private void ComboBoxAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems?[0] == null)
            {
                GridSelectAccount.IsEnabled = false;
                return;
            }

            ActiveAccount = (sender as ComboBox).SelectedItem as BankAccount;
            GridSelectAccount.IsEnabled = true;
        }
    }
}
