using CommunityToolkit.Mvvm.ComponentModel;
using Hotel.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.UI.ViewModels
{
    public partial class SignUpViewModel : ObservableObject
    {
        private readonly IUserService _userService;

        public SignUpViewModel(IUserService userService)
        {
            _userService = userService;
        }
    }
}
