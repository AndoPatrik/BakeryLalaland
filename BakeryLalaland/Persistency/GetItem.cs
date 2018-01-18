using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using BakeryLalaland.Model;

namespace BakeryLalaland.Persistency
{
    class GetItem
    {
        //-------------------------------------Serialization----------------------------------
        //----------------------------------------Bakery and beverages-------------------------------------
        //Auto propery
        public ObservableCollection<MenuCart> DrinksCatalog { get; set; }

        //saving into the file
        public async Task SavetoJson(ObservableCollection<MenuCart> items)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var jsonFile = await localFolder.CreateFileAsync("MenuCartFile2.txt", CreationCollisionOption.ReplaceExisting);
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<MenuCart>));
            using (var stream = await jsonFile.OpenStreamForWriteAsync())
            {
                jsonSerializer.WriteObject(stream, items);
            }
        }

        //retriving from the file
        public async Task<ObservableCollection<MenuCart>> LoadMenuFromJson()
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var jsonFile = await localFolder.GetFileAsync("MenuCartFile2.txt");
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<MenuCart>));
            using (var stream = await jsonFile.OpenStreamForReadAsync())
            {
                DrinksCatalog = jsonSerializer.ReadObject(stream) as ObservableCollection<MenuCart>;
            }
            return DrinksCatalog;
        }

        //-------------------------Customers----------------
        public ObservableCollection<Customer> CustomersCatalog { get; set; }

        //saving into the file
        public async Task SavetoJson(ObservableCollection<Customer> customers)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var jsonFile = await localFolder.CreateFileAsync("Customers.txt", CreationCollisionOption.ReplaceExisting);
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Customer>));
            using (var stream = await jsonFile.OpenStreamForWriteAsync())
            {
                jsonSerializer.WriteObject(stream, customers);
            }
        }

        //retriving from the file
        public async Task<ObservableCollection<Customer>> LoadFromJson()
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var jsonFile = await localFolder.GetFileAsync("Customers.txt");
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Customer>));
            using (var stream = await jsonFile.OpenStreamForReadAsync())
            {
                CustomersCatalog = jsonSerializer.ReadObject(stream) as ObservableCollection<Customer>;
            }
            return CustomersCatalog;
        }

    }
}
