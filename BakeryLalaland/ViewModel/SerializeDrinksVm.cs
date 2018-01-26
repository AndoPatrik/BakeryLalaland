using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Authentication;
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
        private int _numberOfOrders;

        private ObservableCollection<MenuCart> _muffins;
        private ObservableCollection<MenuCart> _cupcakes;
        private ObservableCollection<MenuCart> _cakes;
        private ObservableCollection<MenuCart> _healthy;
        private ObservableCollection<MenuCart> _pizzas;
        private ObservableCollection<MenuCart> _sandwiches;
        private ObservableCollection<MenuCart> _beverages;
        private bool _loaded = false;

        private ObservableCollection<MenuCart> _displayedItems;

        //properties
        public RelayCommand AddItemCommand { get; set; }
        public RelayCommand DeleteItemCommand { get; set; }
        public RelayCommand UpdateItemCommand { get; set; }
        public MenuCart AddNewDrink { get; set; }
        public MenuCart Up { get; set; }
        public ObservableCollection<MenuCart> AdToCartList { get => _adToCartList; set => _adToCartList = value; }

        public int NumberOfOrders
        {
            get => _numberOfOrders;
            set
            {
                _numberOfOrders = value;
                OnPropertyChanged(nameof(NumberOfOrders));
                
            }
        }

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
        
        public MenuCart SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ObservableCollection<MenuCart> Muffins { get => _muffins; set => _muffins = value; }
        public ObservableCollection<MenuCart> Cupcakes { get => _cupcakes; set => _cupcakes = value; }
        public ObservableCollection<MenuCart> Cakes { get => _cakes; set => _cakes = value; }
        public ObservableCollection<MenuCart> Healthy { get => _healthy; set => _healthy = value; }
        public ObservableCollection<MenuCart> Pizzas { get => _pizzas; set => _pizzas = value; }
        public ObservableCollection<MenuCart> Sandwiches { get => _sandwiches; set => _sandwiches = value; }
        public ObservableCollection<MenuCart> Beverages { get => _beverages; set => _beverages = value; }
        public ObservableCollection<MenuCart> DisplayedItems { get => _displayedItems; set => _displayedItems = value; }


        //Constructor
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
            _foodSingleton = FoodSingleton.GetInstance();

            Muffins = new ObservableCollection<MenuCart>();
            Cupcakes = new ObservableCollection<MenuCart>();
            Cakes = new ObservableCollection<MenuCart>();
            Pizzas = new ObservableCollection<MenuCart>();
            Sandwiches = new ObservableCollection<MenuCart>();
            Healthy = new ObservableCollection<MenuCart>();
            Beverages = new ObservableCollection<MenuCart>();
            DisplayedItems = new ObservableCollection<MenuCart>();
    


            if (_cartCollectionSingleton.GetCartCollection() == null)
            {
                AdToCartList = new ObservableCollection<MenuCart>();
            }
            else
            {
                AdToCartList = _cartCollectionSingleton.GetCartCollection();
            }
            
            //_foodSingleton.SetCurrentOrder(SelectedItem);

            if (_cartCollectionSingleton.GetCartCollection() != null)
            {
                NumberOfOrders = _cartCollectionSingleton.GetCartCollection().Count;

            }

           LoadDrinks();
           
        }

        //Loading method
        public async void LoadDrinks()                                        //serialization
        {
            try
            {
                DisplayedItems = await _getDrinks.LoadMenuFromJson();
                
                
                //DisplayedItems = DrinkCatalog;

                foreach (var item in DisplayedItems)
                {
                    if (item.Categoryy == MenuCart.Category.Muffins)
                    {
                        Muffins.Add(item);
                    }
                    if (item.Categoryy == MenuCart.Category.Cupcakes)
                    {
                        Cupcakes.Add(item);
                    }
                    if (item.Categoryy == MenuCart.Category.Cakes)
                    {
                        Cakes.Add(item);
                    }
                    if (item.Categoryy == MenuCart.Category.Healthy)
                    {
                        Healthy.Add(item);
                    }
                    if (item.Categoryy == MenuCart.Category.Pizzas)
                    {
                        Pizzas.Add(item);
                    }
                    if (item.Categoryy == MenuCart.Category.Sandwiches)
                    {
                        Sandwiches.Add(item);
                    }
                    if (item.Categoryy == MenuCart.Category.Beverages)
                    {
                        Beverages.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                //foreach (MenuCart upDrink in DrinkCatalog)
                //{
                //    var drink = upDrink;
                //}
                string error = e.Message;
            }
        }

        public int GetNumberOfOrders()
        {
            _numberOfOrders = _cartCollectionSingleton.GetCartCollection().Count;
            return _numberOfOrders;
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

