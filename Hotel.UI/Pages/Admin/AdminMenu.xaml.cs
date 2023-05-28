using Hotel.UI.ViewModels.Admin;

namespace Hotel.UI.Pages.Admin;

public partial class AdminMenu : ContentPage
{
	public AdminMenu(AdminMenuViewModel adminMenuViewModel)
	{
		InitializeComponent();
		BindingContext = adminMenuViewModel;
	}
}