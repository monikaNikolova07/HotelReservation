using HotelReservation.Data;
using HotelReservation.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core
{
    public class HotelController
    {
        private readonly HotelReservationDBContext _context = new HotelReservationDBContext();

        public HotelController()
        {
            
        }

        /*
        public IEnumerable<Hotel> GetAllHotels()
        {
            return _context.Hotels.ToList();
        }
        */

        public void AddHotel(int id, string name, string address, string city)
        {
            var hotel = new Hotel {Id = id, Name = name, Address = address, City = city };
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
        }

    }
}
