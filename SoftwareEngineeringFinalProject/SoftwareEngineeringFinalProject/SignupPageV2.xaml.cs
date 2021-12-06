using SoftwareEngineeringFinalProject.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SoftwareEngineeringFinalProject
{
    public partial class SignupPageV2 : ContentPage
    {
        public SignupPageV2()
        {
            Title = "Sign Up";
            InitializeComponent();
        }
        public bool emptyEntry(string firstname, string lastname, string username, string password, string password2)
        {
            if (firstname == null || firstname == null || lastname == null || password == null || password2 == null)
                return true;
            return false;
        }
        public bool validName(string name)
        {
            for(int i = 0; i < name.Length; i++)
            {
                if(name[i] >= 65 && name[i] <= 90 || name[i] >= 97 && name[i] <= 122)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
        public async void SignupProcedure(object sender, EventArgs e)
        {
            if (emptyEntry(Entry_Firstname.Text, Entry_Lastname.Text, Entry_Username.Text, Entry_Password.Text, Entry_Password2.Text) )
            {
                await DisplayAlert("Error", "At least one entry is empty", "OK");
            }
            else if(Entry_Password.Text != Entry_Password2.Text)
            {
                await DisplayAlert("Error", "Passwords Do Not Match", "OK");
            }
            else if(!validName(Entry_Firstname.Text))
            {
                await DisplayAlert("Error", "First Name is not valid", "OK");
            }
            else if (!validName(Entry_Lastname.Text))
            {
                await DisplayAlert("Error", "Last Name is not valid", "OK");
            }
            else if (await App.DB.GetUserAsync(Entry_Username.Text) != null)
            {
                await DisplayAlert("Error", "Username is already taken", "OK");
            }
            else
            {
                Cart cart = new Cart();

                await App.DB.SaveCartAsync(cart);

                User user = new User
                {
                    UserName = Entry_Username.Text,
                    UserPassword = Entry_Password.Text,
                    FirstName = Entry_Firstname.Text,
                    LastName = Entry_Lastname.Text,
                    CartID = cart.CartID
                };

                //user.CreateCart();

                await DisplayAlert("Test", "CartID is " + user.CartID, "OK");


                await App.DB.SaveUserAsync(user);

                await DisplayAlert("Awesome!", "Sign up was a success", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
