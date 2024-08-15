using Statsfy.Model;
using Statsfy.Models;
using Statsfy.Services.NavigationServices;
using Statsfy.ViewModel;
using Statsfy.Views;
using System.ComponentModel;
using System.Windows.Input;

namespace Statsfy.ViewModel
{
    class ShellViewModel : BaseViewModel
    {
        private bool _isVisible = true;
        private string _Name = StatsfyUserModel.Instance.Name;
        private string _Email = StatsfyUserModel.Instance.Name;
        private string _Image = StatsfyUserModel.Instance.Name;

        public string Name { get => _Name; private set => SetProperty(ref _Name, value); }
        public string Email { get => _Email; private set => SetProperty(ref _Email, value); }
        public string Image { get => _Image; private set => SetProperty(ref _Image, value); }

                #region Navigation
        private NavigationService _NavigationService;
        #endregion


        #region ICommands
        public ICommand LogOutWithSpotifyCommand { get; set; }
        #endregion

        public ShellViewModel()
        {
            _NavigationService = new NavigationService();
            LogOutWithSpotifyCommand = new Command(LogOutFromSpotify);
            StatsfyUserModel.Instance.PropertyChanged += OnUserPropertyChanged;
        }

        private void LogOutFromSpotify() =>
            this.CloseSession();

        private async void CloseSession()
        {
            await Application.Current.MainPage.Dispatcher.DispatchAsync(async () =>
            {
                var result = await Application.Current.MainPage.DisplayAlert(
                    "Cerrar Sesión",
                    "¿Estás seguro de que deseas cerrar sesión?",
                    "Sí",
                    "No");

                if (result)
                {
                    await _NavigationService.NavigateTo($"//{nameof(LogInPageView)}");
                }
            });
        }

        private void OnUserPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
                Name = StatsfyUserModel.Instance.Name??"User Name";
                Email = StatsfyUserModel.Instance.Email??"User Email";
                Image = StatsfyUserModel.Instance.ProfileImageUrl;
        }
    }
}
