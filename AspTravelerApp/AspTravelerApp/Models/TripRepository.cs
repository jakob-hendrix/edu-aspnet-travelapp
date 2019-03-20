using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspTravelerApp.Models
{
    public class TripRepository
    {
        public TripRepository(TripDbContext context)
        {
            currentDb = context;
        }
        public TripDbContext currentDb { get; }

        public IEnumerable<Trip> Get()
        {
            return currentDb.Trips.ToList();
        }
        public Trip GetById(int id)
        {
            var trip = currentDb.Trips.Include(t => t.Segments).FirstOrDefault(t => t.ID == id);
            return trip;
        }

        public int Add(Trip newTrip)
        {
            currentDb.Trips.Add(newTrip);
            currentDb.SaveChanges();
            return newTrip.ID;
        }

        public void Update(Trip savedTrip)
        {
            currentDb.Trips.Update(savedTrip);
            currentDb.SaveChanges();
        }

        public void Delete(int id)
        {
            currentDb.Trips.Remove(currentDb.Trips.First(t => t.ID == id));
            currentDb.SaveChanges();
        }
    }
}
