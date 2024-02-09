using CS3260_Lab05_MSW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CS3260_Lab05_MSW.Account;

namespace CS3260_Lab05_MSW
{
    ///<summary>
    /// This class models a users bank savings account. It inherits from the Account class and
    /// has specific information about the savings account like the balance and service fees./// </summary>
    internal class SavingsAccount : Account
    {
        private const decimal _savingsMinBalance = 100;
        private const decimal _serviceFee = 0.01m;

        /// <summary>
        /// Savings account contstructor to provide the correct default balance and account number associated
        /// with the account type. Increments the static source number for more accounts to be created
        /// </summary>
        public SavingsAccount()
        {
            _accountType = "Savings";
            _accountnumber = AccountNumSource + "S";
            _accountState = AccountState.New;
            AccountNumSource++;
        }

        /// <summary>
        /// Set's the balance making sure that it's a valid amount and meets the minimum requirement
        /// </summary>
        /// <param name="inBalance">The amount needed to be in the balance</param>
        /// <returns>Bool to determine success of setting the balance</returns>
        public override bool SetBalance(decimal inBalance)
        {
            if (inBalance < 0 || inBalance < _savingsMinBalance)
            {
                return false;
            }

            _balance = inBalance;
            return true;
        }

        /// <summary>
        /// Gets the service fee used for when a deposit is made
        /// </summary>
        /// <returns>decimal of the _serviceFee variable</returns>
        public decimal GetFee() { return _serviceFee; }

        /// <summary>
        /// Overrides main deposit functionality to add intrest to all deposits made to savings
        /// </summary>
        /// <param name="amount">The amount the user want's to deposit</param>
        /// <returns>The success of the deposit</returns>
        public override bool PayInFunds(decimal amount)
        {
            if (amount < 0) //checks to make sure amount is not less than 0
            {
                return false;
            }

            _balance += amount;
            amount = amount * _serviceFee;
            _balance += amount;
            return true;
        }
    }
}
