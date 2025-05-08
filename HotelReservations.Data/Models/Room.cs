using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public decimal PricePerNight { get; set; }

        [ForeignKey(nameof(HotelId))]
        public Hotel Hotel { get; set; }
        public int HotelId { get; set; }
        

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
