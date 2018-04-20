using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;

namespace AddressBook.Models
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _state;
        private string _zip;
        private int _id;
        private static int _counter = 0;

        public Address (string street, string city, string state, string zipCode)
        {
            _street = street;
            _city = city;
            _state = state;
            _zip = zipCode;
            _id = _counter++;
        }

        public string GetStreet()
        {
           return _street;
        }

        public void SetStreet(string street)
        {
           _street = street;
        }

        public string GetCity()
        {
           return _city;
        }

        public void SetCity(string city)
        {
           _city = city;
        }

        public string GetState()
        {
           return _state;
        }

        public void SetState(string state)
        {
           _state = state;
        }

        public string GetZip()
        {
           return _zip;
        }

        public void SetZip(string zip)
        {
           _zip = zip;
        }

        public int GetAddressId()
        {
            return _id;
        }
    }
}
