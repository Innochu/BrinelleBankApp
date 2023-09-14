using BrinelleBank.Data;
using BrinelleBank.Model;

namespace JsonReadWriteSaveTest
{
	public class JsonTest
	{
		[Theory]
		[InlineData("John", "Doe", "1234567890", "johndoe@example.com", "Savings", "password", "12345")]
		
		public void AddCustomer_ShouldAddCustomerToDictionary(string firstName, string lastName, string phoneNumber, string email, string accountType, string password, string bvn)
		{
			// Arrange
			var customer = new Customer(firstName, lastName, phoneNumber, email, accountType, password, bvn);

			// Act
			ListOfCustomers.AddCustomer("123", customer);

			// Assert
			Assert.Contains("123", ListOfCustomers.customerList.Keys);
		}

	}
}


