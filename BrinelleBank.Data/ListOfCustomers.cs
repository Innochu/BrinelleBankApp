

using BrinelleBank.Model;
using Newtonsoft.Json;


namespace BrinelleBank.Data
{
    public class ListOfCustomers
    {
        public static Dictionary<string, Customer> customerList = new Dictionary<string, Customer>();
        public static string filepath = "MyJason_CustomerList";

        public static void AddCustomer(string accountNo, Customer customer)
        {
            customerList.Add(accountNo, customer);
            SaveToFile();  //this saves my data into jason file

		}

        public static void SaveToFile()
        {
            string json = JsonConvert.SerializeObject(customerList, Formatting.Indented);
            File.WriteAllText(filepath, json);


        }

        public static void ReadSavedFile()
        {
            try
            {
                string jsonFile = File.ReadAllText(filepath);
                
            }
        }

    }
}
