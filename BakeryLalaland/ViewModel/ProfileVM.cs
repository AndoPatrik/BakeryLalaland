using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;
using BakeryLalaland.Interfaces;

namespace BakeryLalaland.ViewModel
{
    class ProfileVM
    {
        private CurrentUserSingleton _currentUserSingleton;

        private string _name;
        private string _id;
        private string _password;
        private string _confirmPassword;
        private string _city;
        private string _street;
        private int _number;
        private int _postalCode;
        private int _phoneNumber;

        public ProfileVM()
        {
           _currentUserSingleton = CurrentUserSingleton.GetInstance();
            Name = _currentUserSingleton.GetName();
            Id = _currentUserSingleton.GetId();
            Password = _currentUserSingleton.GetPassword();
            ConfirmPassword = _currentUserSingleton.GetConfrimPassword();
            City = _currentUserSingleton.GetCity();
            Street = _currentUserSingleton.GetStreet();
            Number = _currentUserSingleton.GetStreetNumber();
            PostalCode = _currentUserSingleton.GetPostalCode();
            PhoneNumber = _currentUserSingleton.GetPhoneNum();

        }

        public string Name { get => _name; set => _name = value; }
        public string Id { get => _id; set => _id = value; }
        public string Password { get => _password; set => _password = value; }
        public string ConfirmPassword { get => _confirmPassword; set => _confirmPassword = value; }
        public string City { get => _city; set => _city = value; }
        public string Street { get => _street; set => _street = value; }
        public int Number { get => _number; set => _number = value; }
        public int PostalCode { get => _postalCode; set => _postalCode = value; }
        public int PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
    }
}
