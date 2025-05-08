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
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            var json = File.ReadAllText("../HotelReservations.Data/Data/room.json");
            var rooms = JsonSerializer.Deserialize<Room[]>(json);
            builder.HasData(rooms);
        }
    }
}
