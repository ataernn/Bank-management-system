public class Bank
{
    private Account[] accounts = new Account[50]; // Max 50 Account objects
    private int currentAccountCount = 0; // Keep track of the number of accounts created

    public void CreateAccount(string? accountNumber, string? accountHolder) // Method to create a new account
    {
        if (string.IsNullOrEmpty(accountNumber) || string.IsNullOrEmpty(accountHolder)) // Check if is null or empty
        {
            Console.WriteLine("Account number and holder name cannot be null or empty."); // Inform the user
            return;
        }

        foreach (var account in accounts)
        {
            if (account != null && account.AccountNumber == accountNumber)  // Check if the account number already exists
            {
                Console.WriteLine("Account with this number already exists."); // Inform the user
                return;
            }
        }

        if (currentAccountCount < accounts.Length) // Check if there is space to create a new account
        {
            accounts[currentAccountCount] = new Account(accountNumber, accountHolder); // Create a new account and add it to the array
            currentAccountCount++;  // Increase the count of created accounts
            Console.WriteLine("Account created successfully."); // Inform the user
        }
        else
        {
            Console.WriteLine("Account limit reached. Cannot create new account."); // Inform the user
        }
    }

    public void DepositToAccount(string? accountNumber, decimal amount) // Deposit money into an account
    {
        if (string.IsNullOrEmpty(accountNumber)) // Check if is null or empty
        {
            Console.WriteLine("Account number cannot be null or empty."); // Inform the user
            return;
        }

        foreach (var account in accounts) // Find the account by account number and deposit the specified amount
        {
            if (account != null && account.AccountNumber == accountNumber)
            {
                account.Deposit(amount); // Call Deposit method from the Account class
                return;
            }
        }

        Console.WriteLine("Account not found."); // Inform the user
    }

    public void WithdrawFromAccount(string? accountNumber, decimal amount) 
    {
        if (string.IsNullOrEmpty(accountNumber)) // Check if is null or empty
        {
            Console.WriteLine("Account number cannot be null or empty."); // Inform the user
            return;
        }

        foreach (var account in accounts) // Find the account by account number
        {
            if (account != null && account.AccountNumber == accountNumber)
            {
                account.Withdraw(amount); // Call Withdraw method from the Account class
                return;
            }
        }

        Console.WriteLine("Account not found."); // Inform the user
    }

    public void CheckBalance(string? accountNumber) // Check the balance of a specific account
    {
        if (string.IsNullOrEmpty(accountNumber)) // Check if is null or empty
        {
            Console.WriteLine("Account number cannot be null or empty.");  // Inform the user
            return;
        }

        foreach (var account in accounts) // Find the account by account number
        {
            if (account != null && account.AccountNumber == accountNumber) 
            {
                Console.WriteLine($"Balance: {account.Balance:C}"); // Display balance in currency format
                return;
            }
        }

        Console.WriteLine("Account not found."); // Inform the user
    }

    public void ViewAccounts() // View details of all accounts
    {
        bool anyAccounts = false;
        foreach (var account in accounts) // Loop through all accounts and print their details if they are not null
        {
            if (account != null)
            {
                anyAccounts = true;
                Console.WriteLine(account.GetAccountInfo()); // Call GetAccountInfo from Account class to display account details
            }
        }

        if (!anyAccounts) // Check if no accounts exist
        {
            Console.WriteLine("No accounts available."); // Inform the user
        }
    }
}
