using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryLalaland.Model;

namespace BakeryLalaland.ViewModel
{
    class LoginViewVM
    {
        //Instance Fields
        private ObservableCollection<Customer> _customers;
        private Customer _currentCustomer;
        
        //Props
        public ObservableCollection<Customer> Customers { get => _customers; set => _customers = value; }
        public  bool LoginStatus { get; set; }

        //INotify shit should be added 
        public Customer CurrentCustomer { get => _currentCustomer; set => _currentCustomer = value; }

        //Constructor(s)
        public LoginViewVM()
        {
            CurrentCustomer = new Customer();
            // Here we should load the json thing
            try
            {
                _customers = new ObservableCollection<Customer>()
                {
                    new Customer("John" , "john","xxx","Coppenhagen","Robert Jackobsonvej", 77 , 2220 , 50607280 )                
                };
            }
            catch (Exception e)
            {
                // Handle
            }
        }

        public void Check()
        {
            LoginStatus = false;
            if (Customers != null)
            {
                foreach (Customer customer in Customers)
                {
                    if (customer.Id == CurrentCustomer.Id && customer.Password == CurrentCustomer.Password)
                    {
                        LoginStatus = true;
                        //frame navigation
                        break;
                    }
                    else if (customer.Id == "coffee" && customer.Password=="milk")
                    {
                        LoginStatus = true;
                        //frame navigation
                        break;
                    }
                    if (LoginStatus == false)
                    {
                        //acces denied/pop up window
                    }
                }
            }
        }

        //loading method from json
    }
}
