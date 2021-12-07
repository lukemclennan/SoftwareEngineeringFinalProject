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
    public partial class OccasionCategoryPage : ContentPage
    {
        public string occCategory;

        public OccasionCategoryPage(string category)
        {
            occCategory = category;

            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            collectionViews.ItemsSource = await App.DB.GetOccasionByCategory(occCategory);


        }
    }
}
