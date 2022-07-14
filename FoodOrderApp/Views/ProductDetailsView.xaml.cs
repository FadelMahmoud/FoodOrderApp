using FoodOrderApp.Model;
using FoodOrderApp.ViewModels;
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
    public partial class ProductDetailsView : ContentPage
    {
        ProductDetailsViewModel asm;
        public ProductDetailsView(FoodItem foodItem)
        {
            InitializeComponent();
            asm = new ProductDetailsViewModel(foodItem);
            this.BindingContext = asm;
        }

        private void MiunsCount_Clicked(object sender, EventArgs e)
        { if ( OrderCountLabel.Text != "1")
                OrderCountLabel.Text = ( Convert.ToInt32(OrderCountLabel.Text) -1 ).ToString();
        }
        private void PlusCount_Clicked(object sender, EventArgs e)
        {
            OrderCountLabel.Text = (Convert.ToInt32(OrderCountLabel.Text) + 1).ToString();
        }
    }
}