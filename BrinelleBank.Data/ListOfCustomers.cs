

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

				var customelist = JsonConvert.DeserializeObject<Dictionary<string, Customer>>(jsonFile);

				if (customelist != null)
				{
					customerList = customelist;
				}



				if (customerList.Count > 0)
				{
					Console.WriteLine("Customer data loaded successfully");
				}
				else
				{
					Console.WriteLine("No customer data found in the file");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Some error occurred: " + e.Message);
			}
		}

    }
}
