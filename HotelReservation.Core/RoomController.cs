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

        public void UpdateRoom(int roomId, string roomNumber, int capacity, decimal price)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
            if (room != null)
            {
                room.RoomNumber = roomNumber;
                room.Capacity = capacity;
                room.PricePerNight = price;

                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Стаята не е намерена");
            }
        }

        public void DeleteRoom(int roomId)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Стаята не е намерена");
            }
        }

    }
}
