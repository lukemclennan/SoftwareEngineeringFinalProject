using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SoftwareEngineeringFinalProject.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoftwareEngineeringFinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewSingleOrder : ContentPage
    {
        private int orderID;
        public ViewSingleOrder(int id)
        {
            orderID = id;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            LabelCartID.Text = "CartID: " + orderID;
            Order order = await App.DB.GetOrderAsync(orderID);
            User customer = await App.DB.GetUserAsync(order.UserID);
            if (customer == null)
            {
                LabelCustomer.Text = "Customer UserID: " + order.UserID;
            }
            else
            {
                LabelCustomer.Text = "Customer: " + customer.FirstName + " " + customer.LastName;
            }

            collectionView.ItemsSource = await App.DB.GetOrderArrangementsAsync(orderID);
        }
    }
}