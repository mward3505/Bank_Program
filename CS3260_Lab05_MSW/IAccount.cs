using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CS3260_Lab05_MSW
{
    internal interface IAccount
    {
        public bool SetName(string inName);
        public string GetName();
        public bool SetAddress(string inAddress);
        public string GetAddress();
        public bool PayInFunds(decimal amount);
        public bool WithdrawFunds(decimal amount);
        public bool SetBalance(decimal inBalance);
        public decimal GetBalance();
        public void SetState(Account.AccountState state);
    }
}
