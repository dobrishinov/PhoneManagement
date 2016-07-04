namespace PhoneManagment.Views
{
    using PhoneManagment.Controllers;
    using PhoneManagment.Entites;
    using PhoneManagment.Services;
    using PhoneManagmentFirstVersion.Views;
    using System;
    using System.Collections.Generic;

    public class ContactManagmentView : ContactManagment
    {
        public override void Show()
        {
            while (true)
            {
                ContactManagmentEnum choice = RenderMenu();

                try
                {
                    switch (choice)
                    {
                        case ContactManagmentEnum.Select:
                            {
                                GetAll();
                                break;
                            }
                        case ContactManagmentEnum.View:
                            {
                                View();
                                break;
                            }
                        case ContactManagmentEnum.Insert:
                            {
                                Add();
                                break;
                            }
                        case ContactManagmentEnum.Update:
                            {
                                Update();
                                break;
                            }
                        case ContactManagmentEnum.Delete:
                            {
                                Delete();
                                break;
                            }
                        case ContactManagmentEnum.Exit:
                            {
                                return;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.ReadKey(true);
                }
            }
        }

        protected override ContactManagmentEnum RenderMenu()
        {
            while (true)
            {
                Console.Clear();

                ContactsController contactsController = new ContactsController("contacts.txt");
                PhonesController phonesController = new PhonesController("phones.txt");
                List<ContactEntity> contacts = contactsController.GetAll(Auth.LoggedUser.Id);

                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("##############|Contacts manager|##############");
                Console.ResetColor();

                foreach (ContactEntity contact in contacts)
                {
                    Console.WriteLine("Contact ID: " + contact.Id);
                    Console.WriteLine("Contact Name: " + contact.FullName);
                    Console.WriteLine("Contact Email: " + contact.Email);

                    List<PhoneEntity> phones = phonesController.GetAll(contact.Id);
                    foreach (PhoneEntity phone in phones)
                    {
                        Console.WriteLine("Phone ID: " + phone.Id);
                        Console.WriteLine("Phone Number: " + phone.Phone);
                    }
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("############################################");
                    Console.ResetColor();
                }

                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("#############|Available Options|#############");
                Console.ResetColor();
                
                Console.WriteLine("[G]et all Contacts");
                Console.WriteLine("[V]iew Contact");
                Console.WriteLine("[A]dd Contact");
                Console.WriteLine("[E]dit Contact");
                Console.WriteLine("[D]elete Contact");
                Console.WriteLine("E[x]it");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "G":
                        {
                            return ContactManagmentEnum.Select;
                        }
                    case "V":
                        {
                            return ContactManagmentEnum.View;
                        }
                    case "A":
                        {
                            return ContactManagmentEnum.Insert;
                        }
                    case "E":
                        {
                            return ContactManagmentEnum.Update;
                        }
                    case "D":
                        {
                            return ContactManagmentEnum.Delete;
                        }
                    case "X":
                        {
                            return ContactManagmentEnum.Exit;
                        }
                    default:
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Choice");
                            Console.ReadKey(true);
                            Console.ResetColor();

                            break;
                        }
                }
            }
        }

        protected override void GetAll()
        {
            Console.Clear();

            ContactsController contactsController = new ContactsController("contacts.txt");
            PhonesController phonesController = new PhonesController("phones.txt");
            List<ContactEntity> contacts = contactsController.GetAll(Auth.LoggedUser.Id);

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("###############|All Contacts|###############");
            Console.ResetColor();

            foreach (ContactEntity contact in contacts)
            {
                Console.WriteLine("Contact ID: " + contact.Id);
                Console.WriteLine("Contact Name: " + contact.FullName);
                Console.WriteLine("Contact Email: " + contact.Email);

                List<PhoneEntity> phones = phonesController.GetAll(contact.Id);
                foreach (PhoneEntity phone in phones)
                {
                    Console.WriteLine("Phone ID: " + phone.Id);
                    Console.WriteLine("Phone Number: " + phone.Phone);
                }
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("############################################");
                Console.ResetColor();
            }

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Please enter key to return!");
            Console.ResetColor();

            Console.ReadKey(true);
        }

        protected override void View()
        {
            Console.Clear();

            ContactsController contactsController = new ContactsController("contacts.txt");
            PhonesController phonesController = new PhonesController("phones.txt");
            List<ContactEntity> contacts = contactsController.GetAll(Auth.LoggedUser.Id);

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("##############|View Contacts|###############");
            Console.ResetColor();

            foreach (ContactEntity oneContact in contacts)
            {
                Console.WriteLine("Contact ID: " + oneContact.Id);
                Console.WriteLine("Contact Name: " + oneContact.FullName);
                Console.WriteLine("Contact Email: " + oneContact.Email);

                List<PhoneEntity> phones = phonesController.GetAll(oneContact.Id);
                foreach (PhoneEntity phone in phones)
                {
                    Console.WriteLine("Phone ID: " + phone.Id);
                    Console.WriteLine("Phone Number: " + phone.Phone);
                }
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("############################################");
                Console.ResetColor();
            }

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("################|Enter ID|#################");
            Console.ResetColor();

            Console.Write("Contact ID: ");
            int contactId = Convert.ToInt32(Console.ReadLine());

            

            ContactEntity contact = contactsController.GetById(contactId);
            if (contact == null)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Contact not found. Please enter key to return!");
                Console.ResetColor();
                Console.ReadKey(true);
                return;
            }

            PhoneManagmentView phonesManagerView = new PhoneManagmentView(contact);
            phonesManagerView.Show();
        }

        protected override void Add()
        {
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("###############|Add NEW Contact|##############");
            Console.ResetColor();

            ContactEntity contact = new ContactEntity();
            contact.UserId = Auth.LoggedUser.Id;

            Console.Write("Full Name: ");
            contact.FullName = Console.ReadLine();

            Console.Write("Email: ");
            contact.Email = Console.ReadLine();

            ContactsController contactsController = new ContactsController("contacts.txt");
            contactsController.Save(contact);

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Contact saved successfully! Please enter key to return!");
            Console.ResetColor();
            Console.ReadKey(true);

            PhoneManagmentView phoneManagerView = new PhoneManagmentView(contact);
            phoneManagerView.Show();
        }

        protected override void Update()
        {
            Console.Clear();

            ContactsController contactsController = new ContactsController("contacts.txt");
            PhonesController phonesController = new PhonesController("phones.txt");
            List<ContactEntity> contacts = contactsController.GetAll(Auth.LoggedUser.Id);

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("###############|Update Contact|##############");
            Console.ResetColor();

            foreach (ContactEntity oneContact in contacts)
            {
                Console.WriteLine("Contact ID: " + oneContact.Id);
                Console.WriteLine("Contact Name: " + oneContact.FullName);
                Console.WriteLine("Contact Email: " + oneContact.Email);

                List<PhoneEntity> phones = phonesController.GetAll(oneContact.Id);
                foreach (PhoneEntity phone in phones)
                {
                    Console.WriteLine("Phone ID: " + phone.Id);
                    Console.WriteLine("Phone Number: " + phone.Phone);
                }
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("############################################");
                Console.ResetColor();
            }

            Console.Write("Contact ID: ");
            int contactId = Convert.ToInt32(Console.ReadLine());

            ContactEntity contact = contactsController.GetById(contactId);

            if (contact == null)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Contact not found");
                Console.ResetColor();

                Console.ReadKey(true);
                return;
            }

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("###########|Editing Contact (" + contact.FullName + ")|##########");
            Console.ResetColor();

            Console.WriteLine("Contact ID: " + contact.Id);

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Old name: " + contact.FullName);
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("New Name: ");
            string fullName = Console.ReadLine();
            Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Old email: " + contact.Email);
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("New Email: ");
            string email = Console.ReadLine();
            Console.ResetColor();


            if (!string.IsNullOrEmpty(fullName))
                contact.FullName = fullName;
            if (!string.IsNullOrEmpty(email))
                contact.Email = email;

            contactsController.Save(contact);

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Contact saved successfully!");
            Console.ResetColor();
            Console.ReadKey(true);

            PhoneManagmentView phoneManagerView = new PhoneManagmentView(contact);
            phoneManagerView.Show();
        }

        protected override void Delete()
        {
            ContactsController contactsController = new ContactsController("contacts.txt");

            Console.Clear();

            Console.WriteLine("Delete Contact:");
            Console.Write("Contact Id: ");
            int contactId = Convert.ToInt32(Console.ReadLine());

            ContactEntity contact = contactsController.GetById(contactId);
            if (contact == null)
            {
                Console.WriteLine("Contact not found!");
            }
            else
            {
                contactsController.Delete(contact);
                Console.WriteLine("Contact deleted successfully.");
            }
            Console.ReadKey(true);
        }
    }
}
