namespace AllinOneNews;

public interface IWeatherService
{
    // Task<IEnumerable<Location>> GetLocations(string query);
    //Task<WeatherResponse> GetWeather(Coordinate location);

    Task<IEnumerable<Channels>> GetChannels(string query);

}