using BrinelleBank.Model;
using BrinelleBank.Data;

namespace BrinelleBank.Common
{
    public class StatementOfAccount
    {
        public static void PrintTable()
        {
            Console.Clear();
            Logger.Log("---------------------------------- ACCOUNT STATEMENT ---------------------------------");
            Logger.Log("|Customer Name|   Amount |  Account Number |  Account Type|  Balance|   Remarks   |");
            Logger.Log("--------------------------------------------------------------------------------------");
        }

        public static void PrintStatementOfAccount()
        {  
            PrintTable();

            foreach (var item in ListOfAccount.statements)
            {
                if (item.Key == LoggedIn.LoggedAccount)
                {
					// Print the extracted values with specific formatting:
					//  'value[0]' is printed with a minimum width of 20 characters, left-aligned. I did same for others
					string[] value = item.Value;
                    Console.WriteLine($"{value[0],-20} {value[1],-10} {value[2],-15} {value[3],-15} {value[4],-10} {value[5],-15}");
                }
            }
        }
    }
}