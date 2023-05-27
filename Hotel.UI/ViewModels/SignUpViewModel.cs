using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hotel.Application.Abstractions;
using Hotel.Domain.Entities;
using Hotel.UI.Pages;

namespace Hotel.UI.ViewModels
{
    public partial class SignUpViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        public SignUpViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [ObservableProperty]
        public string _name = string.Empty;
        [ObservableProperty]
        public string _surname = string.Empty;
        [ObservableProperty]
        public string _fathersName = string.Empty;
        [ObservableProperty]
        public string _login = string.Empty;
        [ObservableProperty]
        public string _password = string.Empty;
        [ObservableProperty]
        public DateTime _bday = DateTime.Now;
        [ObservableProperty]
        public string _comment = string.Empty;

        [ObservableProperty]
        public string _output = string.Empty;

        [RelayCommand]
        public async void LogInClicked() => await GoToLogIn();

        public async Task GoToLogIn()
        {
            await Shell.Current.GoToAsync(nameof(LogIn));
        }

        [RelayCommand]
        public async void SignUpClicked() => await AddUserAndLogIn();

        public async Task AddUserAndLogIn()
        {
            if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Surname) || string.IsNullOrEmpty(Login) ||
                string.IsNullOrEmpty(Password))
            {
                Output = "Required fields should be filled";
                return;
            }
            if (await _userService.IsLoginAvailable(Login))
            {
                var newUser = new User()
                {
                    Name = Name,
                    Login = Login,
                    Comment = Comment,
                    DateOfBirth = Bday,
                    FathersName = FathersName,
                    Password = Password,
                    Surname = Surname
                };
                await _userService.AddAsync(newUser);

                IDictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "UserId", newUser.Id }
                };
                await Shell.Current.GoToAsync(nameof(Home), parameters);
            } else
            {
                Output = $"Login '{Login}' is already taken";
                return;
            }
            
        }

        [RelayCommand]
        public void ClearOutput()
        {
            Output = string.Empty;
        }
    }
}
