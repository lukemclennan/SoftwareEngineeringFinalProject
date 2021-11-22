using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SoftwareEngineeringFinalProject
{
    public partial class DeleteUser : ContentPage
    {
        private string fname;
        private string lname;
        private int errorCnt;
  
        public DeleteUser(){
            InitializeComponent();
        }
        public void emptyString(){
            if (Entry_fname.Text == null)
                errorCnt++;
            if (Entry_lname.Text == null)
                errorCnt++;
        }

        async void findAndDelete(object sender, EventArgs e){
            fname = Entry_fname.Text;
            lname = Entry_lname.Text;
            emptyString();
            //invalid entry 
            if (errorCnt > 0){
                await DisplayAlert("Error", "One or Both Entry Fields are empty", "Ok");
                errorCnt = 0;
            }else{
                Models.User user = await App.DB.GetUserAsync(fname, lname);
                if(user == null)
                {
                    await DisplayAlert("Error", "User does not Exist", "Ok");
                }
                else
                {
                    await App.DB.DeleteUserAsync(user);
                    await DisplayAlert("Success", "Successfuly deleted User", "Ok");
                }
             }
        }
    }
}
