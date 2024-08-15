using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Statsfy.Models
{
    public class PlaylistsItems
    {
        [JsonProperty("href")]
        public string Href { get; set; }
        
        [JsonProperty("items")]
        public ObservableCollection<Playlist> Playlists { get; set; }
    }
}