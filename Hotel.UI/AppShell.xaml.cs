using Hotel.UI.Pages;

namespace Hotel.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Home), typeof(Home));
        }
    }
}