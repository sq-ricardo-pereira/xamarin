using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestDriver.Models;
using Xamarin.Forms;

namespace TestDriver.Services
{
    public class LoginService
    {
        public async Task FazerLogin(Login login)
        {

            using (var cliente = new HttpClient())
            {
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", login.email),
                    new KeyValuePair<string, string>("senha", login.senha)
                });

                cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");
                HttpResponseMessage resultado = null;

                try
                {
                    resultado = await cliente.PostAsync("/login", camposFormulario);
				}
				catch
				{
					MessagingCenter.Send<LoginException>(new LoginException(@"Ocorreu um erro de comunicação com o servidor.
                        Por favor verifique a sua conexão e tente novamente mais tarde."), "ErroLogin");
				}

                if (resultado.IsSuccessStatusCode)
                {
                    MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
                    return;
                }

                MessagingCenter.Send<LoginException>(new LoginException("Usuário ou senha inválido"), "ErroLogin");
                
            }
        }
    }

    public class LoginException : Exception
    {
		public LoginException(string message) : base(message)
		{
		}
    }
}
