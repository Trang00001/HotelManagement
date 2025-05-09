using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class InvoiceDAL : DatabaseAccess
    {
        public List<InvoiceDTO> GetAllInvoices()
        {
            List<InvoiceDTO> invoices = new List<InvoiceDTO>();
            try
            {
                OpenConnection();
                string query = "SELECT * FROM Invoice";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    invoices.Add(new InvoiceDTO
                    {
                        InvoiceID = (int)reader["InvoiceID"],
                        BookingID = (int)reader["BookingID"],
                        Datetime = (DateTime)reader["Datetime"],
                        GuestID = (int)reader["GuestID"],
                        TotalPrice = (decimal)reader["TotalPrice"]
                    });
                }
                reader.Close();
            }
            finally
            {
                CloseConnection();
            }
            return invoices;
        }

        public bool AddInvoice(InvoiceDTO invoice)
        {
            try
            {
                OpenConnection();
                string query = "INSERT INTO Invoice (BookingID, Datetime, GuestID, TotalPrice) VALUES (@BookingID, @Datetime, @GuestID, @TotalPrice)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@BookingID", invoice.BookingID);
                cmd.Parameters.AddWithValue("@Datetime", invoice.Datetime);
                cmd.Parameters.AddWithValue("@GuestID", invoice.GuestID);
                cmd.Parameters.AddWithValue("@TotalPrice", invoice.TotalPrice);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
