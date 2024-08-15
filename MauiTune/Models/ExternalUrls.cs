using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statsfy.Models
{
    public class ExternalUrls
    {
        [JsonProperty("spotify")]
        public string Spotify { get; set; }
    }
}
