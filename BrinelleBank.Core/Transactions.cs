using BrinelleBank.Model;
using BrinelleBank.Data;


namespace BrinelleBank.Core
{
    public class Transactions
    {
        

        public static void DepositFunds(double amount)
        {
            if (amount > 0)
            {
                foreach (var item in ListOfCustomers.customerList)
                {
                    if (item.Key == LoggedIn.LoggedAccount)
                    {
                        Customer customer = item.Value;
                        double balance = customer.GetBalance();
                        double currentBalance = balance + amount;
                        customer.SetBalance(currentBalance);
						// Update the customer's balance to the newly calculated 'currentBalance'.

						string[] values = { customer.GetFullName(), amount.ToString(), LoggedIn.LoggedAccount, customer.GetAccountType(), currentBalance.ToString(), "CREDIT" };
                        ListOfAccount.statements.Add(new KeyValuePair<string, string[]>(LoggedIn.LoggedAccount, values));
						// Create a KeyValuePair and add it to a list of statements.

						break;
                    }
                }
                Console.Clear();
                Logger.Log($"{amount} naira has been credited to your account.");
            }
            else
            {
                Console.Clear();
                Logger.Log("Transaction failed. Invalid amount");
            }

        }




        public static void Withdraw(double amount)
        {
            if (amount > 0)
            {
                double bal = CheckBalance();
                string accountType = GetAccountType();
                if (accountType == "SAVINGS")
                {
                    if ((bal - 1000) >= amount)
                    {
                        WithdrawNow(amount);
                        Console.Clear();
                        Logger.Log("Withdrawal successful");

                    }
                    else
                    {
                        Logger.Log("Insufficient funds");
                    }
                }

                else if (accountType == "CURRENT")
                {
                    if (bal >= amount)
                    {
                        WithdrawNow(amount);
                        Logger.Log("Withdrawal successful");
                    }
                    else
                    {
                        Logger.Log("Insufficient Funds");
                    }
                }

            }
            else
            {
                Console.Clear();
                Logger.Log("Invalid withdrawal amount");

            }
        }





        public static void WithdrawNow(double amount)
        {
            foreach (var item in ListOfCustomers.customerList)
            {
                if (item.Key == LoggedIn.LoggedAccount)
                {
                    Customer customer = item.Value;
                    double balance = customer.GetBalance();
                    double currentBalance = balance - amount;
                    customer.SetBalance(currentBalance);

                    string[] values = { customer.GetFullName(), amount.ToString(), LoggedIn.LoggedAccount, customer.GetAccountType(), currentBalance.ToString(), "DEDIT" };
                    ListOfAccount.statements.Add(new KeyValuePair<string, string[]>(LoggedIn.LoggedAccount, values));

                    break;
                }
            }
        }



        public static void Transfer(double amount)
        {
            if (amount < 0)
            {
                Logger.Log($"Invalid Transfer");
            }
            else
            {
                Logger.Log("Input Beneficiary account");
                string beneficiaryAcc = Console.ReadLine();
                if (beneficiaryAcc == LoggedIn.LoggedAccount)
                {
                    Logger.Log("You cannot transfer to same account");
                }
                else
                {
                    double balance = LoggedIn.LoggedCustomer.GetBalance();
                    if (LoggedIn.LoggedCustomer.GetAccountType() == "SAVINGS")
                    {
                        if ((balance - 1000) < amount)
                        {
                            Logger.Log("Insufficient funds");
                            return;
                        }

                    }
                    if (balance >= amount)
                    {
                        bool found = false;

                        foreach (var regUsers in ListOfCustomers.customerList)
                        {
                            if (regUsers.Key == beneficiaryAcc)
                            {
                                double currentBalance = balance - amount;
                                LoggedIn.LoggedCustomer.SetBalance(currentBalance);//In the same bank

                                double beneBalance = regUsers.Value.GetBalance() + amount;
                                regUsers.Value.SetBalance(beneBalance);

                                string[] values = { regUsers.Value.GetFullName(), amount.ToString(), beneficiaryAcc, regUsers.Value.GetAccountType(), currentBalance.ToString(), "CREDIT" };
                                ListOfAccount.statements.Add(new KeyValuePair<string, string[]>(beneficiaryAcc, values));

                                string[] value = { LoggedIn.LoggedCustomer.GetFullName(), amount.ToString(), LoggedIn.LoggedAccount, LoggedIn.LoggedCustomer.GetAccountType(), LoggedIn.LoggedCustomer.GetBalance().ToString(), "DEBIT" };
                                ListOfAccount.statements.Add(new KeyValuePair<string, string[]>(LoggedIn.LoggedAccount, value));

                                found = true;
                                break;
                            }
                        }
                        if (found)
                        {
                            Logger.Log("Transfer successful");

                        }
                        else
                        {
                            Logger.Log("User does not exist");

                        }
                    }
                    else
                    {
                        Logger.Log("Insufficients Balance");

                    }

                }

            }
        }






        public static double CheckBalance()
        {
            double bal = 0;
            foreach (var item in ListOfCustomers.customerList)
            {
                if (item.Key == LoggedIn.LoggedAccount)
                {
                    Customer customer = item.Value;
                    bal = customer.GetBalance();
                    
                    break;
                }
            }
            return bal;
        }

        public static string GetAccountType()
        {
            string accountType = "";
            foreach (var item in ListOfCustomers.customerList)
            {
                if (item.Key == LoggedIn.LoggedAccount)
                {
                    Customer customer = item.Value;
                    accountType = customer.GetAccountType();
                    break;
                }
            }
            return accountType;
        }

    }   
    
}
