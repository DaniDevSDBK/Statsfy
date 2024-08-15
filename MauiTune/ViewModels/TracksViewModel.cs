using Statsfy.Model;
using Statsfy.Models;
using Statsfy.Services.SpotifyApiService;
using Statsfy.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Statsfy.ViewModels
{
    public class TracksViewModel : BaseViewModel
    {
        private ObservableCollection<Track> _Tracks;
        public ObservableCollection<Track> Tracks
        {
            get { return _Tracks; }
            private set
            {
                SetProperty(ref _Tracks, value);
            }
        }

        public TracksViewModel()
        {
            StatsfyUserModel.Instance.PropertyChanged += OnUserPropertyChanged;
            GetUserTopItems(new SpotifyApiService());
        }

        private void OnUserPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Tracks = StatsfyUserModel.Instance.Tracks;
        }

        private async Task GetUserTopItems(SpotifyApiService service) =>
            await service.GetUserTopItems("tracks");

    }
}
