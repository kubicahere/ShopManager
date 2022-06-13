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
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public decimal Phone { get; set; }
        #endregion

        #region Constructors
        public Client(MySqlDataReader reader)
        {
            Id = sbyte.Parse(reader["id"].ToString());
            Name = reader["name"].ToString();
            Surname = reader["surname"].ToString();
            Email = reader["email"].ToString();
            Phone = decimal.Parse(reader["phone"].ToString());
        }
        public Client(string name, string surname, string email, decimal phone)
        {
            Id = null;
            Name = name.Trim();
            Surname = surname.Trim();
            Email = email.Trim();
            Phone = phone;
        }
        public Client(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            Surname = client.Surname;
            Email = client.Email;
            Phone = client.Phone;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{Name} {Surname}: {Email}, {Phone}";
        }

        // Generate string for INSERT TO (name, surname, email, phone) !Do aktualizacji!
        public string ToInsert()
        {
            return $"('{Name}', '{Surname}', {Email},'{Phone}')";
        }
        // Check if the object exists
        public override bool Equals(object obj)
        {
            var client = obj as Client;
            if (client is null) return false;
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
