using System;
using System.Collections.Generic;
using TestDriver.Models;
using Xamarin.Forms;

namespace TestDriver.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        void Login_Clicked(object sender, System.EventArgs e)
        {
            MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
        }
    }
}
