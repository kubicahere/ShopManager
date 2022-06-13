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
    static class RepoProducts
    {
        #region Queries
        private const string ALL_PRODUCTS = "SELECT * FROM product";
        private const string ADD_PRODUCT = "INSERT INTO `product`(`EAN`, `name`, `net_price`, `production_country`, 'production_date') VALUES ";
        #endregion

        #region CRUD Methods
        public static List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_PRODUCTS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    products.Add(new Product(reader));
                connection.Close();
            }
            return products;
        }
        public static bool AddProduct(Product product)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_PRODUCT} {product.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                product.EAN = (decimal)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }
        public static bool EditProduct(Product product, decimal EAN)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDIT_CLIENT = $"UPDATE product SET name='{product.Name}', net_price='{product.NetPrice}', " +
                    $"production_country={product.ProductionCountry}, production_date='{product.ProductionDate}' WHERE EAN={EAN}";

                MySqlCommand command = new MySqlCommand(EDIT_CLIENT, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;

                connection.Close();
            }
            return state;
        }
        public static bool DeleteProduct(Product product)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string DELETE_CLIENT = $"DELETE FROM product WHERE EAN={product.EAN}";

                MySqlCommand command = new MySqlCommand(DELETE_CLIENT, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;

                connection.Close();
            }
            return state;
        }
        #endregion
    }
}
