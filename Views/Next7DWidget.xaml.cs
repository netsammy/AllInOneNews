using AllinOneNews.ViewModels;

namespace AllinOneNews.Views;

public partial class Next7DWidget
{
    public Next7DWidget()
    {
        InitializeComponent();

        BindingContext = new HomeViewModel();
    }
}
