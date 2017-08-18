using System;
using System.Collections.Generic;
using TestDriver.Models;

using Xamarin.Forms;

namespace TestDriver.Views
{
    public partial class AgendamentoView : ContentPage
    {
        public Agendamento Agendamento { get; set; }
        public Veiculo Veiculo { get {
                return Agendamento.Veiculo;
            } set {
                Agendamento.Veiculo = value;
            } }
        public string Nome { get {
                return Agendamento.Nome;
            } set {
                Agendamento.Nome = value;
            } }
        public string Telefone { get {
                return Agendamento.Telefone;
            } set{
                Agendamento.Telefone = value;
            } }
        public string Email { get {
                return Agendamento.Email;
            } set {
                Agendamento.Email = value;
            } }


        public DateTime DataAgendamento
        {
            get
            {
                return dataAgendamento;
            }

            set
            {
                dataAgendamento = value;
            }
        }

        TimeSpan horaAgendamento;
        public TimeSpan HoraAgendamento
        {
            get
            {
                return horaAgendamento;
            }

            set
            {
                horaAgendamento = value;
            }
        }

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Veiculo = veiculo;
            this.BindingContext = this;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Agendamento",
                         string.Format(@"Nome: {0}
            
Fone: {1}
Email: {2}
Data: {3}
Horário: {4}
", Nome, Telefone, Email, DataAgendamento.ToString("dd/MM/yyyy"), HoraAgendamento), "Ok");
        }
    }
}
