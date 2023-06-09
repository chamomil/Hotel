﻿using CommunityToolkit.Mvvm.ComponentModel;
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

        [RelayCommand]
        public async void MyBookingsClicked() => await GoToBookingsList();

        public async Task GoToBookingsList()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "UserId", UserId }
            };
            await Shell.Current.GoToAsync(nameof(BookingsList), parameters);
        }

        [RelayCommand]
        public async void MyProfileClicked() => await GoToProfile();

        public async Task GoToProfile()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "UserId", UserId }
            };
            await Shell.Current.GoToAsync(nameof(Profile), parameters);
        }
    }
}
