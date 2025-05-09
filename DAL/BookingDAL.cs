using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class BookingDAL : DatabaseAccess
    {
        public List<BookingDTO> GetAllBookings()
        {
            List<BookingDTO> bookings = new List<BookingDTO>();
            try
            {
                OpenConnection();
                string query = "SELECT * FROM Booking";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bookings.Add(new BookingDTO
                    {
                        BookingID = (int)reader["BookingID"],
                        GuestID = (int)reader["GuestID"],
                        TotalPrice = (decimal)reader["TotalPrice"],
                        Email = reader["Email"].ToString()
                    });
                }
                reader.Close();
            }
            finally
            {
                CloseConnection();
            }
            return bookings;
        }

        public bool AddBooking(BookingDTO booking)
        {
            try
            {
                OpenConnection();
                string query = "INSERT INTO Booking (GuestID, TotalPrice, Email) VALUES (@GuestID, @TotalPrice, @Email)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@GuestID", booking.GuestID);
                cmd.Parameters.AddWithValue("@TotalPrice", booking.TotalPrice);
                cmd.Parameters.AddWithValue("@Email", booking.Email);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool UpdateBooking(BookingDTO booking)
        {
            try
            {
                OpenConnection();
                string query = "UPDATE Booking SET GuestID=@GuestID, TotalPrice=@TotalPrice, Email=@Email WHERE BookingID=@BookingID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@BookingID", booking.BookingID);
                cmd.Parameters.AddWithValue("@GuestID", booking.GuestID);
                cmd.Parameters.AddWithValue("@TotalPrice", booking.TotalPrice);
                cmd.Parameters.AddWithValue("@Email", booking.Email);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool DeleteBooking(int bookingId)
        {
            try
            {
                OpenConnection();
                string query = "DELETE FROM Booking WHERE BookingID=@BookingID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
