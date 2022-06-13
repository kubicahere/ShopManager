using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.DAL.Entities
{
    class Warehouse
    {
        #region Properties
        public decimal Code { get; set; }
        public string Place { get; set; }
        public decimal GrossPrice { get; set; }
        public int Quantity { get; set; }
        #endregion

        #region Constructors
        public Warehouse(MySqlDataReader reader)
        {
            Code = decimal.Parse(reader["code"].ToString());
            Place = reader["place"].ToString();
            GrossPrice = decimal.Parse(reader["gross_price"].ToString());
            Quantity = Int32.Parse(reader["quantity"].ToString());
        }
        public Warehouse(string place, decimal gross_price, int quantity)
        {
            //Code = null; // Add a proper default value
            Place = place.Trim();
            GrossPrice = gross_price;
            Quantity = quantity;
        }
        public Warehouse(Warehouse warehouse)
        {
            Code = warehouse.Code;
            Place = warehouse.Place;
            GrossPrice = warehouse.GrossPrice;
            Quantity = warehouse.Quantity;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Place}: {Code}, {GrossPrice}, {Quantity}";
        }

        // Generate string for INSERT TO (code, place, gross_price, quantity) !Do aktualizacji!
        public string ToInsert()
        {
            return $"('{Code}', '{Place}', '{GrossPrice}', '{Quantity}')";
        }
        // Check if the object exists
        public override bool Equals(object obj)
        {
            var warehouse = obj as Warehouse;
            if (warehouse is null) return false;
            if (Place.ToLower() != warehouse.Place.ToLower()) return false;
            if (GrossPrice != warehouse.GrossPrice) return false;
            if (Quantity != warehouse.Quantity) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
