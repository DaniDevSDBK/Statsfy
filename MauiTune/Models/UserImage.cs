using Newtonsoft.Json;

namespace Statsfy.Models
{
    public class UserImage
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }
}
