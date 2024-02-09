using CS3260_Lab05_MSW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CS3260_Lab05_MSW
{
    ///<summary>
    /// This class models a users bank account. It contains key information
    /// about an account and varaibles and methods to manage that data/// </summary>
    internal abstract class Account : IAccount
    {
        const decimal initialBalance = 100;

        protected string _name;
        protected string _address;
        protected decimal _balance;
        protected string _accountnumber;
        protected string _accountType;
        protected AccountState _accountState;

        public static int AccountNumSource = 1000;

        public enum AccountState
        {
            New,
            Active,
            UnderAudit,
            Frozen,
            Closed
        }

        //public Account()
        //{
        //    _balance = initialBalance;
        //    _accountState = AccountState.New;
        //    AccountNumber = AccountNumSource;
        //    AccountNumSource++;
        //}

        /// <summary>
        /// Purpose: Get and set the account number
        /// </summary>
        /// <param _accountNumber>the users account number for the class</param>
        /// <returns>get can return the users account number</returns>
        /// -----------------------------------------------------------------
        public string AccountNumber
        {
            get { return _accountnumber; }
        }

        /// <summary>
        /// Gets the account type
        /// </summary>
        /// <returns>String of the account type</returns>
        public string GetType() { return _accountType; }

        /// <summary>
        /// Purpose: Set the name for the account
        /// </summary>
        /// <param _name= inName>Sets the name for the class based ont he users input. Must be a valid or non-empty string</param>
        /// <returns>Returns a bool of true or false to help know if it was a success or not</returns>
        /// -----------------------------------------------------------------
        public bool SetName(string inName)
        {
            bool hasDigit = false;
            foreach (char c in inName)
            {
                if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
            }
            if (inName == null || inName == "" || hasDigit == true)
            {
                return false;
            }

            _name = inName;
            return true;
        }

        /// <summary>
        /// Purpose: Get the name for the account
        /// </summary>
        /// <param _name>name of the users account</param>
        /// <returns>String value of the users name</returns>
        /// -----------------------------------------------------------------
        public string GetName() { return _name; }

        /// <summary>
        /// Purpose: Set the address for the account
        /// </summary>
        /// <param _address= inAddress>Sets the Address for the class based ont he users input. Must be a valid or non-empty string</param>
        /// <returns>Returns a bool of true or false to help know if it was a success or not</returns>
        /// -----------------------------------------------------------------
        public bool SetAddress(string inAddress)
        {
            if (inAddress == null || inAddress == "")
            {
                return false;
            }

            _address = inAddress;
            return true;
        }

        /// <summary>
        /// Purpose: Get the Address for the account
        /// </summary>
        /// <param _address>Address of the user saccount</param>
        /// <returns>String value of the users Address</returns>
        /// -----------------------------------------------------------------
        public string GetAddress() { return _address; }

        /// <summary>
        /// Purpose: Adds the amount the user wants to the balance of the account
        /// </summary>
        /// <param amount>users input of the amount they would like to add and is a decimal</param>
        /// <param _balance>users current balance in their account</param>
        /// <returns>Bool value to know if adding funds was a success</returns>
        /// -----------------------------------------------------------------
        public virtual bool PayInFunds(decimal amount)
        {
            if (amount < 0) //checks to make sure amount is not less than 0
            {
                return false;
            }

            _balance += amount;
            return true;
        }

        /// <summary>
        /// Purpose: Removes the amount the user wants from the balance of the account
        /// </summary>
        /// <param amount>users input of the amount they would like to remove and is a decimal</param>
        /// <param _balance>users current balance in their account</param>
        /// <returns>Bool value to know if adding funds was a success</returns>
        /// -----------------------------------------------------------------
        public virtual bool WithdrawFunds(decimal amount)
        {
            if (amount < 0 || amount > _balance) //checks to make sure amount is not less than 0 or greater than the balance
            {
                return false;
            }

            _balance -= amount;
            return true;
        }

        /// <summary>
        /// Purpose: Set the balance for the account
        /// </summary>
        /// <param inBalance>Users input of their balance</param>
        /// <param _balance>Users current balance on the account</param>
        /// <returns>Returns a bool of true or false to help know if it was a success or not</returns>
        /// -----------------------------------------------------------------
        public virtual bool SetBalance(decimal inBalance)
        {
            if (inBalance < 0)
            {
                return false;
            }

            _balance = inBalance;
            return true;
        }

        /// <summary>
        /// Purpose: Get the Balance for the account
        /// </summary>
        /// <param _balance>Users current balance on the account</param>
        /// <returns>Decimal value of the users Balance</returns>
        /// -----------------------------------------------------------------
        public decimal GetBalance() { return _balance; }

        /// <summary>
        /// Purpose: Set the state for the account
        /// </summary>
        /// <param state>Input of the state of the acount</param>
        /// <param _accountState>Current account status</param>
        /// -----------------------------------------------------------------
        public void SetState(AccountState state)
        {
            _accountState = state;
        }


        /// <summary>
        /// Purpose: Override the ToString() method to print out the status of the account to the user
        /// </summary>
        /// <returns>The string that can be printed to the console</returns>
        public override string ToString()
        {
            return
                $"Acct Name: {_name}\n" +
                $"Acct Address: {_address}\n" +
                $"Acct Number: {_accountnumber}\n" +
                $"Acct Type: {_accountType}\n" +
                $"Current Balance: {_balance.ToString("C")}\n";
        }

    }
}
