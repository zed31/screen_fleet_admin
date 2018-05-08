using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using screen_fleet_admin.Models;

namespace screen_fleet_admin.Repositories
{
    public interface ITVRepository
    {
        /*! \brief Get all the tv data from the Mongo context
         * @return an async task containing a collection of TVModel
         */
        Task<IEnumerable<TVModel>> GetAllTVScreens();

        /*! \brief Get a specific tv screen according to its raw id
         * @param[in]   rawId    the raw id of the tv screen
         * @return an async task containing the tv model
         */
        Task<TVModel> GetTVScreen(string name);

        /*! \brief Add tv Model to the database
         * @param[in]   model   the model to be inserted
         */
        Task AddTVScreen(TVModel item);

        /*! \brief Remove a specific tv with the specific RawId
         * @param[in]   rawId   The raw id of the tv screen
         * @return      an asynchronous task wrapping a boolean, true if the deletion happened successfully, false otherwise
         */
        Task<bool> RemoveTVScreen(string name);

        /*! \brief Update the specific tv screen that maps the specific raw id
         * @param[in]   rawId   The RawId of the specific model
         * @param[in]   tv      The TV model
         * @return  an asynchronous task wrapping a boolean, return true if the modification has successfully done, false
         *          otherwise
         */
        Task<bool> UpdateTVScreen(string name, TVModel tv);

        /*! \brief Remove all the tv screens
         * @return  an asynchronous task wrapping a boolean, return true if the deletion has been successfully done, false
         *          otherwise
         */
        Task<bool> RemoveAllTVScreen();
        
        /*! \brief Modify the content of a TV screen by updating every resources in it
         * @param[in]   rawId   the raw id of the TV screen
         * @param[in]   tv      the model binding of the TV
         * @return      an asynchronous task set to true if the modification has been taken into account, false otherwise
         */
        Task<bool> UpdateTVScreenContent(string rawId, TVModel tv);
    }
}
