using SoftwareEngineeringFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoftwareEngineeringFinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            this.Title = "Home";
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            List<Flower> flowers = await App.DB.GetFlowersAsync();
            flowers.Add(new Flower
            {
                FlowerName = "All",
                FlowerID = -1
            });
            collectionView.ItemsSource = flowers;
        }

        private async void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int flowerID = ((Flower)e.CurrentSelection.FirstOrDefault()).FlowerID;
            await Navigation.PushAsync(new ViewArrangements(flowerID));
            //bool addToCart = await DisplayAlert("Add to Cart?", "Would you like to add " + flower.FlowerName + " to your cart?", "Yes", "No");
            //if (addToCart)
            //{
            //    FlowerArrangement flowerArrangement = new FlowerArrangement {
            //        FlowerID = flower.FlowerID,
            //        FlowerArrangementName = flower.FlowerName + " Arrangement"
            //    };
            //    await App.DB.SaveFlowerArrangementAsync(flowerArrangement);
            //    CartItem cartItem = new CartItem { 
            //        CartID = App.User.CartID,
            //        FlowerArrangementID = flowerArrangement.FlowerArrangementID
            //    };
            //    //await DisplayAlert("FlowerArrangmentID", flowerArrangement.FlowerArrangementID.ToString(), "Ok");
            //    await App.DB.SaveCartItemAsync(cartItem);
            //    await DisplayAlert("Success", "Item added to cart.", "Ok");
            //}
        }
    }
}