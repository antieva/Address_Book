using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;
using System;

namespace AddressBook.Controllers
{
    public class ContactsController : Controller
    {
        [HttpGet("/contacts")]
        public ActionResult Index()
        {
            List<Contact> allContacts = Contact.GetAll();
            return View(allContacts);
        }
    }
}
