namespace PhoneManagment.Entites
{
    using System;

    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool AdminStatus { get; set; }
    }
}
