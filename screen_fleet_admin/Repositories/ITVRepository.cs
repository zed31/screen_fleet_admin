using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using screen_fleet_admin.Models;

namespace screen_fleet_admin.Repositories
{
    public interface ITVRepository
    {
        Task<IEnumerable<TVModels>> GetAllTVScreens();
        Task<TVModels> GetTVScreen(string name);
        Task AddTVScreen(TVModels item);
        Task<bool> RemoveTVScreen(string name);
        Task<bool> UpdateTVScreen(string name);
        Task<bool> UpdateTVScreen(string name, TVModels tv);
        Task<bool> RemoveAllTVScreen();
    }
}
