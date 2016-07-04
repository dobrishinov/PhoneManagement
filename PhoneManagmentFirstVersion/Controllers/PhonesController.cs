namespace PhoneManagment.Controllers
{
    using PhoneManagment.Entites;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class PhonesController : BaseController<PhoneEntity>
    {
        public PhonesController(string pathToFile)
            : base(pathToFile)
        {
        }

        protected override void WriteItemToStream(StreamWriter sw, PhoneEntity item)
        {
            sw.WriteLine(item.ContactId);
            sw.WriteLine(item.Phone);
        }

        protected override void ReadItemFromStream(StreamReader sr, PhoneEntity item)
        {
            item.ContactId = Convert.ToInt32(sr.ReadLine());
            item.Phone = sr.ReadLine();
        }

        public List<PhoneEntity> GetAll(int ContactId)
        {
            return GetAll().FindAll(p => p.ContactId == ContactId);
        }
    }
}
