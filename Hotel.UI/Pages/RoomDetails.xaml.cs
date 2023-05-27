using Hotel.UI.ViewModels;

namespace Hotel.UI.Pages;

public partial class RoomDetails : ContentPage
{
	public RoomDetails(RoomDetailsViewModel roomDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = roomDetailsViewModel;
	}
}