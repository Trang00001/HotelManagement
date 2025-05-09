using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class ServiceInfoBLL
    {
        private ServiceInfoDAL serviceInfoDAL;

        public ServiceInfoBLL()
        {
            serviceInfoDAL = new ServiceInfoDAL();
        }

        // Get all services
        public List<ServiceInfoDTO> GetAllServices()
        {
            return serviceInfoDAL.GetAllServices();
        }

        // Add a new service
        public bool AddService(ServiceInfoDTO service)
        {
            if (service != null)
            {
                return serviceInfoDAL.AddService(service);
            }
            return false;
        }

        // Update an existing service
        public bool UpdateService(ServiceInfoDTO service)
        {
            if (service != null && service.ServiceID > 0)
            {
                return serviceInfoDAL.UpdateService(service);
            }
            return false;
        }

        // Delete a service by ID
        public bool DeleteService(int serviceId)
        {
            if (serviceId > 0)
            {
                return serviceInfoDAL.DeleteService(serviceId);
            }
            return false;
        }

        // Get service details by ServiceID
        public ServiceInfoDTO GetServiceById(int serviceId)
        {
            if (serviceId > 0)
            {
                List<ServiceInfoDTO> services = serviceInfoDAL.GetAllServices();
                foreach (var service in services)
                {
                    if (service.ServiceID == serviceId)
                    {
                        return service;
                    }
                }
            }
            return null;
        }
    }
}
