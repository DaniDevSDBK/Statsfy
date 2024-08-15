using System.Windows.Input;

namespace Statsfy.ViewModel
{
    public class ConfigurationPageViewModel : BaseViewModel
    {
        public ICommand OpenUrlCommand { get; }

        public ConfigurationPageViewModel()
        {
            OpenUrlCommand = new Command<string>(async (url) => await Launcher.OpenAsync(new Uri(url)));
        }
    }
}
