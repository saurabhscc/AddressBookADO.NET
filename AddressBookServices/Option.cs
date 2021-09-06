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
                Console.Write("1. Insert New Contact\n" + "2. Edit Existing Contact\n" + "3. Delete Contact\n" + "4. Retrieve Contact Belongs To City Or State\n" + "5.Size Of AddressBook By City\n" + "6. Retrieve Contacts Belongs To City SortedAlphabatically\n" + "7. Alter Table To Have Type And Name\n" + "8.Type Count OF AddressBook \n" + "9. Exit\n" );
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
                        operations.DeleteContact();
                        break;
                    case 4:
                        operations.RetrieveContactBelongsToCityOrState();
                        operations.Display();
                        break;
                    case 5:
                        operations.SizeOfAddressBookByCity();
                        break;
                    case 6:
                        operations.RetrieveContactBelongsToCitySortedAlphabatically();
                        operations.Display();
                        break;
                    case 7:
                        operations.AlterTableAddColumn();
                        break;
                    case 8:
                        operations.CountByType();
                        break;
                    case 9:
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
