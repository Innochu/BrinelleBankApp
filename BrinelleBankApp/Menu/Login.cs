using BrinelleBank.Model;
using BrinelleBank.Data;


namespace BrinelleBank.Menu

{
    public class Login 
    {
        public static void userLogin()
        {
            Console.WriteLine("\nEnter your account number");
            string accountNo = Console.ReadLine();

            Console.WriteLine("Enter your Password");
            string password = Console.ReadLine();

            if (accountNo=="" || password=="")
            {
                Console.WriteLine("All fields are required. Try again");
                userLogin();//recursion
            }
            else
            {
                Customer foundCustomer = null;

                var getCustomerList = ListOfCustomers.customerList;
                bool found = false;
                foreach(var item in getCustomerList)
                {
                    if (item.Key == accountNo)
                    {
                        foundCustomer = item.Value;
                        string Pword = foundCustomer.GetPassword();

                        if (password == Pword)
                        {
                            found = true;
                        }
                    }
                }

                if (found)
                {
                    LoggedIn.LoggedAccount = accountNo;
                    LoggedIn.LoggedCustomer = foundCustomer;

                    Console.WriteLine("Log in successful");
                    HomePage.Options();
                }
                else
                {
                    Console.WriteLine("Invalid login details");
                    userLogin();//recursion
                }
            }


        }
    }
}
