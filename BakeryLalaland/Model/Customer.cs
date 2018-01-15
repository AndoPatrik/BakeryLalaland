using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryLalaland.Model
{
    class Customer
    {

        private string _name;
        private string _id;
        private string _password;
        private string _city;
        private string _street;      
        private int _number;
        private int _postalCode;
        private int _phoneNumber;

        public string Name { get => _name; set => _name = value; }
        public string Id { get => _id; set => _id = value; }
        public string Password { get => _password; set => _password = value; }
        public string City { get => _city; set => _city = value; }
        public string Street { get => _street; set => _street = value; }
        public int Number { get => _number; set => _number = value; }
        public int PostalCode { get => _postalCode; set => _postalCode = value; }
        public int PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }

        public Customer()
        {
            
        }

        public Customer(string name, string id, string password, string city, string street, int number, int postalCode, int phoneNumber)
        {
            _name = name;
            _id = id;
            _password = password;
            _city = city;
            _street = street;
            _number = number;
            _postalCode = postalCode;
            _phoneNumber = phoneNumber;
        }
    }
}
