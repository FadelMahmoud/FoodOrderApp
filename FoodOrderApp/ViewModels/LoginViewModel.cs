using FoodOrderApp.Services;
using FoodOrderApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodOrderApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }

        private string _Username;
        public string Username
        {
            set
            {
                this._Username = value;
                OnpropertyChanged();
            }
            get
            {
                return this._Username;
            }
        }

        private string _Password;
        public string Password
        {
            set
            {
                this._Password = value;
                OnpropertyChanged();
            }
            get
            {
                return this._Password;
            }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
                this._IsBusy = value;
                OnpropertyChanged();
            }
            get
            {
                return this._IsBusy;
            }
        }

        private bool _Result;
        public bool Result
        {
            set
            {
                this._Result = value;
                OnpropertyChanged();
            }
            get
            {
                return this._Result;
            }
        }

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }


        private async Task RegisterCommandAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username, Password);
                if (Result) 
                    await Application.Current.MainPage.DisplayAlert("Success", "User Registered", "OK");
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "User already exists with this credentials", "OK");
            }
            catch ( Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false; 
            }
        }

        private async Task LoginCommandAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(Username, Password);
                if (Result)
                {
                    Preferences.Set("UserName", Username);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid username or password", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
