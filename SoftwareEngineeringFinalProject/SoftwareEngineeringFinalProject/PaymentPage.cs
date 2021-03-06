using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using SoftwareEngineeringFinalProject.Models;

namespace SoftwareEngineeringFinalProject
{
    public class PaymentPage : ContentPage
    {
        private Entry first;
        private Entry last;
        private Entry ccn;
        private DatePicker expDate;
        private Entry phone;
        private Entry address;
        private Entry city;
        private Entry state;
        private Entry country;
        private Entry zipCode;
        private Button button;
        public PaymentPage()
        {
            this.Title = "Payment";
            first = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "First Name"
            };

            last = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Last Name"
            };

            ccn = new Entry
            {
                Keyboard = Keyboard.Numeric,
                Placeholder = "Credit Card Number"
            };

            expDate = new DatePicker
            {
                Format = "D"
            };

            phone = new Entry
            {
                Keyboard = Keyboard.Telephone,
                Placeholder = "Phone Number"
            };

            address = new Entry
            {
                Keyboard = Keyboard.Default,
                Placeholder = "Address"
            };

            city = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "City"
            };

            state = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "State"
            };

            country = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Country"
            };

            zipCode = new Entry
            {
                Keyboard = Keyboard.Numeric,
                Placeholder = "Zip Code"
            };

            button = new Button();
            button.Text = "Process Payment";
            button.Clicked += Button_Clicked;

            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label {Text = "First Name"},
                        first,
                        new Label { Text = "Last Name" },
                        last,
                        new Label { Text = "Credit Card Number" },
                        ccn,
                        new Label { Text = "Expiration Date" },
                        expDate,
                        new Label { Text = "Phone Number" },
                        phone,
                        new Label { Text = "Address" },
                        address,
                        new Label { Text = "City" },
                        city,
                        new Label { Text = "State" },
                        state,
                        new Label { Text = "Country" },
                        country,
                        new Label { Text = "Zip Code" },
                        zipCode,
                        button
                    }
                }
            };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (first.Text != "" && last.Text != "" && ccn.Text != "" && expDate.Date > DateTime.Now && city.Text != "" && state.Text != "" && country.Text != "" && zipCode.Text != "")
            {
                Payment payment = new Payment
                {
                    FirstName = first.Text,
                    LastName = last.Text,
                    CreditCardNumber = ccn.Text,
                    ExpDate = expDate.Date,
                    Phone = phone.Text,
                    Address = address.Text,
                    City = city.Text,
                    State = state.Text,
                    Country = country.Text,
                    ZipCode = zipCode.Text,
                    UserID = App.User.UserID
                };
                await App.DB.SavePaymentAsync(payment);
                Order order = new Order {
                    UserID = App.User.UserID,
                    Date = DateTime.Now
                };
                await App.DB.SaveOrderAsync(order);
                List<CartItem> cartItems = await App.DB.GetCartItemsAsync(App.User.CartID);
                foreach (CartItem cartItem in cartItems) {
                    OrderItem orderItem = new OrderItem {
                        OrderID = order.OrderID,
                        FlowerArrangementID = cartItem.FlowerArrangementID
                    };
                    await App.DB.SaveOrderItemAsync(orderItem);
                    await App.DB.DeleteCartItemAsync(cartItem);
                }
                await DisplayAlert("Success", "Payment completed", "OK");
                //await Navigation.PushAsync(new PaymentsCollectionPage());
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Your payment information is incomplete", "OK");
            }
        }
    }
}
