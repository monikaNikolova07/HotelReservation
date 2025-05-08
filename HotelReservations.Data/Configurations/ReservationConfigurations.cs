using HotelReservations.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelReservations.Data.Configurations
{
    public class ReservationConfigurations : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            var lines = File.ReadAllLines("../HotelReservations.Data/Data/reservation.txt");

            List<Reservation> reservations = [];

            foreach (string line in lines)
            {
                string[] properties = line.Split(',');

                var reservation = new Reservation
                {
                    Id = int.Parse(properties[0]),
                    ClientId = int.Parse(properties[1]),
                    RoomId = int.Parse(properties[2]),
                    CheckInDate = DateTime.Parse(properties[3]),
                    CheckOutDate = DateTime.Parse(properties[4]),
                    TotalPrice = decimal.Parse(properties[5])
                };

                reservations.Add(reservation);
            }

            builder.HasData(reservations);
        }
    }
}
