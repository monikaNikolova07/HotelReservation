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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            var json = File.ReadAllText("../HotelReservations.Data/Data/client.json");
            var clients = JsonSerializer.Deserialize<Client[]>(json);
            builder.HasData(clients);
        }
    }
}
