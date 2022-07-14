using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodOrderApp.Helpers
{
    public class AddFoodItmeData
    {
        FirebaseClient client;
        public List<FoodItem> FoodItems { get; set; }

        public AddFoodItmeData()
        {
            client = new FirebaseClient("https://foodorderingapp-95db5-default-rtdb.firebaseio.com/");
            FoodItems = new List<FoodItem>()
            {
                new FoodItem
                {
                    ProductID = 1,
                    CategoryID = 1,
                    ImageUrl = "MainBurger.png",
                    Name = "Burger and Pizza Hub 1",
                    Desription = "Burger - Pizza - Breakfast",
                    Rating = "4.8",
                    RatingDetail = "(121 raitings)",
                    HomeSelected = "CompleteHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 2,
                    CategoryID = 1,
                    ImageUrl = "MainBurger.png",
                    Name = "Burger and Pizza Hub 2",
                    Desription = "Burger - Pizza - Breakfast",
                    Rating = "4.8",
                    RatingDetail = "(121 raitings)",
                    HomeSelected = "EmptyHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 3,
                    CategoryID = 1,
                    ImageUrl = "MainBurger.png",
                    Name = "Burger and Pizza Hub 3",
                    Desription = "Burger - Pizza - Breakfast",
                    Rating = "4.8",
                    RatingDetail = "(121 raitings)",
                    HomeSelected = "CompleteHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 4,
                    CategoryID = 1,
                    ImageUrl = "MainBurger.png",
                    Name = "Burger and Pizza Hub 1",
                    Desription = "Burger - Pizza - Breakfast",
                    Rating = "4.8",
                    RatingDetail = "(121 raitings)",
                    HomeSelected = "EmptyHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 5,
                    CategoryID = 2,
                    ImageUrl = "MainPizza.png",
                    Name = "Pizza",
                    Desription = "Pizza - Breakfast",
                    Rating = "4.4",
                    RatingDetail = "(120 raitings)",
                    HomeSelected = "CompleteHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 6,
                    CategoryID = 2,
                    ImageUrl = "MainPizza.png",
                    Name = "Pizza Hub 2",
                    Desription = "Pizza Hub 2- Breakfast",
                    Rating = "4.8",
                    RatingDetail = "(156 raitings)",
                    HomeSelected = "EmptyHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 7,
                    CategoryID = 3,
                    ImageUrl = "MainDessert.png",
                    Name = "Ice Creams",
                    Desription = "Icecream - Breakfast",
                    Rating = "4.4",
                    RatingDetail = "(120 raitings)",
                    HomeSelected = "CompleteHeart",
                    Price = 45
                },
                new FoodItem
                {
                    ProductID = 8,
                    CategoryID = 3,
                    ImageUrl = "MainDessert.jfif",
                    Name = "Cakes",
                    Desription = "Cool Cakes - Breakfast",
                    Rating = "4.8",
                    RatingDetail = "(156 raitings)",
                    HomeSelected = "EmptyHeart",
                    Price = 45
                }
            };
        }

        public async Task AddFoodItmeDataAsync()
        {
            try
            {
                foreach (var fooditem in FoodItems)
                {
                    await client.Child("Products").PostAsync(new FoodItem
                    {
                        ProductID = fooditem.ProductID,
                        CategoryID = fooditem.CategoryID,
                        ImageUrl = fooditem.ImageUrl,
                        Name = fooditem.Name,
                        Desription = fooditem.Desription,
                        Rating = fooditem.Rating,
                        RatingDetail = fooditem.RatingDetail,
                        HomeSelected = fooditem.HomeSelected,
                        Price = fooditem.Price,

                    });
                }
                
            }catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
