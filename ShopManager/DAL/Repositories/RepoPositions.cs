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
    using System.Windows;

    static class RepoPositions
    {
        #region Queries
        private const string ALL_POSITIONS = "SELECT * FROM position";
        private const string ADD_POSITION = "INSERT INTO `position`(`name`) VALUES ";

        #endregion

        #region CRUD Methods
        public static List<Position> GetAllPositions()
        {
            List<Position> positions = new List<Position>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_POSITIONS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    positions.Add(new Position(reader));
                connection.Close();
            }
            return positions;
        }
        public static bool AddPosition(Position position)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_POSITION} {position.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                position.Id = (sbyte)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }
        public static bool EditPosition(Position position, sbyte PositionID)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDIT_CLIENT = $"UPDATE position SET name='{position.Name}' WHERE id={PositionID}";

                MySqlCommand command = new MySqlCommand(EDIT_CLIENT, connection);
                connection.Open();
                var n = command.ExecuteNonQuery();
                if (n == 1) state = true;

                connection.Close();
            }
            return state;
        }
        public static bool DeletePosition(Position position)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string DELETE_CLIENT = $"DELETE FROM position WHERE id={position.Id}";

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
