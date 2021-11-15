﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SoftwareEngineeringFinalProject
{
    public partial class LoginPage : ContentPage
    {
        public int errorCount = 0;
        public string username;
        public string password;
        public LoginPage()
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
        public void LoginProcedure(object sender, EventArgs e)
        {
            password = Entry_Password.Text;
            username = Entry_Username.Text;
            ValidateLogin();
            if (errorCount > 0) //one of the entries is empty
            {
                DisplayAlert("Error", "One or Both Entry Fields are empty", "Ok");
                errorCount = 0;
            }
            else //both entries are not empty
            {
                DisplayAlert("Test", "Username: " + username + " Password: " + password, "Ok");
            }
        }
        public void SignUpProcedure(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignupPageV2());
        }
    }
}
