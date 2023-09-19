using AllinOneNews.ViewModels;

namespace AllinOneNews.Views;

public partial class Next24HrWidget
{
    public Next24HrWidget()
    {
        InitializeComponent();

        BindingContext = new HomeViewModel();
    }
}
