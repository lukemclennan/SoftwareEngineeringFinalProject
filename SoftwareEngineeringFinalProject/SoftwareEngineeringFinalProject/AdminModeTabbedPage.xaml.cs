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
                    Text = "List of Flowers will go here"
                }
            });
            this.Children.Add(new AdminDisplayUsers
            {
                Title = "Users"
            });
            this.Children.Add(new DeleteUser
            {
                Title = "Delete User"
            });
            this.Children.Add(new AdminDeleteFlower
            {
               Title = "Flower Options"
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
