using HotelReservation.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Data.Configurations
{
    public class ReservationServiceConfiguration : IEntityTypeConfiguration<ReservationService>
    {
        public void Configure(EntityTypeBuilder<ReservationService> builder)
        {
            List<ReservationService> reservationServices = new List<ReservationService>();
            builder.HasData(reservationServices);
        }
    }
}
