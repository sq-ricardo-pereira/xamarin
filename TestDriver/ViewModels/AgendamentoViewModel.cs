using System;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Newtonsoft.Json;
using TestDriver.Models;
using Xamarin.Forms;

namespace TestDriver.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        const string URL_POST_AGENDAMENTO = "https://aluracar.herokuapp.com/salvaragendamento";

        public AgendamentoViewModel(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;
            this.Agendamento.DataAgendamento = DateTime.Today;
            CommandAgendar = new Command(() =>
            {
                MessagingCenter.Send<Veiculo>(this.Agendamento.Veiculo, "Agendar");
            }, CanExecut);
        }

        public bool CanExecut()
        {
            return !string.IsNullOrEmpty(this.Nome)
                          && !string.IsNullOrEmpty(this.Telefone)
                          && !string.IsNullOrEmpty(this.Email);
        }

        public Agendamento Agendamento { get; set; }
        public Veiculo Veiculo
        {
            get
            {
                return Agendamento.Veiculo;
            }
            set
            {
                Agendamento.Veiculo = value;
            }
        }
        public string Nome
        {
            get
            {
                return Agendamento.Nome;
            }
            set
            {
                Agendamento.Nome = value;
                OnPropertyChanged();
                ((Command)CommandAgendar).ChangeCanExecute();
            }
        }
        public string Telefone
        {
            get
            {
                return Agendamento.Telefone;
            }
            set
            {
                Agendamento.Telefone = value;
                OnPropertyChanged();
                ((Command)CommandAgendar).ChangeCanExecute();
            }
        }
        public string Email
        {
            get
            {
                return Agendamento.Email;
            }
            set
            {
                Agendamento.Email = value;
                OnPropertyChanged();
                ((Command)CommandAgendar).ChangeCanExecute();
            }
        }


        public DateTime DataAgendamento
        {
            get
            {
                return Agendamento.DataAgendamento;
            }

            set
            {
                Agendamento.DataAgendamento = value;
            }
        }

        public TimeSpan HoraAgendamento
        {
            get
            {
                return Agendamento.HoraAgendamento;
            }

            set
            {
                Agendamento.HoraAgendamento = value;
            }
        }


        public ICommand CommandAgendar { get; set; }

        public async void SalvarAgendamento()
        {
            HttpClient client = new HttpClient();

            var dataHoraAgendamento = new DateTime(
                DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                HoraAgendamento.Hours, HoraAgendamento.Minutes, HoraAgendamento.Seconds
            );

            var json = JsonConvert.SerializeObject(new
            {
                nome = Nome,
                fone = Telefone,
                email = Email,
                carro = Veiculo.Nome,
                preco = Veiculo.Preco,
                dataAgendamento = dataHoraAgendamento

            });

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");
            var resposta = await client.PostAsync(URL_POST_AGENDAMENTO, conteudo);

            if (resposta.IsSuccessStatusCode) 
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento, "SucessoSalvarAgendamento");
                return;
            }

            MessagingCenter.Send<ArgumentException>(new ArgumentException(), "ErroSalvarAgendamento");
        }
    }
}
