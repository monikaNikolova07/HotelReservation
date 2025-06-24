using HotelReservation.Core;
using HotelReservations.Data;
using HotelReservations.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Form1
{
    public partial class Form4 : Form
    {
        private ClientController controller;
        private RoomController roomController;
        private HotelReservationDBContext dbContext;
        private QueryController queryController;
        public Form4()
        {
            dbContext = new HotelReservationDBContext();
            controller = new ClientController(dbContext);
            roomController = new RoomController(dbContext);
            queryController = new QueryController(dbContext);
            InitializeComponent();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hotelId = int.Parse(textBox3.Text);
            string number = textBox1.Text;
            int capacity = int.Parse(listBox1.Text);
            decimal price = int.Parse(textBox2.Text);

            if (string.IsNullOrEmpty(number) || capacity <= 0 || price <= 0)
            {
                MessageBox.Show("Моля, попълнете всички полета.");
                return;
            }

            roomController.AddRoom(hotelId, number, capacity, price);

            MessageBox.Show("Клиента беше създаден успешно!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            string hotel = comboBox1.Text;
            List<Room> rooms = queryController.GetRoomsByHotelName(hotel);

            foreach (var item in rooms)
            {
                listBox3.Items.Add($"{item.RoomNumber} - {item.PricePerNight}");
            }
        }
    }
}
