using Bank.Models.Accounts;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer(null, "Bärt", "Bärtsson");

            var retirementAcc = customer.AddAccount<RetirementAccount>();
            retirementAcc.Deposit(660);
            if (!retirementAcc.TryWithdraw(600, out double availableRetirementBalance)
                || availableRetirementBalance > 0)
            {
                throw new Exception();
            }

            var checkingAcc = customer.AddAccount<CheckingAccount>(1500);
            checkingAcc.Deposit(300);
            if (!checkingAcc.TryWithdraw(1800, out _)
                || checkingAcc.Balance != -1500)
            {
                throw new Exception();
            }
        }
    }
}
