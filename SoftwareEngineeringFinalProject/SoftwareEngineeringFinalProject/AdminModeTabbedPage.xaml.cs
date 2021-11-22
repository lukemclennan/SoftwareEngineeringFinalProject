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
    public partial class AdminModeTabbedPage : TabbedPage
    {
        public AdminModeTabbedPage()
        {
            InitializeComponent();
            this.Children.Add(new ContentPage
            {
                Title = "Home",
                Content = new Label
                {
                    Text = "Home page will go here"
                }
            });
            this.Children.Add(new ContentPage
            {
                Title = "Users",
                Content = new Label
                {
                    Text = "Users page will go here"
                }
            });
            this.Children.Add(new DeleteUser
            {
                Title = "Delete User"
            });
            this.Children.Add(new ViewFlowersPage
            {
                Title = "List of Flowers"
            });
            this.Children.Add(new AddFlowerPage
            {
                Title = "Add Flower"
            });
            this.Children.Add(new ContentPage
            {
                Title = "Delete Flower",
                Content = new Label
                {
                    Text = "Delete flower page will go here"
                }
            });
            this.Children.Add(new ContentPage
            {
                Title = "Orders",
                Content = new Label
                {
                    Text = "Order page will go here"
                }
            });
        }
    }
}
