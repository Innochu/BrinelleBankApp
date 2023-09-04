

namespace BrinelleBank.Common
{
    public class AccountNumberGenerator
    {
        public static string GenerateNewAccountNumber()
        {
			// Generate a random 10-digit number using the GenerateRandomNumber method.
			Random random = new Random();
            return GenerateRandomNumber(random, 10).ToString("D10");

           
        }

        static long GenerateRandomNumber(Random random, int digits)
        {
			// Check if the specified number of digits is valid (greater than 0).
			if (digits <= 0)
                throw new ArgumentOutOfRangeException( "The number of digits must be greater than 0.");

            long min = (long)Math.Pow(10, digits - 1);
            long max = (long)Math.Pow(10, digits) - 1;

            return random.Next((int)min, (int)max);
        }
    }
}
