using HotelReservation.Data;
using HotelReservation.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core
{
    public class RoomController
    {
        private readonly HotelReservationDBContext _context = new HotelReservationDBContext();

        public RoomController()
        {

        }

        public void AddRoom(int hotelId, string roomNumber, int capacity, decimal price)
        {
            var room = new Room
            {
                HotelId = hotelId,
                RoomNumber = roomNumber,
                Capacity = capacity,
                PricePerNight = price
            };
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public IEnumerable<Room> GetRoomsByHotel(int hotelId)
        {
            return _context.Rooms.Where(r => r.HotelId == hotelId).ToList();
        }
    }
}
