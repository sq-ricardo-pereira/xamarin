using System;
using System.Collections.Generic;
using TestDriver.Models;

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
            this.BindingContext = this;
        }

        public string TextFreioAbs { 
            get {
                return string.Format("Freio ABS - R${0}", Veiculo.FREIO_ABS);        
            }
        }


        public bool TemFreioAbs
        {
            get { return Veiculo.TemFreioAbs; }

            set 
            {
                Veiculo.TemFreioAbs = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

		public bool TemArCondicionado
		{
            get { return Veiculo.TemArCondicionado; }

			set
			{
                Veiculo.TemArCondicionado = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(ValorTotal));
			}
		}

	
		public bool TemMp3Player
		{
			get { return Veiculo.TemMp3Player; }

			set
			{
				Veiculo.TemMp3Player = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(ValorTotal));
			}
		}


		public string TextArCondicionado
		{
			get
			{
                return string.Format("Ar Condicionado - R${0}", Veiculo.AR_CONDICIONADO);
			}
		}

		public string TextMp3Player
		{
			get
			{
                return string.Format("MP3 Player - R${0}", Veiculo.MP3_PLAYER);
			}
		}

        public string ValorTotal
        {
            get
            {
                return string.Format("Valor total R${0}", Veiculo.SomaAcessorio);
            }
        }


        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(this.Veiculo));
        }
    }
}
