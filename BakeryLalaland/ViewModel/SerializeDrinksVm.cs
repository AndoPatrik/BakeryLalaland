using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using BakeryLalaland.Interfaces;
using BakeryLalaland.Model;
using BakeryLalaland.Persistency;

namespace BakeryLalaland.ViewModel
{
    class SerializeDrinksVm : NotifyPropertyClass
    {
        //instance fields
        private MenuCart _selectedItem;
        private readonly GetItem _getDrinks;                                   //serialization
        private FoodSingleton _foodSingleton;
        private ObservableCollection<MenuCart> _adToCartList;
        private CartCollectionSingleton _cartCollectionSingleton;

        //properties
        public RelayCommand AddItemCommand { get; set; }
        public RelayCommand DeleteItemCommand { get; set; }
        public RelayCommand UpdateItemCommand { get; set; }
        public MenuCart AddNewDrink { get; set; }
        public MenuCart Up { get; set; }
        public ObservableCollection<MenuCart> AdToCartList { get => _adToCartList; set => _adToCartList = value; }
        public IList<MenuCart.Category> MenuItemsCategories
        {
            get
            {
                return Enum.GetValues(typeof(MenuCart.Category)).Cast<MenuCart.Category>().ToList<MenuCart.Category>();
            }
        }

        public ObservableCollection<MenuCart> DrinkCatalog
        {
            get { return Up.Drinks; }
            set
            {
                Up.Drinks = value;
                OnPropertyChanged(nameof(DrinkCatalog));
            }
        }
        //Unused
        public MenuCart SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public SerializeDrinksVm()
        {
            //initializing objects
            _cartCollectionSingleton = CartCollectionSingleton.GetInstance();
            AddNewDrink = new MenuCart();
            Up = new MenuCart();
            AddItemCommand = new RelayCommand(DoAddDrink);
            DeleteItemCommand = new RelayCommand(DoDeleteDrink);
            UpdateItemCommand = new RelayCommand(DoUpdateDrink);
            SelectedItem = new MenuCart();
            _getDrinks = new GetItem();
            LoadDrinks();
            _foodSingleton = FoodSingleton.GetInstance();

            if (_cartCollectionSingleton.GetCartCollection() == null)
            {
                AdToCartList = new ObservableCollection<MenuCart>();
            }
            else
            {
                AdToCartList = _cartCollectionSingleton.GetCartCollection();
            }

            
            //_foodSingleton.SetCurrentOrder(SelectedItem);

            //Task.Run(() => LoadDrinks());                                //serialization
        }

        //Loading method
        public async void LoadDrinks()                                        //serialization
        {
            try
            {
                DrinkCatalog = await _getDrinks.LoadMenuFromJson();
            }
            catch (Exception e)
            {
                foreach (MenuCart upDrink in DrinkCatalog)
                {
                    var drink = upDrink;
                }
                string error = e.Message;
            }
        }


        public async void DoAddDrink()
        {

            DrinkCatalog.Add(AddNewDrink);
            await _getDrinks.SavetoJson(DrinkCatalog);                       //serialization
        }

        public async void DoUpdateDrink()
        {
            await _getDrinks.SavetoJson(DrinkCatalog);
        }

        public async void DoDeleteDrink()
        {
            DrinkCatalog.Remove(SelectedItem);
            await _getDrinks.SavetoJson(DrinkCatalog);                       //serialization
        }

    }
}

