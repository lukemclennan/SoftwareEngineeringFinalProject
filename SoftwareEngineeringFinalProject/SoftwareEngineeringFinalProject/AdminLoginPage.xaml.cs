using SoftwareEngineeringFinalProject.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SoftwareEngineeringFinalProject
{
    public partial class AdminLoginPage : ContentPage
    {
        public int errorCount = 0;
        public string username;
        public string password;
        public AdminLoginPage()
        {
            InitializeComponent();
        }
        public void ValidateLogin()
        {
            if (Entry_Username.Text == null)
                errorCount++;
            if (Entry_Password.Text == null)
                errorCount++;
        }
        public async void LoginProcedure(object sender, EventArgs e)
        {
            password = Entry_Password.Text;
            username = Entry_Username.Text;
            Models.Admin defaultAdmin = new Models.Admin
            {
                AdminFirstName = "John",
                AdminLastName = "Doe",
                AdminUsername = "admin",
                AdminPassword = "password"
            };
            if (await App.DB.GetAdminAsync(defaultAdmin.AdminUsername) == null)
            {
                await App.DB.SaveAdminAsyn(defaultAdmin);
            }
            ValidateLogin();
            if (errorCount > 0) //one of the entries is empty
            {
                await DisplayAlert("Error", "One or Both Entry Fields are empty", "Ok");
                errorCount = 0;
            }
            else //both entries are not empty
            {
                Admin admin = await App.DB.GetAdminAsync(username, password);
                if (admin == null) 
                {
                    await DisplayAlert("Error", "One or Both Entry Fields are invalid", "Ok");
                }
                else
                {
                    await DisplayAlert("Success", "Username: " + username + " Password: " + password, "Ok");
                    //await Navigation.PushAsync(new UserModeTabbedPage());
                }
            }
        }
    }
}
