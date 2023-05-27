using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hotel.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.ViewModels
{
    [QueryProperty("UserId", "UserId")]
    public partial class MenuViewModel : ObservableObject
    {
        [ObservableProperty]
        public int _userId;

        [RelayCommand]
        public async void BookRoomClicked() => await GoToBooking();

        public async Task GoToBooking()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "UserId", UserId }
            };
            await Shell.Current.GoToAsync(nameof(Home), parameters);
        }

        [RelayCommand]
        public async void LogOutClicked() => await GoToLogIn();

        public async Task GoToLogIn()
        {
            await Shell.Current.GoToAsync(nameof(LogIn));
        }
    }
}
