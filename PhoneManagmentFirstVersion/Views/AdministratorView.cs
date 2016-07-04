namespace PhoneManagment.Views
{
    using System;
    using PhoneManagment.Services;

    public class AdministratorView
    {
        public void Show()
        {
            while (true)
            {
                AdministratorNum choice = RenderMenu();
                try
                {
                    switch (choice)
                    {
                        case AdministratorNum.UserManagment:
                            {
                                UserManagmentView userManagmentView = new UserManagmentView();
                                userManagmentView.Show();
                                break;
                            }
                        case AdministratorNum.ContactManagment:
                            {
                                ContactManagmentView contactManagmentView = new ContactManagmentView();
                                contactManagmentView.Show();
                                break;
                            }
                        case AdministratorNum.Exit:
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
        private AdministratorNum RenderMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("##############|Administration|##############");
                Console.ResetColor();
                Console.WriteLine("Manage [U]sers");
                Console.WriteLine("Manage [C]ontacts");
                Console.WriteLine("E[x]it");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "U":
                        {
                            return AdministratorNum.UserManagment;
                        }
                    case "C":
                        {
                            return AdministratorNum.ContactManagment;
                        }
                    case "X":
                        {
                            return AdministratorNum.Exit;
                        }
                    default:
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice.");
                            Console.ResetColor();
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }
    }
}
