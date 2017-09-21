using System;
using System.Windows.Input;
using TestDriver.Models;
using TestDriver.Services;
using Xamarin.Forms;

namespace TestDriver.ViewModels
{
    public class LoginViewModel
    {
        private string usuario;
        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        public ICommand EntrarCommand { get; private set; }

        public LoginViewModel()
        {
            EntrarCommand = new Command(async () =>
            {
                var login = new LoginService();
                await login.FazerLogin(new Login(usuario, password));

            }, EnableButton );
        }

        private bool EnableButton()
        {
            return !string.IsNullOrEmpty(Usuario)
                   && !string.IsNullOrEmpty(Password);
        }
    }
}
