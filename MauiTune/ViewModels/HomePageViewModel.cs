using Statsfy.Model;
using Statsfy.Models;
using Statsfy.Services.SpotifyApiService;
using Statsfy.Services.SpotifyService;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Statsfy.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        private ObservableCollection<Artist> _Artists;
        public ObservableCollection<Artist> Artists
        {
            get { return _Artists; }
            private set { 
                SetProperty(ref _Artists, value);
            }
        }

        public HomePageViewModel()
        {
            StatsfyUserModel.Instance.PropertyChanged += OnUserPropertyChanged;
            GetUserTopItems(new SpotifyApiService());
        }

        private void OnUserPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Artists = StatsfyUserModel.Instance.Artists;
        }

        private async Task GetUserTopItems(SpotifyApiService service) =>
            await service.GetUserTopItems("artists");
    }

}