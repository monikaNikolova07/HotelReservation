using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservations.Data.Models
{
    [PrimaryKey(nameof(ReservationId), nameof(ServiceId))]
    public class ReservationService
    {
        [ForeignKey(nameof(ReservationId))]
        public Reservation Reservation { get; set; }
        public int ReservationId { get; set; }
        

        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }
        public int ServiceId { get; set; }
        
    }
}
