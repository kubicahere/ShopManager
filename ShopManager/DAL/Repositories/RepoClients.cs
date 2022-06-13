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
    static class RepoClients
    {
        #region Queries
        private const string ALL_CLIENTS = "SELECT * FROM client";
        private const string ADD_CLIENT = "INSERT INTO `client`(`name`, `surname`, `email`, `phone`) VALUES ";
        #endregion

        #region CRUD Methods
        public static List<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_CLIENTS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    clients.Add(new Client(reader));
                connection.Close();
            }
            return clients;
        }
        public static bool AddClient(Client client)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_CLIENT} {client.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                client.Id = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }
        public static bool EditClient(Client client, sbyte ClientID)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDIT_CLIENT = $"UPDATE client SET name='{client.Name}', nazwisko='{client.Surname}', " +
                    $"email={client.Email}, phone='{client.Phone}' WHERE id={ClientID}";

                MySqlCommand command = new MySqlCommand(EDIT_CLIENT, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;

                connection.Close();
            }
            return state;
        }
        public static bool DeleteClient(Client client)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string DELETE_CLIENT = $"DELETE FROM client WHERE id={client.Id}";

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
