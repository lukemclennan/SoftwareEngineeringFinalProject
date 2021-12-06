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

            collectionView.ItemsSource = await App.DB.GetCartArrangementsAsync2(App.User.CartID);
        }

        private async void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int cartItemID = ((CartQueryResult)e.CurrentSelection.FirstOrDefault()).CartItemID;
            CartItem cartItem = await App.DB.GetCartItemAsync(cartItemID);
            await App.DB.DeleteCartItemAsync(cartItem);
            OnAppearing();
            await DisplayAlert("Deleted", "Item successfully deleted", "OK");
        }

        private async void CheckoutButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaymentPage());
        }
    }
}

