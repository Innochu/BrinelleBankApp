using BrinelleBank.Model;
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

		// Add similar test methods for other methods in the Customer class.
	}
}

