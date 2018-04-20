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
            Address newAddress = new Address(Request.Form["street"], Request.Form["city"], Request.Form["state"],Request.Form["zip"]);
            List<Address> allAddresses = new List<Address> {};
            allAddresses.Add(newAddress);
            Contact newContact = new Contact (Request.Form["name"],Request.Form["phoneNumber"],allAddresses);
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

        [HttpGet("/contacts/{id}/address/new")]
        public ActionResult AddressForm(int id)
        {
            Console.WriteLine("I am in the AddressForm");
            Contact contact = Contact.Find(id);
            return View(contact);
        }

        [HttpPost("/contacts/{id}/address/new")]
        public ActionResult CreateNewAddress(int id)
        {
            Address newAddress = new Address(Request.Form["street"], Request.Form["city"], Request.Form["state"],Request.Form["zip"]);
            Contact contact = Contact.Find(id);
            List<Address> allAddresses = contact.GetAddresses();
            foreach(var address in allAddresses)
            {
                Console.WriteLine(address.GetAddressId());
            }
            allAddresses.Add(newAddress);
            contact.SetAddresses(allAddresses);
            return View("Details", contact);
        }

        [HttpGet("/contacts/{contactId}/{addressId}/delete")]
        public ActionResult DeleteAddress(int contactId, int addressId)
        {
             Console.WriteLine("hey");
             Contact contact = Contact.Find(contactId);
             Console.WriteLine(contact.GetName());
             List<Address> allAddresses = contact.GetAddresses();
             int i;
             for (i = 0; i < allAddresses.Count; i++)
             {
                 if (allAddresses[i].GetAddressId() == addressId) {
                     break;
                 }
              }
              if (i != allAddresses.Count) {
                 allAddresses.RemoveAt(i);
              }
              contact.SetAddresses(allAddresses);
             return View("Details", contact);
        }
    }
}
