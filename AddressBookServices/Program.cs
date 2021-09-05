using System;

namespace AddressBookServices
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book System ADO");
            Console.WriteLine("<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>");
            Option operation = new Option();
            operation.AddressBookOperation();
        }
    }
}
