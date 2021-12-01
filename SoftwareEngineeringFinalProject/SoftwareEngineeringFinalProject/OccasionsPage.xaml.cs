using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoftwareEngineeringFinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OccasionsPage : ContentPage
    {
        public OccasionsPage()
        {
            InitializeComponent();
            this.Title = "Occasions";
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await App.DB.GetOccasionsAsync();

        }
    }
}
