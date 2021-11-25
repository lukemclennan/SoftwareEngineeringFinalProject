
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SoftwareEngineeringFinalProject
{
    public partial class AdminDeleteFlower : ContentPage
    {
        private string fname;
        private string cost;
        private string url;

        public AdminDeleteFlower()
        {
            InitializeComponent();
        }

        public static double ConvertToDouble(string Value)
        {
            if (Value == null)
            {
                return 0;
            }
            else
            {
                double OutVal;
                double.TryParse(Value, out OutVal);

                if (double.IsNaN(OutVal) || double.IsInfinity(OutVal))
                {
                    return 0;
                }
                return OutVal;
            }
        }

        async void addFlower(Object sender, EventArgs e)
        {
            fname = Entry_fname.Text;
            cost = Entry_cost.Text;
            url = Entry_URL.Text;

            if (fname == null || cost == null || url == null)
            {
                await DisplayAlert("Error", "One or Multiple Entry Fields are empty", "Ok");
            }
            else
            {
                Models.Flower flower = new Models.Flower
                {
                    FlowerName = fname,
                    CostPerFlower = ConvertToDouble(cost),
                    ImagePath = url
                };
                await App.DB.SaveFlowerAsync(flower);
                await DisplayAlert("Success", "New flower added", "Ok");
            }

        }

        async void updateFlowerPrice(Object sender, EventArgs e)
        {
            fname = Entry_fname3.Text;
            cost = Entry_cost2.Text;

            //invalid entry 
            if (fname == null || cost == null)
            {
                await DisplayAlert("Error", "One or Both Entry Fields are empty", "Ok");
            }
            else
            {
                Models.Flower flower = await App.DB.GetFlowerAsync(fname);
                if (flower == null)
                {
                    await DisplayAlert("Error", "Flower does not Exist", "Ok");
                }
                else
                {
                    flower.CostPerFlower = ConvertToDouble(cost);
                    await App.DB.SaveFlowerAsync(flower);
                    await DisplayAlert("Success", "Successfuly Updated Flower Price", "Ok");
                }
            }
        }


        async void findAndDeleteFlower(Object sender, EventArgs e)
        {
            fname = Entry_fname2.Text;
 
            //invalid entry 
            if (fname == null)
            {
                await DisplayAlert("Error", "Entry Fields are empty", "Ok");
            }
            else
            {
                Models.Flower flower = await App.DB.GetFlowerAsync(fname);
                if (flower == null)
                {
                    await DisplayAlert("Error", "Flower does not Exist", "Ok");
                }
                else
                {
                    await App.DB.DeleteFlowerAsync(flower);
                    await DisplayAlert("Success", "Successfuly Removed Flower", "Ok");
                }
            }
        }

   
  

        async void addOccasion(Object sender, EventArgs e)
        {
            fname = Entry_Occ.Text;
            cost = Entry_cost3.Text;
            url = Entry_URL2.Text;

            if (fname == null || cost == null || url == null)
            {
                await DisplayAlert("Error", "One or Multiple Entry Fields are empty", "Ok");
            }
            else
            {
                Models.Occasions occ = new Models.Occasions
                {
                    OccasionName = fname,
                    CostPerOccasion = ConvertToDouble(cost),
                    ImagePath = url
                };
                await App.DB.SaveOccasionAsync(occ);
                await DisplayAlert("Success", "New Occasion Arrangment added", "Ok");
            }
        }

        async void updateOccaionPrice(Object sender, EventArgs e)
        {
            fname = Entry_fname4.Text;
            cost = Entry_cost4.Text;

            //invalid entry 
            if (fname == null || cost == null)
            {
                await DisplayAlert("Error", "One or Both Entry Fields are empty", "Ok");
            }
            else
            {
                Models.Occasions occ = await App.DB.GetOccasionAsync(fname);
                if (occ == null)
                {
                    await DisplayAlert("Error", "Occasion does not Exist", "Ok");
                }
                else
                {
                    occ.CostPerOccasion = ConvertToDouble(cost);
                    await App.DB.SaveOccasionAsync(occ);
                    await DisplayAlert("Success", "Successfuly Updated Flower Price", "Ok");
                }
            }
        }

        async void deleteOccasion(Object sender, EventArgs e)
        {
            fname = Entry_Occ2.Text;
            if (fname == null)
            {
                await DisplayAlert("Error", "Entry Fields are empty", "Ok");
            }
            else
            {
                Models.Occasions occ = await App.DB.GetOccasionAsync(fname);
                if (occ == null)
                {
                    await DisplayAlert("Error", "Occasion does not Exist", "Ok");
                }
                else
                {
                    await App.DB.DeleteOccasionAsyn(occ);
                    await DisplayAlert("Success", "Successfuly Removed Occasion", "Ok");
                }
            }
        }

    
    }
}

