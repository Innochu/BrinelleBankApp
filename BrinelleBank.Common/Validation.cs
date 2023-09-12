using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Xml.Linq;
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
					break;
				}
				//phoneNumber = GetUserPhoneNumber();
			}
			return phoneNumber;
		}

		
	


	
		public static bool IsBVNValid(string bvn)
		{
			return Regex.IsMatch(bvn, @"^[0-10]+$") && bvn.Length == 11;
		}

		public static string GetUserBVN(string bvn)
		{
			
			return bvn;
		}
		 
		


		public static bool IsNameValid(string name)
		{
			return Regex.IsMatch(name, @"^[A-Za-z\s]+$");
		}

		

		public static string ValidateName(string name)
		{
			//string name = GetUserInputName();
			while (!IsNameValid(name))
			{
				Console.WriteLine("Invalid name. Please enter a valid name consisting of letters and spaces.");
				//name = GetUserInputName();
			}
			return char.ToUpper(name[0]) + name.Substring(1);
		}



		public static bool IsEmailValid(string email)
		{
		
			string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]*[a-zA-Z0-9]+(\.[a-zA-Z]{2,})+$";
			return Regex.IsMatch(email, pattern);
		}
		
		public static string ValidateEmail(string email)
		{
			//string email = GetUserInputEmail();
			while (!IsEmailValid(email))
			{
				Console.WriteLine("Email should be written in the correct format (Email@gmail.com)");
				//email = GetUserInputEmail();
			}
			return email;
		}
	}
}


