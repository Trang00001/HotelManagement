using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class GuestBLL
    {
        private GuestDAL guestDAL;

        public GuestBLL()
        {
            guestDAL = new GuestDAL();
        }

        // Get all guests
        public List<GuestDTO> GetAllGuests()
        {
            return guestDAL.GetAllGuests();
        }

        // Add a new guest
        public bool AddGuest(GuestDTO guest)
        {
            if (guest != null)
            {
                return guestDAL.AddGuest(guest);
            }
            return false;
        }

        // Update an existing guest
        public bool UpdateGuest(GuestDTO guest)
        {
            if (guest != null && guest.GuestID > 0)
            {
                return guestDAL.UpdateGuest(guest);
            }
            return false;
        }

        // Delete a guest by ID
        public bool DeleteGuest(int guestId)
        {
            if (guestId > 0)
            {
                return guestDAL.DeleteGuest(guestId);
            }
            return false;
        }
    }
}
