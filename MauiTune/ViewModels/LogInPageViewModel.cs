using Statsfy.Model;
using Statsfy.Services.NavigationServices;
using Statsfy.Services.SpotifyApiService;
using Statsfy.Views;
using System.Security.Principal;
using System.Windows.Input;

namespace Statsfy.ViewModel
{
    public class LogInPageViewModel : BaseViewModel
    {
        #region Navigation
        private NavigationService _NavigationService;
        #endregion

        #region ICommands
        public ICommand LoginWithSpotifyCommand { get; }
        #endregion

        public LogInPageViewModel()
        {
            _NavigationService = new NavigationService();
            LoginWithSpotifyCommand = new Command(LoginWithSpotify);
        }

        private async void LoginWithSpotify()
        {
            var service = new SpotifyApiService();
            var authUrl = service.GenAuthUrl();

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = authUrl,
                    UseShellExecute = true
                });

                await StartServer(service);
                await GetUser(service);
                ValidateUser();
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected Error");
            }
        }

        private async Task StartServer(SpotifyApiService service) =>
            await service.StartWebServer();
        
        private async Task GetUser(SpotifyApiService service)
        {
            await service.GetUser();
        }

        private async void ValidateUser()
        {
            if (!String.IsNullOrWhiteSpace(StatsfyUserModel.Instance.SpotifyUserModel.AccessToken))
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(StatsfyUserModel.Instance.Name), null);
            }
            await _NavigationService.NavigateTo($"//{nameof(HomePageView)}");
        }
    }
}
