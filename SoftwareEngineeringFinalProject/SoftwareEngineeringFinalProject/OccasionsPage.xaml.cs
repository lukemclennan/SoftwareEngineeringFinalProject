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

            List<Models.Occasions> listOfOccasions = await App.DB.GetOccasionsAsync();
            List<string> categories = new List<string>();

            foreach(var curOccasion in listOfOccasions)
            {
                if (curOccasion.OccasionCategory != null && categories.Contains(curOccasion.OccasionCategory) == false)
                {
                    categories.Add(curOccasion.OccasionCategory);
                }
            }
            Console.WriteLine("Number of categories of occasions is " + categories.Count + " or " + listOfOccasions.Count + "\n");
            Console.WriteLine("The first occasion is " + categories[0] + ".\n");
            if(categories.Count != 0)
                collectionView.ItemsSource = categories;
            else
            {
                categories.Add("No categories currently");
                collectionView.ItemsSource = categories;
            }
        }

        private async void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {/*
            Flower flowerID = ((Flower)e.CurrentSelection.FirstOrDefault());
            await Navigation.PushAsync(new ViewArrangements(flowerID.FlowerName));
         */

            IReadOnlyList <object> readOnly = e.CurrentSelection;

            string cat = (string) readOnly[0];


            await Navigation.PushAsync(new OccasionCategoryPage(cat));
        }
    }
}
