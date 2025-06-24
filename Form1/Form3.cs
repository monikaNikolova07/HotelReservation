using HotelReservation.Core;
using HotelReservations.Data;
using HotelReservations.Data.Models;
using Microsoft.IdentityModel.Tokens;
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

    public partial class Form3 : Form
    {
        private ClientController controller;
        private RoomController roomController;
        private HotelController hotelController;
        private HotelReservationDBContext dbContext;
        private QueryController queryController;
        public Form3()
        {
            dbContext = new HotelReservationDBContext();
            controller = new ClientController(dbContext);
            roomController = new RoomController(dbContext);
            queryController = new QueryController(dbContext);
            hotelController = new HotelController(dbContext);
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox2.Text;
            string phoneNumber = textBox3.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                MessageBox.Show("Моля, попълнете всички полета.");
                return;
            }

            controller.AddClient(name, email, phoneNumber);

            MessageBox.Show("Клиента беше създаден успешно!");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string name = textBox1.Text;
            string email = textBox2.Text;
            string phoneNumber = textBox3.Text;
            int id = dbContext.Clients.FirstOrDefault(r => r.PhoneNumber == phoneNumber).Id;

            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                MessageBox.Show("Моля, попълнете всички полета.");
                return;
            }

            controller.UpdateClient(id, name, email, phoneNumber);

            MessageBox.Show("Ъпдейтнахте успешно!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            DateTime startdata = dateTimePicker1.Value;
            DateTime enddata = dateTimePicker2.Value;
            List<Client> clients = queryController.GetClientsByDateRange(startdata, enddata);

            foreach (var item in clients)
            {
                listBox2.Items.Add($"{item.Name} - {item.PhoneNumber}");
            }
        }
    }
}
