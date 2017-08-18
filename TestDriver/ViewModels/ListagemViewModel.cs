using System;
using System.Collections.Generic;
using TestDriver.Models;

namespace TestDriver.ViewModels
{
    public class ListagemViewModel
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemViewModel()
        {
            this.Veiculos = new ListaVeiculo().Veiculos;
        }
    }
}
