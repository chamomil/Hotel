using CommunityToolkit.Maui.Core.Views;
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
    [QueryProperty("BookingData", "BookingData")]
    public partial class RoomDetailsViewModel : ObservableObject
    {
        private readonly IBookingDataService _bookingDataService;

        public RoomDetailsViewModel(IBookingDataService bookingDataService) 
        {
            _bookingDataService = bookingDataService;
        }

        [ObservableProperty]
        public BookingData bookingData;

        [RelayCommand]
        public async void OnConfirmClicked() => await ConfirmAndGoBack();

        public async Task ConfirmAndGoBack()
        {
            await _bookingDataService.AddAsync(BookingData);
            await Shell.Current.GoToAsync("..");
        }
    }
}
