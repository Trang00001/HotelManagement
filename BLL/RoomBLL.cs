using System;
using System.Collections.Generic;
using DTO;
using DAL;
using System.Data;

namespace BLL
{
    public class RoomBLL
    {
        private RoomDAL roomDAL;

        public RoomBLL()
        {
            roomDAL = new RoomDAL();
        }

        // Get all rooms
        public List<RoomDTO> GetAllRooms()
        {
            List<RoomDTO> rooms = new List<RoomDTO>();
            DataTable dt = roomDAL.GetAllRooms();

            foreach (DataRow row in dt.Rows)
            {
                rooms.Add(new RoomDTO
                {
                    RoomID = (int)row["RoomID"],
                    RoomType = row["RoomType"].ToString(),
                    Price = (decimal)row["Price"]
                });
            }

            return rooms;
        }

        // Add a new room
        public bool AddRoom(RoomDTO room)
        {
            if (room != null)
            {
                return roomDAL.AddRoom(room);
            }
            return false;
        }

        // Update an existing room
        public bool UpdateRoom(RoomDTO room)
        {
            if (room != null && room.RoomID > 0)
            {
                return roomDAL.UpdateRoom(room);
            }
            return false;
        }

        // Delete a room by ID
        public bool DeleteRoom(int roomId)
        {
            if (roomId > 0)
            {
                return roomDAL.DeleteRoom(roomId);
            }
            return false;
        }

        // Get room details by RoomID
        public RoomDTO GetRoomById(int roomId)
        {
            if (roomId > 0)
            {
                return roomDAL.GetRoomById(roomId);
            }
            return null;
        }
    }
}
