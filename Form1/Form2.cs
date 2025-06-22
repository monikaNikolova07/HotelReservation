using HotelReservations.Data;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       /* private void Form2_Load(object sender, EventArgs e)
        {
            using (var context = new HotelReservationDBContext())
            {
                var rooms = context.Rooms.ToList();

                comboBox1.DataSource = rooms;
                comboBox1.DisplayMember = "RoomNumber";
                comboBox1.ValueMember = "Id";
            }
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            string clientName = textBox1.Text;
            string selectedRoom = comboBox1.SelectedItem?.ToString();
            DateTime checkIn = dateTimePicker1.Value;
            DateTime checkOut = dateTimePicker2.Value;

            if (string.IsNullOrWhiteSpace(clientName) || string.IsNullOrWhiteSpace(selectedRoom))
            {
                MessageBox.Show("Моля, попълнете всички полета.");
                return;
            }
            MessageBox.Show("Резервацията беше създадена успешно!");
            this.Close();
        }
    }
}
