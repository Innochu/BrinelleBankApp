using System.Text.RegularExpressions;
using BrinelleBank.Model;

namespace BrinelleBank.Common
{
	public class Validation
	{

		public static string ValidateAccType(string input)
		{
			string word = input;
			if (word == "S" || word == "C" || word == "s" || word == "c")
			{
				return word;
			}
			else
			{
				Logger.Log("Invalid input. Select either s for SAVINGS or c for CURRENT");
				word = Console.ReadLine();
				ValidateAccType(word);
			}
			return word;
		}
		public static bool IsPasswordValid(string password)
		{
			//string pattern = @"^(?=.*[a-zA-Z0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,}$";
			string pattern = @"^(?=.*[a-zA-Z])(?=.*[0-9])(?=.*[!@#$%^&*]).{6,}$";
			return Regex.IsMatch(password, pattern);
		}



		public static string ValidatePassword(string password)
		{
			//string password = GetUserPassword();
			while (!IsPasswordValid(password))
			{
				Console.WriteLine("Password should be a minimum of 6 characters that include alphanumeric and at least one special character");
				//password = GetUserPassword();
			}
			return password;
		}


		public static bool IsPhoneNumberValid(string phoneNumber)
		{
			return Regex.IsMatch(phoneNumber, @"^[0-9]+$") && phoneNumber.Length == 11;
		}

		public static string GetUserPhoneNumber()
		{
			Console.WriteLine("Enter your phone number:");
			return Console.ReadLine();
		}

		public static string ValidateNumber(string phoneNumber)
		{
			//string phoneNumber = GetUserPhoneNumber();
			while (!IsPhoneNumberValid(phoneNumber))
			{
				if (!Regex.IsMatch(phoneNumber, @"^[0-9]+$"))
				{
					Console.WriteLine("Phone number must contain only numbers.");
				}
				else if (phoneNumber.Length != 11)
				{
					Console.WriteLine("Invalid phone number. Please enter an 11-digit phone number.");
				}
				//phoneNumber = GetUserPhoneNumber();
			}
			return phoneNumber;
		}

		
	


	public static string ValidateBVN(string bvn)
		{
			string bv = bvn;
			bool valid = Regex.IsMatch(bvn, @"^[0-9]+$");

			if (!valid)
			{
				Console.WriteLine("BVN must contain only numeric characters");
				bv = Console.ReadLine();
				ValidateBVN(bv);
			}

			if (bv.Length != 11)
			{
				Console.WriteLine("BVN must be at least 11 digits");
				bv = Console.ReadLine();
				ValidateBVN(bv);
			}
			return bv;
		}

		public static string ValidateName(string name)
		{
			string nam = name;
			bool valid = Regex.IsMatch(name, @"^[A-Za-z\s]+$");
			if (!valid)
			{
				Console.WriteLine("Invalid name. Please enter a valid name consisting of letters and spaces.");
				nam = Console.ReadLine();
				ValidateName(nam);
			}
			return char.ToUpper(nam[0]) + nam.Substring(1);

		}

		public static string IsValidEmail(string email)
		{
			string em = email;
			string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

			if (!Regex.IsMatch(em, pattern))
			{
				Console.WriteLine("Email should be written in the correct format (Email@gmail.com)");
				em = Console.ReadLine();
				IsValidEmail(em);
			}
			return em;
		}
	}
}


