using CS3260_Lab05_MSW;

namespace CS3260_Lab07_MSW
{
    [TestClass]
    public class BankingTest
    {
        private static SavingsAccount? _saveAccount;
        private static CheckingAccount? _checkingAccount;
        private static CDAccount? _cdAccount;
        private static AccountBank? _bankAccounts;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _saveAccount = new SavingsAccount();
            _checkingAccount = new CheckingAccount();
            _cdAccount = new CDAccount();
            _bankAccounts = new AccountBank();

            _bankAccounts.StoreAccount(_saveAccount);
            _bankAccounts.StoreAccount(_checkingAccount);
            _bankAccounts.StoreAccount(_cdAccount);
        }

        //[TestInitialize]
        //public static void BankTestInitialize(TestContext context)
        //{
        //    _saveAccount.SetBalance(100);
        //    _saveAccount.SetAddress("123 main");
        //    _saveAccount.SetName("Matt");
        //    _checkingAccount.SetBalance(150);
        //    _checkingAccount.SetAddress("122 street");
        //    _checkingAccount.SetName("John");
        //    _cdAccount.SetBalance(500);
        //    _cdAccount.SetAddress("154 main street");
        //    _cdAccount.SetName("Bob");
        //}

        [TestMethod]
        public void SavingsAccountTest()
        {
            //Success tests
            Assert.IsNotNull(_saveAccount);
            Assert.AreEqual(_saveAccount.GetType(), "Savings");
            Assert.AreEqual(_saveAccount.SetBalance(100), true);
            Assert.AreEqual(_saveAccount.GetBalance(), 100);
            Assert.AreEqual(_saveAccount.SetAddress("123 main"), true);
            Assert.AreEqual(_saveAccount.GetAddress(), "123 main");
            Assert.AreEqual(_saveAccount.SetName("Matt"), true);
            Assert.AreEqual(_saveAccount.GetName(), "Matt");
            Assert.AreEqual(_saveAccount.PayInFunds(100), true);
            Assert.AreEqual(_saveAccount.GetBalance(), 202);
            Assert.AreEqual(_saveAccount.WithdrawFunds(100), true);
            Assert.AreEqual(_saveAccount.GetBalance(), 102);

            //Fail tests
            Assert.AreEqual(_saveAccount.SetBalance(50), false);
            Assert.AreEqual(_saveAccount.SetAddress(""), false);
            Assert.AreEqual(_saveAccount.SetName("123"), false);
            Assert.AreEqual(_saveAccount.PayInFunds(-1), false);
            Assert.AreEqual(_saveAccount.WithdrawFunds(-1), false);
            Assert.AreEqual(_saveAccount.WithdrawFunds(100000), false);

            //Testing account number
            string accountNumber = _saveAccount.AccountNumber;
            bool result = accountNumber.EndsWith('S');
            Assert.IsTrue(result, $"Expected account number to end with 'S', but it didn't");
        }

        [TestMethod]
        public void CheckingAccountTest()
        {
            //Success tests
            Assert.IsNotNull(_checkingAccount);
            Assert.AreEqual(_checkingAccount.GetType(), "Checking");
            Assert.AreEqual(_checkingAccount.SetBalance(100), true);
            Assert.AreEqual(_checkingAccount.GetBalance(), 100);
            Assert.AreEqual(_checkingAccount.SetAddress("123 street"), true);
            Assert.AreEqual(_checkingAccount.GetAddress(), "123 street");
            Assert.AreEqual(_checkingAccount.SetName("Bob"), true);
            Assert.AreEqual(_checkingAccount.GetName(), "Bob");
            Assert.AreEqual(_checkingAccount.PayInFunds(100), true);
            Assert.AreEqual(_checkingAccount.GetBalance(), 200);
            Assert.AreEqual(_checkingAccount.WithdrawFunds(100), true);
            Assert.AreEqual(_checkingAccount.GetBalance(), 100);

            //Fail tests
            Assert.AreEqual(_checkingAccount.SetBalance(50), false);
            Assert.AreEqual(_checkingAccount.SetAddress(""), false);
            Assert.AreEqual(_checkingAccount.SetName("123"), false);
            Assert.AreEqual(_checkingAccount.PayInFunds(-1), false);
            Assert.AreEqual(_checkingAccount.WithdrawFunds(-1), false);
            Assert.AreEqual(_checkingAccount.WithdrawFunds(100000), false);

            //Testing account number
            string accountNumber = _checkingAccount.AccountNumber;
            bool result = accountNumber.EndsWith('C');
            Assert.IsTrue(result, $"Expected account number to end with 'C', but it didn't");
        }

        [TestMethod]
        public void CDAccountTest()
        {
            //Success tests
            Assert.IsNotNull(_cdAccount);
            Assert.AreEqual(_cdAccount.GetType(), "Certificate of Deposit");
            Assert.AreEqual(_cdAccount.SetBalance(500), true);
            Assert.AreEqual(_cdAccount.GetBalance(), 500);
            Assert.AreEqual(_cdAccount.SetAddress("122 main street"), true);
            Assert.AreEqual(_cdAccount.GetAddress(), "122 main street");
            Assert.AreEqual(_cdAccount.SetName("John"), true);
            Assert.AreEqual(_cdAccount.GetName(), "John");
            Assert.AreEqual(_cdAccount.WithdrawFunds(100), true);
            Assert.AreEqual(_cdAccount.GetBalance(), 400);

            //Fail tests
            Assert.AreEqual(_cdAccount.SetBalance(50), false);
            Assert.AreEqual(_cdAccount.SetAddress(""), false);
            Assert.AreEqual(_cdAccount.SetName("123"), false);
            Assert.AreEqual(_cdAccount.PayInFunds(100), false);
            Assert.AreEqual(_cdAccount.WithdrawFunds(-1), false);
            Assert.AreEqual(_cdAccount.WithdrawFunds(100000), false);

            //Testing account number
            string accountNumber = _cdAccount.AccountNumber;
            bool result = accountNumber.EndsWith('D');
            Assert.IsTrue(result, $"Expected account number to end with 'D', but it didn't");
        }

        [TestMethod]
        public void BankTest()
        {
            Assert.AreEqual(_bankAccounts.Length, 3);
            Assert.AreEqual(_bankAccounts.FindAccount(_saveAccount.AccountNumber), _saveAccount);
            Assert.AreEqual(_bankAccounts.FindAccount(_checkingAccount.AccountNumber), _checkingAccount);
            Assert.AreEqual(_bankAccounts.FindAccount(_cdAccount.AccountNumber), _cdAccount);
        }

        [TestMethod]
        public void BankFailTest()
        {
            SavingsAccount account = null;
            Assert.AreEqual(_bankAccounts.StoreAccount(account), false);
            Assert.AreEqual(_bankAccounts.FindAccount("123"), null);
        }
    }
}