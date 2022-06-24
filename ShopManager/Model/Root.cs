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
    class Root
    {
        #region Getters & setters
        public ObservableCollection<Product> listOfProducts { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Employee> listOfEmployees { get; set; } = new ObservableCollection<Employee>();
        public ObservableCollection<Purchase> listOfPurchases { get; set; } = new ObservableCollection<Purchase>();
        #endregion
        public Root()
        {
            var products = RepoProducts.GetAllProducts();
            foreach (var product in products)
            {
                listOfProducts.Add(product);
            }
            var employees = RepoEmployees.GetAllEmployees();
            foreach (var employee in employees)
            {
                listOfEmployees.Add(employee);
            }
            var purchases = RepoPurchases.GetAllPurchases();
            foreach (var purchase in purchases)
            {
                listOfPurchases.Add(purchase);
            }
        }
    }
}
