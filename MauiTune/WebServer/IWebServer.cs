using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    public interface IWebServer
    {
        Task<String> Start(string[] prefixes);
        void Stop();
    }
}
