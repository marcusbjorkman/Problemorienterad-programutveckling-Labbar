using Bank.Models.Accounts;

using System;
using System.Collections.Generic;

namespace Bank.Models.Customers
{
    public class Customer
    {
        public string Cellphone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<BankAccount> BankAccounts { get; } = new List<BankAccount>();

        public Customer(string cellPhone, string firstName, string lastnName)
        {
            Cellphone = cellPhone;
            FirstName = firstName;
            LastName = lastnName;
        }

        /// <summary>
        /// Adds a new BankAccount and returns it
        /// </summary>
        public T AddAccount<T>(double credit = 0) where T : BankAccount
        {
            BankAccount account = null;
            if (typeof(T) == typeof(CheckingAccount))
            {
                account = new CheckingAccount(credit);
            }
            else if (typeof(T) == typeof(RetirementAccount))
            {
                account = new RetirementAccount();
            }
            else if (typeof(T) == typeof(SavingsAccount))
            {
                account = new SavingsAccount();
            }
            else
            {
                throw new NotImplementedException();
            }

            BankAccounts.Add(account);
            return account as T;
        }

    }
}
