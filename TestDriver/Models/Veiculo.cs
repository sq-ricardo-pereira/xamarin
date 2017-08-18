using System;
namespace TestDriver.Models
{
    public class Veiculo
    {
		public string Nome { get; set; }
		public decimal Preco { get; set; }
		public const int FREIO_ABS = 800;
		public const int AR_CONDICIONADO = 1000;
		public const int MP3_PLAYER = 300;

		public string PrecoFormatado
		{
			get
			{
				return string.Format("R$ {0}", Preco);
			}
		}

        public bool TemFreioAbs { get; set; }
        public bool TemArCondicionado { get; set; }
        public bool TemMp3Player { get; set; }

        public decimal SomaAcessorio
        {
           
            get {
                return Preco + (TemFreioAbs ? FREIO_ABS : 0) + (TemMp3Player ? MP3_PLAYER : 0) + (TemArCondicionado ? AR_CONDICIONADO : 0);
            }
        }

    }
}
