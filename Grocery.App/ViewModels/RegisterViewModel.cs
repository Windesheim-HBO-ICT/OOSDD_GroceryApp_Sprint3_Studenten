
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Xml.Linq;

namespace Grocery.App.ViewModels
{
    public partial class RegisterViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string registerMessage;

        public RegisterViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        public string RegisterMessage { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }

        [RelayCommand]
        private void Register()
        {
            var client = new Client
            {
                Name = Name,
                Email = Email,
                Password = Password
            };

            bool success = _authService.Register(client); 

            if (success)
            {
                RegisterMessage = "Account succesvol aangemaakt!";
                
                Shell.Current.GoToAsync("..");
            }
            else
            {
                RegisterMessage = "Registratie mislukt. Probeer opnieuw.";
            }
        }
    }
}

