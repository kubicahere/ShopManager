﻿using ShopManager.DAL.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.DAL.Repositories
{
    using Entities;
    static class RepoPurchases
    {
        #region Queries
        private const string ALL_PURCHASE = "SELECT * FROM purchase";
        private const string ADD_PURCHASE = "INSERT INTO `purchase`(`purchase_date`, `product_code`, `client_id`, 'employee_id') VALUES ";
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
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_PURCHASE} {purchase.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                purchase.Id = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }
        public static bool EditPurchase(Purchase purchase, sbyte PurchaseID)
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
        }
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