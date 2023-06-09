﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Hotel.Application.Abstractions;
using Hotel.Domain.Entities;
using Hotel.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.ViewModels
{
    [QueryProperty("UserId", "UserId")]
    [QueryProperty("IsAdmin", "IsAdmin")]
    public partial class ProfileViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        public ProfileViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [ObservableProperty]
        public int _userId;
        [ObservableProperty]
        public bool _isAdmin = false;

        [ObservableProperty]
        public User _currentUser = new();

        [RelayCommand]
        public async void LoadInfo() => await GetUser();

        public async Task GetUser()
        {
            CurrentUser = new();
            CurrentUser = await _userService.GetByIdAsync(UserId);
        }

        [RelayCommand]
        public async void EditClicked() => await GoToEditing();

        public async Task GoToEditing()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "UserId", UserId }
            };
            await Shell.Current.GoToAsync(nameof(EditProfile), parameters);
        }

        [RelayCommand]
        public async void DeleteClicked() => await DeleteAndLogOut();

        public async Task DeleteAndLogOut()
        {
            await _userService.DeleteAsync(UserId);
            if (IsAdmin)
            {
                await Shell.Current.GoToAsync("../..");
            }
            else
            {
                await Shell.Current.GoToAsync(nameof(LogIn));
            }
        }
    }
}
