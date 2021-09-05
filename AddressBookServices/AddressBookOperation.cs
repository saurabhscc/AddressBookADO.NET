using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookServices
{
    public class AddressBookOperation
    {
        //Set Connection Betn database and C#
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBookSystem";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public void InsertNewContact()
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("spInsertNewContact", this.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.Write("Give FirstName: ");
                string firstName = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                Console.Write("Give LastName: ");
                string lastName = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@LastName", lastName);
                Console.Write("Give Address: ");
                string address = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@Address", address);
                Console.Write("Give City: ");
                string city = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@City", city);
                Console.Write("Give State: ");
                string state = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@State", state);
                Console.Write("Give Zip: ");
                string zip = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@Zip", zip);
                Console.Write("Give PhoneNumber: ");
                string phoneNumber = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                Console.Write("Give Email: ");
                string email = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@Email", email);


                int effectedRows = sqlCommand.ExecuteNonQuery();
                if (effectedRows >= 1)
                {
                    Console.WriteLine("Successfully Added");
                }
                else
                    Console.WriteLine("Error");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
