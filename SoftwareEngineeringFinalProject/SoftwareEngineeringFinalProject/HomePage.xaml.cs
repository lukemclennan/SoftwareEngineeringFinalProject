﻿using SoftwareEngineeringFinalProject.Models;
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

            collectionView.ItemsSource = await App.DB.GetFlowersAsync();
        }

        private async void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Flower flower = (Flower)e.CurrentSelection.FirstOrDefault();
            bool addToCart = await DisplayAlert("Add to Cart?", "Would you like to add " + flower.FlowerName + " to your cart?", "Yes", "No");
            if (addToCart)
            {
                FlowerArrangement flowerArrangement = new FlowerArrangement { 
                    FlowerID = flower.FlowerID,
                };
                CartItem cartItem = new CartItem { 
                    CartID = App.User.CartID,
                    FlowerArrangementID = flowerArrangement.FlowerArrangementID
                };
                await App.DB.SaveFlowerArrangementAsync(flowerArrangement);
                await App.DB.SaveCartItemAsync(cartItem);
                await DisplayAlert("Success", "Item added to cart.", "Ok");
            }
        }
    }
}