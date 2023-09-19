//using Microsoft.UI.Xaml.Controls;

namespace AllinOneNews.Pages;

public partial class MapPage : ContentPage
{
    public MapPage()
    {
        InitializeComponent();
    }


    // private WebView _webView;

    public MapPage(string url)
    {
        //destroy the previous instance OnBackButtonPressed
        _webView = new WebView();


        //this.OnBackButtonPressed
        InitializeComponent();


        _webView = new WebView
        {
            Source = new UrlWebViewSource { Url = url }
        };

        Content = _webView;
    }


    //    protected override bool OnBackButtonPressed()
    //    {
    //        // Destroy the MapPage 
    //        //_webView.ClearValue(WebView.SourceProperty);
    //        //_webView.Reload();
    //        //_webView.RemoveBinding(WebView.SourceProperty);
    //        //_webView.BindingContext = null;
    //        try
    //        {

    ////#if WINDOWS
    ////            var platformView = _webView.Handler.PlatformView as WebView;
    ////            platformView.CoreWebView.CookieManager.DeleteAllCookies();
    ////#endif
    //            //_webView.Source = null;

    //            //_webView = null;
    //            Content = null;
    //            // _webView.Reload();
    //            GC.Collect();

    //        }
    //        catch { }




    //        return base.OnBackButtonPressed();
    //    }


    protected override void OnDisappearing()
    {

        base.OnDisappearing();

        try
        {



            //

            //_webView = null;
            _webView.Reload();
            _webView.Source.BindingContext = null;
            _webView.Source.ClearValue(WebView.SourceProperty);
            grid.Children.Remove(_webView);
            Content = null;

            //GC.Collect();

        }
        catch { }


    }




#pragma warning disable CS0169 // The field 'MapPage._instance' is never used
    private static MapPage _instance;
#pragma warning restore CS0169 // The field 'MapPage._instance' is never used
#pragma warning disable CS0169 // The field 'MapPage._url' is never used
    private string _url;
#pragma warning restore CS0169 // The field 'MapPage._url' is never used


}
