using CS3260_Lab05_MSW;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3260_Lab05_MSW
{
    /// <summary>
    /// This class creates and holds a Account bank array to store multiple accounts information and provides
    /// access to the array's information. Inherits from the
    /// Enumerable interface to provide bracket functionality.
    /// </summary>
    internal class AccountBank : IEnumerable<Account>
    {
        //Creates the array
        private Account[] _accounts;

        /// <summary>
        /// Account banks constructor to create the array with the appropriate size to input the accounts
        /// </summary>
        /// <param name="size">The size of the array that will be created</param>
        public AccountBank(int size)
        {
            _accounts = new Account[size];
        }

        /// <summary>
        /// Provide a length operator for the array to use to provide how big it is
        /// </summary>
        public int Length
        {
            get { return _accounts.Length; }
        }

        /// <summary>
        /// provides the ability to use [] notation when accessing the array to be able to get and set information
        /// in the specific location
        /// </summary>
        /// <param name="i">Provides a way for the index to work with the array</param>
        /// <returns></returns>
        public Account this[int i]
        {
            get { return _accounts[i]; }
            set { _accounts[i] = value; }
        }

        /// <summary>
        /// Provides a way to use the array in a foreach loop
        /// </summary>
        /// <returns>the account enumerator</returns>
        public IEnumerator<Account> GetEnumerator()
        {
            return ((IEnumerable<Account>)_accounts).GetEnumerator();
        }

        /// <summary>
        /// Provides another way to use the array in a foreach loop
        /// </summary>
        /// <returns>the account enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _accounts.GetEnumerator();
        }

        /// <summary>
        /// Stores the information in the Account bank array with the Account object provided
        /// </summary>
        /// <param name="account">The account object that you would like to store in the array</param>
        /// <returns>The success bool value to know if the information was properly stored</returns>
        bool StoreAccount(Account account)
        {
            if (account == null)
            {
                return false;
            }

            bool foundEmptySpot = false;
            for (int i = 0; i < _accounts.Length; i++)
            {
                if (_accounts[i] == null)
                {
                    _accounts[i] = account;
                    foundEmptySpot = true;
                    break;
                }
            }

            if (!foundEmptySpot)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method for finding an account number in the Account bank array
        /// </summary>
        /// <param name="accountNumber">The desired account number that needs to be found</param>
        /// <returns>The Account object that was found in the array. If not found then it returns null</returns>
        Account FindAccount(string accountNumber)
        {
            foreach (var account in _accounts)
            {
                if (account != null && account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }

            return null;
        }
    }
}
