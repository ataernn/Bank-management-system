using System;

class Account
{
    // Properties to store account number, account holder's name, and account balance
    public string AccountNumber { get; private set; }
    public string AccountHolder { get; private set; }
    public decimal Balance { get; private set; }

    // Constructor to initialize a new account with an account number, account holder, and optional initial balance (default is 0)
    public Account(string accountNumber, string accountHolder, decimal initialBalance = 0)
    {
        AccountNumber = accountNumber; // Set the account number
        AccountHolder = accountHolder; // Set the account holder's name
        Balance = initialBalance; // Set the initial balance (default is 0)
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0) // Check if the deposit amount is greater than 0
        {
            Balance += amount; // Add the deposit amount to the account balance
            Console.WriteLine($"Successfully deposited {amount:C}. New balance: {Balance:C}"); // Inform the user
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive."); // Show an error message, if the amount is zero or negative
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)  // Check if the withdrawal amount is positive
        {
            Balance -= amount; // Subtract the withdrawal amount from the balance
            Console.WriteLine($"Successfully withdrew {amount:C}. New balance: {Balance:C}"); // Inform the user
        }
        else if (amount > Balance) //Check if the withdrawal amount exceeds the current balance
        {
            Console.WriteLine("Insufficient balance."); // Show an error message, if the withdrawal amount is greater than balance
        }
        else
        {
            Console.WriteLine("Withdrawal amount must be positive."); // Show an error message, if the amount is zero or negative.
        }
    }

    public string GetAccountInfo() // Get formatted account details including account number, holder name, and balance
    {
        return $"Account Number: {AccountNumber}, Holder: {AccountHolder}, Balance: {Balance:C}"; // Return a formatted string with account details
    }
}
