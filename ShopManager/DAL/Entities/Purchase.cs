using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.DAL.Entities
{
    class Purchase
    {
        #region Properties
        public sbyte? Id { get; set; }
        public string Client_name { get; set; }
        public string Client_surname { get; set; }
        public string PurchaseDate { get; set; }
        public string ProductName { get; set; }
        public string? EmployeeSurname { get; set; }
        public string Price { get; set; }
        #endregion

        #region Constructors
        public Purchase(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["id"].ToString());
            Client_name = reader["client_name"].ToString();
            Client_surname = reader["client_surname"].ToString();
            PurchaseDate = reader["purchase_date"].ToString();
            ProductName = reader["product_name"].ToString();
            EmployeeSurname = reader["employee_surname"].ToString();
            Price = reader["price"].ToString();
        }
        public Purchase(string clientName, string clientSurname, string employeeSurname, string product_name, string purchase_date, string price)
        {
            Id = null; // Add a proper default value
            PurchaseDate = purchase_date.Trim();
            Client_name = clientName;
            Client_surname = clientSurname;
            ProductName = product_name;
            EmployeeSurname = employeeSurname;
            Price = price;
        }
        public Purchase(Purchase purchase)
        {
            Id = purchase.Id;
            Client_name = purchase.Client_name;
            Client_surname = purchase.Client_surname;
            EmployeeSurname = purchase.EmployeeSurname;
            ProductName = purchase.ProductName;
            PurchaseDate = purchase.PurchaseDate;
        }
        public Purchase() { }
        #endregion

        #region Methods
        public override string ToString()
        {
            // TODO: Query the details of Purchase
            return $"{ProductName}: {EmployeeSurname}, {Client_name} {Client_surname}";
        }

        // Generate string for INSERT TO (EAN, name, net_price, production_country, production_date) !Do aktualizacji!
        public string ToInsert()
        {
            return $"('{Id}', '{PurchaseDate}', '{ProductName}', '{Price}, '{Client_name}', '{Client_surname}',  '{EmployeeSurname}')";
        }
        // Check if the object exists
        public override bool Equals(object obj)
        {
            var purchase = obj as Purchase;
            if (purchase is null) return false; // Update the if statements if necessary
            if (PurchaseDate.ToLower() != purchase.PurchaseDate.ToLower()) return false;
            if (ProductName != purchase.ProductName) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
