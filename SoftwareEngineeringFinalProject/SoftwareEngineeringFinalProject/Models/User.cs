using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareEngineeringFinalProject.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CartID { get; set; }

        public async void CreateCart() {
            Cart cart = new Cart();
            int x = await App.DB.SaveCartAsync(cart);
            //await DisplayAlert("Cart created", "CartID = " + cart.CartID, "OK");
            CartID = cart.CartID;
            Console.WriteLine("Return value of SaveCartAsycnc: " + x);
            Console.WriteLine("CartID.cartID = " + cart.CartID);
            Console.WriteLine("CartID = " + CartID);
        }
    }
}
