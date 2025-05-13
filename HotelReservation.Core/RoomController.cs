using HotelReservations.Data;
using HotelReservations.Data.Models;
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

        public RoomController(HotelReservationDBContext context)
        {
            _context = context;
        }

        public bool AddRoom(int hotelId, string roomNumber, int capacity, decimal price)
        {
            var room = new Room
            {
                HotelId = hotelId,
                RoomNumber = roomNumber,
                Capacity = capacity,
                PricePerNight = price
            };
            _context.Rooms.Add(room);
            return _context.SaveChanges() == 1;
        }

        public bool UpdateRoom(int roomId, string roomNumber, int capacity, decimal price)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
            if (room != null)
            {
                room.RoomNumber = roomNumber;
                room.Capacity = capacity;
                room.PricePerNight = price;

                return _context.SaveChanges() == 1;
            }
            else
            {
                throw new ArgumentException("Стаята не е намерена");
            }
        }

        public bool DeleteRoom(int roomId)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                return _context.SaveChanges() == 1;
            }
            else
            {
                throw new ArgumentException("Стаята не е намерена");
            }
        }

    }
}
