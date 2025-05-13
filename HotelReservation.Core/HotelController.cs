using HotelReservations.Data;
using HotelReservations.Data.Models;

namespace HotelReservation.Core
{
    public class HotelController
    {
        private readonly HotelReservationDBContext _context = new HotelReservationDBContext();

        public HotelController(HotelReservationDBContext context)
        {
            _context = context;
        }

        public bool AddHotel(string name, string address, string city)
        {
            var hotel = new Hotel {Name = name, Address = address, City = city };
            _context.Hotels.Add(hotel);
            return _context.SaveChanges() == 1;
        }
        public bool UpdateHotel(int id, string name, string address, string city)
        {
            var hotel = _context.Hotels.FirstOrDefault(h => h.Id == id);
            if (hotel == null) return false;

            hotel.Name = name;
            hotel.Address = address;
            hotel.City = city;

            return _context.SaveChanges() == 1;
        }

        public bool DeleteHotel(int id)
        {
            var hotel = _context.Hotels.FirstOrDefault(h => h.Id == id);
            if (hotel == null) return false;

            _context.Hotels.Remove(hotel);
            return _context.SaveChanges() == 1;
        }
    }
}
