using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspTravelerApp.Models
{
    public class SampleData
    {
        public static void InitializeData(IServiceProvider provider)
        {
            using (var serviceScope = provider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var env = serviceScope.ServiceProvider.GetService<IHostingEnvironment>();

                if (!env.IsDevelopment()) return;

                //var db = serviceScope.ServiceProvider.GetService<TripRepository>
            }
        }
    }
}
