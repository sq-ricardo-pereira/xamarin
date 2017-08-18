﻿using System;
namespace TestDriver.Models
{
    public class Agendamento
    {

		public Veiculo Veiculo { get; set; }
		public string Nome { get; set; }
		public string Telefone { get; set; }
		public string Email { get; set; }
        public DateTime DataAgendamento { get; set; }
        public TimeSpan HoraAgendamento { get; set; }
       
    }
}
