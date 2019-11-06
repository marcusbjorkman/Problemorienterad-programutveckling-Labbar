using Bank.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models.Customers
{
    public class Customer
    {
        public string Cellphone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<BankAccount> BankAccounts { get; set; }
    }
}
