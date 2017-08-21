using System;
using System.Collections.Generic;
using TestDriver.Models;
using TestDriver.ViewModels;
using Xamarin.Forms;

namespace TestDriver.Views
{
    public partial class DetalheVeiculoViews : ContentPage
    {
        public Veiculo Veiculo { get; set; }

        public DetalheVeiculoViews(Veiculo veiculo)
        {
            InitializeComponent();
            this.Veiculo = veiculo;
            this.BindingContext = new DetalheVeiculoViewModel(veiculo);
        }


        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(this.Veiculo));
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
			MessagingCenter.Subscribe<Veiculo>(this, "Proximo", Message);
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			MessagingCenter.Unsubscribe<Veiculo>(this, "Proximo");
		}

		private void Message(Veiculo veiculo)
		{
			Navigation.PushAsync(new AgendamentoView(veiculo));
		}
    }
}
