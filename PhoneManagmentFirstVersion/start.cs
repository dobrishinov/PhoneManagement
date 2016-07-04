namespace PhoneManagment
{
    using PhoneManagment.Services;
    using PhoneManagment.Views;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            LoginView loginView = new LoginView();
            loginView.Show();

            if (Auth.LoggedUser.AdminStatus)
            {
                AdministratorView administratorView = new AdministratorView();
                administratorView.Show();
            }
            else
            {
                ContactManagmentView contactManagerView = new ContactManagmentView();
                contactManagerView.Show();
            }
        }
    }
}
