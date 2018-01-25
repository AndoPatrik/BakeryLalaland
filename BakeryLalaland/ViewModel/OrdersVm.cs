using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryLalaland.Interfaces;
using BakeryLalaland.Model;

namespace BakeryLalaland.ViewModel
{
    class OrdersVm
    {
        private ObservableCollection<MenuCart> _cartCollection;

        private CartCollectionSingleton _cartCollectionSingleton;
        //private FoodSingleton _foodSingleton;

        //private string _name;
        //private int _number;
        //private string _image;
        //private int _price;
        //private string _ingred;
        //private MenuCart.Category _category;

        public ObservableCollection<MenuCart> CartCollection { get => _cartCollection; set => _cartCollection = value; }
        //public string Name { get => _name; set => _name = value; }
        //public int Number { get => _number; set => _number = value; }
        //public string Image { get => _image; set => _image = value; }
        //public int Price { get => _price; set => _price = value; }
        //public string Ingred { get => _ingred; set => _ingred = value; }
        //public MenuCart.Category Category { get => _category; set => _category = value; }

        public OrdersVm()
        {
            _cartCollectionSingleton = CartCollectionSingleton.GetInstance();
            CartCollection = new ObservableCollection<MenuCart>();
            CartCollection = _cartCollectionSingleton.GetCartCollection();
            //_foodSingleton = FoodSingleton.GetInstance();

            //Name = _foodSingleton.GetName();
            //Number = _foodSingleton.GetNumber();
            //Image = _foodSingleton.GetImage();
            //Price = _foodSingleton.GetPrice();
            //Ingred = _foodSingleton.GetIngredients();
            //Category = _foodSingleton.GetCategory();
        }

        
    }
}
