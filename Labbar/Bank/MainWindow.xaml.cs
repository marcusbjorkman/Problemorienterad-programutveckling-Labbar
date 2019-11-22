using Bank.Models.Accounts;
using Bank.Models.Customers;

using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

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
        public ObservableCollection<BankAccount> AccountList { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            
            ComboBoxCustomer.ItemsSource = CustomerList;
            ComboBoxCustomer.DisplayMemberPath = nameof(Customer.FullName);
            
            ComboBoxAccount.DisplayMemberPath = nameof(BankAccount.DisplayName);
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
            ComboBoxAccount.ItemsSource = AccountList;

            GridSelectCustomer.IsEnabled = true;
        }

        private void ComboBoxAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((object[])e.AddedItems)?.FirstOrDefault() == null)
            {
                return;
            }

            var selectedAccount = (sender as ComboBox).SelectedItem as BankAccount;
            if (selectedAccount == ActiveAccount)
            {
                return;
            }

            ActiveAccount = selectedAccount;
            GridSelectAccount.IsEnabled = true;
            TxtBlockWithdrawals.Text = null;
        }

        private void BtnOkTransaction_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBoxAmount.Text) 
                || !double.TryParse(TxtBoxAmount.Text, out double amount))
            {
                MessageBox.Show("Ange ett belopp först!");
                return;
            }

            if (RadioBtnWithdraw.IsChecked.Value)
            {
                if (ActiveAccount.TryWithdraw(amount, out _))
                {
                    TxtBlockWithdrawals.Text += 
                        $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm")} - {RadioBtnWithdraw.Content} - {amount}kr\n";
                }
                else
                {
                    MessageBox.Show("Du saknar täckning på kontot.");
                    return;
                }
            }
            else
            {
                ActiveAccount.Deposit(amount);
                TxtBlockWithdrawals.Text +=
                    $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm")} - {RadioBtnDeposit.Content} - {amount}kr\n";
            }

            int sIndex = ComboBoxAccount.SelectedIndex;
            ComboBoxAccount.SelectedIndex = -1;
            ComboBoxAccount.Items.Refresh();
            ComboBoxAccount.SelectedIndex = sIndex;
        }
    }
}
