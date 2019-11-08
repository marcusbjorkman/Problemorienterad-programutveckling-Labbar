using System;

namespace Bank.Models.Accounts
{
    public abstract class BankAccount
    {
        public Guid Id { get; }
        public Type AccountType { get; }

        public double Balance { get; protected set; }

        public double Credit { get; protected set; }

        protected BankAccount(Type accountType)
        {
            AccountType = accountType;
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Tries to withdraw the specified amount.
        /// </summary>
        /// <param name="amount">The amount to withdraw</param>
        public abstract bool TryWithdraw(double amount, out double availableBalance);

        /// <summary>
        /// Returns the new balance after the deposit is made.
        /// </summary>
        /// <param name="amount">The amount to deposit</param>
        public double Deposit(double amount)
        {
            Balance += amount;
            return Balance;
        }

        public double GetAvailableBalance()
        {
            return Math.Max(Balance, 0) + Credit;
        }
    }
}
