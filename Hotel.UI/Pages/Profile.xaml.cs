using Hotel.UI.ViewModels;

namespace Hotel.UI.Pages;

public partial class Profile : ContentPage
{
	public Profile(ProfileViewModel profileViewModel)
	{
		InitializeComponent();
		BindingContext = profileViewModel;
	}
}