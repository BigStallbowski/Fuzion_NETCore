using Fuzion.UI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface IManufacturerRepository
    {
        Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync();

        Task<Manufacturer> GetManufacturerByIdAsync(int id);

        Task CreateManufacturerAsync(Manufacturer manufacturer);

        Task UpdateManufacturerAsync(Manufacturer manufacturer);

        Task DeleteManufacturerAsync(Manufacturer manufacturer);
    }
}