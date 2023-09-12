

using BrinelleBank.Model;
using Newtonsoft.Json;


namespace BrinelleBank.Data
{
    public class ListOfCustomers
    {
        public static Dictionary<string, Customer> customerList = new Dictionary<string, Customer>();

        public static void AddCustomer(string accountNo, Customer customer)
        {
            customerList.Add(accountNo, customer);
        }

        public static void SaveToFile()
        {
            string json = JsonConvert.SerializeObject(customerList, Formatting.Indented);
        }
    }
}
