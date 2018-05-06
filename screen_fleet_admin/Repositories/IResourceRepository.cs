using screen_fleet_admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace screen_fleet_admin.Repositories
{
    public interface IResourceRepository
    {
        Task<IEnumerable<ResourceModel>> GetAllResources();
        Task<ResourceModel> GetSpecificResource(string id);
        Task<bool> RemoveSpecificResource(string id);
        Task<bool> UpdateResource(string id, ResourceModel newResource);
        Task AddNewResource(ResourceModel resource);
    }
}
