using BrinelleBank.Model;
using BrinelleBank.Data;


namespace BrinelleBank.Core
{
	public class Transactions
	{
		public static void DepositFunds(double amount)
		{
			if (IsDepositValid(amount))
			{
				Customer customer = FindCustomerByAccountNumber(LoggedIn.LoggedAccount);

				if (customer != null)
				{
					double currentBalance = UpdateCustomerBalance(customer, amount);
					RecordDepositTransaction(customer, amount, currentBalance);
					Console.Clear();
					Logger.Log($"{amount} naira has been credited to your account.");
				}
				else
				{
					Console.Clear();
					Logger.Log("Customer not found.");
				}
			}
			else
			{
				Console.Clear();
				Logger.Log("Transaction failed. Invalid amount");
			}
		}

		public static bool IsDepositValid(double amount)
		{
			return amount > 0;
		}

		public static Customer FindCustomerByAccountNumber(string accountNumber)
		{
			if (ListOfCustomers.customerList.TryGetValue(accountNumber, out Customer customer))
			{
				return customer;
			}

			return null;
		}

		public static double UpdateCustomerBalance(Customer customer, double amount)
		{
			double balance = customer.GetBalance();
			double currentBalance = balance + amount;
			customer.SetBalance(currentBalance);
			return currentBalance;
		}

		public static void RecordDepositTransaction(Customer customer, double amount, double currentBalance)
		{
			string[] values = { customer.GetFullName(), amount.ToString(), LoggedIn.LoggedAccount, customer.GetAccountType(), currentBalance.ToString(), "CREDIT" };
			ListOfAccount.statements.Add(new KeyValuePair<string, string[]>(LoggedIn.LoggedAccount, values));
		}






		// Define a delegate that matches the signature of WithdrawNow
		private delegate void WithdrawHandler(double amountToWithdraw);

		public static void Withdraw(double amountToWithdraw)
		{
            double balance = CheckBalance();

            if (amountToWithdraw > 0 && balance > 0)
			{

               
				string accountType = GetAccountType();

				if (accountType == "SAVINGS")
				{
					PerformWithdraw(amountToWithdraw, WithdrawNow);
                    Console.WriteLine("withdrawal successful");
                }
				else if (accountType == "CURRENT")
				{
					PerformWithdraw(amountToWithdraw, WithdrawNow);
                    Console.WriteLine("withdrawal successful");
                }
			}
			else
				
			{
				
				Logger.Log("Invalid withdrawal amount");
			}
		}  


		private static void PerformWithdraw(double amountToWithdraw, WithdrawHandler withdrawHandler)
		{
            withdrawHandler?.Invoke(amountToWithdraw);
        }

		public static void WithdrawNow(double amountToWithdraw)
		{
			foreach (var item in ListOfCustomers.customerList)
			{
				if (item.Key == LoggedIn.LoggedAccount)
				{
					Customer customer = item.Value;
					double balance = customer.GetBalance();
					double currentBalance = balance - amountToWithdraw;
					customer.SetBalance(currentBalance);

					string[] values = { customer.GetFullName(), amountToWithdraw.ToString(), LoggedIn.LoggedAccount, customer.GetAccountType(), currentBalance.ToString(), "DEDIT" };
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
