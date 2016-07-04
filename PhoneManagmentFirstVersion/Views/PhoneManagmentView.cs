namespace PhoneManagment.Views
{
    using System;
    using PhoneManagment.Entites;
    using PhoneManagment.Controllers;
    using PhoneManagment.Services;
    using System.Collections.Generic;

    public class PhoneManagmentView
    {
        private ContactEntity contact = null;

        public PhoneManagmentView(ContactEntity contact)
        {
            this.contact = contact;
        }

        public void Show()
        {
            while (true)
            {
                PhoneManagmentEnum choice = RenderMenu();

                switch (choice)
                {
                    case PhoneManagmentEnum.Select:
                        {
                            GetAll();
                            break;
                        }
                    case PhoneManagmentEnum.Insert:
                        {
                            Add();
                            break;
                        }
                    case PhoneManagmentEnum.Delete:
                        {
                            Delete();
                            break;
                        }
                    case PhoneManagmentEnum.Exit:
                        {
                            return;
                        }
                }
            }
        }

        private PhoneManagmentEnum RenderMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Phones management (" + this.contact.FullName + ")");
                Console.WriteLine("ID" + contact.Id);
                Console.WriteLine("Name: " + contact.FullName);
                Console.WriteLine("Email: " + contact.Email);
                Console.WriteLine("##############################");
                Console.WriteLine("[G]et all phones");
                Console.WriteLine("[A]dd phone");
                Console.WriteLine("[D]elete phone");
                Console.WriteLine("E[x]it");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "G":
                        {
                            return PhoneManagmentEnum.Select;
                        }
                    case "A":
                        {
                            return PhoneManagmentEnum.Insert;
                        }
                    case "D":
                        {
                            return PhoneManagmentEnum.Delete;
                        }
                    case "X":
                        {
                            return PhoneManagmentEnum.Exit;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }

        private void GetAll()
        {
            Console.Clear();

            PhonesController phonesController = new PhonesController("phones.txt");
            List<PhoneEntity> phones = phonesController.GetAll(this.contact.Id);

            foreach (PhoneEntity phone in phones)
            {
                Console.WriteLine("ID" + phone.Id);
                Console.WriteLine("Phone :" + phone.Phone);
                Console.WriteLine("##################################");
            }

            Console.ReadKey(true);
        }

        private void Add()
        {
            Console.Clear();

            PhoneEntity phone = new PhoneEntity();
            phone.ContactId = this.contact.Id;

            Console.WriteLine("Add bew Phone:");
            Console.Write("Phone: ");
            phone.Phone = Console.ReadLine();

            PhonesController phoneController = new PhonesController("phones.txt");
            phoneController.Save(phone);

            Console.WriteLine("Phone saved successfully");
            Console.ReadKey(true);
        }

        public void Delete()
        {
            PhonesController phoneController = new PhonesController("phones.txt");

            Console.Clear();

            Console.WriteLine("Delete phone:");
            Console.WriteLine("phone id: ");
            int phoneId = Convert.ToInt32(Console.ReadLine());

            PhoneEntity phone = phoneController.GetById(phoneId);
            if (phone == null)
            {
                Console.WriteLine("Phone not found!");
            }
            else
            {
                phoneController.Delete(phone);
                Console.WriteLine("Phone deleted successfully");
            }
            Console.ReadKey(true);
        }
    }
}
