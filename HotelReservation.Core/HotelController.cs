using HotelReservations.Data;
using HotelReservations.Data.Models;

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
