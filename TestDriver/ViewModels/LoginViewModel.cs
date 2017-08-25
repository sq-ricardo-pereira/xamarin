using System;
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
            }
        }
        public LoginViewModel()
        {
        }
    }
}
