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

        [HttpGet("/contacts/new")]
        public ActionResult Form()
        {
            Console.WriteLine("I am in the Form");
            return View();
        }

        [HttpPost("/contacts/new")]
        public ActionResult Create()
        {
            Contact newContact = new Contact (Request.Form["name"],Request.Form["phoneNumber"],Request.Form["address"]);
            newContact.Save();
            List<Contact> allContacts = Contact.GetAll();
            return View("Index", allContacts);
        }

        [HttpGet("/details/{id}")]
        public ActionResult Details(int id)
        {
            Contact contact = Contact.Find(id);
            return View(contact);
        }

        [HttpPost("/contacts/delete/{id}")]
        public ActionResult DeleteContact(int id)
        {
             Contact.ClearContact(id);
             List<Contact> allContacts = Contact.GetAll();
             return View("Delete", allContacts);
        }

        [HttpPost("/contacts/delete")]
        public ActionResult Delete()
        {
             Contact.ClearAll();
             List<Contact> allContacts = Contact.GetAll();
             return View(allContacts);
        }
    }
}
