using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoftwareEngineeringFinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewOrdersPage : ContentPage
    {
        public ViewOrdersPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await App.DB.GetOrdersAsync();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}