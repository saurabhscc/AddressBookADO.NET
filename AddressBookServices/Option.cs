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
                Console.Write("1. Insert New Contact\n" + "2. Edit Existing Contact\n" + "3. Delete Contact\n" + "4. Retrieve Contact Belongs To City Or State\n" + "5. Exit\n" );
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
                        if (operations.addressBook.Count > 0)
                        {
                            Console.WriteLine("<<<<<<<<<<<<>>>>>>>>>>>>");
                            foreach (AddressBook contact in operations.addressBook)
                            {
                                Console.WriteLine("Contact Id: " + contact.ContactId);
                                Console.WriteLine("FirstName: " + contact.FirstName);
                                Console.WriteLine("LastName: " + contact.LastName);
                                Console.WriteLine("Address: " + contact.Address);
                                Console.WriteLine("City: " + contact.City);
                                Console.WriteLine("State: " + contact.State);
                                Console.WriteLine("Zip: " + contact.Zip);
                                Console.WriteLine("PhoneNumber: " + contact.PhoneNumber);
                                Console.WriteLine("Email: " + contact.Email);
                                Console.WriteLine("   ");
                            }
                        }
                        else
                            Console.WriteLine("Data Not Found");
                        break;
                    case 5:
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
