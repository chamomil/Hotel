using Hotel.UI.Pages;

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
        }
    }
}