using BakeryLalaland.Interfaces;
using BakeryLalaland.Model;
using BakeryLalaland.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BakeryLalaland.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MenuList : Page
    {
        private FoodSingleton _foodSingleton;
        private SerializeDrinksVm _serializeDrinksVm;
        private CartCollectionSingleton _cartCollectionSingleton;

        public MenuList()
        {
            this.InitializeComponent();
            _foodSingleton = FoodSingleton.GetInstance();
            _serializeDrinksVm = new SerializeDrinksVm();
            _cartCollectionSingleton = CartCollectionSingleton.GetInstance();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //MenuFrame.Navigate(typeof(ProfileView));
            //BackButton.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenuPage));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //MenuFrame.Navigate(typeof(CurrentOrder));
            //BackButton.Visibility = Visibility.Visible;
            _cartCollectionSingleton.SetCartCollection(_serializeDrinksVm.AdToCartList);
        }

        private void List_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var item = (MenuCart)e.ClickedItem;
            _foodSingleton.SetCurrentOrder(item);

            try
            {
                _serializeDrinksVm.AdToCartList.Add(item);
            }
            catch (Exception exception)
            {
                string ex = exception.ToString();
                MessageDialog msd = new MessageDialog(ex, "error");
                msd.ShowAsync();
            }

        }
    }
}
