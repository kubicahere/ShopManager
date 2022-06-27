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

    static class RepoPurchases
    {
        #region Queries
        private const string ALL_PURCHASE = "SELECT * FROM purchase";
        private const string ADD_PURCHASE = "INSERT INTO `purchase`(`id`, `purchase_date`, `product_name`, `price`, `client_name`,`client_surname`, `employee_surname`) VALUES ";
        public static ObservableCollection<Purchase> GetClientPurchasesById(Client client)
        {
            ObservableCollection<Purchase> purchases = new ObservableCollection<Purchase>();
            string CLIENT_PURCHASE = $"SELECT * FROM purchase WHERE client_name='{client.Name}' and client_surname='{client.Surname}'";
            
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(CLIENT_PURCHASE, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    purchases.Add(new Purchase(reader));
                connection.Close();
            }
            return purchases;
        }
        public static sbyte? GetLastPurchaseID()
        {
            string LAST_PURCHASE = $"select * from purchase order by 1 desc limit 1";
            Purchase purchase = new Purchase();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(LAST_PURCHASE, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    purchase = new Purchase(reader);
                connection.Close();
            }
            return purchase.Id;
        }
        
        #endregion

        #region CRUD Methods
        public static List<Purchase> GetAllPurchases()
        {
            List<Purchase> purchases = new List<Purchase>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_PURCHASE, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    purchases.Add(new Purchase(reader));
                connection.Close();
            }
            return purchases;
        }
        public static bool AddPurchase(Purchase purchase)
        {
            bool state = false;
            string _price = purchase.Price.ToString().Replace(",", ".");
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            purchase.Price = decimal.Parse(_price);
            MessageBox.Show(purchase.Price.ToString());
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_PURCHASE} {purchase.ToInsert()}", connection);
                MessageBox.Show($"{ADD_PURCHASE} {purchase.ToInsert()}");
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                purchase.Id = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }
       /* public static bool EditPurchase(Purchase purchase, sbyte PurchaseID)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDIT_PURCHASE = $"UPDATE purchase SET purchase_date='{purchase.PurchaseDate}', product_code='{purchase.ProductCode}', " +
                    $"client_id={purchase.ClientID}, employee_id='{purchase.EmployeeID}' WHERE id={PurchaseID}";

                MySqlCommand command = new MySqlCommand(EDIT_PURCHASE, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;

                connection.Close();
            }
            return state;
        }*/
        public static bool DeletePurchase(Purchase purchase)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string DELETE_PURCHASE = $"DELETE FROM purchase WHERE id={purchase.Id}";

                MySqlCommand command = new MySqlCommand(DELETE_PURCHASE, connection);
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
