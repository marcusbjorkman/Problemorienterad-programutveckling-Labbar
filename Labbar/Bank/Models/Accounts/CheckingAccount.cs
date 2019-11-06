using System;

namespace Bank.Models.Accounts
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(double credit)
            : base(typeof(CheckingAccount))
        {
            Credit = credit;
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

            var creditWithdrawal = Math.Max(Balance, 0) - amount;
            if (creditWithdrawal < 0)
            {
                Credit += creditWithdrawal;
            }

            Balance -= amount;
            availableBalance = GetAvailableBalance();

            return true;
        }
    }
}
