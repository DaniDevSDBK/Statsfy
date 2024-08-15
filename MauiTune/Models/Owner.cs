using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statsfy.Models
{
    public class Owner
    {
        public string DisplayName { get; set; }
        public ExternalUrls ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
