using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoftwareEngineeringFinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminDisplayUsers : ContentPage
    {
        public AdminDisplayUsers()
        {
            InitializeComponent();

            this.Title = "Users";
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await App.DB.GetUsersAsync();
        }
    }
}
