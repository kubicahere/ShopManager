using ShopManager.DAL.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.DAL.Repositories
{
    using Entities;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Threading;
    using System.Windows;

    static class RepoWarehouse
    {
        #region Queries
        private const string ADD_PRODUCT = "INSERT INTO `warehouse`(`name`, `place`, `price`) VALUES ";
        
        #endregion

        #region CRUD Methods
        public static bool AddProduct(Warehouse product)
        {
            bool state = false;
            string _price = product.GrossPrice.ToString().Replace(",", ".");
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            product.GrossPrice = decimal.Parse(_price);
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_PRODUCT} {product.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                connection.Close();
            }
            return state;
        }
        #endregion
    }
}
