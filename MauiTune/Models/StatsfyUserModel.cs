using Newtonsoft.Json;
using Statsfy.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Statsfy.Model
{
    public class StatsfyUserModel:INotifyPropertyChanged
    {
        private static StatsfyUserModel _instance;
        private SpotifyUserModel _spotifyUserModel;
        private string _name;
        private string _email;
        private List<UserImage> _images;
        private ObservableCollection<Artist> _artists;
        private ObservableCollection<Track> _tracks;
        private ObservableCollection<Album> _albums;
        private ObservableCollection<Playlist> _playlists;

        public event PropertyChangedEventHandler PropertyChanged;

        public SpotifyUserModel SpotifyUserModel { get => _spotifyUserModel; set => _spotifyUserModel = value;}

        private StatsfyUserModel() => _spotifyUserModel = new SpotifyUserModel();
        public static StatsfyUserModel Instance => _instance ?? (_instance = new StatsfyUserModel());

        [JsonProperty("display_name")]
        public string Name { get => _name; set { _name = value; OnPropertyChanged(nameof(_name)); } }

        [JsonProperty("email")]
        public string Email { get => _email; set { _email = value; OnPropertyChanged(nameof(_email)); } }

        [JsonProperty("images")]
        public List<UserImage> Images { get => _images; set { _images = value; OnPropertyChanged(nameof(_images)); } }

        public string ProfileImageUrl => Images?.FirstOrDefault()?.Url;


        public ObservableCollection<Artist> Artists { get => _artists; set { _artists = value; OnPropertyChanged(nameof(_artists)); } }

        public ObservableCollection<Track> Tracks { get => _tracks; set { _tracks = value; OnPropertyChanged(nameof(_tracks)); } }

        public ObservableCollection<Album> Albums { get => _albums; set { _albums = value; OnPropertyChanged(nameof(_albums)); } }
        
        public ObservableCollection<Playlist> Playlists { get => _playlists; set { _playlists = value; OnPropertyChanged(nameof(_playlists)); } }


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
