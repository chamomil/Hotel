using Hotel.UI.ViewModels;

namespace Hotel.UI.Pages;

public partial class LogIn : ContentPage
{
    public LogIn(LogInViewModel logInViewModel)
    {
        InitializeComponent();
        BindingContext = logInViewModel;
    }
}