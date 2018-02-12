using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;
using Windows.UI.Popups;
using BakeryLalaland.Interfaces;
using BakeryLalaland.Model;
using BakeryLalaland.Persistency;

namespace BakeryLalaland.ViewModel
{
    class ProfileVM : NotifyPropertyClass
    {
        private CurrentUserSingleton _currentUserSingleton;
        private Customer _newUpdate;
        private readonly GetItem _getItem;
        private readonly FrameNavigationClass _frameNavigation;

        public RelayCommand UpdateCommand { get; set; }
        private LoginViewVM Collection { get; set; }

        public ObservableCollection<Customer> CustomersCatalog
        {
            get { return Collection.Customers; }
            set
            {
                Collection.Customers = value;
                OnPropertyChanged(nameof(CustomersCatalog));
            }
        }
        

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
           CurrentUserSingleton = CurrentUserSingleton.GetInstance();
            Name = CurrentUserSingleton.GetName();
            Id = CurrentUserSingleton.GetId();
            Password = CurrentUserSingleton.GetPassword();
            ConfirmPassword = CurrentUserSingleton.GetConfrimPassword();
            City = CurrentUserSingleton.GetCity();
            Street = CurrentUserSingleton.GetStreet();
            Number = CurrentUserSingleton.GetStreetNumber();
            PostalCode = CurrentUserSingleton.GetPostalCode();
            PhoneNumber = CurrentUserSingleton.GetPhoneNum();

            UpdateCommand = new RelayCommand(Update);
            Collection = new LoginViewVM();
            _getItem = new GetItem();
            _frameNavigation = new FrameNavigationClass();
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;OnPropertyChanged(nameof(Name));
            }
            
        }

        public string Id
        {
            get => _id;
            set
            {
                _id = value; OnPropertyChanged(nameof(Id));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value; OnPropertyChanged(nameof(Password));
            }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value; OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value; OnPropertyChanged(nameof(City));
            }
        }

        public string Street
        {
            get => _street;
            set
            {
                _street = value; OnPropertyChanged(nameof(Street));
            }
        }
        public int Number
        {
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }
        public int PostalCode
        {
            get => _postalCode;
            set
            {
                _postalCode = value;
                OnPropertyChanged(nameof(PostalCode));
            }
        }
        public int PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public Customer NewUpdate
        {
            get => _newUpdate;
            set
            {
                _newUpdate = value;
                OnPropertyChanged(nameof(NewUpdate));
            }
        }

        internal CurrentUserSingleton CurrentUserSingleton { get => _currentUserSingleton; set
            {
                _currentUserSingleton = value;
                OnPropertyChanged(nameof(CurrentUserSingleton));
            } }

        public async void Update()
        {
            try
            {
                Collection.Customers = await _getItem.LoadFromJson();
                foreach (var item in Collection.Customers)
                {
                    if (item.Id == CurrentUserSingleton.GetId() && item.Password == CurrentUserSingleton.GetPassword())
                    {
                        item.Name = Name;
                        item.City = City;
                        item.Id = Id;
                        item.ConfirmPassword = ConfirmPassword;
                        item.Number = Number;
                        item.Password = Password;
                        item.PhoneNumber = PhoneNumber;
                        item.PostalCode = PostalCode;
                        item.Street = Street;

                        await _getItem.SavetoJson(Collection.Customers);
                        _frameNavigation.ActivateFrameNavigation(typeof(MainPage));
                        MessageDialog msg = new MessageDialog("Profile has been updated. Log in again to refresh changes", "Confirmation");
                        await msg.ShowAsync();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                string ex = e.ToString();
                MessageDialog msd = new MessageDialog(ex, "error");
                msd.ShowAsync();
            }
        }
    }
}
