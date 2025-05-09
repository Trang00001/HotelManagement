using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class BookingRoomDAL : DatabaseAccess
    {
        public List<BookingRoomDTO> GetAllBookingRooms()
        {
            List<BookingRoomDTO> bookingRooms = new List<BookingRoomDTO>();
            try
            {
                OpenConnection();
                string query = "SELECT * FROM BookingRoom";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bookingRooms.Add(new BookingRoomDTO
                    {
                        BookingID = (int)reader["BookingID"],
                        RoomID = (int)reader["RoomID"],
                        Date = (DateTime)reader["Date"]
                    });
                }
                reader.Close();
            }
            finally
            {
                CloseConnection();
            }
            return bookingRooms;
        }

        public bool AddBookingRoom(BookingRoomDTO bookingRoom)
        {
            try
            {
                OpenConnection();
                string query = "INSERT INTO BookingRoom (BookingID, RoomID, Date) VALUES (@BookingID, @RoomID, @Date)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@BookingID", bookingRoom.BookingID);
                cmd.Parameters.AddWithValue("@RoomID", bookingRoom.RoomID);
                cmd.Parameters.AddWithValue("@Date", bookingRoom.Date);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
