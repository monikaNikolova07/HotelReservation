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
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            var lines = File.ReadAllLines("../HotelReservations.Data/Data/reservation.txt");

            List<Service> services = [];

            foreach (string line in lines)
            {
                string[] properties = line.Split(',');

                var service = new Service
                {
                    Id = int.Parse(properties[0]),
                    Name = properties[1],
                    Price = decimal.Parse(properties[2])
                };

                services.Add(service);
            }
            builder.HasData(services);
        }
    }
}
