


namespace BrinelleBank.Model
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string BVN { get; set; }

        public double Balance { get; set; }
        public string AccountType { get; set; }
        public string Password { get; set; }


        public Customer(string firstName, string lastName, string phoneNumber, string email, string accountType, string password, string bvn)
        {
            this.FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Balance = 0;
            AccountType = accountType;
            Password = password;
            BVN = bvn;
        }

       public Customer() { }    

        public string GetFirstName()
        {
            return FirstName;
        }

        public string GetLastName()
        {
            return LastName;
        }

        public string GetFullName()
        {
            return GetFirstName() + " " + GetLastName();
        }

        public string GetPhoneNumber()
        {
            return PhoneNumber;
        }

        public string GetEmail()
        {
            return Email;
        }

        public string GetAccountType()
        {
            return AccountType;
        }

        public string GetPassword()
        {
            return Password;
        }

        public void SetBalance(double amount)
        {
            Balance += amount;
        }

        public double GetBalance()
        {
            return Balance;
        }

        public string GetBvn()
        {
            return BVN;
        }
    }
}
