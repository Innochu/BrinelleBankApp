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
	public class withdrawalMethodTest
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
        public void Withdraw_ValidAmount()
        {
            // Arrange
            double initialBalance = 1000.0; // Set an initial balance for testing
            double amountToWithdraw = 500.0; // Adjust the amount as needed for your test case
            string accountType = "SAVINGS"; // Set the account type for testing (Savings or Current)

            // Create a mock customer and add it to ListOfCustomers
            Customer customer = new("John", "Doe", "1234567890", "john@example.com", accountType, "SecurePassword", "12345678901");
            customer.SetBalance(initialBalance);
            if (customer != null)
            {
                ListOfCustomers.customerList.Add(LoggedIn.LoggedAccount, customer);
            }
            else
            {
                Console.WriteLine("Error: mockCustomer is null. Unable to add to customerList.");
            }

            // Act
            Transactions.Withdraw(amountToWithdraw);

            // Assert
            double expectedBalance = initialBalance - amountToWithdraw;
            double actualBalance = customer.GetBalance();
            Assert.Equal(expectedBalance, actualBalance);
        }

        // Add more test methods for different scenarios:
        // - Invalid amount
        // - Current account
        // - Insufficient funds
    


	



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


}


