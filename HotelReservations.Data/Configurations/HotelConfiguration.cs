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
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            var json = File.ReadAllText("../../../../HotelReservations.Data/Data/hotel.json");
            var hotels = JsonSerializer.Deserialize<Hotel[]>(json);
            builder.HasData(hotels);
        }
    }
}
