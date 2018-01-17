using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryLalaland.Interfaces;
using BakeryLalaland.Model;
using BakeryLalaland.Persistancy;

namespace BakeryLalaland.ViewModel
{
    class SignUpVM : NotifyPropertyClass
    {
        //instance fields
        private readonly GetItem _getMembers;
        private FrameNavigationClass _frameNavigation;

        //props
        public RelayCommand AddItemCommand { get; set; }
        public Customer AddNewCustomer { get; set; }
        private LoginViewVM Collection { get; set; }

        public ObservableCollection<Customer> CustomersCatalogVm
        {
            get { return Collection.Customers; }
            set
            {
                Collection.Customers = value;
                OnPropertyChanged(nameof(CustomersCatalogVm));
            }
        }
        
        public SignUpVM()
        {
            _getMembers = new GetItem();
            AddNewCustomer = new Customer();
            AddItemCommand = new RelayCommand(DoAddItem);
            Collection = new LoginViewVM();
            _frameNavigation = new FrameNavigationClass();
        }

        public async void DoAddItem()
        {
            CustomersCatalogVm.Add(AddNewCustomer);
            await _getMembers.SavetoJson(CustomersCatalogVm);
            _frameNavigation.ActivateFrameNavigation(typeof(MainPage));
        }
    }
}
