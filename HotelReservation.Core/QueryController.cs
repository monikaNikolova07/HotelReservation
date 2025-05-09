using HotelReservations.Data;
using HotelReservations.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core
{
    public class QueryController
    {
        private readonly HotelReservationDBContext _context;

        public QueryController(HotelReservationDBContext context)
        {
            _context = context;
        }

        // Заявка 1: Хотели в конкретен град
        public IEnumerable<Hotel> GetHotelsByCity(string city)
        {
            return _context.Hotels.Where(h => h.City == city).ToList();
        }

        // Заявка 2: Стаи над определена цена
        public IEnumerable<Room> GetRoomsAbovePrice(decimal price)
        {
            return _context.Rooms.Where(r => r.PricePerNight > price).ToList();
        }

        // Заявка 3: Клиенти с повече от 1 резервация (връзка Client - Reservation)
        public IEnumerable<Client> GetClientsWithMultipleReservations()
        {
            return _context.Clients
                .Where(c => _context.Reservations.Count(r => r.ClientId == c.Id) > 1)
                .ToList();
        }

        // Заявка 4: Стаи в конкретен хотел (с вход и 2 таблици: Room, Hotel)
        public IEnumerable<Room> GetRoomsByHotelName(string hotelName)
        {
            return _context.Rooms
                .Where(r => r.Hotel.Name == hotelName)
                .Include(r => r.Hotel)
                .ToList();
        }

        // Заявка 5: Резервации за даден клиент (с вход, връзка Reservation - Client - Room)
        public IEnumerable<Reservation> GetReservationsForClient(string clientName)
        {
            return _context.Reservations
                .Include(r => r.Client)
                .Include(r => r.Room)
                .ThenInclude(room => room.Hotel)
                .Where(r => r.Client.Name == clientName)
                .ToList();
        }
        // Заявка 6: Не работи и е изтрита

        // Заявка 7: Общ приход за конкретен хотел (с вход и 3 таблици)
        public decimal GetTotalRevenueForHotel(string hotelName)
        {
            return _context.Reservations
                .Where(r => r.Room.Hotel.Name == hotelName)
                .Include(r => r.Room)
                .Sum(r => r.TotalPrice);
        }

        // Заявка 8: Хотели без резервации (left join-like)
        public IEnumerable<Hotel> GetHotelsWithoutReservations()
        {
            return _context.Hotels
                .Include(h => h.Rooms)
                .Where(h => !h.Rooms.Any(r => _context.Reservations.Any(res => res.RoomId == r.Id)))
                .ToList();
        }

        // Заявка 9: Стаи, които никога не са резервирани (с повече от 1 таблица)
        public IEnumerable<Room> GetUnusedRooms()
        {
            return _context.Rooms
                .Include(r => r.Hotel)
                .Where(r => !_context.Reservations.Any(res => res.RoomId == r.Id))
                .ToList();
        }

        // Заявка 10: Клиенти, които са резервирали в определен период (с вход и 3 таблици)
        public IEnumerable<Client> GetClientsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.Reservations
                .Include(r => r.Client)
                .Include(r => r.Room)
                .ThenInclude(r => r.Hotel)
                .Where(r => r.CheckInDate >= startDate && r.CheckOutDate <= endDate)
                .Select(r => r.Client)
                .Distinct()
                .ToList();
        }
    }
}
