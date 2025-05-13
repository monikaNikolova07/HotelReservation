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

        public ClientController(HotelReservationDBContext context)
        {
            _context = context;
        }

        public void AddClient(string name, string email, string phone)
        {
            var client = new Client { Name = name, Email = email, PhoneNumber = phone };
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public Client GetClientById(int id)
        {
            return _context.Clients.FirstOrDefault(c => c.Id == id);
        }

        public List<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public bool UpdateClient(int id, string name, string email, string phone)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null) return false;

            client.Name = name;
            client.Email = email;
            client.PhoneNumber = phone;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteClient(int id)
        {
            var client = _context.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null) return false;

            _context.Clients.Remove(client);
            _context.SaveChanges();
            return true;
        }
    }
}
