using System;
using System.Collections.Generic;
using TestDriver.Models;
using TestDriver.ViewModels;
using Xamarin.Forms;

namespace TestDriver.Views
{
    public partial class AgendamentoView : ContentPage
    {

        public AgendamentoViewModel AgendamentoViewModel { get; set; }

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.AgendamentoViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = this.AgendamentoViewModel;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Agendamento",
            string.Format(@"Nome: {0} 
            Fone: {1}                                                   
            Email: {2}
            Data: {3}
            Horário: {4}
            ", AgendamentoViewModel.Nome, AgendamentoViewModel.Telefone, AgendamentoViewModel.Email, AgendamentoViewModel.DataAgendamento.ToString("dd/MM/yyyy"), AgendamentoViewModel.HoraAgendamento), "Ok");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "Agendar", Message);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "Agendar");
            MessagingCenter.Unsubscribe<Veiculo>(this, "SucessoSalvarAgendamento");
            MessagingCenter.Unsubscribe<Veiculo>(this, "ErroSalvarAgendamento");
        }

        private async void Message(Veiculo veiculo)
        {

            var confirma = await DisplayAlert("Atenção", "Você realmente deseja fazer o agendamento?", "Sim", "Não");

            if (confirma == true)
            {
                this.AgendamentoViewModel.SalvarAgendamento();
            }

            MessagingCenter.Subscribe<Agendamento>(this, "SucessoSalvarAgendamento", (obj) => {
                DisplayAlert("Agendamento", "Agendamento salvo com sucesso", "Ok");
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "ErroSalvarAgendamento", (obj) => {
				DisplayAlert("Agendamento", "Erro ao fazer o agendamento, verifique os dados ou tente mais tarde", "Ok");
			});
        }
    }
}
