using System;
using System.Collections.Generic;

namespace TestDriver.Models
{
    public class ListaVeiculo
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListaVeiculo()
        {
			this.Veiculos = new List<Veiculo>
			{
				new Veiculo { Nome = "Azira", Preco = 60000 },
				new Veiculo { Nome = "Palio", Preco = 3000 }
			};

		}
    }
}
