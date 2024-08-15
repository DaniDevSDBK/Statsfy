using Statsfy.Model;
using Statsfy.Models;
using Statsfy.Services.SpotifyApiService;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Statsfy.ViewModel
{
    public class DiscoverPageViewModel : BaseViewModel
    {
        #region ICommands
        public ICommand SearchIntoSpotifyCommand { get; }
        public ICommand AddFilterCommand { get; }
        public ICommand RemoveFilterCommand { get; }

        #endregion

        public ObservableCollection<SearchType> SearchTypes { get; set; }
        public ObservableCollection<SearchType> SelectedFilters { get; set; }

        private SearchType _selectedSearchType;
        public SearchType SelectedSearchType
        {
            get { return _selectedSearchType; }
            set { _selectedSearchType = value; OnPropertyChanged(nameof(SelectedSearchType)); }
        }

        private string _UserSearchItem;
        public string UserSearchItem
        {
            get { return _UserSearchItem; }
            set { _UserSearchItem = value; OnPropertyChanged(nameof(UserSearchItem)); }
        }

        public string Query => string.Join("%2C", SelectedFilters.Select(filter => filter.ToString()));

        private ObservableCollection<Artist> _Artists;
        public ObservableCollection<Artist> Artists
        {
            get { return _Artists; }
            private set
            {
                SetProperty(ref _Artists, value);
            }
        }

        private ObservableCollection<Album> _Albums;
        public ObservableCollection<Album> Albums
        {
            get { return _Albums; }
            private set
            {
                SetProperty(ref _Albums, value);
            }
        }

        private ObservableCollection<Track> _Tracks;
        public ObservableCollection<Track> Tracks
        {
            get { return _Tracks; }
            private set
            {
                SetProperty(ref _Tracks, value);
            }
        }
        
        private ObservableCollection<Playlist> _Playlists;
        public ObservableCollection<Playlist> Playlists
        {
            get { return _Playlists; }
            private set
            {
                SetProperty(ref _Playlists, value);
            }
        }

        public DiscoverPageViewModel()
        {
            SearchIntoSpotifyCommand = new Command(SearchIntoSpotify);
            SearchTypes = new ObservableCollection<SearchType>(Enum.GetValues(typeof(SearchType)).Cast<SearchType>());
            SelectedFilters = new ObservableCollection<SearchType>();
            AddFilterCommand = new Command(AddFilter);
            RemoveFilterCommand = new Command<SearchType>(RemoveFilter);
            StatsfyUserModel.Instance.PropertyChanged += OnUserPropertyChanged;
        }

        private async void SearchIntoSpotify()
        {
            if (String.IsNullOrWhiteSpace(UserSearchItem) ) {  return; }

            await SpotifySearch(new SpotifyApiService());
        }

        private async Task SpotifySearch(SpotifyApiService service)
        {
            await service.SpotifySearch(UserSearchItem, Query);
        }

        private void AddFilter()
        {
            if (!SelectedFilters.Contains(SelectedSearchType))
            {
                SelectedFilters.Add(SelectedSearchType);
            }
        }

        private void RemoveFilter(SearchType filter)
        {
            if (SelectedFilters.Contains(filter))
            {
                SelectedFilters.Remove(filter);
            }
        }

        private void OnUserPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Artists = StatsfyUserModel.Instance.Artists;
            Albums = StatsfyUserModel.Instance.Albums;
            Tracks = StatsfyUserModel.Instance.Tracks;
            Playlists = StatsfyUserModel.Instance.Playlists;
        }
    }
}
