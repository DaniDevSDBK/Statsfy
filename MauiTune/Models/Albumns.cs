using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Statsfy.Models
{
    public class Albumns
    {
        [JsonProperty("albums")]
        public AlbumsItems AlbumsItems { get; set; }
    }
}
