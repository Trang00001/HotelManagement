using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class BookingBLL
    {
        private BookingDAL bookingDAL;

        public BookingBLL()
        {
            bookingDAL = new BookingDAL();
        }

        public List<BookingDTO> GetAllBookings()
        {
            return bookingDAL.GetAllBookings();
        }

        public bool AddBooking(BookingDTO booking)
        {
            if (booking != null)
            {
                return bookingDAL.AddBooking(booking);
            }
            return false;
        }

        public bool UpdateBooking(BookingDTO booking)
        {
            if (booking != null)
            {
                return bookingDAL.UpdateBooking(booking);
            }
            return false;
        }

        public bool DeleteBooking(int bookingId)
        {
            if (bookingId > 0)
            {
                return bookingDAL.DeleteBooking(bookingId);
            }
            return false;
        }
    }
}
