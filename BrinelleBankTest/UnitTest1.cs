using BrinelleBank.Common;
using Newtonsoft.Json.Linq;
using System;

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

	}
	





	}


