namespace PhoneManagmentFirstVersion.Views
{
    using PhoneManagment.Controllers;
    using PhoneManagment.Entites;
    using PhoneManagment.Services;
    using System;
    using System.Collections.Generic;

    public abstract class ContactManagment
    {
        public abstract void Show();
        protected abstract ContactManagmentEnum RenderMenu();
        protected abstract void GetAll();
        protected abstract void View();
        protected abstract void Add();
        protected abstract void Update();
        protected abstract void Delete();
    }
}
