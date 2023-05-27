using Hotel.UI.ViewModels;

namespace Hotel.UI.Pages;

public partial class SignUp : ContentPage
{
    public SignUp(SignUpViewModel signUpViewModel)
    {
        InitializeComponent();
        BindingContext = signUpViewModel;
    }
}