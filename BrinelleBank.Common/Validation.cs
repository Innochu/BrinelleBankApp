using System.Text.RegularExpressions;
using BrinelleBank.Model;

namespace BrinelleBank.Common
{
    public class Validation
    {

        public static string ValidateAccType(string input)
        {
            string word = input;
            if(word == "S" || word == "C" || word == "s" || word == "c")
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
        public static string ValidatePassword(string pass)
        {
            string pv = pass;
            string pattern = @"^(?=.*[a-zA-Z0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,}$";
			// - (?=.*[!@#$%^&*])   : Positive lookahead for at least one special character.
			// - (?=.*[a-zA-Z0-9])  : Positive lookahead for at least one alphanumeric character.

			if (!Regex.IsMatch(pv, pattern))
            {
                Console.WriteLine("Password should be minimum 6 characters that include alphanumeric and at least one special characters");
                pv = Console.ReadLine();
                ValidatePassword(pv);
            }
            return pv;

        }

        public static string ValidateNumber(string bvn)
        {
            string bv = bvn;
            bool valid = Regex.IsMatch(bvn, @"^[0-9]+$");
            if (!valid)
            {
                Console.WriteLine("Phone number must contain only numbers");
                bv = Console.ReadLine();
                ValidateNumber(bv);
            }

            if (bv.Length != 11)
            {
                Console.WriteLine("Invalid phone number. Please enter an 11-digit phone number.");
                bv = Console.ReadLine();
                ValidateNumber(bv);
            }
            return bv;
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
    

