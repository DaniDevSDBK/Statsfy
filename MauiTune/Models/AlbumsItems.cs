using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Statsfy.Models
{
    public class AlbumsItems
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("items")]
        public ObservableCollection<Album> Albumns { get; set; }
    }
}