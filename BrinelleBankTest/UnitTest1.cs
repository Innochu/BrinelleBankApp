using BrinelleBank.Common;
using BrinelleBank.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using Xunit;

namespace BrinelleBankTest
{
	public class AccountTypeValidationTests
	{
		[Theory]
		[InlineData("s", "s")] // Valid lowercase input
		[InlineData("S", "S")] // Valid uppercase input
		[InlineData("c", "c")] // Valid lowercase input
		[InlineData("C", "C")] // Valid uppercase input
		public void ValidateAccType_ValidInput_ShouldReturnSameInput(string input, string expected)
		{
			// Act
			string result = Validation.ValidateAccType(input);

			// Assert
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData("ValidPassword1!", true)]  // Valid password
		[InlineData("AllLowercase", false)]    // No special character
		[InlineData("1234567890!@#", false)]   // No letters
		[InlineData("SpecialCharacters!", false)] // No letters or numbers
		public void IsPasswordValid_ShouldValidatePassword(string password, bool expected)
		{
			// Act
			bool result = Validation.IsPasswordValid(password);

			// Assert
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData("12345678901", true)]  // Valid 11-digit number
		[InlineData("1234567890", false)]   // Too short
		[InlineData("123456789012", false)] // Too long
		[InlineData("12345abc678", false)]  // Contains non-numeric characters
		[InlineData("1234567890123", false)] // Too long
		public void IsPhoneNumberValid_ShouldValidatePhoneNumber(string phoneNumber, bool expected)
		{
			// Act
			bool result = Validation.IsPhoneNumberValid(phoneNumber);

			// Assert
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData("12345678901", false)] // Too long
		[InlineData("1234567890", false)]  // Too short
		[InlineData("12345abc678", false)] // Contains non-numeric characters
		[InlineData("12345678901a", false)] // Contains non-numeric characters
		[InlineData("1234567890a", false)]  // Contains non-numeric characters

		public void IsBVNValid_ShouldValidateBVN(string bvn, bool expected)
		{
			// Act
			bool result = Validation.IsBVNValid(bvn);

			// Assert
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData("John Doe", true)]   // Valid name with spaces
		[InlineData("Alice", true)]       // Valid name without spaces
		[InlineData("12345", false)]     // Invalid name with numbers
		[InlineData("J@ck", false)]      // Invalid name with special characters
		[InlineData("John Doe1", false)] // Invalid name with numbers
		public void IsNameValid_ShouldValidateName(string name, bool expected)
		{
			// Act
			bool result = Validation.IsNameValid(name);

			// Assert
			Assert.Equal(expected, result);
		}

		[Theory]
		[InlineData("email@example.com", true)]              // Valid email
		[InlineData("invalid-email", false)]                 // Invalid format
		[InlineData("user@subdomain.example.co.uk", true)]   // Valid email
		[InlineData("user@example", false)]                  // Invalid format
		[InlineData("user@example.c", false)]                // Invalid format (less than 2 characters after the last dot)
		[InlineData("user@example.", false)]                 // Invalid format (dot at the end)
		[InlineData("user@example-.com", false)]             // Invalid format (hyphen at the end)
		[InlineData("user@sub.-domain.example.com", true)]   // Valid email (hyphen in subdomain)

		public void IsEmailValid_ShouldValidateEmail(string email, bool expected)
		{
			// Act
			bool result = Validation.IsEmailValid(email);

			// Assert
			Assert.Equal(expected, result);
		}



		[Fact]
		public void CustomerConstructor_Initialization()
		{
			// Arrange: Prepare data for customer initialization
			string firstName = "John";
			string lastName = "Doe";
			string phoneNumber = "1234567890";
			string email = "john@example.com";
			string accountType = "Savings";
			string password = "SecurePassword";
			string bvn = "12345678901";



			


			// Act: Create a customer object using the constructor
			Customer customer = new Customer(firstName, lastName, phoneNumber, email, accountType, password, bvn);


			

			// Assert: Verify that the customer object is correctly initialized
			Assert.Equal(firstName, customer.FirstName);
			Assert.Equal(lastName, customer.LastName);
			Assert.Equal(phoneNumber, customer.PhoneNumber);
			Assert.Equal(email, customer.Email);
			Assert.Equal(0, customer.Balance); // Initial balance should be 0
			Assert.Equal(accountType, customer.AccountType);
			Assert.Equal(password, customer.Password);
			Assert.Equal(bvn, customer.BVN);

		}

		// You can add more tests to cover different scenarios or edge cases if needed.
		[Fact]
		public void CustomerConstructor_Initialization2()
		{
			// Test Case 2
			string firstName2 = "Alice";
			string lastName2 = "Smith";
			string phoneNumber2 = "9876543210";
			string email2 = "alice@example.com";
			string accountType2 = "Current";
			string password2 = "StrongPassword";
			string bvn2 = "98765432109";


			// Act: Create a customer object using the constructor
			Customer customer2 = new Customer(firstName2, lastName2, phoneNumber2, email2, accountType2, password2, bvn2);


			// Assert: Verify that the customer object is correctly initialized
			Assert.Equal(firstName2, customer2.FirstName);
			Assert.Equal(lastName2, customer2.LastName);
			Assert.Equal(phoneNumber2, customer2.PhoneNumber);
			Assert.Equal(email2, customer2.Email);
			Assert.Equal(0, customer2.Balance); // Initial balance should be 0
			Assert.Equal(accountType2, customer2.AccountType);
			Assert.Equal(password2, customer2.Password);
			Assert.Equal(bvn2, customer2.BVN);
		}

	}



}










