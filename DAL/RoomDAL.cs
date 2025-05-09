using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class RoomDAL : DatabaseAccess
    {
        public DataTable GetAllRooms()
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                string query = "SELECT * FROM Room";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                da.Fill(dt);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public bool AddRoom(RoomDTO room)
        {
            try
            {
                OpenConnection();
                string query = "INSERT INTO Room (RoomType, Price) VALUES (@RoomType, @Price)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
                cmd.Parameters.AddWithValue("@Price", room.Price);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool UpdateRoom(RoomDTO room)
        {
            try
            {
                OpenConnection();
                string query = "UPDATE Room SET RoomType=@RoomType, Price=@Price WHERE RoomID=@RoomID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@RoomID", room.RoomID);
                cmd.Parameters.AddWithValue("@RoomType", room.RoomType);
                cmd.Parameters.AddWithValue("@Price", room.Price);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool DeleteRoom(int roomId)
        {
            try
            {
                OpenConnection();
                string query = "DELETE FROM Room WHERE RoomID=@RoomID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@RoomID", roomId);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                CloseConnection();
            }
        }

        public RoomDTO GetRoomById(int roomId)
        {
            try
            {
                OpenConnection();
                string query = "SELECT * FROM Room WHERE RoomID=@RoomID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@RoomID", roomId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new RoomDTO
                    {
                        RoomID = (int)reader["RoomID"],
                        RoomType = reader["RoomType"].ToString(),
                        Price = (decimal)reader["Price"]
                    };
                }
            }
            finally
            {
                CloseConnection();
            }
            return null;
        }
    }
}
