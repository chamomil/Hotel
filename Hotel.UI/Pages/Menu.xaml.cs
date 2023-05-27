using Hotel.UI.ViewModels;

namespace Hotel.UI.Pages;

public partial class Menu : ContentPage
{
	public Menu(MenuViewModel menuViewModel)
	{
		InitializeComponent();
		BindingContext = menuViewModel;
	}
}