using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank(); // Create a new Bank instance
        bool exit = false; // Boolean variable to control the loop for the menu

        while (!exit) // Program loop that continues until the user chooses to exit
        {
            // Display menu options
            Console.WriteLine("\nBank Account Management System");
            Console.WriteLine("1. Create New Account");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. View All Accounts");
            Console.WriteLine("6. Exit");
            Console.Write("Please choose an option: ");

            string? choice = Console.ReadLine(); // Get the user input for the menu choice

            if (string.IsNullOrEmpty(choice)) // If no input was provided , continue to the next loop iteration
            {
                Console.Clear();
                Console.WriteLine("No option chosen."); // Inform the user
                continue;
            }

            switch (choice) // Switch case to handle different menu choices
            {
                case "1":
                    Console.Clear(); // Clear the console
                    Console.WriteLine("Create New Account\n"); // Inform the user that they are in the create an account section
                    Console.Write("Account Number: "); // Ask account number
                    string? accountNumber = Console.ReadLine(); // Create an account number string according to input
                    if (!IsNumeric(accountNumber)) // Validate that the account number consists of only digits
                    {
                        Console.WriteLine("Account number must contain only numbers."); // Inform the user
                        continue;
                    }

                    if (string.IsNullOrEmpty(accountNumber)) // Check if the account number is empty
                    {
                        Console.WriteLine("Account number cannot be empty."); // Inform the user
                        continue;
                    }

                    Console.Write("Account Holder Name: "); // Ask account holder name
                    string? accountHolder = Console.ReadLine(); // Create a account holder string

                    if (!IsValidName(accountHolder)) // Validate that the account holder name contains only letters
                    {
                        Console.WriteLine("Account holder name must contain only letters."); // Inform the user
                        continue;
                    }
                    
                    if (string.IsNullOrEmpty(accountHolder)) // Check if the account holder is empty
                    {
                        Console.WriteLine("Account holder name cannot be empty."); // Inform the user
                        continue;
                    }

                    bank.CreateAccount(accountNumber, accountHolder); // Create the account using the bank instance
                    break;

                case "2":
                    Console.Clear(); // Clear the console
                    Console.WriteLine("Deposit Money\n"); // Inform the user that they are in the deposit money section
                    Console.Write("Account Number: "); // Ask account number
                    accountNumber = Console.ReadLine(); // Read input
                    if (!IsNumeric(accountNumber)) // Validate that the account number consists of only digits
                    {
                        Console.WriteLine("Account number must contain only numbers."); // Inform the user
                        continue;
                    }

                    if (string.IsNullOrEmpty(accountNumber)) // Check if the account number is empty
                    {
                        Console.WriteLine("Account number cannot be empty."); // Inform the user
                        continue;
                    }

                    Console.Write("Deposit Amount: "); // Ask for the deposit amount
                    if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount)) 
                    {
                        bank.DepositToAccount(accountNumber, depositAmount); // Deposit the specified amount into the account
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount entered."); // Inform the user
                    }
                    break;

                case "3":
                    Console.Clear(); // Clear the console
                    Console.WriteLine("Withdraw Money\n"); // Inform the user that they are in the withdraw money section
                    Console.Write("Account Number: "); // Ask account number
                    accountNumber = Console.ReadLine(); // Read input
                    if (!IsNumeric(accountNumber)) // Validate that the account number consists of only digits
                    {
                        Console.WriteLine("Account number must contain only numbers."); // Inform the user
                        continue;
                    }

                    if (string.IsNullOrEmpty(accountNumber)) // Check if the account number is empty
                    {
                        Console.WriteLine("Account number cannot be empty."); // Inform the user
                        continue;
                    }

                    Console.Write("Withdrawal Amount: "); // Ask for the withdrawal amount
                    if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                    {
                        bank.WithdrawFromAccount(accountNumber, withdrawAmount); // Withdraw the specified amount from the account
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount entered."); // Inform the user
                    }
                    break;

                case "4":
                    Console.Clear(); // Clear the console
                    Console.WriteLine("Check Balance\n"); // Inform the user that they are in the check balance section
                    Console.Write("Account Number: "); // Ask account number
                    accountNumber = Console.ReadLine(); // Read input
                    if (!IsNumeric(accountNumber)) // Validate that the account number consists of only digits
                    {
                        Console.WriteLine("Account number must contain only numbers."); // Inform the user
                        continue;
                    }

                    if (string.IsNullOrEmpty(accountNumber)) // Check if the account number is empty
                    {
                        Console.WriteLine("Account number cannot be empty."); // Inform the user
                        continue;
                    }

                    bank.CheckBalance(accountNumber); // Check the balance of the specified account
                    break;

                case "5":
                    Console.Clear(); // Clear the console
                    Console.WriteLine("All Accounts\n"); // Inform the user that they are in the all accounts section
                    bank.ViewAccounts(); // Display the details of all accounts
                    break;

                case "6":
                    exit = true;
                    Console.WriteLine("Exiting the program..."); // Inform the user
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again."); // Show an error message if user enter invalid choice
                    break;
            }
        }
    }

    static bool IsNumeric(string? str) // Check the input string consists only of digits
    {
        return str != null && str.All(char.IsDigit);
    }

    static bool IsValidName(string? str) // Check the input string consists only of letters (no numbers or special characters)
    {
        return str != null && str.All(char.IsLetter);
    }
}