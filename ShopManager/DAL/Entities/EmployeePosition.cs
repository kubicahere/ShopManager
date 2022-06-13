using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.DAL.Entities
{
    class EmployeePosition
    {
        #region Properties
        public sbyte? Id { get; set; }
        public string Name { get; set; }
        #endregion

        #region Constructors
        public EmployeePosition(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["id"].ToString());
            Name = reader["name"].ToString();
        }
        public EmployeePosition(string name)
        {
            Id = null; // Add a proper default value
            Name = name.Trim();
        }
        public EmployeePosition(EmployeePosition employee_position)
        {
            Id = employee_position.Id;
            Name = employee_position.Name;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Name} {Surname}: {Salary}";
        }

        // Generate string for INSERT TO (code, place, gross_price, quantity) !Do aktualizacji!
        public string ToInsert()
        {
            return $"('{Id}': '{Name}')";
        }
        // Check if the object exists
        public override bool Equals(object obj)
        {
            var employee_position = obj as EmployeePosition;
            if (employee_position is null) return false;
            if (Name.ToLower() != employee_position.Name.ToLower()) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
