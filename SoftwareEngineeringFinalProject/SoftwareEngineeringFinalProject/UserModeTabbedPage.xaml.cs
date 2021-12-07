
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
            this.Children.Add(new HomePage
            {
                Title = "Home"
            });
            this.Children.Add(new OccasionsPage
            {
                Title = "Occasions"
            });
            this.Children.Add(new CartPage
            {
                Title = "Cart"
            });
            this.Children.Add(new AdminLoginPage
            {
                Title = "Admin Mode"
            });
            this.Children.Add(new AboutPageV2
            {
                Title = "About"
            });

            Title = Children[TabIndex].Title;

            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }

    }
}
