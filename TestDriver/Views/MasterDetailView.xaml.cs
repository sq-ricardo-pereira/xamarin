using System;
using System.Collections.Generic;
using TestDriver.Models;
using Xamarin.Forms;

namespace TestDriver.Views
{
    public partial class MasterDetalheView : MasterDetailPage
    {
        private readonly Usuario usuario;

        public MasterDetalheView(Usuario usuario)
        {
			InitializeComponent();
			this.usuario = usuario;
        }
    }
}
