﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using BakeryLalaland.Interfaces;
using BakeryLalaland.Model;
using BakeryLalaland.Persistency;
using BakeryLalaland.View;

namespace BakeryLalaland.ViewModel
{
    class LoginViewVM : NotifyPropertyClass
    {
        //Instance Fields
        private ObservableCollection<Customer> _customers;
        private Customer _currentCustomer;
        private FrameNavigationClass FrameNavigation;
        private readonly GetItem _getCustomer;
        private readonly CurrentUserSingleton _currentUserSingleton;

        //Props
        public RelayCommand CheckCommand { get; set; }
        public ObservableCollection<Customer> Customers { get => _customers; set => _customers = value; }
        public bool LoginStatus { get; set; }

        public Customer CurrentCustomer
        {
            get => _currentCustomer;
            set
            {
                _currentCustomer = value;
                OnPropertyChanged(nameof(CurrentCustomer));
            }
        }

        //Constructor(s)
        public LoginViewVM()
        {
            CurrentCustomer = new Customer();
            CheckCommand = new RelayCommand(Check);
            _currentCustomer = new Customer();
            FrameNavigation = new FrameNavigationClass();
            _currentCustomer = new Customer();
            _getCustomer = new GetItem();
            Customers = new ObservableCollection<Customer>();
            _currentUserSingleton = CurrentUserSingleton.GetInstance();
        }

        //Methods
        public async void Check()
        {
            LoginStatus = false;
            LoadCustomers();
            if (Customers != null)
            {
                foreach (Customer customer in Customers)
                {
                    if (customer.Id == CurrentCustomer.Id && customer.Password == CurrentCustomer.Password)
                    {
                        _currentUserSingleton.SetCurrentUser(customer);
                        LoginStatus = true;
                        FrameNavigation.ActivateFrameNavigation(typeof(MenuPage));
                        MessageDialog msd = new MessageDialog("Hello", "Login works for user");
                        await msd.ShowAsync();
                        break;
                    }
                    //It pointed the customer.Id instead of the CurrentCustomer.Id
                    else if (CurrentCustomer.Id == "coffee" && CurrentCustomer.Password == "milk")
                    {
                        LoginStatus = true;
                        FrameNavigation.ActivateFrameNavigation(typeof(ManagerPage));
                        MessageDialog msd = new MessageDialog("Hello", "Login works admin");
                        await msd.ShowAsync();
                        break;
                    }
                }
                if (LoginStatus == false)
                {
                    MessageDialog msd = new MessageDialog("Hello", "Insert the correct data");
                    await msd.ShowAsync();
                }
            }
        }

        //Loading customers from json
        public async void LoadCustomers()
        {
            try
            {
                Customers = await _getCustomer.LoadFromJson();
            }
            catch (Exception e)
            {
                _customers = new ObservableCollection<Customer>()
                {
                    new Customer("John" , "john","xxx","xxx","Coppenhagen","Robert Jackobsonvej", 77 , 2220 , 50607280 )
                };
                await _getCustomer.SavetoJson(Customers);
            }
        }
    }
}
