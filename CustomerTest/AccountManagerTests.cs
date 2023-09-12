using BrinelleBank.Model;
using BrinelleBank.Data;
using BrinelleBank.Core;

namespace CustomerTest
{
	public class AccountManagerTests
	{

		[Fact]
		public void FindCustomerByAccountNumber_NonExistentCustomer_ReturnsNull()
		{
			// Arrange
			string nonExistentAccountNumber = "";

			// Act
			Customer result = Transactions.FindCustomerByAccountNumber(nonExistentAccountNumber);

			// Assert
			Assert.Null(result);
		}

		[Fact]
		public void UpdateCustomerBalance_ValidAmount_UpdatesBalance()
		{
			// Arrange
			double initialBalance = 1000.0; // Replace with an initial balance based on your test data
			double depositAmount = 500.0;   // Replace with the deposit amount based on your test data
			Customer customer = new Customer(); // Replace with an actual customer object based on your test data

			// Set the initial balance for the customer.
			customer.SetBalance(initialBalance);

			// Act
			double updatedBalance = Transactions.UpdateCustomerBalance(customer, depositAmount);

			// Assert
			double expectedBalance = initialBalance + depositAmount;
			Assert.Equal(expectedBalance, updatedBalance);
		}


		[Fact]
		public void RecordDepositTransaction_ShouldAddTransactionToStatementsList()
		{
			// Arrange
			Customer customer = new Customer();
			double amount = 100.0;
			double currentBalance = 500.0;

			// Assume that ListOfAccount.statements is properly initialized or mocked

			// Act
			Transactions.RecordDepositTransaction(customer, amount, currentBalance);

			// Assert
			// You can add assertions here to verify that the transaction was recorded correctly
			Assert.Single(ListOfAccount.statements); // Ensure only one transaction was added
			var transaction = ListOfAccount.statements[0];
			Assert.Equal(LoggedIn.LoggedAccount, transaction.Key); // Check the account key
			var values = transaction.Value;
			Assert.Equal(customer.GetFullName(), values[0]); // Check customer name
			Assert.Equal(amount.ToString(), values[1]); // Check transaction amount
			Assert.Equal(customer.GetAccountType(), values[3]); // Check account type
			Assert.Equal(currentBalance.ToString(), values[4]); // Check current balance
			Assert.Equal("CREDIT", values[5]); // Check transaction type
		}

		

		[Fact]
		public void CheckBalance_CustomerNotExists_ReturnsDefault()
		{
			// Arrange
			string loggedAccount = "999999"; // Replace with a non-existent logged account
			double expectedDefault = 0.0;    // Replace with the expected default balance
			ListOfCustomers.customerList.Clear(); // Ensure no customer with the logged account exists

			// Act
			double result = Transactions.CheckBalance();

			   
			// Assert
			Assert.Equal(expectedDefault, result);
		}


	}


}


