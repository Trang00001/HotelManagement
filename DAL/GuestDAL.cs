using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class GuestDAL : DatabaseAccess
    {
        public List<GuestDTO> GetAllGuests()
        {
            List<GuestDTO> guests = new List<GuestDTO>();
            try
            {
                OpenConnection();
                string query = "SELECT * FROM Guest";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    guests.Add(new GuestDTO
                    {
                        GuestID = (int)reader["GuestID"],
                        FullName = reader["FullName"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        GuestPrivateInf = reader["GuestPrivateInf"].ToString()
                    });
                }
                reader.Close();
            }
            finally
            {
                CloseConnection();
            }
            return guests;
        }

        public bool AddGuest(GuestDTO guest)
        {
            try
            {
                OpenConnection();
                string query = "INSERT INTO Guest (FullName, PhoneNumber, Email, GuestPrivateInf) VALUES (@FullName, @PhoneNumber, @Email, @GuestPrivateInf)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@FullName", guest.FullName);
                cmd.Parameters.AddWithValue("@PhoneNumber", guest.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", guest.Email);
                cmd.Parameters.AddWithValue("@GuestPrivateInf", guest.GuestPrivateInf);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool UpdateGuest(GuestDTO guest)
        {
            try
            {
                OpenConnection();
                string query = "UPDATE Guest SET FullName=@FullName, PhoneNumber=@PhoneNumber, Email=@Email, GuestPrivateInf=@GuestPrivateInf WHERE GuestID=@GuestID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@GuestID", guest.GuestID);
                cmd.Parameters.AddWithValue("@FullName", guest.FullName);
                cmd.Parameters.AddWithValue("@PhoneNumber", guest.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", guest.Email);
                cmd.Parameters.AddWithValue("@GuestPrivateInf", guest.GuestPrivateInf);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool DeleteGuest(int guestId)
        {
            try
            {
                OpenConnection();
                string query = "DELETE FROM Guest WHERE GuestID=@GuestID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@GuestID", guestId);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
