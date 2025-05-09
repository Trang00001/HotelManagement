using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ServiceInfoDAL : DatabaseAccess
    {
        public List<ServiceInfoDTO> GetAllServices()
        {
            List<ServiceInfoDTO> services = new List<ServiceInfoDTO>();
            try
            {
                OpenConnection();
                string query = "SELECT * FROM ServiceInfo";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    services.Add(new ServiceInfoDTO
                    {
                        ServiceID = (int)reader["ServiceID"],
                        Service = reader["Service"].ToString(),
                        Price = (decimal)reader["Price"]
                    });
                }
                reader.Close();
            }
            finally
            {
                CloseConnection();
            }
            return services;
        }

        public bool AddService(ServiceInfoDTO service)
        {
            try
            {
                OpenConnection();
                string query = "INSERT INTO ServiceInfo (Service, Price) VALUES (@Service, @Price)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Service", service.Service);
                cmd.Parameters.AddWithValue("@Price", service.Price);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool UpdateService(ServiceInfoDTO service)
        {
            try
            {
                OpenConnection();
                string query = "UPDATE ServiceInfo SET Service=@Service, Price=@Price WHERE ServiceID=@ServiceID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ServiceID", service.ServiceID);
                cmd.Parameters.AddWithValue("@Service", service.Service);
                cmd.Parameters.AddWithValue("@Price", service.Price);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool DeleteService(int serviceId)
        {
            try
            {
                OpenConnection();
                string query = "DELETE FROM ServiceInfo WHERE ServiceID=@ServiceID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ServiceID", serviceId);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}