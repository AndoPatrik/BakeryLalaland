using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryLalaland.Interfaces;
using BakeryLalaland.Model;
using BakeryLalaland.Persistency;

namespace BakeryLalaland.ViewModel
{
    class ManagingUsersVM : NotifyPropertyClass
    {
        //instance fields
        private Customer _selectedCustomer;
        private readonly GetItem _getItem;

        //props
        public RelayCommand AddItemCommand { get; set; }
        public RelayCommand DeleteItemCommand { get; set; }
        public RelayCommand UpdateItemCommand { get; set; }
        public Customer AddNewCustomer { get; set; }
        public LoginViewVM Collection { get; set; }

        public ObservableCollection<Customer> CustomersCatalogManager
        {
            get { return Collection.Customers; }
            set
            {
                Collection.Customers = value;
                OnPropertyChanged(nameof(CustomersCatalogManager));
            }
        }

        public Customer SelectedItem
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ManagingUsersVM()
        {
            AddNewCustomer = new Customer();
            Collection = new LoginViewVM();
            AddItemCommand = new RelayCommand(DoAddCustomer);
            DeleteItemCommand = new RelayCommand(DoDeleteCustomer);
            UpdateItemCommand = new RelayCommand(DoUpdateCustomer);
            SelectedItem = new Customer();
            _getItem = new GetItem();
            LoadCustomers();
        }

        //Loading method
        public async void LoadCustomers()                                        //serialization
        {
            try
            {
                CustomersCatalogManager = await _getItem.LoadFromJson();
            }
            catch (Exception e)
            {
                foreach (Customer customer in CustomersCatalogManager)
                {
                    var drink = customer;
                }
                string error = e.Message;
            }
        }


        public async void DoAddCustomer()
        {

            CustomersCatalogManager.Add(AddNewCustomer);
            await _getItem.SavetoJson(CustomersCatalogManager);                       //serialization
        }

        public async void DoUpdateCustomer()
        {
            await _getItem.SavetoJson(CustomersCatalogManager);
        }

        public async void DoDeleteCustomer()
        {
            CustomersCatalogManager.Remove(SelectedItem);
            await _getItem.SavetoJson(CustomersCatalogManager);                       //serialization
        }
    }
}
