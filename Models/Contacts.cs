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
        private int _id;
        private static int _counter = 0;
        private static  List<Contact> _contacts = new List<Contact> {};

        public Contact (string name, string phoneNumber, string address)
        {
            _name = name;
            _phoneNumber = phoneNumber;
            _address = address;
            _id = _counter++;
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

        public int GetId()
        {
            return _id;
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
            return _contacts.Single(c => c._id == searchId);
        }
        public static void ClearContact(int id)
        {
            int i;
            for (i = 0; i < _contacts.Count; i++)
            {
                if (_contacts[i]._id == id) {
                    break;
                }
             }
             if (i != _contacts.Count) {
                _contacts.RemoveAt(i);
             }
        }
    }
}
