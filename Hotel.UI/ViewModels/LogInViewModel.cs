using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hotel.Application.Abstractions;
using Hotel.UI.Pages;

namespace Hotel.UI.ViewModels
{
    public partial class LogInViewModel : ObservableObject
    {
        private readonly IUserService _userService;

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
            if (await ValidationCheck())
            {
                await Shell.Current.GoToAsync(nameof(Home));
            }
            else if (Output == string.Empty)
            {
                Output = "Incorrect input";
            }
        }

        private async Task<bool> ValidationCheck()
        {
            if (Username.Length > 0 && Password.Length > 0)
            {
                return await _userService.IsLoginAndPasswordValid(Username, Password);
            }
            Output = "Fields should be filled";
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
