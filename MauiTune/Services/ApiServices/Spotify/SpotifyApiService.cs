using Statsfy.Models;
using Statsfy.Services.ApiServices;
using Statsfy.Services.AuthenticationServices;
using Statsfy.Services.SpotifyService;
using Statsfy.Services.WebServerServices;

namespace Statsfy.Services.SpotifyApiService
{
    public class SpotifyApiService : BaseApiService, IApiSpotifyRepositoryService
    {
        private SpotifyAuthenticationService _authenticationService;
        private WebServerService _server;

        public SpotifyApiService()
        {
            _authenticationService = new SpotifyAuthenticationService();
            _server = new WebServerService();
        }

        public string GenAuthUrl() =>
            RunInBackgroundColor(() => _authenticationService.GenAuthUrl()).First().ToString();

        public async Task StartWebServer() => 
            await _authenticationService.GetAccessTokenAsync(await _server.Start(new String[] { _authenticationService.GetRedirectUri() }));

        public void StopWebServer() => 
            _server.Stop();

        public async Task GetUser() =>
            await _authenticationService.GetUser();

        public async Task GetUserTopItems(string type) =>
            await _authenticationService.GetUserTopItems(type);
        
        public async Task SpotifySearch(String item,String query) =>
            await _authenticationService.SpotifySearch(item,query);
    }
}
