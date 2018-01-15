using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryLalaland.Model
{
    class Order
    {

        private int _time;
        private int _number;
        private string _currentCustomer;

        public int Time { get => _time; set => _time = value; }
        public int Number { get => _number; set => _number = value; }
        public string CurrentCustomer { get => _currentCustomer; set => _currentCustomer = value; }

        public Order(int time, int number, string currentCustomer)
        {
            _time = time;
            _number = number;
            _currentCustomer = currentCustomer;
        }

    }
}
