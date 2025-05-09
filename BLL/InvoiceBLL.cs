using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class InvoiceBLL
    {
        private InvoiceDAL invoiceDAL;

        public InvoiceBLL()
        {
            invoiceDAL = new InvoiceDAL();
        }

        public List<InvoiceDTO> GetAllInvoices()
        {
            return invoiceDAL.GetAllInvoices();
        }

        public bool AddInvoice(InvoiceDTO invoice)
        {
            if (invoice != null)
            {
                return invoiceDAL.AddInvoice(invoice);
            }
            return false;
        }
    }
}
