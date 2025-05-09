using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ServiceInvoiceDTO
    {
        public int ServiceInvoiceID { get; set; }
        public int BookingID { get; set; }
        public int ServiceID { get; set; }
        public DateTime Datetime { get; set; }
        public int GuestID { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
