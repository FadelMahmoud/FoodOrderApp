using FoodOrderApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderApp.ViewModels
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        private FoodItem _SelectedFoodItem;
        public FoodItem SelectedFoodItem
        {
            set
            {
                _SelectedFoodItem = value;
                OnpropertyChanged();
            }

            get
            {
                return _SelectedFoodItem;
            }
        }
        public ProductDetailsViewModel(FoodItem foodItem)
        {
            SelectedFoodItem = foodItem;
        }
    }
}
