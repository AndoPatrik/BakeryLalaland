using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using BakeryLalaland.Interfaces;
using BakeryLalaland.Model;

namespace BakeryLalaland.Model
{
    
    public class MenuCart : NotifyPropertyClass
    {
        private string _name;
        private int _number;
        private string _image;
        private int _price;
        private string _ingred;
        private Category _category;
        public ObservableCollection<MenuCart> _drinks; //_drinks refers to beverages and food !!!

        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public int Number { get { return _number; } set { _number = value; OnPropertyChanged(nameof(Number)); } }
        public string Image { get { return _image; } set { _image = value; OnPropertyChanged(nameof(Image)); } }
        public int Price { get { return _price; } set { _price = value; OnPropertyChanged(nameof(Price)); } }
        public string Ingred { get { return _ingred; } set { _ingred = value; OnPropertyChanged(nameof(Ingred)); } }
        public Category Categoryy { get { return _category; } set { _category = value; OnPropertyChanged(nameof(Categoryy)); } }
        public ObservableCollection<MenuCart> Drinks { get { return _drinks; } set { _drinks = value; OnPropertyChanged(nameof(Drinks)); } }


        public MenuCart(string name, int number, string image, int price, Category category, string ingred)
        {
            _name = name;
            _number = number;
            _image = image;
            _price = price;
            _category = category;
            _ingred = ingred;
        }
        public override string ToString()
        {
            return $"{Name}{Number}{Image}{Price}{Categoryy}{Ingred}";
        }

        public MenuCart()
        {
            Drinks = new ObservableCollection<MenuCart>()
            {
                new MenuCart("Coffee", 111,  @"../Assets/001.jpg", 10, Category.Beverages, ""),
                new MenuCart("Capuccino", 112,  @"../Assets/002.jpg", 10, Category.Beverages, "Coffee and milk"),
                new MenuCart("Hot chocolate", 113,  @"../Assets/003.jpg", 20, Category.Beverages, "Dark/Milk/White chocolate"),
                new MenuCart("Muffin", 1111, @"../Assets/101.jpg", 10, Category.Muffins, "Chocolate"),
                new MenuCart("Strawberry cupcake", 1112, @"../Assets/201.jpg", 10, Category.Cupcakes, "Stawberries, cream, cocoa, vanilia"),
                new MenuCart("Strawberry cake", 1113, @"../Assets/301.jpg", 10, Category.Cakes, "Strawberries, bananas, cream, vanilia"),
                new MenuCart("Fruit tarte", 1114, @"../Assets/401.jpg", 10, Category.Healthy,"Blueberries, raspberries, strawberries, blackberries")
            };
        }

        public enum Category
        {
            Muffins,
            Cupcakes,
            Cakes,
            Healthy,
            Pizzas,
            Sandwiches,
            Beverages
        }


    }


}
