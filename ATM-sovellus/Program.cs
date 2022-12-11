using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

/// @author Samuel Saastamoinen
/// @version 6.12.2002
/// <summary>
/// Simple ATM-software.User must enter correct PIN-number to use ATM. User can check balance, 5 latest transactions and withdraw and deposit money. 
/// </summary>
public class ATM
{   
    /// <summary>
    /// Main function, that asks user to input PIN-number. User can check account balance, deposit money, withdraw money and see latest 5 transactions.
    /// If PIN-number is incorrect, user is 'logged out'.
    /// </summary>
    public static void Main()
    {      
        //Variables for PIN-number, account balance, amount of transactions and latest transactions
        int PIN = 1139;
        double balance = 5467.60;
        List<double> transactions = new List<double>();    //List for storing 5 latest transactions
        bool isRunning = true; //Variable for closing ATM-machine

        Console.WriteLine("Enter PIN-number :");
        int givenPIN = Convert.ToInt32(Console.ReadLine());

        while (isRunning == true)
        {
            if (givenPIN == PIN)
            {
                //User types out number that corresponds to the operation they want to perform.
                Console.WriteLine("Choose the operation you want to perform:");
                Console.WriteLine("1. Check your account's balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Latest transactions");
                Console.WriteLine("5. Exit");

                string operation = Console.ReadLine();

                switch(operation)
                {
                    case "1":
                        Console.WriteLine("Your account's balance is " + CheckBalance(balance));    //Function CheckBalance is called
                        break;
                    case "2":
                        Console.Write("Enter money to be deposited: ");
                        double depositedMoney = double.Parse(Console.ReadLine());
                        LatestTransactions(transactions, depositedMoney);
                        //transactions.Add(depositedMoney); //Transaction is added to the list of transactíons
                        Console.WriteLine("Account's balance is now " + Deposit(balance, depositedMoney));   //Function Deposit is called  
                        break;
                    case "3":
                        Console.Write("Enter mnoney to be withdrawn: ");
                        double withdrawnMoney = double.Parse(Console.ReadLine());
                        LatestTransactions(transactions, withdrawnMoney);
                        //transactions.Add(-withdrawnMoney);
                        if (withdrawnMoney > 1000)
                        {
                            Console.WriteLine("You can't withdraw more than 1000 at a time");
                            Console.Write("Enter valid sum: ");
                            withdrawnMoney = double.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("Account's balance is now " + Withdraw(balance, withdrawnMoney)); //Function Withdraw is called
                        break;
                    case"4":
                        Console.WriteLine("Latest transactions : " + String.Join(", ", transactions)); //List of 5 latest transactions is written out
                        break;
                    case "5":
                        Console.WriteLine("Thank you for using ATM-machine");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid number"); //If user's input is invalid, program asks user to inpput a valid number
                        break;
                }

            }
            else //If PIN-number doesn't match user's PIN-number, user is logged out
            {
                //käyttäjä kirjattava ulos
                Console.WriteLine("Wrong PIN");
                isRunning = false;
            }
        }
    }

    /// <summary>
    /// Function that returns user's account's balance
    /// </summary>
    /// <param name="balance">Account's balance</param>
    /// <returns>Account's balance</returns>
    public static double CheckBalance(double balance)
    {
        return balance;
    }

    /// <summary>
    /// Function that adds given amount of money to account
    /// </summary>
    /// <param name="balance">Account's balance</param>
    /// <param name="depositedMoney">Given amount of money to be deposited</param>
    /// <returns>Account's new balance</returns>
    public static double Deposit(double balance, double depositedMoney)
    {      
        double newBalance = depositedMoney + balance;
        return newBalance;
    }

    /// <summary>
    /// Function that substracts given amount of money from account
    /// </summary>
    /// <param name="balance">Account's balance</param>
    /// <param name="withdrawnMoney">Given amount of money to be withdrawn</param>
    /// <returns>Account's new balance</returns>
    public static double Withdraw(double balance, double withdrawnMoney)
    {
        double newBalance = balance - withdrawnMoney;      
        return newBalance;
    }

    public static List<double> LatestTransactions(List<double> transactions, double money)
    {
        transactions.Add(money);
        return transactions;
    }
}
