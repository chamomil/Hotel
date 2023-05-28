using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hotel.Application.Abstractions;
using Hotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.ViewModels
{
    [QueryProperty("UserId", "UserId")]
    public partial class EditProfileViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        public EditProfileViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [ObservableProperty]
        public int _userId;

        [ObservableProperty]
        public User _currentUser = new();
        [ObservableProperty]
        public string output = string.Empty;

        [RelayCommand]
        public async void LoadInfo() => await GetUser();

        public async Task GetUser()
        {
            CurrentUser = await _userService.GetByIdAsync(UserId);
        }

        [RelayCommand]
        public void ClearOutput()
        {
            Output = string.Empty;
        }

        [RelayCommand]
        public async void SubmitClicked() => await SubmitAndGoBack();

        public async Task SubmitAndGoBack()
        {
            if (CurrentUser.Name.Length == 0 || CurrentUser.Surname.Length == 0)
            {
                Output = "Required fields should be filled";
                return;
            }

            if (CurrentUser.DateOfBirth.Date == DateTime.Now.Date)
            {
                Output = "Are you a newborn? So sweet. But call the adults";
                return;
            }

            await _userService.UpdateAsync(CurrentUser);
            await Shell.Current.GoToAsync("..");
        }
    }
}
