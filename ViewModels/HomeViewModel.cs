using AllinOneNews.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AllinOneNews.ViewModels;

public class HomeViewModel : INotifyPropertyChanged
{
    public List<Forecast> Week { get; set; }

    public List<Forecast> Hours { get; set; }

    public Command QuitCommand { get; set; } = new Command(() =>
    {
        Application.Current.Quit();
    });

    public Command AddLocationCommand { get; set; } = new Command(() =>
    {
        // nav to modal form
    });

    public Command<string> ChangeLocationCommand { get; set; } = new Command<string>((location) =>
    {
        // change primary location
    });

    public Command RefreshCommand { get; set; } = new Command(() =>
    {
        // fake a refresh call
    });

    private Command toggleModeCommand;

    public Command ToggleModeCommand
    {
        get
        {
            return toggleModeCommand;
        }
        set
        {
            toggleModeCommand = value;
            OnPropertyChanged();
        }
    }

    public HomeViewModel()
    {
        //InitData();

        ToggleModeCommand = new Command(() =>
        {
            App.Current.UserAppTheme = App.Current.UserAppTheme == AppTheme.Light ? AppTheme.Dark : AppTheme.Light;
        });
    }



    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
    }

}
