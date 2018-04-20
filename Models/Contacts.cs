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
        private int _contactId;
        private List<Address> _addresses;
        private static int _counter = 0;
        private static  List<Contact> _contacts = new List<Contact> {};

        public Contact (string name, string phoneNumber, List<Address> allAddresses)
        {
            _name = name;
            _phoneNumber = phoneNumber;
            _contactId = _counter++;
            _addresses = allAddresses;
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

        public List<Address> GetAddresses()
        {
           return _addresses;
        }

        public void SetAddresses(List<Address> addresses)
        {
           _addresses = addresses;
        }

        public int GetId()
        {
            return _contactId;
        }

        public void Save()
        {
            _contacts.Add(this);
        }

        public static List<Contact> GetAll()
        {
            return _contacts;
        }
        public static void ClearAll()
        {
            _contacts.Clear();
        }

        public static Contact Find(int searchId)
        {
            return _contacts.Single(c => c._contactId == searchId);
        }

        public static void ClearContact(int id)
        {
            int i;
            for (i = 0; i < _contacts.Count; i++)
            {
                if (_contacts[i]._contactId == id) {
                    break;
                }
             }
             if (i != _contacts.Count) {
                _contacts.RemoveAt(i);
             }
        }
    }
}
