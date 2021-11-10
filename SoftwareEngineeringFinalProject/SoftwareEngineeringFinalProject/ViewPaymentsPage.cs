using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SoftwareEngineeringFinalProject
{
    public class ViewPaymentsPage : ContentPage
    {
        public ViewPaymentsPage()
        {
            CollectionView collectionView = new CollectionView
            {
                //ItemsSource = App.DB.GetPaymentsAsync()
            };
            Content = new StackLayout
            {
                Children = {
                    collectionView
                }
            };
        }
    }
}