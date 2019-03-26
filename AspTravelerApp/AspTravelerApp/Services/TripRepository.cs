using AspTravelerApp.Data;
using AspTravelerApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AspTravelerApp.Services
{
    public class TripRepository
    {
        private TripDbContext _context;
        public TripRepository(TripDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Trip> Get()
        {
            return _context.Trips.ToList();
        }
        public Trip GetById(int id)
        {
            var trip = _context.Trips.Include(t => t.Segments).FirstOrDefault(t => t.ID == id);
            return trip;
        }

        public int Add(Trip newTrip)
        {
            _context.Trips.Add(newTrip);
            _context.SaveChanges();
            return newTrip.ID;
        }

        public void Update(Trip savedTrip)
        {
            _context.Trips.Update(savedTrip);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Trips.Remove(_context.Trips.First(t => t.ID == id));
            _context.SaveChanges();
        }
    }
}
