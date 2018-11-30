using Fuzion.UI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuzion.UI.Core.Context
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

            var models = GetModels();
            db.Models.AddRange(models);

            try
            {
                var numAffected = await db.SaveChangesAsync();
                _Logger.LogInformation($"Saved {numAffected} models");
            }
            catch (Exception e)
            {
                _Logger.LogError($"Error in {nameof(FuzionDbContext)}: " + e.Message);
                throw;
            }

            var operatingSystems = GetOperatingSystems();
            db.OS.AddRange(operatingSystems);

            try
            {
                var numAffected = await db.SaveChangesAsync();
                _Logger.LogInformation($"Saved {numAffected} operating systems");
            }
            catch (Exception e)
            {
                _Logger.LogError($"Error in {nameof(FuzionDbContext)}: " + e.Message);
                throw;
            }

            var purposes = GetPurposes();
            db.Purposes.AddRange(purposes);

            try
            {
                var numAffected = await db.SaveChangesAsync();
                _Logger.LogInformation($"Saved {numAffected} purposes");
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
                new HardwareType { Name = "Scanner" },
                new HardwareType { Name = "Printer" }
            };

            return hardwareTypes;
        }

        private List<Manufacturer> GetManufacturers()
        {
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer { Name = "Dell" },
                new Manufacturer { Name = "Fujitsu" },
                new Manufacturer { Name = "Canon" },
                new Manufacturer { Name = "Samsung" },
                new Manufacturer { Name = "Apple" }
            };

            return manufacturers;
        }

        private List<Model> GetModels()
        {
            var models = new List<Model>
            {
                new Model {Name = "Latitude 7530"},
                new Model {Name = "FI-7160"},
                new Model {Name = "Galaxy 9"},
                new Model {Name = "iPhone X"},
                new Model {Name = "Precision 3620"}
            };

            return models;
        }

        private List<OS> GetOperatingSystems()
        {
            var operatingSystems = new List<OS>
            {
                new OS {Name = "Windows 7"},
                new OS {Name = "Windows 10"},
                new OS {Name = "Android"},
                new OS {Name = "iOS"}
            };

            return operatingSystems;
        }

        private List<Purpose> GetPurposes()
        {
            var purposes = new List<Purpose>
            {
                new Purpose {Name = "Production"},
                new Purpose {Name = "Development"}
            };

            return purposes;
        }
    }
}