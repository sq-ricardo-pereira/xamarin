using System;
using TestDriver.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestDriver.ViewModels
{
    public class DetalheVeiculoViewModel : BaseViewModel
    {
        public Veiculo Veiculo { get; set; }

        public DetalheVeiculoViewModel(Veiculo veiculo)
        {
            this.Veiculo = veiculo;

            ProximoCommand = new Command(() => {
                MessagingCenter.Send<Veiculo>(veiculo, "Proximo");
            });
        }

		public string TextFreioAbs
		{
			get
			{
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



        public ICommand ProximoCommand { get; set; }

       
    }
}
