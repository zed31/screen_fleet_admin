using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using screen_fleet_admin.Models;

namespace screen_fleet_admin.Repositories
{
    public interface ITVRepository
    {
        Task<IEnumerable<TVModel>> GetAllTVScreens();
        Task<TVModel> GetTVScreen(string name);
        Task AddTVScreen(TVModel item);
        Task<bool> RemoveTVScreen(string name);
        Task<bool> UpdateTVScreen(string name, TVModel tv);
        Task<bool> RemoveAllTVScreen();
    }
}
