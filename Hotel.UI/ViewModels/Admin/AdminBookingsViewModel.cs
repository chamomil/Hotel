using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hotel.Application.Abstractions;
using Hotel.Domain.Entities;
using Hotel.UI.Pages;
using Hotel.UI.Pages.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.ViewModels.Admin
{
    public partial class AdminBookingsViewModel : ObservableObject
    {
        private readonly IBookingDataService _bookDataService;

        public AdminBookingsViewModel(IBookingDataService bookingDataService)
        {
            _bookDataService = bookingDataService;
        }

        [ObservableProperty]
        public ObservableCollection<BookingData> _bookings = new();

        [RelayCommand]
        public async void GetRooms() => await GetRoomsList();

        public async Task GetRoomsList()
        {
            var bookedRooms = await _bookDataService.GetAllAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Bookings = new();
                foreach (var booking in bookedRooms)
                {
                    Bookings.Add(booking);
                }
            });
        }

        [RelayCommand]
        public async void BookingClicked(BookingData booking) => await GoToRoomDetails(booking);

        public async Task GoToRoomDetails(BookingData booking)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "BookingData", booking },
                { "IsConfirmation", false },
                { "IsDeletion", true }
            };
            await Shell.Current.GoToAsync(nameof(RoomDetails), parameters);
        }

        [RelayCommand]
        public async void MenuClicked() => await GoToMenu();

        public async Task GoToMenu()
        {
            await Shell.Current.GoToAsync(nameof(AdminMenu));
        }
    }
}
