using System;

namespace Bank.Models.Accounts
{
    public class SavingsAccount : BankAccount
    {

        public SavingsAccount()
            : base(typeof(SavingsAccount))
        {

        }

        public override bool TryWithdraw(double amount, out double availableBalance)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot withdraw less than 0", nameof(amount));
            }

            var currentBalance = GetAvailableBalance();
            if (amount > currentBalance)
            {
                availableBalance = currentBalance;
                return false;
            }

            Balance -= amount;
            availableBalance = GetAvailableBalance();

            return true;
        }
    }
}
