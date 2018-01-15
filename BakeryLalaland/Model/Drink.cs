using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace BakeryLalaland.Model
{
    class Drink
    {
        private string _name;
        private int _number;
        private BitmapImage _image;
        private int _price;

        public string Name { get => _name; set => _name = value; }
        public int Number { get => _number; set => _number = value; }
        public BitmapImage Image { get => _image; set => _image = value; }
        public int Price { get => _price; set => _price = value; }

        public Drink()
        {

        }

        public Drink(string name, int number, BitmapImage image, int price)
        {
            _name = name;
            _number = number;
            _image = image;
            _price = price;
        }
    }



    
}
