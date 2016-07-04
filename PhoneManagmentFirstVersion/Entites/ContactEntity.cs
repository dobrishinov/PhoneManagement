namespace PhoneManagment.Entites
{
    using System;

    public class ContactEntity : BaseEntity
    {
        public int UserId { get; set; }
        public string FullName { get; set; } 
        public string Email { get; set; }
    }
}
