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
        public string Name { get; set; }
        public string Place { get; set; }
        public decimal GrossPrice { get; set; }
        #endregion

        #region Constructors
        public Warehouse(MySqlDataReader reader)
        {
            Place = reader["place"].ToString();
            Name = reader["name"].ToString();
            GrossPrice = decimal.Parse(reader["price"].ToString());
        }
        public Warehouse(string name, string place, decimal gross_price)
        {
            Place = place.Trim();
            Name = name;
            GrossPrice = gross_price;
            
        }
        public Warehouse(Warehouse warehouse)
        {
            Place = warehouse.Place;
            GrossPrice = warehouse.GrossPrice;
            Name = warehouse.Name;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Place}: {Name}, {GrossPrice}";
        }

        // Generate string for INSERT TO (code, place, gross_price, quantity) !Do aktualizacji!
        public string ToInsert()
        {
            return $"('{Name}', '{Place}', '{GrossPrice}')";
        }
        // Check if the object exists
        public override bool Equals(object obj)
        {
            var warehouse = obj as Warehouse;
            if (warehouse is null) return false;
            if (Place.ToLower() != warehouse.Place.ToLower()) return false;
            if (GrossPrice != warehouse.GrossPrice) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
