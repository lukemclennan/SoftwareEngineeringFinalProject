using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SoftwareEngineeringFinalProject
{
    public partial class AdminDeleteFlower : ContentPage
    {
        private string fname;
        //private int errorCnt;

        public AdminDeleteFlower()
        {
            InitializeComponent();
        }

       async void findAndDeleteFlower(Object sender, EventArgs e)
        {
            fname = Entry_fname.Text;
 
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
    }
}
