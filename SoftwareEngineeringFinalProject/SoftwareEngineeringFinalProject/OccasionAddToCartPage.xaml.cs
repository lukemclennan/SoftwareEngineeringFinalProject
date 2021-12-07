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
    public partial class OccasionAddToCartPage : ContentPage
    {
        public int occasionID;
        public OccasionAddToCartPage(int occasionIDParameter)
        {
            occasionID = occasionIDParameter;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Models.Occasions occasion = await App.DB.GetOccasionAsync(occasionID);
            List<Models.Occasions> occasionsList = new List<Models.Occasions>();
            occasionsList.Add(occasion);
            collectionViews.ItemsSource = occasionsList;
        }
        public async void AddToCartProcedure(object sender, EventArgs e)
        {
            var result = await this.DisplayAlert("Alert!", "Are you sure you want to add this occasion to the cart?", "Yes", "No");

            if (result)
            {
                Models.CartItem newCartItem = new Models.CartItem()
                {
                    CartID = App.User.CartID,
                    OccasionID = occasionID
                };

                await App.DB.SaveCartItemAsync(newCartItem);


                await this.DisplayAlert("Success", "You have successfully added this occasion to your cart", "Ok");
            }

        }
    }
}
