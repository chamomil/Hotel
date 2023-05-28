using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hotel.UI.Pages;
using Hotel.UI.Pages.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.ViewModels.Admin
{
    public partial class AdminMenuViewModel : ObservableObject
    {
        [RelayCommand]
        public async void SeeBookingsClicked() => await GoToBookings();

        public async Task GoToBookings()
        {
            await Shell.Current.GoToAsync(nameof(AdminBookings));
        }

        [RelayCommand]
        public async void SeeUsersClicked() => await GoToUsers();

        public async Task GoToUsers()
        {
            await Shell.Current.GoToAsync(nameof(AdminUsers));
        }

        [RelayCommand]
        public async void LogOutClicked() => await LogOut();

        public async Task LogOut()
        {
            await Shell.Current.GoToAsync(nameof(LogIn));
        }
    }
}
