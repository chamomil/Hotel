using CommunityToolkit.Maui.Core.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hotel.Application.Abstractions;
using Hotel.Domain.Entities;
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

        public HomeViewModel(IRoomService roomService, IBookingDataService bookingDataService)
        {
            _roomService = roomService;
            _bookingDataService = bookingDataService;
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
            if (FirstDate >= SecondDate || FirstDate  < DateTime.Now)
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
    }
}
