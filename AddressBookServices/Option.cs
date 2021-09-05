using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookServices
{
    public class Option
    {
        AddressBookOperation operations = new AddressBookOperation();
        public int choice;

        public void AddressBookOperation()
        {
            do
            {
                Console.Write("1. Insert New Contact\n" + "2. Edit Existing Contact\n"+"3. Exit\n" );
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        operations.InsertNewContact();
                        break;
                    case 2:
                        operations.EditExistingContact();
                        break;
                    case 3:
                        Console.WriteLine("Exit");
                        break;

                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            }
            while (choice != 0);
        }
    }
}
