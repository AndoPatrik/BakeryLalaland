using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryLalaland.Model;

namespace BakeryLalaland.Interfaces
{
    class FoodSingleton
    {
        public static MenuCart _order;

        private static FoodSingleton Instance { get; set; }

        public FoodSingleton()
        {
            _order = new MenuCart();
        }

        public static FoodSingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new FoodSingleton();
            }

            return Instance;
        }

        public void SetCurrentOrder(MenuCart order)
        {
            _order = order;
        }

        public MenuCart GetCurrentOrder()
        {
            return _order;
        }

        public string GetName()
        {
            return _order.Name;
        }

        public int GetNumber()
        {
            return _order.Number;
        }

        public string GetImage()
        {
            return _order.Image;
        }

        public int GetPrice()
        {
            return _order.Price;
        }

        public string GetIngredients()
        {
            return _order.Ingred;
        }

        public MenuCart.Category GetCategory()
        {
            return _order.Categoryy;
        }
    }
}
