using HotelReservations.Data;
using HotelReservations.Data.Models;

namespace HotelReservation.Core
{
    
    public class ReservationController
    {
        
        private readonly HotelReservationDBContext _context = new HotelReservationDBContext();

        public ReservationController()
        {

        }

        public void MakeReservation(int clientId, int roomId, DateTime checkIn, DateTime checkOut)
        {
            var room = _context.Rooms.Find(roomId);
            if (room == null) return;

            var totalNights = (checkOut - checkIn).Days;
            var totalPrice = room.PricePerNight * totalNights;

            var reservation = new Reservation
            {
                ClientId = clientId,
                RoomId = roomId,
                CheckInDate = checkIn,
                CheckOutDate = checkOut,
                TotalPrice = totalPrice
            };

            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        

        /*
        public IEnumerable<Reservation> GetClientReservations(int clientId)
        {
            return _context.Reservations
                .Include(r => r.Room)
                .ThenInclude(r => r.Hotel)
                .Where(r => r.ClientId == clientId)
                .ToList();
        }
        */
    }
}
