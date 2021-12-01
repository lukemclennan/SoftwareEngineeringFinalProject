
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace SoftwareEngineeringFinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserModeTabbedPage : Xamarin.Forms.TabbedPage
    {
        public UserModeTabbedPage()
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
            this.Children.Add(new OccasionsPage
            {
                Title = "Occasions"
            });
            this.Children.Add(new ContentPage
            {
                Title = "Arrangments",
                Content = new Label
                {
                    Text = "Arrangments page will go here"
                }
            });
            this.Children.Add(new AdminLoginPage
            {
                Title = "Admin Mode"
            });
            this.Children.Add(new AboutPageV2
            {
                Title = "About"
            });

            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}
