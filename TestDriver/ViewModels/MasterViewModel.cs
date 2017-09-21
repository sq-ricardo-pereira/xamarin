using System;
using TestDriver.Models;

namespace TestDriver.ViewModels
{
    public class MasterViewModel
    {
        public string Email 
        { 
            get 
            {
                return this.usuario.Email;
            }

            set 
            {
                this.usuario.Email = value;    
            }
        }
        public string Nome 
        { 
            get 
            {
                return this.usuario.Nome;
            }

            set
            {
                this.usuario.Nome = value;
            }
        }

        private readonly Usuario usuario;

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
        }
    }
}
