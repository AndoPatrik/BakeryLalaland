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
                new MenuCart("Mochaccino", 113,  @"../Assets/007.jpg", 20, Category.Beverages, "Coffee with milk and chocolate"),
                new MenuCart("Hot chocolate", 114,  @"../Assets/003.jpg", 20, Category.Beverages, "Dark/Milk/White chocolate"),
                new MenuCart("Green tea", 115,  @"../Assets/004.jpg", 20, Category.Beverages, "Green tea with lemon, jasmine and mint"),
                new MenuCart("Black tea", 116,  @"../Assets/005.jpg", 20, Category.Beverages, "Black tea with different flavours"),
                new MenuCart("Fruit tea", 117,  @"../Assets/006.jpg", 20, Category.Beverages, "Different flavours - wildberries, orange&cinnamon, apple&cinnamon .."),
                new MenuCart("Blueberry milkshake", 118,  @"../Assets/008.jpg", 20, Category.Beverages, "Milkshake of blueberries"),
                new MenuCart("Stawberry milkshake", 119,  @"../Assets/009.jpg", 20, Category.Beverages, "Milkshake of stawberries and vanilia"),
                new MenuCart("Banana milkshake", 120,  @"../Assets/010.jpg", 20, Category.Beverages, "Milkshake of bananas and peanut butter"),
                new MenuCart("Green smoothie", 121,  @"../Assets/011.jpg", 20, Category.Beverages, "Smoothie of spinach, cucumber, avocado and coconut milk"),
                new MenuCart("Multifruit fresh juice", 122,  @"../Assets/012.jpg", 20, Category.Beverages, "Fresh-squized juice of oranges, apples, carrots and magic flavour"),
                new MenuCart("Muffin", 101, @"../Assets/101.jpg", 10, Category.Muffins, "Classical muffins with chocolate chips and vanilia"),
                new MenuCart("Coffee muffin", 102, @"../Assets/102.png", 10, Category.Muffins, "Coffee muffin with cocoa and Nutella cream"),
                new MenuCart("Fruity muffin", 103, @"../Assets/103.jpg", 10, Category.Muffins, "Fruity muffin with blueberries and raspberries"),
                new MenuCart("Strawberry cupcake", 1112, @"../Assets/201.jpg", 10, Category.Cupcakes, "Stawberries, cream, cocoa, vanilia"),
                new MenuCart("Blackberry cupcake", 1112, @"../Assets/202.jpg", 10, Category.Cupcakes, "Blackberries, cream, cocoa, vanilia"),
                new MenuCart("Caramel cupcake", 1112, @"../Assets/203.jpg", 10, Category.Cupcakes, "Caramel, cream, salt, vanilia"),
                new MenuCart("Oreo cupcake", 1112, @"../Assets/204.jpg", 10, Category.Cupcakes, "Cocoa, oreo, cream, vanilia"),
                new MenuCart("Blueberries cupcake", 1112, @"../Assets/205.jpg", 10, Category.Cupcakes, "Blueberries, cream, honey, vanilia"),
                new MenuCart("Redberries cupcake", 1112, @"../Assets/206.jpg", 10, Category.Cupcakes, "Redberries, cream, nuts, vanilia"),
                new MenuCart("Lemon cupcake", 1112, @"../Assets/207.jpg", 10, Category.Cupcakes, "Lemon, cream, vanilia"),
                new MenuCart("Baileys cupcake", 1112, @"../Assets/208.jpg", 10, Category.Cupcakes, "Baileys, cream, cocoa, vanilia"),
                new MenuCart("Redvelvet cupcake", 1112, @"../Assets/209.jpg", 10, Category.Cupcakes, "Wildberries, cream, vanilia"),   
                new MenuCart("Chocolate cake", 300, @"../Assets/300.jpg", 10, Category.Cakes, "Cocoa, blackberries, blueberries, vanilia"),
                new MenuCart("Strawberry cake", 301, @"../Assets/301.jpg", 10, Category.Cakes, "Strawberries, bananas, cream, vanilia"),
                new MenuCart("Mille feuille cake", 302, @"../Assets/302.jpg", 10, Category.Cakes, "Blackberries, bananas, cream, jam, honey, vanilia"),
                new MenuCart("Raspberries cake", 303, @"../Assets/303.jpg", 10, Category.Cakes, "Raspberries, chocolate, cream, nuts"),
                new MenuCart("Tiramisu cake", 304, @"../Assets/304.jpg", 10, Category.Cakes, "Coffee, mascarpone, vanilia"),
                new MenuCart("Fruit tarte", 401, @"../Assets/401.jpg", 10, Category.Healthy,"Blueberries, raspberries, strawberries, blackberries"),
                new MenuCart("Tiramisu bites", 402, @"../Assets/402.jpg", 10, Category.Healthy,"Raw vegar tiramusi bites"),
                new MenuCart("Blueberry cheesecake", 401, @"../Assets/403.jpg", 10, Category.Healthy,"Blueberries, cream, vanilia, cookies"),
                new MenuCart("Banana split cups", 402, @"../Assets/404.jpg", 10, Category.Healthy,"Bananas, raspberries, chocolate, nuts"),
                new MenuCart("Energy bites", 401, @"../Assets/405.jpg", 10, Category.Healthy,"Oatmeal, honey, peanut butter, raisins, nuts"),
                new MenuCart("BakeryLand Pizza", 501, @"../Assets/501.jpg", 10, Category.Pizzas,"Tomatoes, pebbers, mushrooms, mozarella, ham"),
                new MenuCart("Pepperoni Pizza", 502, @"../Assets/502.jpg", 10, Category.Pizzas,"Tomatoes, pepperoni, mozarella"),
                new MenuCart("Margarita", 503, @"../Assets/503.jpg", 10, Category.Pizzas,"Tomatoes, veggies, mozarella"),
                new MenuCart("Veggie", 601, @"../Assets/601.jpg", 10, Category.Sandwiches,"Tomatoes, cucumbers, spinach, avocado"),
                new MenuCart("Chicken", 602, @"../Assets/602.jpg", 10, Category.Sandwiches,"Chicken, cabbage, tomatoes, cucumbers"),
                new MenuCart("Tuna", 603, @"../Assets/603.jpg", 10, Category.Sandwiches,"Tuna, cabbage, tomatoes, cheese")
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
