using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class ServiceInvoiceBLL
    {
        private ServiceInvoiceDAL serviceInvoiceDAL;

        public ServiceInvoiceBLL()
        {
            serviceInvoiceDAL = new ServiceInvoiceDAL();
        }

        public List<ServiceInvoiceDTO> GetAllServiceInvoices()
        {
            return serviceInvoiceDAL.GetAllServiceInvoices();
        }

        public bool AddServiceInvoice(ServiceInvoiceDTO serviceInvoice)
        {
            if (serviceInvoice != null)
            {
                return serviceInvoiceDAL.AddServiceInvoice(serviceInvoice);
            }
            return false;
        }
    }
}
