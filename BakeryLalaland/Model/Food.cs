using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace BakeryLalaland.Model
{
    class Food
    {

        private string _name;
        private int _number;
        private string _ingredients;
        private BitmapImage _image;
        private int _price;
        private string _category;

        public string Name { get => _name; set => _name = value; }
        public int Number { get => _number; set => _number = value; }
        public string Ingredients { get => _ingredients; set => _ingredients = value; }
        public BitmapImage Image { get => _image; set => _image = value; }
        public int Price { get => _price; set => _price = value; }
        public string Category
        {
            get => _category; set => _category = value;
        }

        public Food()
        {
            
        }

        public Food(string name, int number, string ingredients, BitmapImage image,int price, string category)
        {
            _name = name;
            _number = number;
            _ingredients = ingredients;
            _image = image;
            _price = price;
            _category = category;
        }
    }
}
