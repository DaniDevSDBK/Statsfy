namespace Statsfy.Services.NavigationServices
{
    public class NavigationService : INavigation
    {
        public IReadOnlyList<Page> ModalStack => Shell.Current?.Navigation.ModalStack;

        public IReadOnlyList<Page> NavigationStack => Shell.Current?.Navigation.NavigationStack;

        public void InsertPageBefore(Page page, Page before) =>
            Shell.Current.Navigation.InsertPageBefore(page, before);

        public Task<Page> PopAsync() =>
            Shell.Current.Navigation.PopAsync();

        public Task<Page> PopAsync(bool animated) =>
            Shell.Current.Navigation.PopAsync(animated);

        public Task<Page> PopModalAsync() => 
            Shell.Current.Navigation.PopModalAsync();

        public Task<Page> PopModalAsync(bool animated) =>
            Shell.Current.Navigation.PopModalAsync(animated);

        public Task PopToRootAsync() =>
            Shell.Current.Navigation.PopToRootAsync();

        public Task PopToRootAsync(bool animated) =>
            Shell.Current.Navigation.PopToRootAsync(animated);

        public Task PushAsync(Page page) => 
            Shell.Current.Navigation.PushAsync(page);

        public Task PushAsync(Page page, bool animated) => 
            Shell.Current.Navigation.PushAsync(page, animated);

        public Task PushModalAsync(Page page) => 
            Shell.Current.Navigation.PushModalAsync(page);

        public Task PushModalAsync(Page page, bool animated) => 
            Shell.Current.Navigation.PushModalAsync(page, animated);

        public void RemovePage(Page page) =>
            Shell.Current.Navigation.RemovePage(page);

        public async Task NavigateTo(string route) => 
            await Shell.Current.GoToAsync(route);
    }
}
