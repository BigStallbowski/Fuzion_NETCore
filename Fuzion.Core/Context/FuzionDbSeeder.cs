using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fuzion.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fuzion.Core.Context
{
    public class FuzionDbSeeder
    {
        private readonly ILogger _Logger;

        public FuzionDbSeeder(ILoggerFactory loggerFactory)
        {
            _Logger = loggerFactory.CreateLogger("FuzionDbSeederLogger");
        }

        public async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var fuzionDb = serviceScope.ServiceProvider.GetService<FuzionDbContext>();
                if (await fuzionDb.Database.EnsureCreatedAsync())
                {
                    if (!await fuzionDb.Hardware.AnyAsync())
                    {
                        await InsertFuzionSampleData(fuzionDb);
                    }
                }
            }
        }

        public async Task InsertFuzionSampleData(FuzionDbContext db)
        {
            var hardwareTypes = GetHardwareTypes();
            db.HardwareTypes.AddRange(hardwareTypes);

            try
            {
                var numAffected = await db.SaveChangesAsync();
                _Logger.LogInformation($"Saved {numAffected} hardware types");
            }
            catch (Exception e)
            {
                _Logger.LogError($"Error in {nameof(FuzionDbSeeder)}: " + e.Message);
                throw;
            }

            var manufacturers = GetManufacturers();
            db.Manufacturers.AddRange(manufacturers);

            try
            {
                var numAffected = await db.SaveChangesAsync();
                _Logger.LogInformation($"Saved {numAffected} manufacturers");
            }
            catch (Exception e)
            {
                _Logger.LogError($"Error in {nameof(FuzionDbContext)}: " + e.Message);
                throw;
            }
        }

        private List<HardwareType> GetHardwareTypes()
        {
            var hardwareTypes = new List<HardwareType>
            {
                new HardwareType { Name = "Laptop" },
                new HardwareType { Name = "Workstation" },
                new HardwareType { Name = "Tablet" },
                new HardwareType { Name = "Server" },
                new HardwareType { Name = "Scanner"},
                new HardwareType { Name = "Printer" }
            };

            return hardwareTypes;
        }

        private List<Manufacturer> GetManufacturers()
        {
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer {Name = "Dell"},
                new Manufacturer {Name = "Fujitsu"},
                new Manufacturer {Name = "Canon"}
            };

            return manufacturers;
        }
    }
}