using ShopManager.DAL.Entities;
using ShopManager.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.Model
{
    class User
    {
        #region Getters & setters
        public ObservableCollection<Product> listOfProducts { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Purchase> listOfPurchases { get; set; } = new ObservableCollection<Purchase>();
        #endregion
        public User()
        {
            var products = RepoProducts.GetAllProducts();
            //var purchases = RepoPurchases.GetClientPurchasesById(Cclient);
            foreach(var product in products)
            {
                listOfProducts.Add(product);
            }
            //var purchases = RepoPurchases.GetClientPurchasesById(client);
            //foreach(var purchase in purchases)
            //{
            //    listOfPurchases.Add(purchase);
            //}
        }

    }
}
