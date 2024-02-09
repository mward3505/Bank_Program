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
    /// This class models a users bank checking account. It inherits from the Account class and
    /// has specific information about the checking account like the balance and service fees./// </summary>
    internal class CheckingAccount : Account
    {
        private const decimal _checkingMinBalance = 100;
        private const decimal _serviceFee = 5;

        /// <summary>
        /// Checking account contstructor to provide the correct default balance and account number associated
        /// with the account type. Increments the static source number for more accounts to be created
        /// </summary>
        public CheckingAccount()
        {
            _accountType = "Checking";
            _accountnumber = AccountNumSource + "C";
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
            if (inBalance < 0 || inBalance < _checkingMinBalance)
            {
                return false;
            }

            _balance = inBalance;
            return true;
        }

        /// <summary>
        /// Get the service fee for withdrawls
        /// </summary>
        /// <returns>Decimal of the _serviceFee</returns>
        public decimal GetFee() { return _serviceFee; }

        /// <summary>
        /// Overrides the main withdraw function from account to implement behavior for when the user wants to withdraw an amount that will
        /// bring their account under the minimum and apply the fee
        /// </summary>
        /// <param name="amount">The amount the user wants to withdraw</param>
        /// <returns>Boolean of the success of the withdraw</returns>
        public override bool WithdrawFunds(decimal amount)
        {
            if (_balance - amount < _checkingMinBalance)
            {
                
                if (amount < 0 || amount + _serviceFee > _balance && amount != 0) //checks to make sure amount is not less than 0 or greater than the balance with service fee
                {
                    return false;
                }
                else
                {
                    if (amount == 0)
                    {
                        return true;
                    }
                    _balance -= amount + _serviceFee;
                    return true;
                }
            }
            if (amount < 0 || amount > _balance && amount != 0) //checks to make sure amount is not less than 0 or greater than the balance
            {
                return false;
            }

            _balance -= amount;
        
            return true;
        }
    }
}
