namespace PhoneManagment.Views
{
    using System;
    using PhoneManagment.Entites;
    using PhoneManagment.Controllers;
    using PhoneManagment.Services;
    using System.Collections.Generic;

    public class UserManagmentView
    {
        public void Show()
        {
            while (true)
            {
                UserManagmentEnum choice = RenderMenu();

                try
                {
                    switch (choice)
                    {
                        case UserManagmentEnum.Select:
                            {
                                GetAll();
                                break;
                            }
                        case UserManagmentEnum.View:
                            {
                                View();
                                break;
                            }
                        case UserManagmentEnum.Insert:
                            {
                                Add();
                                break;
                            }
                        case UserManagmentEnum.Update:
                            {
                                Update();
                                break;
                            }
                        case UserManagmentEnum.Delete:
                            {
                                Delete();
                                break;
                            }
                        case UserManagmentEnum.Exit:
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

        private UserManagmentEnum RenderMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("User management:");
                Console.WriteLine("[G]et all Users");
                Console.WriteLine("[V]iew User");
                Console.WriteLine("[A]dd User");
                Console.WriteLine("[E]dit User");
                Console.WriteLine("[D]elete User");
                Console.WriteLine("E[x]it");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "G":
                        {
                            return UserManagmentEnum.Select;
                        }
                    case "V":
                        {
                            return UserManagmentEnum.View;
                        }
                    case "A":
                        {
                            return UserManagmentEnum.Insert;
                        }
                    case "E":
                        {
                            return UserManagmentEnum.Update;
                        }
                    case "D":
                        {
                            return UserManagmentEnum.Delete;
                        }
                    case "X":
                        {
                            return UserManagmentEnum.Exit;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice.");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }

        private void GetAll()
        {
            Console.Clear();

            UsersControllers usersControllers = new UsersControllers("users.txt");
            List<UserEntity> users = usersControllers.GetAll();

            foreach (UserEntity user in users)
            {
                Console.WriteLine("ID:" + user.Id);
                Console.WriteLine("Username :" + user.Username);
                Console.WriteLine("Password :" + user.Password);
                Console.WriteLine("First Name :" + user.FirstName);
                Console.WriteLine("Last Name :" + user.LastName);
                Console.WriteLine("IsAdmin :" + user.AdminStatus);

                Console.WriteLine("########################################");
            }

            Console.ReadKey(true);
        }

        private void View()
        {
            Console.Clear();

            Console.Write("User ID: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            UsersControllers usersControllers = new UsersControllers("users.txt");

            UserEntity user = usersControllers.GetById(userId);
            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("User not found.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("ID:" + user.Id);
            Console.WriteLine("Username :" + user.Username);
            Console.WriteLine("Password :" + user.Password);
            Console.WriteLine("First Name :" + user.FirstName);
            Console.WriteLine("Last Name :" + user.LastName);
            Console.WriteLine("Is Admin :" + user.AdminStatus);

            Console.ReadKey(true);
        }

        private void Add()
        {
            Console.Clear();

            UserEntity user = new UserEntity();

            Console.WriteLine("Add new User:");
            Console.Write("Username: ");
            user.Username = Console.ReadLine();
            Console.Write("Password: ");
            user.Password = Console.ReadLine();
            Console.Write("First Name: ");
            user.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            user.LastName = Console.ReadLine();
            Console.Write("Is Admin: ");
            user.AdminStatus = Convert.ToBoolean(Console.ReadLine());

            UsersControllers usersControllers = new UsersControllers("users.txt");
            usersControllers.Save(user);

            Console.WriteLine("User saved successfully.");
            Console.ReadKey(true);
        }

        private void Update()
        {
            Console.Clear();

            Console.Write("User ID: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            UsersControllers usersControllers = new UsersControllers("users.txt");
            UserEntity user = usersControllers.GetById(userId);

            if (user == null)
            {
                Console.Clear();
                Console.WriteLine("User not found.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("Editing User (" + user.Username + ")");
            Console.WriteLine("ID:" + user.Id);

            Console.WriteLine("Username :" + user.Username);
            Console.Write("New Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Password:" + user.Password);
            Console.Write("New Password :");
            string password = Console.ReadLine();

            Console.WriteLine("First Name:" + user.FirstName);
            Console.Write("New First Name :");
            string firstName = Console.ReadLine();

            Console.WriteLine("Last Name:" + user.LastName);
            Console.Write("New Last Name :");
            string lastName = Console.ReadLine();

            Console.WriteLine("IsAdmin:" + user.AdminStatus);
            Console.Write("New IsAdmin :");
            string isAdmin = Console.ReadLine();

            if (!string.IsNullOrEmpty(username))
                user.Username = username;
            if (!string.IsNullOrEmpty(password))
                user.Password = password;
            if (!string.IsNullOrEmpty(firstName))
                user.FirstName = firstName;
            if (!string.IsNullOrEmpty(lastName))
                user.LastName = lastName;
            if (!string.IsNullOrEmpty(isAdmin))
                user.AdminStatus = Convert.ToBoolean(isAdmin);

            usersControllers.Save(user);

            Console.WriteLine("User saved successfully.");
            Console.ReadKey(true);
        }

        private void Delete()
        {
            UsersControllers usersControllers = new UsersControllers("users.txt");

            Console.Clear();

            Console.WriteLine("Delete User:");
            Console.Write("User Id: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            UserEntity user = usersControllers.GetById(userId);
            if (user == null)
            {
                Console.WriteLine("User not found!");
            }
            else
            {
                usersControllers.Delete(user);
                Console.WriteLine("User deleted successfully.");
            }
            Console.ReadKey(true);
        }
    }
}
