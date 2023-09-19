using Microsoft.Maui.Controls.Xaml;
using AllinOneNews.ViewModels;
using Microsoft.Maui.Controls;


namespace AllinOneNews.Pages;

public partial class FavoritesPage : ContentPage
{
    public FavoritesPage()
    {
        InitializeComponent();

        BindingContext = new FavoritesViewModel();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await Task.Delay(300);
        TransitionIn();
    }

    async void TransitionIn()
    {
        foreach (var item in tiles)
        {
            await item.FadeTo(1, 800);
            await Task.Delay(50);
        }
    }

    int tileCount = 0;
    List<Frame> tiles = new List<Frame>();
    void OnHandlerChanged(object sender, EventArgs e)
    {
        Frame f = (Frame)sender;
        tiles.Add(f);
        tileCount++;
    }

    //implement ImageButton_Clicked
    async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MapPage());
    }
    //implement TapGestureRecognizer_Tapped get commandparamter from xaml


    async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
    {
        try
        {
            try
            {
                var image = (Button)sender;
                var data = image.BindingContext;
                string url = ((AllinOneNews.Channels)image.BindingContext).URL;
                
                await Navigation.PushAsync(new MapPage(url));
            }
            catch (Exception ex)
            {
                // Handle the exception
            }
        }
        catch (Exception ex)
        {
            //Debug.WriteLine($"err: {ex.Message}");
        }
    }

    private MapPage _mapPageInstance;

    async void Image_Tapped(object sender, EventArgs e)
    {


        try
        {
            var image = (Image)sender;
            var data = image.BindingContext;
            string url = ((AllinOneNews.Channels)image.BindingContext).URL;

            var mapPage = new MapPage(url);
            await Navigation.PushAsync(mapPage);
        }
        catch (Exception ex)
        {
            // Handle the exception
        }




        //try
        //{
        //    var image = (Image)sender;
        //    var data = image.BindingContext;
        //    string url = ((AllinOneNews.Channels)image.BindingContext).URL;

        //    await Navigation.PushAsync(new MapPage(url));
        //}
        //catch (Exception ex)
        //{
        //    // Handle the exception
        //}
    }
}
