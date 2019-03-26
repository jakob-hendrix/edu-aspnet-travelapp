using AspTravelerApp.Models;
using AspTravelerApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspTravelerApp.Data
{
    public class SampleData
    {
        public static void InitializeData(IServiceProvider provider, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger("InitializeData");

            using (var serviceScope = provider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var env = serviceScope.ServiceProvider
                                      .GetService<IHostingEnvironment>();

                // Only add fake data for dev purposes
                if (!env.IsDevelopment()) return;

                var db = serviceScope.ServiceProvider.GetService<TripRepository>();

                if (db.Get().Any())
                {
                    logger.LogDebug("Data exists in DB. Not adding seeder data.");
                    return;
                }

                logger.LogDebug("Adding initial data to our db for testing");
                // Mock up a trip!
                var startDate = FirstFridayNextMonth(DateTime.Today);
                var endDate = startDate.AddDays(2);

                var newTrip = new Trip
                {
                    Name = "Weekend in NYC",
                    Description = "Train to New York City for the weekend",
                    StartDate = startDate,
                    EndDate = startDate.AddDays(3).AddMinutes(-1)
                };

                var trainDepart = new Segment
                {
                    Name = "Amtrak Train PHL->NYP",
                    StartDate = startDate.AddHours(17),
                    EndDate = startDate.AddHours(19),
                    DepartureAddress = "30th St. Station\nPhiladelphia, PA",
                    ArrivalAddress = "New York Penn Stations\nNew York, NY",
                    ReservationID = "123456",
                    Trip = newTrip,
                    Type = SegmentType.Train
                };
                newTrip.Segments.Add(trainDepart);

                var lodging = new Segment
                {
                    Name = "New Times Roman Hostel",
                    StartDate = startDate.AddHours(19).AddMinutes(10),
                    EndDate = endDate.AddHours(12),
                    ArrivalAddress = "123456 Times Square\nNew York, NY",
                    ReservationID = "ABCDE",
                    Trip = newTrip,
                    Type = SegmentType.Lodging
                };
                newTrip.Segments.Add(lodging);

                var trainReturn = new Segment
                {
                    Name = "Amtrak Train NYP->PHL",
                    StartDate = endDate.AddHours(15),
                    EndDate = endDate.AddHours(17),
                    DepartureAddress = "New York Penn Stations\nNew York, NY",
                    ArrivalAddress = "30th St. Station\nPhiladelphia, PA",
                    ReservationID = "654321",
                    Trip = newTrip,
                    Type = SegmentType.Train
                };
                newTrip.Segments.Add(trainReturn);

                db.Add(newTrip);
                logger.LogDebug("DB updated with initial data");
            }
        }

        private static DateTime FirstFridayNextMonth(DateTime dateToCheck)
        {
            // how are these different
            var firstOfNextMonth = new DateTime(dateToCheck.Year, dateToCheck.Month, 1).AddMonths(1);
            var daysUntilFriday = 5 - (int)firstOfNextMonth.DayOfWeek;
            if (daysUntilFriday > 0)
            {
                return firstOfNextMonth.AddDays(daysUntilFriday);
            }
            else if (daysUntilFriday < 0)
            {
                return firstOfNextMonth.AddDays(7 + daysUntilFriday);
            }
            else
            {
                return firstOfNextMonth;  // it's Friday!
            }
        }
    }
}
