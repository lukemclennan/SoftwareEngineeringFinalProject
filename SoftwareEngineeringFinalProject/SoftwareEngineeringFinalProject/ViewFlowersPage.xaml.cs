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
    public partial class ViewFlowersPage : ContentPage
    {
        public ViewFlowersPage()
        {
            InitializeComponent();

            this.Title = "Flowers";
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await App.DB.GetFlowersAsync();
        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddFlowerPage());
        }
    }
}