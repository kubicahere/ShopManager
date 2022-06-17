using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.DAL.Entities
{
    class Client
    {
        #region Properties
        public sbyte? Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        #endregion

        #region Constructors
        public Client() { }
        public Client(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["id"].ToString());
            Login = reader["login"].ToString();
            Password = reader["passwd"].ToString();
            Name = reader["name"].ToString();
            Surname = reader["surname"].ToString();
            Email = reader["email"].ToString();
            Phone = reader["phone"].ToString();
        }
        public Client(string login, string password, string name, string surname, string email, string phone)
        {
            Id = null;
            Login = login.Trim();
            Password = password.Trim();
            Name = name.Trim();
            Surname = surname.Trim();
            Email = email.Trim();
            Phone = phone;
        }
        public Client(Client client)
        {
            Id = client.Id;
            Login = client.Login;
            Password = client.Password;
            Name = client.Name;
            Surname = client.Surname;
            Email = client.Email;
            Phone = client.Phone;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Login}: {Password}, {Name} {Surname}: {Email}, {Phone}";
        }

        // Generate string for INSERT TO (name, surname, email, phone) !Do aktualizacji!
        public string ToInsert()
        {
            return $"('{Login}: {Password}, {Name}', '{Surname}', {Email},'{Phone}')";
        }
        // Check if the object exists
        public override bool Equals(object obj)
        {
            var client = obj as Client;
            if (client is null) return false;
            if (Login.ToLower() != client.Login.ToLower()) return false;
            if (Password.ToLower() != client.Password.ToLower()) return false;
            if (Name.ToLower() != client.Name.ToLower()) return false;
            if (Surname.ToLower() != client.Surname.ToLower()) return false;
            if (Email.ToLower() != client.Email.ToLower()) return false;
            if (Phone != client.Phone) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
