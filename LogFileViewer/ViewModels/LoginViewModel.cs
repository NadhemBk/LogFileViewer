using LogFileViewer.Infrastructure;
using LogFileViewer.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LogFileViewer.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _errorMessage;

        public LoginViewModel()
        {
            WindowTitle = "LoginView";
        }

        public string Username { get; set; }
        public string ErrorMessage 
        { 
            get => _errorMessage;
            set 
            {
                _errorMessage = value;
                OnPropertyChanged();
            } 
        }

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        
        [Inject]
        public INavigationService NavigationService { get; set; }

        public ICommand Login => new ActionCommand(OnLogin, x => true);

        private void OnLogin(object parameters)
        {
            if(Username == null)
            {
                ErrorMessage = "Please enter a valid username.";
                return;
            }

            var authenticated = AuthenticationService.validateAuthentication(Username.ToLower(), ((PasswordBox)parameters).Password);
            if (authenticated)
            {
                ErrorMessage = string.Empty;
                NavigationService.NavigateToMain();
            }
            else
            {
                ErrorMessage = "Username or password is incorrect. Please try again.";
            }
        }
    }
}
