using Statsfy.Services.NavigationServices;
using Statsfy.ViewModel;
using Statsfy.Views;

namespace Statsfy;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FA6Solid900");
                fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FA6Regular400");
                fonts.AddFont("Font Awesome 6 Brands-Regular-400.otf", "FA6BrandReg");
            });

        #region Services
        builder.Services.AddSingleton<INavigation, NavigationService>();
        #endregion

        return builder.Build();
    }
}
