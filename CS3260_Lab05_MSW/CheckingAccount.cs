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
        private const decimal _checkingMinBalance = 10;
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
    }
}
