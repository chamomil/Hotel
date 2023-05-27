using CommunityToolkit.Maui.Core.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hotel.Application.Abstractions;
using Hotel.Domain.Entities;
using Hotel.UI.Pages;
using Microsoft.Maui.Controls.Compatibility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.ViewModels
{
    [QueryProperty("UserId", "UserId")]
    public partial class HomeViewModel : ObservableObject
    {
        private readonly IRoomService _roomService;
        private readonly IBookingDataService _bookingDataService;
        private readonly IUserService _userService;

        public HomeViewModel(IRoomService roomService, IBookingDataService bookingDataService, IUserService userService)
        {
            _roomService = roomService;
            _bookingDataService = bookingDataService;
            _userService = userService;
        }

        [ObservableProperty]
        int userId;

        [ObservableProperty]
        DateTime firstDate = DateTime.Now;
        [ObservableProperty]
        DateTime secondDate = DateTime.Now;

        [ObservableProperty]
        public ObservableCollection<Room> _rooms = new();

        [RelayCommand]
        public async void FindRoomClicked() => await GetRoom();

        public async Task GetRoom()
        {
            if (FirstDate.Date > SecondDate.Date || FirstDate.Date < DateTime.Today)
            {
                return;
            }
            var rooms = await _roomService.GetAvailableRooms(FirstDate, SecondDate);
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Rooms = new();
                foreach (var room in rooms)
                {
                    Rooms.Add(room);
                }
            });
        }

        [RelayCommand]
        public async void ShowDetails(Room room) => await GoToRoomsDetails(room);

        public async Task GoToRoomsDetails(Room room)
        {
            var user = await _userService.GetByIdAsync(UserId);
            var booking = new BookingData() { DateOfEntry = FirstDate, DateOfLeaving = SecondDate, Room = room, User = user, RoomId = room.Id, UserId = UserId };
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "BookingData", booking }
            };
            await Shell.Current.GoToAsync(nameof(RoomDetails), parameters);
        }

        [RelayCommand]
        public async void ChangeDate() => await ClearRooms();

        public async Task ClearRooms()
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Rooms = new();
            });
        }

        [RelayCommand]
        public async void MenuClicked() => await GoToMenu();

        public async Task GoToMenu()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "UserId", UserId }
            };
            await Shell.Current.GoToAsync(nameof(Menu), parameters);
        }
    }
}
