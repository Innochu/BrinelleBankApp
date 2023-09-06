using BrinelleBank.Model;
using BrinelleBank.Data;
using BrinelleBank.Common;


namespace BrinelleBank.Menu
{
    public class Account
    {

        public static void CreateUserAccount()
        {
            Console.WriteLine("WELCOME TO BRINELLE BANK - ACCOUNT CREATION");

            Customer customer = AccountCreationPrompt(); // Call a separate method for account creation

            if (customer != null)
            {
                string accountNumber = AccountNumberGenerator.GenerateNewAccountNumber();
                ListOfCustomers.AddCustomer(accountNumber, customer);

                string[] values = { customer.GetFullName(), "0", accountNumber, customer.GetAccountType(), "0", "New Account" };
                ListOfAccount.statements.Add(new KeyValuePair<string, string[]>(accountNumber, values));
                Console.Clear();

                Logger.Log($"Hello {customer.GetFullName()}, Your {customer.GetAccountType()} account has been created successfully. \nYour account number is {accountNumber}");

                Login.userLogin();
            }

        }

        public static Customer AccountCreationPrompt()
        {
            Console.WriteLine("Input BVN");
            string bvn = Console.ReadLine();
            bvn = Validation.ValidateBVN(bvn);

            Console.WriteLine("Input first name");
            string firstName = Console.ReadLine();
            firstName = Validation.ValidateName(firstName);

            Console.WriteLine("Input last name");
            string lastName = Console.ReadLine();
            lastName = Validation.ValidateName(lastName);

            Console.WriteLine("Input phone number");
            string phoneNumber = Console.ReadLine();
            phoneNumber = Validation.ValidateNumber(phoneNumber);

            Console.WriteLine("Input Email");
            string email = Console.ReadLine();
            email = Validation.ValidateEmail(email);

            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();
            password = Validation.ValidatePassword(password);

            Console.WriteLine("Enter account type (S for Savings, C for Current)");
            string acctType = Console.ReadLine().ToLower();
            Console.Clear();
            if (acctType == "s" || acctType == "c")
            {
                string accountType = acctType == "s" ? "SAVINGS" : "CURRENT";

                bool found = false;

                foreach (var registeredUsers in ListOfCustomers.customerList)//inheritance
                {
                    Customer user = registeredUsers.Value;
                    if (user.GetBvn() == bvn && user.GetAccountType() == accountType)
                    {
                        found = true;
                        Logger.Log($"You already have a {accountType} account.");
                        break;
                    }

                }

                if (!found)
                {
                    Customer customer = new Customer(firstName, lastName, phoneNumber, email, accountType, password, bvn);
                    string accountNumber = AccountNumberGenerator.GenerateNewAccountNumber();

                    ListOfCustomers.AddCustomer(accountNumber, customer);

                    string[] values = { firstName + " " + lastName, "0", accountNumber, accountType, "0", "New Account" };
                    ListOfAccount.statements.Add(new KeyValuePair<string, string[]>(accountNumber, values));


                    Logger.Log($"Hello {firstName} {lastName}, Your {accountType} account has been created successfully. \nYour account number is {accountNumber}");
                }


                Login.userLogin();

            }
            else
            {
                Console.WriteLine("Invalid account type. Please enter 'S' for Savings or 'C' for Current.");
                // You may want to allow the user to retry or return to the main menu.
            }

            return null;
        }


    }
}
