using SoftwareEngineeringFinalProject.Data;
using SoftwareEngineeringFinalProject.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoftwareEngineeringFinalProject
{
    public partial class App : Application
    {
        static Database db;
        static User user;

        //create the database
        public static Database DB
        {
            get
            {
                if (db == null)
                {
                    db = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Database.db3"));
                    //if (db.GetUserAsync("test", "1234") == null)
                    //{
                    //    User testUser = new User
                    //    {
                    //        UserName = "test",
                    //        UserPassword = "1234",
                    //        FirstName = "FirstName",
                    //        LastName = "LastName"
                    //    };
                    //    testUser.CreateCart();
                    //    db.SaveUserAsync(testUser);
                    //}
                }
                return db;
            }
        }
        public static User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
