using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.DAL.Entities
{
    class Product
    {
        #region Properties
        public decimal EAN { get; set; }
        public string Name { get; set; }
        public decimal NetPrice { get; set; }
        public string ProductionCountry { get; set; }
        public string ProductionDate { get; set; }
        #endregion

        #region Constructors
        public Product(MySqlDataReader reader)
        {
            EAN = decimal.Parse(reader["EAN"].ToString());
            Name = reader["name"].ToString();
            NetPrice = decimal.Parse(reader["net_price"].ToString());
            ProductionCountry = reader["production_country"].ToString();
            ProductionDate = reader["production_date"].ToString();
        }
        public Product(string name, decimal net_price, string production_country, string production_date)
        {
            //EAN = null; // Add a proper default value (it's a barcode)
            Name = name.Trim();
            ProductionCountry = production_country.Trim();
            ProductionDate = production_date.Trim();
            NetPrice = net_price;
        }
        public Product(Product product)
        {
            EAN = product.EAN;
            Name = product.Name;
            ProductionCountry = product.ProductionCountry;
            ProductionDate = product.ProductionDate;
            NetPrice = product.NetPrice;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Name}: {NetPrice}, {ProductionDate}, {ProductionCountry}";
        }

        // Generate string for INSERT TO (EAN, name, net_price, production_country, production_date) !Do aktualizacji!
        public string ToInsert()
        {
            return $"('{EAN}', '{Name}', '{NetPrice}', '{ProductionCountry}', {ProductionDate})";
        }
        // Check if the object exists
        public override bool Equals(object obj)
        {
            var product = obj as Product;
            if (product is null) return false;
            if (Name.ToLower() != product.Name.ToLower()) return false;
            if (ProductionCountry.ToLower() != product.ProductionCountry.ToLower()) return false;
            if (ProductionDate.ToLower() != product.ProductionDate.ToLower()) return false;
            if (NetPrice != product.NetPrice) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
