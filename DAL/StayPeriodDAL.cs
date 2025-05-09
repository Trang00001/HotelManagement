using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class StayPeriodDAL : DatabaseAccess
    {
        public List<StayPeriodDTO> GetAllStayPeriods()
        {
            List<StayPeriodDTO> stayPeriods = new List<StayPeriodDTO>();
            try
            {
                OpenConnection();
                string query = "SELECT * FROM StayPeriod";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stayPeriods.Add(new StayPeriodDTO
                    {
                        BookingID = (int)reader["BookingID"],
                        GuestID = (int)reader["GuestID"],
                        CheckIn = (DateTime)reader["CheckIn"],
                        CheckOut = (DateTime)reader["CheckOut"]
                    });
                }
                reader.Close();
            }
            finally
            {
                CloseConnection();
            }
            return stayPeriods;
        }

        public bool AddStayPeriod(StayPeriodDTO stayPeriod)
        {
            try
            {
                OpenConnection();
                string query = "INSERT INTO StayPeriod (BookingID, GuestID, CheckIn, CheckOut) VALUES (@BookingID, @GuestID, @CheckIn, @CheckOut)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@BookingID", stayPeriod.BookingID);
                cmd.Parameters.AddWithValue("@GuestID", stayPeriod.GuestID);
                cmd.Parameters.AddWithValue("@CheckIn", stayPeriod.CheckIn);
                cmd.Parameters.AddWithValue("@CheckOut", stayPeriod.CheckOut);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
