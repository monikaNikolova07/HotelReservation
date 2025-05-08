using HotelReservations.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Configurations
{
    public class ReservationServiceConfiguration : IEntityTypeConfiguration<ReservationService>
    {
        public void Configure(EntityTypeBuilder<ReservationService> builder)
        {
            var lines = File.ReadAllLines("../HotelReservations.Data/Data/reservation.txt");

            List<ReservationService> reservationServices = [];

            foreach (string line in lines)
            {
                string[] properties = line.Split(',');

                var reservationService = new ReservationService
                {
                    ReservationId = int.Parse(properties[0]),
                    ServiceId = int.Parse(properties[1])
                };

                reservationServices.Add(reservationService);
            }

            builder.HasData(reservationServices);
        }
    }
}
