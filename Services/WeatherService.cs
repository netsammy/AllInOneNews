﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Channels;

//All-in-One News
//AllinOneNews
namespace AllinOneNews;

public class WeatherService : IWeatherService
{
    static List<Location> locations = new()
    {
        new Location { Name = "Redmond", Coordinate = new Coordinate(47.6740, 122.1215), Icon = "fluent_weather_cloudy_20_filled.png", WeatherStation = "USA", Value = "62°" },
        new Location { Name = "St. Louis", Coordinate = new Coordinate(38.6270, 90.1994), Icon = "fluent_weather_rain_showers_night_20_filled.png", WeatherStation = "USA", Value = "74°" },
        new Location { Name = "Boston", Coordinate = new Coordinate(42.3601, 71.0589), Icon = "fluent_weather_cloudy_20_filled.png", WeatherStation = "USA", Value = "54°" },
        new Location { Name = "NYC", Coordinate = new Coordinate(40.7128, 74.0060), Icon = "fluent_weather_cloudy_20_filled.png", WeatherStation = "USA", Value = "63°" },
        new Location { Name = "Amsterdam", Coordinate = new Coordinate(52.3676, 4.9041), Icon = "fluent_weather_cloudy_20_filled.png", WeatherStation = "USA", Value = "49°" },
        new Location { Name = "Seoul", Coordinate = new Coordinate(37.5665, 126.9780), Icon = "fluent_weather_cloudy_20_filled.png", WeatherStation = "USA", Value = "56°" },
        new Location { Name = "Johannesburg", Coordinate = new Coordinate(26.2041, 28.0473), Icon = "fluent_weather_sunny_20_filled.png", WeatherStation = "USA", Value = "62°" },
        new Location { Name = "Rio", Coordinate = new Coordinate(22.9068, 43.1729), Icon = "fluent_weather_sunny_20_filled.png", WeatherStation = "USA", Value = "79°" },
        new Location { Name = "Madrid", Coordinate = new Coordinate(40.4168, 3.7038), Icon = "fluent_weather_sunny_20_filled.png", WeatherStation = "USA", Value = "71°" },
        new Location { Name = "Buenos Aires", Coordinate = new Coordinate(34.6037, 58.3816), Icon = "fluent_weather_sunny_20_filled.png", WeatherStation = "USA", Value = "61°" },
        new Location { Name = "Punta Cana", Coordinate = new Coordinate(18.5601, 68.3725), Icon = "fluent_weather_rain_showers_day_20_filled.png", WeatherStation = "USA", Value = "84°" },
        new Location { Name = "Hyderabad", Coordinate = new Coordinate(17.3850, 78.4867), Icon = "fluent_weather_sunny_20_filled.png", WeatherStation = "USA", Value = "84°" },
        new Location { Name = "San Francisco", Coordinate = new Coordinate(37.7749, 122.4194), Icon = "fluent_weather_sunny_20_filled.png", WeatherStation = "USA", Value = "69°" },
        new Location { Name = "Nairobi", Coordinate = new Coordinate(1.2921, 36.8219), Icon = "fluent_weather_rain_20_filled.png", WeatherStation = "USA", Value = "67°" },
        new Location { Name = "Lagos", Coordinate = new Coordinate(6.5244, 3.3792), Icon = "fluent_weather_partly_cloudy.png", WeatherStation = "USA", Value = "83°" }
    };

    private readonly HttpClient httpClient;

    public WeatherService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public Task<IEnumerable<Location>> GetLocations(string query)
        => Task.FromResult(locations.Where(l => l.Name.Contains(query)));

    public Task<WeatherResponse> GetWeather(Coordinate location)
        => httpClient.GetFromJsonAsync<WeatherResponse>($"/weather/{location}");

    public async Task<IEnumerable<Channels>> GetChannels(string query)
    {

        try
        {
            // Create a new HttpClient object.
            HttpClient httpClient = new HttpClient();

            // Get the JSON data from the URL.
            // HttpResponseMessage response = httpClient.GetAsync("https://api.tvmaze.com/shows").Result;

            //"https://raw.githubusercontent.com/netsammy/gh-pages/main/data.json"


            //string jsonFile = "D:\\abdus projects\\MAUI\\2023\\AllinOneNews\\src\\AllinOneNews\\Data\\data.json";
            //string jsonFile = "https://raw.githubusercontent.com/netsammy/gh-pages/main/data.json";

            // Create a new List<Channels> object.
            IEnumerable<Channels> channels;//= new IEnumerable<Channels>();
            string jsonFileUrl = "https://raw.githubusercontent.com/netsammy/gh-pages/main/data.json";

            using (HttpClient client = new HttpClient())
            {
                string jsonData = await client.GetStringAsync(jsonFileUrl);

                var jsonSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                var menu = JObject.Parse(jsonData)["Menu"].ToString();
                channels = JsonConvert.DeserializeObject<List<Channels>>(menu, jsonSettings);

                var channelsSorted = channels.OrderBy(c => c.Country );

                return channelsSorted;
            }


            //string jsonData = File.ReadAllText(jsonFile);


            //// Create a new List<Channels> object.
            //IEnumerable<Channels> channels;//= new IEnumerable<Channels>();


            //var jsonSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            //var menu = JObject.Parse(jsonData)["Menu"].ToString();
            //channels = JsonConvert.DeserializeObject<List<Channels>>(menu, jsonSettings);



            //return channels;

            //return Task.FromResult(channels);

        }catch(Exception ex)
        {
            List<Channels> channels = new List<Channels>();
            Channels channel= new Channels();
            channel.Name = ex.Message;
            channel.Category = ex.StackTrace;

            channels.Add(channel);
            IEnumerable<Channels> channelsEnumerable = channels;

            //return Task.FromResult(channelsEnumerable);
            return channelsEnumerable;

        }
        //// Check the response status code.
        //if (response.StatusCode == HttpStatusCode.OK)
        //{


        //    // Deserialize the JSON data into the List<Channels> object.
        //     channels = JsonConvert.DeserializeObject<List<Channels>>(response.Content.ReadAsStringAsync().Result);

        //    return Task.FromResult(channels);
        //    //// Iterate through the List<Channels> object and print the channel names.
        //    //foreach (var channel in channels)
        //    //{
        //    //    Console.WriteLine(channel.Name);
        //    //}
        //}

        return null;

    }

        

}