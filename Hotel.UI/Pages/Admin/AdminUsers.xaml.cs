using Hotel.UI.ViewModels.Admin;

namespace Hotel.UI.Pages.Admin;

public partial class AdminUsers : ContentPage
{
	public AdminUsers(AdminUsersViewModel adminUsersViewModel)
	{
		InitializeComponent();
		BindingContext = adminUsersViewModel;
	}
}