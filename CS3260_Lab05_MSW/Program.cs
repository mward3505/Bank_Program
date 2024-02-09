// Project Prolog
// Name: Matt Ward
// CS3260 Section 001
// Project: Lab_05
// Date: 2/2/2024
// Purpose: Provide the main program for the UVU bank. The user will be able to create multiple types of accounts
// and provide the necessary details for each. Accounts info will be displyed. User will be able to select the accounts
// and have the ability to deposit and withdraw from them according to different rules for each account.
//
// I declare that the following code was written by me or provided
// by the instructor for this project. I understand that copying source
// code from any other source constitutes plagiarism, and that I will receive
// a zero on this project if I am found in violation of this policy.\
using CS3260_Lab05_MSW;
using System.ComponentModel;
using System.Security;
using System.Security.Principal;

//Account myAccount = new Account();
bool nameStatus;
bool addressStatus;
bool balanceStatus = false;
bool depositStatus;
bool withdrawStatus;
bool accountTypeStatus;
bool exitProgram = false;
bool validInput = false;

//Creates empty dictionary for bank
AccountBank bankAccounts = new AccountBank();

/// <summary>
/// Purpose: Set the Name for the account object
/// </summary>
/// <param currentAccount>This is the current account object that needs the name for the account</param>
/// -----------------------------------------------------------------
void SetAccountName(Account currentAccount)
{
    do
    {
        Console.WriteLine("\nEnter the name for the account:");
        nameStatus = currentAccount.SetName(Console.ReadLine());

        if (nameStatus == false)
        {
            Console.WriteLine("Invalid name. Please re-enter");
        }

    } while (nameStatus != true);
    Console.WriteLine();
}

/// <summary>
/// Purpose: Set the Address for the account object
/// </summary>
/// <param currentAccount>This is the current account object that needs the Address for the account</param>
/// -----------------------------------------------------------------
void SetAccountAddress(Account currentAccount)
{
    do
    {
        Console.WriteLine("Enter the address for the account:");
        addressStatus = currentAccount.SetAddress(Console.ReadLine());

        if (addressStatus == false)
        {
            Console.WriteLine("Invalid address. Please re-enter");
        }

    } while (addressStatus != true);
    Console.WriteLine();
}

/// <summary>
/// Purpose: Set the Balance for the account object
/// </summary>
/// <param currentAccount>This is the current account object that needs the Balance for the account</param>
/// -----------------------------------------------------------------
void SetAccountBalance(Account currentAccount)
{
    do
    {
        Console.WriteLine("Enter the starting balance for the account:");
        if (decimal.TryParse(Console.ReadLine(), out decimal balanceAmount))
        {
            balanceStatus = currentAccount.SetBalance(balanceAmount);

            if (balanceStatus == false)
            {
                Console.WriteLine("Either invalid amount or doesn't meet the minumum balance. " +
                    "\nSavings Min: $100, Checking Min: $10, CD Min: $500. Please try again.");
                continue;
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid balance.");
        }

    } while (balanceStatus != true);
}

//// Gets how many accounts the users want to create
//do
//{
//    Console.WriteLine("How many accounts would you like to create?");
//    if (int.TryParse(Console.ReadLine(), out int size))
//    {
//        if (size <= 0)
//        {
//            Console.WriteLine("Please input a positive number greater than 0. ");
//            continue;
//        }
//        currentAccounts = new AccountBank(size);
//        validInput = true;
//    }
//    else
//    {
//        Console.WriteLine("Please input a number for how many accounts you would like to create.\n");
//    }
//} while (validInput != true);

//Goes through the AccountBank array to get all the account types and provides the information for the array
do
{
    accountTypeStatus = false;
        
    Console.WriteLine("Please enter the account type you would like. (Savings, Checking, or CD)");
    string accountType = (Console.ReadLine());
    accountType = accountType.ToLower();
    bool doneStatus = false;

    switch (accountType)
    {
        case "savings":
            SavingsAccount saveAccount = new SavingsAccount();
            SetAccountName(saveAccount);
            SetAccountAddress(saveAccount);
            SetAccountBalance(saveAccount);

            //Store account into dictionary bank
            bankAccounts.StoreAccount(saveAccount);
            break;

        case "checking":
            CheckingAccount checkAccount = new CheckingAccount();
            SetAccountName(checkAccount);
            SetAccountAddress(checkAccount);
            SetAccountBalance(checkAccount);

            //Store account into dictionary bank
            bankAccounts.StoreAccount(checkAccount);
            break;

        case "cd":
            CDAccount cdAccount = new CDAccount();
            SetAccountName(cdAccount);
            SetAccountAddress(cdAccount);
            SetAccountBalance(cdAccount);
            
            bankAccounts.StoreAccount(cdAccount);
            break;

        default:
            Console.WriteLine("Please input a valid account type.\n");
            doneStatus = true;
            break;
    }


    //Loop through to make user is done
    while (!doneStatus)
    {
        Console.WriteLine("\nAre you finished inputting accoungs? (Y or N)");
        string finishedInput = Console.ReadLine();
        if (finishedInput == null || finishedInput == "")
        {
            Console.WriteLine("Please enter valid command.");
        }
        finishedInput = finishedInput.ToLower();

        if (finishedInput != "y" || finishedInput != "n")
        {
            if (finishedInput == "y")
            {
                accountTypeStatus = true;
                doneStatus = true;
            }
            else
            {
                doneStatus = true;
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid command.");
        }
    }
} while (!accountTypeStatus);


/// <summary>
/// Purpose: Print Account bank array to the console for all accounts in the abank
/// </summary>
/// -----------------------------------------------------------------
void PrintBankAccounts()
{
    Console.WriteLine("\nCurrent accounts in Bank:\n");
    foreach (Account account in bankAccounts)
    {
        Console.WriteLine(account.ToString());
    }
}

//Print accounts to console
PrintBankAccounts();

/// <summary>
/// Purpose: ask the user for the account they desire to work with
/// </summary>
Account accountSelection()
{
    bool exitStatus = false;
    Account currentAccount = null;
    while (!exitStatus)
    {
        Console.WriteLine("Please enter the account number you would like to use or 0 to exit:");
        string accountSelected = Console.ReadLine();

        if (accountSelected == "0")
        {
            exitStatus = true;
            return currentAccount;
        }
 
        currentAccount = bankAccounts.FindAccount(accountSelected);
        if (currentAccount == null)
        {
            Console.WriteLine("Could not find the account number you are looking for. Try another valid account number.\n");
        }
        else
        {
            exitStatus = true;
            return currentAccount;
        }
    }

    return currentAccount;
}

//Main mode after accounts have been added
while (!exitProgram)
{
    bool exitAccount = false;

    //Gets account selection 
    Account currentAccount = accountSelection();

    if (currentAccount == null)
    {
        exitAccount = true;
        exitProgram = true;
    }

    while (!exitAccount)
    {
        //Get user command
        Console.WriteLine("\nEnter the number for what you would like to do: 1-Deposit, 2-Withdraw, 3-Account Selection");
        if (int.TryParse(Console.ReadLine(), out int userCommand))
        {
            if (userCommand == 1) //Deposit command that allows the user to add funds to their balance
            {
                if (currentAccount.GetType() == "Certificate of Deposit")
                {
                    Console.WriteLine("Unable to deposit in this account type. Only can Withdraw funds from account.");
                    continue;
                }
                else
                {
                    Console.WriteLine("Enter the amount you would like to deposit:");

                    if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount)) //Checks for validity of the decimal
                    {
                        depositStatus = currentAccount.PayInFunds(depositAmount);
                        if (depositStatus == false)
                        {
                            Console.WriteLine("You have inputted an invalid deposit amount. Please redo command.\n");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have input an invalid deposit amount. Please redo command.\n");
                        continue;
                    }

                    Console.WriteLine("Deposit made successfully!\n");
                    Console.WriteLine(currentAccount.ToString());
                }
            }
            else if (userCommand == 2) //Withdraw command that allows the user to remove funds from thier balance if there is enough
            {
                Console.WriteLine("Enter the amount you would like to withdraw:");

                if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount)) //Checks for validity of the decimal
                {
                    if (currentAccount is CheckingAccount checking)
                    {
                        {
                            decimal balanceWithFee = currentAccount.GetBalance() + checking.GetFee();
                            withdrawStatus = currentAccount.WithdrawFunds(withdrawAmount);
                            if (withdrawStatus == false)
                            {
                                if (currentAccount.GetBalance() < withdrawAmount)
                                {
                                    Console.WriteLine("Not enough in your current balance to withdraw. Please redo command\n");
                                    continue;
                                } else if (balanceWithFee > withdrawAmount)
                                {
                                    Console.WriteLine("Not enough in your current balance to withdraw with fee. Please redo command");
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("You have inputted a invalid withdraw amount. Please redo command\n");
                                    continue;
                                }

                            }
                        }
                    } else
                    {
                        withdrawStatus = currentAccount.WithdrawFunds(withdrawAmount);
                        if (withdrawStatus == false)
                        {
                            if (currentAccount.GetBalance() < withdrawAmount)
                            {
                                Console.WriteLine("Not enough in your current balance to withdraw. Please redo command\n");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("You have inputted a invalid withdraw amount. Please redo command\n");
                                continue;
                            }

                        }
                    }
                }
                else
                {
                    Console.WriteLine("You have inputted a invalid withdraw amount. Please redo command\n");
                    continue;
                }

                Console.WriteLine("Withdraw made successfully!\n");
                Console.WriteLine(currentAccount.ToString());
            }
            else if (userCommand == 3) //Exits account processing
            {
                exitAccount = true;
            }
            else { Console.WriteLine("Invalid Command. Please re-enter.\n"); }
        }
        else { Console.WriteLine("Invalid Command. Please re-enter.\n"); }
    }
    
}

Console.WriteLine("\nThanks for using UVU bank today! Have a wonderful rest of your day!");
Console.WriteLine("Press enter to close the window");
Console.ReadLine();