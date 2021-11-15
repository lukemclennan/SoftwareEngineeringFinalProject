using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftwareEngineeringFinalProject.Models;

using Xamarin.Forms;

namespace SoftwareEngineeringFinalProject
{
    public class AddFlowerPage : ContentPage
    {
        private Entry name;
        private Entry price;
        private Entry img;
        private Button button;
        public AddFlowerPage()
        {
            this.Title = "Add Flower";
            name = new Entry
            {
                Placeholder = "Flower name",
                Keyboard = Keyboard.Text
            };
            price = new Entry
            {
                Keyboard = Keyboard.Numeric,
                Placeholder = "Cost per flower"
            };
            img = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "https://www.domain.com/image.jpg"
            };
            button = new Button();
            button.Text = "Save";
            button.Clicked += Button_Clicked;
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Flower name:" },
                    name,
                    new Label { Text = "Cost per flower:" },
                    price,
                    new Label { Text = "Image URL:" },
                    img,
                    button
                }
            };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            double cost;
            if (name.Text != null && img.Text != null && (cost = Convert.ToDouble(price.Text)) != 0.0)
            {
                Flower newFlower = new Flower
                {
                    FlowerName = name.Text,
                    CostPerFlower = cost,
                    ImagePath = img.Text
                };
                await App.DB.SaveFlowerAsync(newFlower);
                await DisplayAlert("Success", "New flower added", "Ok");
                await Navigation.PopAsync();
            }
            else {
                bool again = await DisplayAlert("Error", "Invalid input", "Try Again", "Back");
                if (!again)
                {
                    await Navigation.PopAsync();
                }
            }
        }
    }
}
