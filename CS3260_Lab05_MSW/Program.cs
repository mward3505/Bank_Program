// Project Prolog
// Name: Matt Ward
// CS3260 Section 001
// Project: Lab_05
// Date: 2/2/2024
// Purpose: Provide the main program for the UVU bank. The user will be able to create multiple types of accounts
// and provide the necessary details for each. They will be displayed at the end of the program.
//
// I declare that the following code was written by me or provided
// by the instructor for this project. I understand that copying source
// code from any other source constitutes plagiarism, and that I will receive
// a zero on this project if I am found in violation of this policy.\
using CS3260_Lab05_MSW;
using System.Security.Principal;

//Account myAccount = new Account();
bool nameStatus;
bool addressStatus;
bool balanceStatus = false;
bool depositStatus;
bool withdrawStatus;
bool accountTypeStatus;
//bool exitProgram = false;
bool validInput = false;

AccountBank currentAccounts = null;

/// <summary>
/// Purpose: Set the Name for the account object
/// </summary>
/// <param currentAccount>This is the current account object that needs the name for the account</param>
/// -----------------------------------------------------------------
void SetAccountName(Account currentAccount)
{
    do
    {
        Console.WriteLine("Enter the name for the account:");
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

// Gets how many accounts the users want to create
do
{
    Console.WriteLine("How many accounts would you like to create?");
    if (int.TryParse(Console.ReadLine(), out int size))
    {
        if (size <= 0)
        {
            Console.WriteLine("Please input a positive number greater than 0. ");
            continue;
        }
        currentAccounts = new AccountBank(size);
        validInput = true;
    }
    else
    {
        Console.WriteLine("Please input a number for how many accounts you would like to create.\n");
    }
} while (validInput != true);

//Goes through the AccountBank array to get all the account types and provides the information for the array
for (int i = 0; i < currentAccounts.Length; i++)
{
    do
    {
        accountTypeStatus = false;
        Console.WriteLine("\nPlease enter the account type you would like. (Savings, Checking, or CD):");
        string accountType = (Console.ReadLine());
        accountType = accountType.ToLower();

        switch (accountType)
        {
            case "savings":
                currentAccounts[i] = new SavingsAccount();
                SetAccountName(currentAccounts[i]);
                SetAccountAddress(currentAccounts[i]);
                SetAccountBalance(currentAccounts[i]);
                accountTypeStatus = true;
                break;

            case "checking":
                currentAccounts[i] = new CheckingAccount();
                SetAccountName(currentAccounts[i]);
                SetAccountAddress(currentAccounts[i]);
                SetAccountBalance(currentAccounts[i]);
                accountTypeStatus = true;
                break;

            case "cd":
                currentAccounts[i] = new CDAccount();
                SetAccountName(currentAccounts[i]);
                SetAccountAddress(currentAccounts[i]);
                SetAccountBalance(currentAccounts[i]);
                accountTypeStatus = true;
                break;

            default:
                Console.WriteLine("Please input a valid account type");
                break;
        }
    } while (!accountTypeStatus);
}

/// <summary>
/// Purpose: Print Account bank array to the console for all accounts in the abank
/// </summary>
/// -----------------------------------------------------------------
void PrintBankAccounts()
{
    Console.WriteLine("\nCurrent accounts in Bank:\n");
    for (int i = 0; i < currentAccounts.Length; i++)
    {
        Console.WriteLine(currentAccounts[i].ToString());
    }
}

PrintBankAccounts();

//foreach (Account a in currentAccounts)
//{

//}

////User interaction to deposit or withdraw their account. Also gives user the opprotunity to exit
//do
//{
//    //Get user command
//    Console.WriteLine("Enter the number for what you would like to do: 1-Deposit, 2-Withdraw, 3-Exit");
//    if (int.TryParse(Console.ReadLine(), out int userCommand))
//    {
//        if (userCommand == 1) //Deposit command that allows the user to add funds to their balance
//        {
//            Console.WriteLine("Enter the amount you would like to deposit:");

//            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount)) //Checks for validity of the decimal
//            {
//                depositStatus = currentAccount.PayInFunds(depositAmount);
//                if (depositStatus == false)
//                {
//                    Console.WriteLine("You have inputted an invalid deposit amount. Please redo command.\n");
//                    continue;
//                }
//            }
//            else
//            {
//                Console.WriteLine("You have input an invalid deposit amount. Please redo command.\n");
//                continue;
//            }

//            Console.WriteLine("Deposit made successfully!\n");
//            Console.WriteLine(currentAccount.ToString());
//        }
//        else if (userCommand == 2) //Withdraw command that allows the user to remove funds from thier balance if there is enough
//        {
//            Console.WriteLine("Enter the amount you would like to withdraw:");

//            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount)) //Checks for validity of the decimal
//            {
//                withdrawStatus = currentAccount.WithdrawFunds(withdrawAmount);
//                if (withdrawStatus == false)
//                {
//                    if (currentAccount.GetBalance() < withdrawAmount)
//                    {
//                        Console.WriteLine("Not enough in your current balance to withdraw. Please redo command\n");
//                        continue;
//                    }
//                    else
//                    {
//                        Console.WriteLine("You have inputted a invalid withdraw amount. Please redo command\n");
//                        continue;
//                    }

//                }
//            }
//            else
//            {
//                Console.WriteLine("You have inputted a invalid withdraw amount. Please redo command\n");
//                continue;
//            }

//            Console.WriteLine("Withdraw made successfully!\n");
//            Console.WriteLine(currentAccount.ToString());
//        }
//        else if (userCommand == 3) //Exits the program
//        {
//            exitProgram = true;
//        }
//        else { Console.WriteLine("Invalid Command. Please re-enter.\n"); }
//    }
//    else { Console.WriteLine("Invalid Command. Please re-enter.\n"); }



//} while (exitProgram != true);

Console.WriteLine("\nThanks for using UVU bank today! Have a wonderful rest of your day!");
Console.WriteLine("Press enter to close the window");
Console.ReadLine();


