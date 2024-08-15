using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Statsfy.Models
{
    public class Playlists
    {
        [JsonProperty("playlists")]
        public PlaylistsItems PlaylistsItems { get; set; }
    }
}
