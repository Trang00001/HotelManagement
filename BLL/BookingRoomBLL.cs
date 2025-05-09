using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class BookingRoomBLL
    {
        private BookingRoomDAL bookingRoomDAL;

        public BookingRoomBLL()
        {
            bookingRoomDAL = new BookingRoomDAL();
        }

        public List<BookingRoomDTO> GetAllBookingRooms()
        {
            return bookingRoomDAL.GetAllBookingRooms();
        }

        public bool AddBookingRoom(BookingRoomDTO bookingRoom)
        {
            if (bookingRoom != null)
            {
                return bookingRoomDAL.AddBookingRoom(bookingRoom);
            }
            return false;
        }
    }
}
