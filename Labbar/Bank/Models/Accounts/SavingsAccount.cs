using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
    }
}
