using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryLalaland.Model
{
    public class Customer
    {

        private string _name;
        private string _id;
        private string _password;
        private string _confirmPassword;
        private string _city;
        private string _street;      
        private int _number;
        private int _postalCode;
        private int _phoneNumber;

        public string Name { get => _name; set => _name = value; }
        public string Id { get => _id; set => _id = value; }
        public string Password { get => _password; set => _password = value; }
        public string ConfirmPassword { get => _confirmPassword; set => _confirmPassword = value;}
        public string City { get => _city; set => _city = value; }
        public string Street { get => _street; set => _street = value; }
        public int Number { get => _number; set => _number = value; }
        public int PostalCode { get => _postalCode; set => _postalCode = value; }
        public int PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }

        public Customer()
        {

        }

        public Customer(string name, string id, string password, string confirmPassword, string city, string street, int number, int postalCode, int phoneNumber)
        {
            _name = name;
            _id = id;
            _password = password;
            _confirmPassword = confirmPassword;
            _city = city;
            _street = street;
            _number = number;
            _postalCode = postalCode;
            _phoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{Name}{Id}{Password}{ConfirmPassword}{City}{Street}{Number}{PostalCode}{PhoneNumber}";
        }
    }
}
