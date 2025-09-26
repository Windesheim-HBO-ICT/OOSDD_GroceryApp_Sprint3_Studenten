using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.App.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private readonly GlobalViewModel _global;

        [ObservableProperty]
        private string name = "";

        [ObservableProperty]
        private string email = "";

        [ObservableProperty]
        private string password = "";

        [ObservableProperty]
        private string confirmPassword = "";

        [ObservableProperty]
        private string registerMessage = "";

        public RegisterViewModel(IAuthService authService, GlobalViewModel global)
        {
            _authService = authService;
            _global = global;
        }

        [RelayCommand]
        private void Register()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                RegisterMessage = "Naam mag niet leeg zijn.";
                return;
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                RegisterMessage = "Email mag niet leeg zijn.";
                return;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                RegisterMessage = "Wachtwoord mag niet leeg zijn.";
                return;
            }

            if (string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                RegisterMessage = "Wachtwoord bevestiging mag niet leeg zijn.";
                return;
            }

            if (ConfirmPassword != Password)
            {
                RegisterMessage = "Wachtwoord bevestiging moet gelijk zijn aan wachtwoord.";
                return;
            }

            var client = _authService.Register(Name, Email, Password);
            _global.Client = client;
            Application.Current.MainPage = new AppShell();
        }
    }
}