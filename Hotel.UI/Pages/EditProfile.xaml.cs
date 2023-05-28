using Hotel.UI.ViewModels;

namespace Hotel.UI.Pages;

public partial class EditProfile : ContentPage
{
	public EditProfile(EditProfileViewModel editProfileViewModel)
	{
		InitializeComponent();
		BindingContext  = editProfileViewModel;
	}
}