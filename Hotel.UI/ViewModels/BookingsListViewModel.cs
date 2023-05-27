using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hotel.Application.Abstractions;
using Hotel.Domain.Entities;
using Hotel.UI.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.ViewModels
{
    [QueryProperty("UserId", "UserId")]
    public partial class BookingsListViewModel : ObservableObject
    {
        private readonly IRoomService _roomService;
        private readonly IUserService _userService;

        public BookingsListViewModel(IRoomService roomService, IUserService userService)
        {
            _roomService = roomService;
            _userService = userService;
        }
        [ObservableProperty]
        public int _userId;

        [ObservableProperty]
        public ObservableCollection<BookingData> _bookings = new();

        [RelayCommand]
        public async void GetRooms() => await GetRoomsList();

        public async Task GetRoomsList()
        {
            var user = await _userService.GetByIdAsync(UserId);
            var bookedRooms = user.BookedRooms;
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
        public async void ShowDetails(BookingData booking) => await GoToRoomsDetails(booking);

        public async Task GoToRoomsDetails(BookingData booking)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "BookingData", booking },
                { "IsConfirmation", false },
                { "IsDeletion", true }
            };
            await Shell.Current.GoToAsync(nameof(RoomDetails), parameters);
        }
    }
}
