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

namespace Hotel.UI.ViewModels.Admin
{
    public partial class AdminUsersViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        public AdminUsersViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [ObservableProperty]
        ObservableCollection<User> _users = new();

        [RelayCommand]
        public async void LoadUsers() => await GetUsers();

        public async Task GetUsers()
        {
            Users = new();
            var loaded = await _userService.GetAllAsync();
            foreach (var user in loaded)
            {
                Users.Add(user);
            }
        }
    }
}
