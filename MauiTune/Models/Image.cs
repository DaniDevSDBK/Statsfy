using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statsfy.Models
{

    public class Image
    {
        private string _Url = String.Empty;

        [JsonProperty("url")]
        public string Url { get=> _Url; set => _Url = value; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        public Image() 
        {
            _Url = "Image not disponible";
        }
    }
}
