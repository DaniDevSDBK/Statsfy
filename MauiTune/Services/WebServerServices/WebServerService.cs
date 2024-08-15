namespace Statsfy.Services.WebServerServices
{
    public class WebServerService
    {
        private WebServer.IWebServer _webServer;

        public WebServer.IWebServer WebServer => _webServer;

        public WebServerService()
        {
            _webServer = new WebServer.WebServer();
        }

        public async Task<String> Start(String[] prefixes) =>
            await Task.Run(() => WebServer.Start(prefixes));

        public void Stop() =>
            WebServer.Stop();
    }
}
