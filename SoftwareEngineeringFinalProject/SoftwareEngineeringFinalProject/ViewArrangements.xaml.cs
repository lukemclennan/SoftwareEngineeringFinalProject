using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareEngineeringFinalProject.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoftwareEngineeringFinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewArrangements : ContentPage
    {
        public string flowerCategory;
        public ViewArrangements(string flwrcat)
        {
            flowerCategory = flwrcat;
            InitializeComponent();
            this.Title = "";
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (flowerCategory == null)
            {
                collectionView.ItemsSource = await App.DB.GetFlowerArrangementsAsync();
            }
            else
            {
                collectionView.ItemsSource = await App.DB.GetFlowerArrangementsByCategory(flowerCategory);
            }
           
        }

        async void collectionView_SelectionChanged(Object sender, SelectionChangedEventArgs e)
        {
            FlowerArrangement arr = (FlowerArrangement)e.CurrentSelection.FirstOrDefault();
            bool addToCart = await DisplayAlert("Add to Cart?", "Would you like to add " + arr.FlowerArrangementName + " to your cart?", "Yes", "No");
            if (addToCart)
            {
                CartItem cartItem = new CartItem
                {
                    CartID = App.User.CartID,
                    FlowerArrangementID = arr.FlowerArrangementID
                };
  
                await App.DB.SaveCartItemAsync(cartItem);
                await DisplayAlert("Success", "Item added to cart.", "Ok");
            }
        }
    }
}