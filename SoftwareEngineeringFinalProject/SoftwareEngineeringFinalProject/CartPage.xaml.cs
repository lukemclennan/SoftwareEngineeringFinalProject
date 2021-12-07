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
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //get cart items (arrangments) in the CollectionView
            collectionView.ItemsSource = await App.DB.GetCartArrangementsAsync2(App.User.CartID);

            //get cart items (occasions) in the CollectionView
            collectionViewOccasions.ItemsSource = await App.DB.GetCartOccasionsAsync(App.User.CartID);

            //get total cost of cart
            Cart cart = await App.DB.GetCartAsync(App.User.CartID);
            double cost = await cart.GetTotalCost();
            priceLabel.Text = "Total Cost: $" + cost.ToString("N2");
        }

        private async void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //delete item
            int cartItemID = ((CartQueryResult)e.CurrentSelection.FirstOrDefault()).CartItemID;
            CartItem cartItem = await App.DB.GetCartItemAsync(cartItemID);
            await App.DB.DeleteCartItemAsync(cartItem);
            OnAppearing();
            await DisplayAlert("Deleted", "Item successfully deleted", "OK");
            //update cost
            Cart cart = await App.DB.GetCartAsync(App.User.CartID);
            double cost = await cart.GetTotalCost();
            priceLabel.Text = "Total Cost: $" + cost.ToString("N2");
        }

        private async void CheckoutButtonClicked(object sender, EventArgs e)
        {
            //go to payment
            await Navigation.PushAsync(new PaymentPage());
        }
    }
}

