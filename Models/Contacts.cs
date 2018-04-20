using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;

namespace AddressBook.Models
{
    public class Contact
    {
        private string _name;
        private string _phoneNumber;
        private string _address;
        private static  List<Contact> _contacts = new List<Contact> {};

        public Contact (string name, string phoneNumber, string address)
        {
            _name = name;
            _phoneNumber = phoneNumber;
            _address = address;
        }

        public string GetName()
        {
           return _name;
        }
        public void SetName(string name)
        {
           _name = name;
        }
        public string GetPhoneNumber()
        {
           return _phoneNumber;
        }
        public void SetPhoneNumber(string phoneNumber)
        {
           _phoneNumber = phoneNumber;
        }
        public string GetAddress()
        {
           return _address;
        }
        public void SetAddress(string address)
        {
           _address = address;
        }

        public void Save()
        {
            _contacts.Add(this);
        }

        public static List<Contact> GetAll()
        {
            return _contacts;
        }
        public static List<Contact> ClearAll()
        {
            _contacts.Clear();
        }
    }
}
