using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SoftwareEngineeringFinalProject
{
    public class ViewSingleOrder : ContentPage
    {
        public ViewSingleOrder()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };
        }
    }
}