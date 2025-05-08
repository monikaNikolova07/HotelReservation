using HotelReservations.Data;
using HotelReservations.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Core
{
    public class ClientController
    {
        private readonly HotelReservationDBContext _context = new HotelReservationDBContext();

        public ClientController()
        {
            
        }

        public void AddClient(int id, string name, string email, string phone)
        {
            var client = new Client { Id = id, Name = name, Email = email, PhoneNumber = phone };
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        /*
        public IEnumerable<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }
        */
    }
}
