using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace AllinOneNews.ViewModels;

public class FavoritesViewModel : INotifyPropertyChanged
{
    IWeatherService weatherService = new WeatherService(null);

    private ObservableCollection<Channels> favorites;
    public ObservableCollection<Channels> Favorites
    {
        get
        {
            return favorites;
        }

        set
        {
            favorites = value;
            OnPropertyChanged();
        }
    }

    async void Fetch()
    {

        if (Connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("No connectivity!",
                $"Please check internet and try again.", "OK");
            return;
        }

        //var locations = await weatherService.GetLocations(string.Empty);

        var channels = await weatherService.GetChannels(string.Empty);

        UpdateFavoritesChannels(channels);

        OnPropertyChanged(nameof(Channels));

        OnPropertyChanged(nameof(Favorites));

    }

    //private void UpdateFavorites(IEnumerable<Location> locations)
    //{
    //    favorites = new ObservableCollection<Location>();
    //    for (int i = locations.Count() - 1; i >= 0; i--)
    //    {
    //        favorites.Add(locations.ElementAt(i));
    //    }
    //}

    private void UpdateFavoritesChannels(IEnumerable<Channels> channels)
    {
        favorites = new ObservableCollection<Channels>();
        //favorites=channels as ObservableCollection<Channels>;
        ////for (int i = channels.Count() - 1; i >= 0; i--)
        for (int i = 0; i < channels.Count() - 1; i++)
        {
            favorites.Add(channels.ElementAt(i));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
    }

    public FavoritesViewModel()
    {


        Fetch();
    }
}
