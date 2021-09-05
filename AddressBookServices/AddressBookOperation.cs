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
        public List<AddressBook> addressBook = new List<AddressBook>();
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
        public void EditExistingContact()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spEditExistingContact", this.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.Write("FirstName Of Contact For Address To Be Updated : ");
                string firstName = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                Console.Write("New Address: ");
                string address = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@Address", address);

                sqlConnection.Open();
                int effectedRows = sqlCommand.ExecuteNonQuery();
                if (effectedRows >= 1)
                {
                    Console.WriteLine("Successfully Edited ");
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
        public void DeleteContact()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spDeleteContact", this.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.Write("FirstName Of Contact For Address To Be Deleted:  ");
                string firstName = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@FirstName", firstName);

                sqlConnection.Open();
                int effectedRows = sqlCommand.ExecuteNonQuery();
                if (effectedRows >= 1)
                {
                    Console.WriteLine("Successfully Deleted");
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
        public List<AddressBook> RetrieveContactBelongsToCityOrState()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spRetrievePersonBelongsToCityOrState", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.Write("Name Of City: ");
                string city = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@City", city);
                Console.Write("Name Of State: ");
                string state = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@State", state);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();

                sqlConnection.Open();
                sqlDataAdapter.Fill(dataTable);

                addressBook.Clear();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    addressBook.Add(
                        new AddressBook
                        {
                            ContactId = Convert.ToInt32(dataRow["ContactId"]),
                            FirstName = Convert.ToString(dataRow["FirstName"]),
                            LastName = Convert.ToString(dataRow["LastName"]),
                            Address = Convert.ToString(dataRow["Address"]),
                            City = Convert.ToString(dataRow["City"]),
                            State = Convert.ToString(dataRow["State"]),
                            Zip = Convert.ToString(dataRow["Zip"]),
                            PhoneNumber = Convert.ToString(dataRow["PhoneNumber"]),
                            Email = Convert.ToString(dataRow["Email"]),
                        }
                        );
                }
                return addressBook;
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
        public void SizeOfAddressBookByCity()
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("spGetSizeOfAddressBookByCity", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.Write("Name Of City: ");
                string city = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@City", city);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine("   ");
                    Console.WriteLine(string.Format("Number Of Contacts Belongs To " + city + ": {0}", reader[0]));
                }
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
        public List<AddressBook> RetrieveContactBelongsToCitySortedAlphabatically()
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spRetrieveContactsByCitySortedAlphabatically", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.Write("Name Of City: ");
                string city = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@City", city);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();

                sqlConnection.Open();
                sqlDataAdapter.Fill(dataTable);

                addressBook.Clear();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    addressBook.Add(
                        new AddressBook
                        {
                            ContactId = Convert.ToInt32(dataRow["ContactId"]),
                            FirstName = Convert.ToString(dataRow["FirstName"]),
                            LastName = Convert.ToString(dataRow["LastName"]),
                            Address = Convert.ToString(dataRow["Address"]),
                            City = Convert.ToString(dataRow["City"]),
                            State = Convert.ToString(dataRow["State"]),
                            Zip = Convert.ToString(dataRow["Zip"]),
                            PhoneNumber = Convert.ToString(dataRow["PhoneNumber"]),
                            Email = Convert.ToString(dataRow["Email"]),
                        }
                        );
                }
                return addressBook;
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
