using System;
using Xamarin.Forms;
using System.Collections.Generic;
using TestDriver.Models;

namespace TestDriver.Views
{

	public partial class ListagemView : ContentPage
	{
        public List<Veiculo> Veiculos { get; set; }

		public ListagemView()
		{
			InitializeComponent();
            this.Veiculos = new ListaVeiculo().Veiculos;
			this.BindingContext = this;
		}

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			var veiculo = (Veiculo)e.Item;

            Navigation.PushAsync(new DetalheVeiculoViews(veiculo));

		}
	}
}
