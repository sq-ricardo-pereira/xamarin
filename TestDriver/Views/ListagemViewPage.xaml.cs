using System;
﻿using Xamarin.Forms;
using System.Collections.Generic;

namespace TestDriver.Views
{

    public class Veiculo
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public string PrecoFormatado 
        {
            get
            {
                return string.Format("R$ {0}", Preco);
            }
        }
    }

    public partial class ListagemView : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemView()
        {
            InitializeComponent();

            this.Veiculos = new List<Veiculo>
            {
                new Veiculo { Nome = "Azira", Preco = 60000 },
                new Veiculo { Nome = "Palio", Preco = 3000 }
            };

            this.BindingContext = this;
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;

            Navigation.PushAsync(new DetalheView());
        }
    }
}
