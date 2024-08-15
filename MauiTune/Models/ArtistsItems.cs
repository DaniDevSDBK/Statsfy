using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Statsfy.Models
{
    public class ArtistsItems
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("items")]
        public ObservableCollection<Artist> Artists { get; set; }
    }
}
