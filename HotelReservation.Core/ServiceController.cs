using HotelReservations.Data;
using HotelReservations.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core
{
    public class ServiceController
    {
        private readonly HotelReservationDBContext _context = new HotelReservationDBContext();

        public ServiceController(HotelReservationDBContext context) 
        {
            _context = context;
        }

        public bool AddService(string name, decimal price)
        {
            var serviceAdd = new Service { Name = name, Price = price };
            _context.Services.Add(serviceAdd);
            return _context.SaveChanges() == 1;
        }
    }
}
