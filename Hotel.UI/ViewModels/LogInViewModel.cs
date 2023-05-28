using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hotel.Application.Abstractions;
using Hotel.UI.Pages;
using Hotel.UI.Pages.Admin;

namespace Hotel.UI.ViewModels
{
    public partial class LogInViewModel : ObservableObject
    {
        private readonly IUserService _userService;
        private const string ADMIN_LOGIN = "admin";
        private const string ADMIN_PASSWORD = "admin";

        public LogInViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [ObservableProperty]
        public string _username = string.Empty;
        [ObservableProperty]
        public string _password = string.Empty;

        [ObservableProperty]
        string output = string.Empty;

        [RelayCommand]
        public async void LogInClicked() => await ValidateAndLogIn();

        public async Task ValidateAndLogIn()
        {
            Output = string.Empty;
            if (Username.Length == 0 || Password.Length == 0)
            {
                Output = "Fields should be filled";
                return;
            }
            if (await ValidationCheck())
            {
                int UserId = await _userService.GetUserIdByLogin(Username);
                IDictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "UserId", UserId }
                };
                await Shell.Current.GoToAsync(nameof(Home), parameters);
                return;
            }
            if (Username == ADMIN_LOGIN && Password == ADMIN_PASSWORD)
            {
                await Shell.Current.GoToAsync(nameof(AdminBookings));
                return;
            }
            Output = "Incorrect input";
            return;

        }

        private async Task<bool> ValidationCheck()
        {
            if (await _userService.IsLoginAndPasswordValid(Username, Password))
            {
                return true;
            }
            return false;
        }

        [RelayCommand]
        public void ClearOutput()
        {
            Output = string.Empty;
        }

        [RelayCommand]
        public async void SignUpClicked() => await GoToSignUp();

        public async Task GoToSignUp()
        {
            await Shell.Current.GoToAsync(nameof(SignUp));
        }
    }
}
