using Hotel.UI.Pages;
using Hotel.UI.Pages.Admin;

namespace Hotel.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Home), typeof(Home));
            Routing.RegisterRoute(nameof(SignUp), typeof(SignUp));
            Routing.RegisterRoute(nameof(LogIn), typeof(LogIn));
            Routing.RegisterRoute(nameof(RoomDetails), typeof(RoomDetails));
            Routing.RegisterRoute(nameof(Menu), typeof(Menu));
            Routing.RegisterRoute(nameof(BookingsList), typeof(BookingsList));
            Routing.RegisterRoute(nameof(Profile), typeof(Profile));
            Routing.RegisterRoute(nameof(EditProfile), typeof(EditProfile));
            Routing.RegisterRoute(nameof(AdminBookings), typeof(AdminBookings));
            Routing.RegisterRoute(nameof(AdminMenu), typeof(AdminMenu));
            Routing.RegisterRoute(nameof(AdminUsers), typeof(AdminUsers));
        }
    }
}