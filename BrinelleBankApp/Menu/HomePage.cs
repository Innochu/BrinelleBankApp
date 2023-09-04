using BrinelleBank.Common;
using BrinelleBank.Core;
using BrinelleBank.Model;


namespace BrinelleBank.Menu
{
    public class HomePage
    {
        public void userWelcome()
        {
            Console.WriteLine("WELCOME TO BRINELLE BANK");
            Console.WriteLine("Press 1 to create account\n Press 2 to login\n");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Account.CreateUserAccount();
                    break;

                case "2":
                    Login.userLogin();
                    break;

                case "3":

                    break;
            }

        }

        public static void Options()
        {

            while (true)
            {
                Console.WriteLine("\nPress 1 to depositFunds\nPress 2 to Withdraw");
                Console.WriteLine("Press 3 to Transfer\nPress 4 for Account Statement");
                Console.WriteLine("Press 5 for Balance\nPress 6 Create another account");
                Console.WriteLine("Press 7 to login to another account\n Press 8 to exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Logger.Log("Input amount to deposit");
                        string inputAmount = Console.ReadLine();

                        double amount = Convert.ToDouble(inputAmount);

                        Transactions.DepositFunds(amount);
                        break;

                    case "2":
                        Logger.Log("Input amount to withdraw");
                        string inputWithdrawAmount = Console.ReadLine();
                        double amountToWithdraw = Convert.ToDouble(inputWithdrawAmount);

                        Transactions.Withdraw(amountToWithdraw);
                        break;

                    case "3":
                        Logger.Log("Input amount to Transfer");
                        double transferAmount = double.Parse(Console.ReadLine());
                        Transactions.Transfer(transferAmount);
                        break;

                    case "4":
                        StatementOfAccount.PrintStatementOfAccount();
                        break;

                    case "5":
                        double bal = Transactions.CheckBalance();
                        Console.Clear();

                        Logger.Log($"Your current Balance is {bal} naira");
                        break;

                    case "6":
                        Account.CreateUserAccount();
                        break;

                    case "7":
                        Login.userLogin();
                        break;

                    case "8":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }

        }
    }
}
