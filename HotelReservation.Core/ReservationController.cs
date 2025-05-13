using HotelReservations.Data;
using HotelReservations.Data.Models;

namespace HotelReservation.Core
{
    
    public class ReservationController
    {
        
        private readonly HotelReservationDBContext _context = new HotelReservationDBContext();

        public ReservationController(HotelReservationDBContext context)
        {
            _context = context;
        }

        public bool MakeReservation(int clientId, int roomId, DateTime checkIn, DateTime checkOut)
        {
            var room = _context.Rooms.Find(roomId);
            if (room == null) ;

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
            return _context.SaveChanges() == 1;
        }

        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations.ToList();
        }

        public bool UpdateReservation(int id, DateTime newCheckIn, DateTime newCheckOut)
        {
            var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservation == null) return false;

            var room = _context.Rooms.Find(reservation.RoomId);
            if (room == null) return false;

            var totalNights = (newCheckOut - newCheckIn).Days;
            reservation.CheckInDate = newCheckIn;
            reservation.CheckOutDate = newCheckOut;
            reservation.TotalPrice = room.PricePerNight * totalNights;

            _context.SaveChanges();
            return true;
        }

        public bool CancelReservation(int id)
        {
            var reservation = _context.Reservations.FirstOrDefault(r => r.Id == id);
            if (reservation == null) return false;

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
            return true;
        }
    }
}
