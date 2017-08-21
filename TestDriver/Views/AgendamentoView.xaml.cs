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
    }
}
