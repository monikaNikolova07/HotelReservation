using HotelReservation.Core;
using HotelReservations.Data;
using HotelReservations.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Form1
{
    public partial class Form2 : Form
    {
        private HotelReservationDBContext context;
        private ReservationController reservationController;
        private QueryController queryController;
        public Form2()
        {
            context = new HotelReservationDBContext();
            queryController = new QueryController(context);
            reservationController = new ReservationController(context);
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int clientId = int.Parse(textBox1.Text);
            string selectedRoom = comboBox1.SelectedItem?.ToString();
            int selectedId = context.Rooms.FirstOrDefault(r => r.RoomNumber == selectedRoom).Id;
            DateTime checkIn = dateTimePicker1.Value;
            DateTime checkOut = dateTimePicker2.Value;

            if (clientId < 0 || string.IsNullOrWhiteSpace(selectedRoom))
            {
                MessageBox.Show("Моля, попълнете всички полета.");
                return;
            }

            reservationController.MakeReservation(clientId, selectedId, checkIn, checkOut);

            MessageBox.Show("Резервацията беше създадена успешно!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            form1.Show();

            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            listBox1.Visible = true;
            label7.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string clientName = textBox2.Text;

            List<Reservation> reservations = queryController.GetReservationsForClient(clientName);

            foreach (var item in reservations)
            {
                listBox1.Items.Add($"{item.Room.RoomNumber} - {item.TotalPrice}");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
