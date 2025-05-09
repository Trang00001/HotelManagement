using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BookingDTO
    {
        public int BookingID { get; set; }
        public int GuestID { get; set; }
        public decimal TotalPrice { get; set; }
        public string Email { get; set; }
    }

}
