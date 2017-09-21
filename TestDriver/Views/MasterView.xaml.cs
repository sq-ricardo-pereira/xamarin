using System;
using System.Collections.Generic;
using TestDriver.Models;
using TestDriver.ViewModels;
using Xamarin.Forms;

namespace TestDriver.Views
{
    public partial class MasterView : ContentPage
    {

        public MasterViewModel ViewModel { get; set; }

        public MasterView(Usuario usuario)
        {
            InitializeComponent();
            this.ViewModel = new MasterViewModel(usuario);
            this.BindingContext = this.ViewModel;
        }
    }
}
