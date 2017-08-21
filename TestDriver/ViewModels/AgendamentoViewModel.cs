using System;
using TestDriver.Models;

namespace TestDriver.ViewModels
{
    public class AgendamentoViewModel
    {
        public AgendamentoViewModel(Veiculo veiculo)
        {
			this.Agendamento = new Agendamento();
			this.Agendamento.Veiculo = veiculo;
			this.Agendamento.DataAgendamento = DateTime.Today;
        }

		public Agendamento Agendamento { get; set; }
		public Veiculo Veiculo
		{
			get
			{
				return Agendamento.Veiculo;
			}
			set
			{
				Agendamento.Veiculo = value;
			}
		}
		public string Nome
		{
			get
			{
				return Agendamento.Nome;
			}
			set
			{
				Agendamento.Nome = value;
			}
		}
		public string Telefone
		{
			get
			{
				return Agendamento.Telefone;
			}
			set
			{
				Agendamento.Telefone = value;
			}
		}
		public string Email
		{
			get
			{
				return Agendamento.Email;
			}
			set
			{
				Agendamento.Email = value;
			}
		}


		public DateTime DataAgendamento
		{
			get
			{
				return Agendamento.DataAgendamento;
			}

			set
			{
				Agendamento.DataAgendamento = value;
			}
		}

		public TimeSpan HoraAgendamento
		{
			get
			{
				return Agendamento.HoraAgendamento;
			}

			set
			{
				Agendamento.HoraAgendamento = value;
			}
		}
    }
}
