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
        public string PositionName { get; set; }
        #endregion

        #region Constructors
        public Employee() { }
        public Employee(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["id"].ToString());
            PositionName = reader["position_name"].ToString();
            Name = reader["name"].ToString();
            Surname = reader["surname"].ToString();
            Salary = decimal.Parse(reader["salary"].ToString());
        }
        public Employee(string name, decimal salary, string surname, string position_name)
        {
            Id = null; // Add a proper default value
            Name = name.Trim();
            Surname = surname.Trim();
            Salary = salary;
            PositionName = position_name;
        }
        public Employee(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Surname = employee.Surname;
            Salary = employee.Salary;
            PositionName = employee.PositionName;
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
            return $"('{Name}', '{Surname}', '{Salary}', '{PositionName}')";
        }
        // Check if the object exists
        public override bool Equals(object obj)
        {
            var employee = obj as Employee;
            if (employee is null) return false;
            if (Name.ToLower() != employee.Name.ToLower()) return false;
            if (Surname.ToLower() != employee.Surname.ToLower()) return false;
            if (Salary != employee.Salary) return false;
            if (PositionName != employee.PositionName) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
