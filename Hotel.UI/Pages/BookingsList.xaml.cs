using Hotel.UI.ViewModels;

namespace Hotel.UI.Pages;

public partial class BookingsList : ContentPage
{
	public BookingsList(BookingsListViewModel bookingsListViewModel)
	{
		InitializeComponent();
		BindingContext = bookingsListViewModel;
	}
}