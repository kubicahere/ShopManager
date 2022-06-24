using ShopManager.DAL.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.DAL.Repositories
{
    using Entities;
    static class RepoEmployees
    {
        #region Queries
        private const string ALL_EMPLOYEES = "SELECT * FROM employee";
        private const string ADD_EMPLOYEE = "INSERT INTO `employee`(`name`, `surname`, `salary`, `position_id`) VALUES ";

        #endregion
       /* public static string GetEmployeePosition(Employee e)
        {
            e = new Employee();
            //string select = $"SELECT {e.PositionID} FROM POSITION WHERE employee.id ={e.Id}";
        }*/
        #region CRUD Methods
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_EMPLOYEES, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    employees.Add(new Employee(reader));
                connection.Close();
            }
            return employees;
        }
        public static bool AddEmployee(Employee employee)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_EMPLOYEE} {employee.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                employee.Id = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }
        public static bool EditEmployee(Employee employee, sbyte EmployeeID)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDIT_CLIENT = $"UPDATE employee SET name='{employee.Name}', surname='{employee.Surname}', " +
                    $"salary={employee.Salary}, position_id='{employee.PositionID}' WHERE id={EmployeeID}";

                MySqlCommand command = new MySqlCommand(EDIT_CLIENT, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;

                connection.Close();
            }
            return state;
        }
        public static bool DeleteEmployee(Employee employee)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string DELETE_CLIENT = $"DELETE FROM employee WHERE id={employee.Id}";

                MySqlCommand command = new MySqlCommand(DELETE_CLIENT, connection);
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
