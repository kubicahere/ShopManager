using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.DAL.Entities
{
    public class Employee
    {
        #region Properties
        public sbyte? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public sbyte? PositionID { get; set; }
        #endregion

        #region Constructors
        public Employee() { }
        public Employee(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["id"].ToString());
            PositionID = sbyte.Parse(reader["position_id"].ToString());
            Name = reader["name"].ToString();
            Surname = reader["surname"].ToString();
            Salary = decimal.Parse(reader["salary"].ToString());
        }
        public Employee(string name, decimal salary, string surname, sbyte position_id)
        {
            Id = null; // Add a proper default value
            Name = name.Trim();
            Surname = surname.Trim();
            Salary = salary;
            PositionID = position_id;
        }
        public Employee(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Surname = employee.Surname;
            Salary = employee.Salary;
            PositionID = employee.PositionID;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Name}, {Surname}, {Salary}";
        }

        // Generate string for INSERT TO (code, place, gross_price, quantity) !Do aktualizacji!
        public string ToInsert()
        {
            return $"('{Name}', '{Surname}', '{Salary}', '{PositionID}')";
        }
        // Check if the object exists
        public override bool Equals(object obj)
        {
            var employee = obj as Employee;
            if (employee is null) return false;
            if (Name.ToLower() != employee.Name.ToLower()) return false;
            if (Surname.ToLower() != employee.Surname.ToLower()) return false;
            if (Salary != employee.Salary) return false;
            if (PositionID != employee.PositionID) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
