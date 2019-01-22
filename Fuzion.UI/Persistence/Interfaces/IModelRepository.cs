using Fuzion.UI.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuzion.UI.Persistence.Interfaces
{
    public interface IModelRepository
    {
        Task<IEnumerable<Model>> GetAllModelsAsync();

        Task<Model> GetModelByIdAsync(int id);

        Task CreateModelAsync(Model model);

        Task UpdateModelAsync(Model model);

        Task DeleteModelAsync(Model model);
    }
}