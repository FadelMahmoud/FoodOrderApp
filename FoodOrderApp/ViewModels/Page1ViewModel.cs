using FoodOrderApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodOrderApp.ViewModels
{
    public class Page1ViewModel:BaseViewModel
    {

        public Page1ViewModel()
        {
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }
        public Command RegisterCommand { get; set; }


        private async Task RegisterCommandAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new TabbedPage1());
            /*
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
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
            */
        }
    }
}
