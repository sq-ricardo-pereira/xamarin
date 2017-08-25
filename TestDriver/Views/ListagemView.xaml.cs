using System;
using Xamarin.Forms;
using System.Collections.Generic;
using TestDriver.Models;
using TestDriver.ViewModels;

namespace TestDriver.Views
{

	public partial class ListagemView : ContentPage
	{
        
        public ListagemViewModel ViewModel { get; set; }
		public ListagemView()
		{
            InitializeComponent();
            this.ViewModel = new ListagemViewModel();
            this.BindingContext = this.ViewModel;
		}

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			var veiculo = (Veiculo)e.Item;

            Navigation.PushAsync(new DetalheVeiculoViews(veiculo));

		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", Message);

            await this.ViewModel.GetVeiculos();
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
