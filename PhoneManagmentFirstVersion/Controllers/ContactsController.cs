namespace PhoneManagment.Controllers
{
    using System;
    using PhoneManagment.Entites;
    using System.IO;
    using System.Collections.Generic;

    public class ContactsController : BaseController<ContactEntity>
    {
        public ContactsController(string pathToFile)
            : base(pathToFile)
        {
        }

        protected override void WriteItemToStream(StreamWriter sw, ContactEntity item)
        {
            sw.WriteLine(item.UserId);
            sw.WriteLine(item.FullName);
            sw.WriteLine(item.Email);
        }

        protected override void ReadItemFromStream(StreamReader sr, ContactEntity item)
        {
            item.UserId = Convert.ToInt32(sr.ReadLine());
            item.FullName = sr.ReadLine();
            item.Email = sr.ReadLine();
        }

        public List<ContactEntity> GetAll(int userId)
        {
            return GetAll().FindAll(c => c.UserId == userId);
        }
    }
}
