using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statsfy.Services.SpotifyService
{
    interface IApiSpotifyRepositoryService
    {
        Task GetUserTopItems(string type);
    }
}
