using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ServiceInvoiceDAL : DatabaseAccess
    {
        public List<ServiceInvoiceDTO> GetAllServiceInvoices()
        {
            List<ServiceInvoiceDTO> serviceInvoices = new List<ServiceInvoiceDTO>();
            try
            {
                OpenConnection();
                string query = "SELECT * FROM ServiceInvoice";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    serviceInvoices.Add(new ServiceInvoiceDTO
                    {
                        ServiceInvoiceID = (int)reader["ServiceInvoiceID"],
                        BookingID = (int)reader["BookingID"],
                        ServiceID = (int)reader["ServiceID"],
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
            return serviceInvoices;
        }

        public bool AddServiceInvoice(ServiceInvoiceDTO serviceInvoice)
        {
            try
            {
                OpenConnection();
                string query = "INSERT INTO ServiceInvoice (BookingID, ServiceID, Datetime, GuestID, TotalPrice) VALUES (@BookingID, @ServiceID, @Datetime, @GuestID, @TotalPrice)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@BookingID", serviceInvoice.BookingID);
                cmd.Parameters.AddWithValue("@ServiceID", serviceInvoice.ServiceID);
                cmd.Parameters.AddWithValue("@Datetime", serviceInvoice.Datetime);
                cmd.Parameters.AddWithValue("@GuestID", serviceInvoice.GuestID);
                cmd.Parameters.AddWithValue("@TotalPrice", serviceInvoice.TotalPrice);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
