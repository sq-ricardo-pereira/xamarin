using System;
using System.Collections.Generic;
using TestDriver.Models;
using TestDriver.Services;
using Xamarin.Forms;

namespace TestDriver.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<LoginException>(this, "ErroLogin", async (exc) =>
            {
                await DisplayAlert("Login", exc.Message, "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<LoginException>(this, "ErroLogin");
        }

    }
}
