using FoodOrderApp.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            /*
            string uname = Preferences.Get("UserName", String.Empty);
            if (String.IsNullOrEmpty(uname))
                MainPage = new LoginView();
            else MainPage = new ProductsView();
            */
            MainPage = new NavigationPage(new Page1());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
