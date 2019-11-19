using Bank.Models.Accounts;
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
    /// Interaction logic for NewAccountWindow.xaml
    /// </summary>
    public partial class NewAccountWindow : Window
    {
        public NewAccountWindow()
        {
            InitializeComponent();
        }

        private void RadioBtnChecking_Checked(object sender, RoutedEventArgs e)
        {
            if (TxtBoxCredit != null)
            {
                TxtBoxCredit.IsEnabled = true;
            }
        }

        private void RadioBtnChecking_Unchecked(object sender, RoutedEventArgs e)
        {
            TxtBoxCredit.IsEnabled = false;
        }

        private void BtnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            var owner = Owner as MainWindow;
            if (owner.AccountList?.FirstOrDefault() == null)
            {
                owner.AccountList?.Remove(null);
            }

            double credit = 0;
            if (!string.IsNullOrEmpty(TxtBoxCredit.Text) && double.TryParse(TxtBoxCredit.Text, out credit))
            {

            }

            BankAccount newAccount = null;
            if (RadioBtnChecking.IsChecked.Value)
            {
                newAccount = owner.ActiveCustomer.AddAccount<CheckingAccount>(credit);
            }
            else if (RadioBtnSaving.IsChecked.Value)
            {
                newAccount = owner.ActiveCustomer.AddAccount<SavingsAccount>();
            }
            else
            {
                newAccount = owner.ActiveCustomer.AddAccount<RetirementAccount>();
            }

            owner.AccountList.Add(newAccount);

            owner.ComboBoxAccount.SelectedItem = newAccount;
            Close();
        }
    }
}
