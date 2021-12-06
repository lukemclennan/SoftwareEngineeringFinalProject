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

            //database

            //occasions data
            Models.Occasions birthdayCelebration = new Models.Occasions
            {
                OccasionName = "Birthday Celebration",
                CostPerOccasion = 54.95,
                ImagePath = "https://www.scottsflowers.com/images/telsg10/T28-1^1xg.jpg"
            };
            Models.Occasions christmasWishesCenterpiece = new Models.Occasions
            {
                OccasionName = "Christmas Wishes Centerpiece",
                CostPerOccasion = 69.95,
                ImagePath = "https://www.scottsflowers.com/images/T127-1xg.jpg"
            };
            Models.Occasions newYearsRadianRouge = new Models.Occasions
            {
                OccasionName = "New Year's Radiant Rouge",
                CostPerOccasion = 99.95,
                ImagePath = "https://www.scottsflowers.com/images/flowerclique/FCRV-13lg.jpg"
            };

            if (DB.GetOccasionAsync(birthdayCelebration.OccasionName) == null)
                DB.SaveOccasionAsync(birthdayCelebration);
            if (DB.GetOccasionAsync(christmasWishesCenterpiece.OccasionName) == null)
                DB.SaveOccasionAsync(birthdayCelebration);
            if (DB.GetOccasionAsync(newYearsRadianRouge.OccasionName) == null)
                DB.SaveOccasionAsync(birthdayCelebration);

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
