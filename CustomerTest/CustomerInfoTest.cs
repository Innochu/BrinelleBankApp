using BrinelleBank.Model;
using BrinelleBank.Data;
using BrinelleBank.Core;
using System;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using System.Transactions;
using Xunit;

namespace CustomerTest
{
	public class CustomerInfoTest
	{
		[Fact]

		public void GetFullName_ReturnsFullName()
		{
			// Arrange
			Customer customer = new Customer("John", "Doe", "1234567890", "john@example.com", "Savings", "SecurePassword", "12345678901");

			// Act
			string fullName = customer.GetFullName();

			// Assert
			Assert.Equal("John Doe", fullName);
		}

		[Fact]
		public void SetBalance_SetsBalance()
		{
			// Arrange
			Customer customer = new Customer("John", "Doe", "1234567890", "john@example.com", "Savings", "SecurePassword", "12345678901");

			// Act
			customer.SetBalance(1000.0);

			// Assert
			Assert.Equal(1000.0, customer.GetBalance());
		}

		[Fact]
		public void GetPhoneNumber_ReturnsPhoneNumber()
		{
			// Arrange
			Customer customer = new Customer("John", "Doe", "1234567890", "john@example.com", "Savings", "SecurePassword", "12345678901");

			// Act
			string phoneNumber = customer.GetPhoneNumber();

			// Assert
			Assert.Equal("1234567890", phoneNumber);
		}

		[Fact]
		public void GetEmail_ReturnsEmail()
		{
			// Arrange
			Customer customer = new Customer("John", "Doe", "1234567890", "john@example.com", "Savings", "SecurePassword", "12345678901");

			// Act
			string email = customer.GetEmail();

			// Assert
			Assert.Equal("john@example.com", email);
		}

		[Fact]
		public void GetAccountType_ReturnsAccountType()
		{
			// Arrange
			Customer customer = new Customer("John", "Doe", "1234567890", "john@example.com", "Savings", "SecurePassword", "12345678901");

			// Act
			string accountType = customer.GetAccountType();

			// Assert
			Assert.Equal("Savings", accountType);
		}

		[Fact]
		public void GetPassword_ReturnsPassword()
		{
			// Arrange
			Customer customer = new Customer("John", "Doe", "1234567890", "john@example.com", "Savings", "SecurePassword", "12345678901");

			// Act
			string password = customer.GetPassword();

			// Assert
			Assert.Equal("SecurePassword", password);
		}

		[Fact]
		public void SetsBalance()
		{
			// Arrange
			Customer customer = new Customer("John", "Doe", "1234567890", "john@example.com", "Savings", "SecurePassword", "12345678901");

			// Act
			customer.SetBalance(1000.0);

			// Assert
			Assert.Equal(1000.0, customer.GetBalance());
		}

		[Fact]
		public void GetFirstName_ReturnsFirstName()
		{
			// Arrange
			Customer customer = new Customer("John", "Doe", "1234567890", "john@example.com", "Savings", "SecurePassword", "12345678901");

			// Act
			string firstName = customer.GetFirstName();

			// Assert
			Assert.Equal("John", firstName);
		}

		[Fact]
		public void GetLastName_ReturnsLastName()
		{
			// Arrange
			Customer customer = new Customer("John", "Doe", "1234567890", "john@example.com", "Savings", "SecurePassword", "12345678901");

			// Act
			string lastName = customer.GetLastName();

			// Assert
			Assert.Equal("Doe", lastName);
		}
		[Fact]
		public void GetBvn_ReturnsBvn()
		{
			// Arrange
			Customer customer = new Customer("John", "Doe", "1234567890", "john@example.com", "Savings", "SecurePassword", "12345678901");

			// Act
			string bvn = customer.GetBvn();

			// Assert
			Assert.Equal("12345678901", bvn);
		}


		[Fact]
		public void WithdrawNow_ValidAmount()
		{
			// Arrange
			double initialBalance = 1000.0; // Set an initial balance for testing
			double amountToWithdraw = 500.0; // Adjust the amount as needed for your test case

			// Create a mock customer and add it to ListOfCustomers
			Customer mockCustomer = new Customer("John", "Doe", "1234567890", "john@example.com", "Savings", "SecurePassword", "12345678901");
			mockCustomer.SetBalance(initialBalance);
			ListOfCustomers.customerList.Add("1234567890", mockCustomer);

			// Act
			Transactions.WithdrawNow(amountToWithdraw);

			// Assert

			Assert.Equal(initialBalance - amountToWithdraw, mockCustomer.GetBalance());


		}

		[Fact]
		public void IsDepositValid_ValidAmount_ReturnsTrue()
		{
			// Arrange
			double validAmount = 100.0;

			// Act
			bool result = Transactions.IsDepositValid(validAmount);

			// Assert
			Assert.True(result);
		}

		[Fact]
		public void IsDepositValid_InvalidAmount_ReturnsFalse()
		{
			// Arrange
			double invalidAmount = -50.0;

			// Act
			bool result = Transactions.IsDepositValid(invalidAmount);

			// Assert
			Assert.False(result);
		}


	}


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
		public void CheckBalance_CustomerExists_ReturnsBalance()
		{
			// Arrange
			string loggedAccount = "34563425367"; // Replace with a valid logged account based on your test data
			double expectedBalance = 1000.0; // Replace with the expected balance based on your test data
			var customer = new Customer("Bright", "okeke", "08160417161", "n@gmail.com", "SAVINGS", "bank123#", "34563425367");    // Replace with an actual customer object based on your test data
			customer.SetBalance(expectedBalance);
			ListOfCustomers.customerList.Add(loggedAccount, customer);

			// Act
			double result = Transactions.CheckBalance();

			// Assert
			Assert.Equal(expectedBalance, result);
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


