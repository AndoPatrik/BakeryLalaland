using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments;
using BakeryLalaland.Model;

namespace BakeryLalaland.Interfaces
{
    class CartCollectionSingleton
    {
        public static ObservableCollection<MenuCart> _orders;

        private static CartCollectionSingleton Instance { get; set; }

        public CartCollectionSingleton()
        {
            _orders = new ObservableCollection<MenuCart>();
        }

        public static CartCollectionSingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new CartCollectionSingleton();
            }

            return Instance;
        }

        public void SetCartCollection(ObservableCollection<MenuCart> orders)
        {
            _orders = orders;
        }

        public ObservableCollection<MenuCart> GetCartCollection()
        {
            return _orders;
        }
    }
}
