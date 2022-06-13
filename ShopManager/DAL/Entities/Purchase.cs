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
        public sbyte? ClientID { get; set; }
        public sbyte? EmployeeID { get; set; }
        public string PurchaseDate { get; set; }
        public decimal ProductCode { get; set; }
        #endregion

        #region Constructors
        public Purchase(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["id"].ToString());
            ClientID = sbyte.Parse(reader["client_id"].ToString());
            EmployeeID = sbyte.Parse(reader["employee_id"].ToString());
            PurchaseDate = reader["purchase_date"].ToString();
            ProductCode = decimal.Parse(reader["product_code"].ToString());
        }
        public Purchase(sbyte client_id, sbyte employee_id, decimal product_code, string purchase_date)
        {
            Id = null; // Add a proper default value
            PurchaseDate = purchase_date.Trim();
            ClientID = client_id;
            EmployeeID = employee_id;
            ProductCode = product_code;
        }
        public Purchase(Purchase purchase)
        {
            Id = purchase.Id;
            ClientID = purchase.ClientID;
            EmployeeID = purchase.EmployeeID;
            ProductCode = purchase.ProductCode;
            PurchaseDate = purchase.PurchaseDate;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            // TODO: Query the details of Purchase
            return $"{ProductCode}: {EmployeeID}, {ClientID}";
        }

        // Generate string for INSERT TO (EAN, name, net_price, production_country, production_date) !Do aktualizacji!
        public string ToInsert()
        {
            return $"('{Id}', '{PurchaseDate}', '{ProductCode}', '{ClientID}', {EmployeeID})";
        }
        // Check if the object exists
        public override bool Equals(object obj)
        {
            var purchase = obj as Purchase;
            if (purchase is null) return false; // Update the if statements if necessary
            if (PurchaseDate.ToLower() != purchase.PurchaseDate.ToLower()) return false;
            if (ProductCode != purchase.ProductCode) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
