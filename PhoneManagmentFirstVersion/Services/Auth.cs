namespace PhoneManagment.Services
{
    using System;
    using PhoneManagment.Controllers;
    using PhoneManagment.Entites;

    public static class Auth
    {
        public static UserEntity LoggedUser { get; private set; }

        public static void AuthenticateUser(string username, string password)
        {
            UsersControllers userController = new UsersControllers("users.txt");
            Auth.LoggedUser = userController.GetByUsernameAndPassword(username, password);
        }
    }
}
