using System;
using Xamarin.Forms;
using System.Collections.Generic;
using TestDriver.Models;

namespace TestDriver.Views
{

	public partial class ListagemView : ContentPage
	{
        

		public ListagemView()
		{
            InitializeComponent();
		}

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			var veiculo = (Veiculo)e.Item;

            Navigation.PushAsync(new DetalheVeiculoViews(veiculo));

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", Message);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }

        private void Message(Veiculo veiculo)
        {
            Navigation.PushAsync(new DetalheVeiculoViews(veiculo));
        }


	}
}
