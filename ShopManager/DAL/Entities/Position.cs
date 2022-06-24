using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.DAL.Entities
{
    class Position
    {
        #region Properties
        public int? Id { get; set; }
        public string Name { get; set; }
        #endregion

        #region Constructors
        public Position() { }
        public Position(MySqlDataReader reader)
        {
            Id = int.Parse(reader["id"].ToString());
            Name = reader["name"].ToString();
        }
        public Position(string name)
        {
            Id = null;
            Name = name.Trim();
        }
        public Position(Position position)
        {
            Id = position.Id;
            Name = position.Name;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $" {Id}: {Name}";
        }

        // Generate string for INSERT TO (name, surname, email, phone) !Do aktualizacji!
        public string ToInsert()
        {
            return $"('{Name}')";
        }
        // Check if the object exists
        public override bool Equals(object obj)
        {
            var position = obj as Position;
            if (position is null) return false;
            if (Name.ToLower() != position.Name.ToLower()) return false;

            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
