using System;

namespace Bank.Models.Accounts
{
    public class RetirementAccount : BankAccount
    {
        public RetirementAccount()
            : base(typeof(RetirementAccount))
        {

        }

        public override bool TryWithdraw(double amount, out double availableBalance)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot withdraw less than 0", nameof(amount));
            }

            var totalWithdrawal = amount * 1.1;
            var currentBalance = GetAvailableBalance();

            if (totalWithdrawal > currentBalance)
            {
                availableBalance = currentBalance;
                return false;
            }

            Balance -= totalWithdrawal;
            availableBalance = GetAvailableBalance();

            return true;
        }
    }
}
