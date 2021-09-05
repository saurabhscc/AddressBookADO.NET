using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookServices
{
    public class AddressBookOperation
    {
        //Set Connection Betn database and C#
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBookSystem";
        SqlConnection sqlConnection = new SqlConnection(connectionString);
    }
}
