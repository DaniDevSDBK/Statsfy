using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Statsfy.Models
{
    public class Tracks
    {
        public string Href { get; set; }
        public int Total { get; set; }

        [JsonProperty("tracks")]
        public TracksItems TracksItems { get; set; }
    }
}
