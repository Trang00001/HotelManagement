using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;  // Assuming your BLL classes are in the BLL namespace
using DTO;  // Assuming your DTO classes are in the DTO namespace

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Load event for the form
        private void Form1_Load(object sender, EventArgs e)
        {
            // Create an instance of RoomBLL to access room data
            RoomBLL roomBLL = new RoomBLL();

            // Get all rooms
            List<RoomDTO> rooms = roomBLL.GetAllRooms();

            // Display the room details in the DataGridView
            dataGridViewRooms.DataSource = rooms;
        }
    }
}
