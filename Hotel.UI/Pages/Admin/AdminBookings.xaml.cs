using Hotel.UI.ViewModels.Admin;

namespace Hotel.UI.Pages.Admin;

public partial class AdminBookings : ContentPage
{
	public AdminBookings(AdminBookingsViewModel adminBookingsViewModel)
	{
		InitializeComponent();
		BindingContext = adminBookingsViewModel;
	}
}