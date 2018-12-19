using Fuzion.UI.Core.Context;
using Fuzion.UI.Core.Models;
using Fuzion.UI.Persistence.DTOS;
using Fuzion.UI.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fuzion.UI.Persistence.Repositories
{
    public class HardwareRepository : Repository<Hardware>, IHardwareRepository
    {
        public HardwareRepository(FuzionDbContext ctx) : base(ctx)
        {
        }

        public FuzionDbContext FuzionContext => _ctx as FuzionDbContext;

        public async Task<IEnumerable<Hardware>> GetAllHardwareWithDetails()
        {
            return await FuzionContext.Hardware
                .Include(h => h.HardwareType)
                .Include(h => h.Manufacturer)
                .Include(h => h.Model)
                .Include(h => h.OS)
                .Include(h => h.Purpose)
                .OrderBy(h => h.AssetNumber)
                .ToListAsync();
        }

        public async Task<Hardware> GetHardwareById(int id)
        {
            var hardware = await FindByConditionAsync(x => x.Id.Equals(id));
            return hardware.FirstOrDefault();
        }

        public async Task<HardwareCounts> GetHardwareCounts()
        {
            HardwareCounts hardwareCounts = new HardwareCounts
            {
                TotalAvailableHardware = await FuzionContext.Hardware
                    .CountAsync(x => x.IsRetired != 1),
                TotalAvailableWorkstations = await FuzionContext.Hardware
                    .CountAsync(x => x.HardwareType.Name == "Workstation"),
                TotalAvailableLaptops = await FuzionContext.Hardware
                    .CountAsync(x => x.HardwareType.Name == "Laptop"),
                TotalAvailableMobileDevices = await FuzionContext.Hardware
                    .CountAsync(x => x.HardwareType.Name == "Mobile"),
                TotalDeployedHardware = await FuzionContext.Hardware
                    .CountAsync(x => x.IsAssigned == 1),
                TotalDeployedWorkstations = await FuzionContext.Hardware
                    .CountAsync(x => x.HardwareType.Name == "Workstation" && x.IsAssigned == 1),
                TotalDeployedLaptops = await FuzionContext.Hardware
                    .CountAsync(x => x.HardwareType.Name == "Laptop" && x.IsAssigned == 1),
                TotalDeployedMobileDevices = await FuzionContext.Hardware
                    .CountAsync(x => x.HardwareType.Name == "Mobile" && x.IsAssigned == 1)
            };
            return hardwareCounts;
        }

        public async Task<Hardware> CreateHardware(Hardware hardware)
        {
            Create(hardware);
            await SaveAsync();
            return hardware;
        }

        public async Task UpdateHardware(Hardware hardware)
        {
            Update(hardware);
            await SaveAsync();
        }

        public async Task DeleteHardware(Hardware hardware)
        {
            Delete(hardware);
            await SaveAsync();
        }

        public async Task AssignHardware(Hardware hardware)
        {
            hardware.IsAssigned = 1;
            Update(hardware);
            await SaveAsync();
        }

        public async Task UnassignHardware(Hardware hardware)
        {
            hardware.IsAssigned = 0;
            hardware.AssignedTo = null;
            Update(hardware);
            await SaveAsync();
        }

        public async Task RetireHardware(Hardware hardware)
        {
            hardware.IsAssigned = 0;
            hardware.AssignedTo = null;
            hardware.IsRetired = 1;
            Update(hardware);
            await SaveAsync();
        }
    }
}