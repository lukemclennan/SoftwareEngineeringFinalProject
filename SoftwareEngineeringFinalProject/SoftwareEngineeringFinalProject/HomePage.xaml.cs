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

            List<Flower> list = await App.DB.GetFlowersAsync();
            list.Add(new Flower
            {
                FlowerName = "All",
                FlowerID = -1
            });
            collectionView.ItemsSource = list;
        }

        private async void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Flower flower = ((Flower)e.CurrentSelection.FirstOrDefault());
            if (flower.FlowerID == -1)
                await Navigation.PushAsync(new ViewArrangements());
            else
                await Navigation.PushAsync(new ViewArrangements(flower.FlowerName));
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
