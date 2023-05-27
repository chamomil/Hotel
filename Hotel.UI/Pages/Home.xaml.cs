using Hotel.UI.ViewModels;

namespace Hotel.UI.Pages;

public partial class Home : ContentPage
{
    public Home(HomeViewModel homeViewModel)
    {
        InitializeComponent();
        BindingContext = homeViewModel;
    }
}