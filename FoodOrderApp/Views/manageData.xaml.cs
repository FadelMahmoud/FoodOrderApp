using FoodOrderApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class manageData : ContentPage
    {
        public manageData()
        {
            InitializeComponent();
        }

        private async void ButtonCategories_Clicked(object sender, EventArgs e)
        {
            var acd = new AddCategoryData();
            await acd.AddCategoryDataAsync();
        }

        private async void ButtonProducts_Clicked(object sender, EventArgs e)
        {
            var afd = new AddFoodItmeData();
            await afd.AddFoodItmeDataAsync();
        }
    }
}