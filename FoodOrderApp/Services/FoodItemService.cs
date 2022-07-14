using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderApp.Services
{
    public class FoodItemService
    {
        FirebaseClient client;
        public FoodItemService()
        {
            client = new FirebaseClient("https://foodorderingapp-95db5-default-rtdb.firebaseio.com/");
        }

        public async Task<List<FoodItem>> GetFoodItemsAsync()
        {
            var products = (await client.Child("Products").
                OnceAsync<FoodItem>()).
                Select(f => new FoodItem
                {
                    ProductID = f.Object.ProductID,
                    CategoryID = f.Object.CategoryID,
                    ImageUrl = f.Object.ImageUrl,
                    Name = f.Object.Name,
                    Desription = f.Object.Desription,
                    Rating = f.Object.Rating,
                    RatingDetail = f.Object.RatingDetail,
                    HomeSelected = f.Object.HomeSelected,
                    Price = f.Object.Price
                }).ToList();

            return products;
        }

        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryAsync(int categoryID)
        {
            var FoodItemsByCategory = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).Where(p => p.CategoryID == categoryID).ToList();

            foreach( var item in items)
            {
                FoodItemsByCategory.Add(item);
            }

            return FoodItemsByCategory;
        }

        public async Task<ObservableCollection<FoodItem>> GetLatestFoodItemsAsync()
        {
            var LatestFoodItems = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).OrderByDescending(f => f.ProductID).Take(3);

            foreach (var item in items)
            {
                LatestFoodItems.Add(item);
            }

            return LatestFoodItems;
        }
    }
}
