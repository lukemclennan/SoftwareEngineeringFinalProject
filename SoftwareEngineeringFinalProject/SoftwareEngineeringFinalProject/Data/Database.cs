using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SoftwareEngineeringFinalProject.Models;
using System;
using System.Collections;

namespace SoftwareEngineeringFinalProject.Data
{
    public class Database
    {
        private readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Admin>().Wait();
            database.CreateTableAsync<Payment>().Wait();
            database.CreateTableAsync<User>().Wait();
            database.CreateTableAsync<Order>().Wait();
            database.CreateTableAsync<OrderItem>().Wait();
            database.CreateTableAsync<Flower>().Wait();
            database.CreateTableAsync<FlowerArrangement>().Wait();
            database.CreateTableAsync<Occasions>().Wait();
            database.CreateTableAsync<Cart>().Wait();
            database.CreateTableAsync<CartItem>().Wait();

            Console.WriteLine("Database path is:    " + dbPath + "\n");

            AddData();
            

        }


        private async void AddData() {
            //occasions data
            Occasions birthdayCelebration = new Occasions
            {
                OccasionName = "Birthday Celebration",
                OccasionCategory = "Personal",
                CostPerOccasion = 54.95,
                ImagePath = "https://www.scottsflowers.com/images/telsg10/T28-1^1xg.jpg"
            };
            Occasions christmasWishesCenterpiece = new Occasions
            {
                OccasionName = "Christmas Wishes Centerpiece",
                OccasionCategory = "Holidays", 
                CostPerOccasion = 69.95,
                ImagePath = "https://www.scottsflowers.com/images/T127-1xg.jpg"
            };
            Occasions newYearsRadianRouge = new Occasions
            {
                OccasionName = "New Year's Radiant Rouge",
                OccasionCategory = "Holidays",
                CostPerOccasion = 99.95,
                ImagePath = "https://www.scottsflowers.com/images/flowerclique/FCRV-13lg.jpg"
            };

            if ((await GetOccasionAsync(birthdayCelebration.OccasionName)) == null)
                await SaveOccasionAsync(birthdayCelebration);
            if ((await GetOccasionAsync(christmasWishesCenterpiece.OccasionName)) == null)
                await SaveOccasionAsync (christmasWishesCenterpiece);
            if ((await GetOccasionAsync(newYearsRadianRouge.OccasionName)) == null)
                await SaveOccasionAsync (newYearsRadianRouge);

            //flower category data
            Models.Flower Rose = new Models.Flower
            {
                FlowerName = "Rose",
                ImagePath = "https://www.scottsflowers.com/gifs/hp-roses.jpg"
            };
            Models.Flower Lavender = new Models.Flower
            {
                FlowerName = "Lavender",
                ImagePath = "https://www.scottsflowers.com/images/telsg10/T600-9^1lg.jpg"
            };
            Models.Flower BestSeller = new Models.Flower
            {
                FlowerName = "BestSeller",
                ImagePath = "https://www.scottsflowers.com/gifs/hp-celebrations.jpg"
            };
            Models.Flower Modern = new Models.Flower
            {
                FlowerName = "Modern",
                ImagePath = "https://www.scottsflowers.com/gifs/hp-birthday.jpg"
            };
            if ((await GetFlowerAsync(Rose.FlowerName)) == null)
                await SaveFlowerAsync(Rose);
            if ((await GetFlowerAsync(Lavender.FlowerName)) == null)
                await SaveFlowerAsync(Lavender);
            if ((await GetFlowerAsync(BestSeller.FlowerName)) == null)
                await SaveFlowerAsync(BestSeller);
            if ((await GetFlowerAsync(Modern.FlowerName)) == null)
                await SaveFlowerAsync(Modern);

            //flower arrangement Rose data
            Models.FlowerArrangement LoveStory = new Models.FlowerArrangement
            {
                FlowerArrangementName = "Love Story",
                Category = "Rose",
                costPerArrangement = 209.95,
                Description = "Love Story is a 'wow' arrangement! It is ultimate beauty and perfection! It features a dozen roses, Hydrangea, Snapdragons, Stock, Aspidistra, and other premium foliage. Roses symbolize love and hope and are the perfect anniversary gift or gift of love.",
                ImagePath = "https://www.scottsflowers.com/images/flowerclique/FC-15xg.jpg"
            };
            Models.FlowerArrangement EndlessLoveStory = new Models.FlowerArrangement
            {
                FlowerArrangementName = "Endless Love Story",
                Category = "Rose",
                costPerArrangement = 249.95,
                Description = "Endless Love Story is a 'wow' arrangement! It is ultimate beauty and perfection! It features a dozen roses, Lilies, Hydrangea, Snapdragons, Stock, Aspidistra, and other premium foliage. Roses symbolize love and hope and are the perfect anniversary gift. Lilies symbolize happiness and purity of heart, which makes this design a shop and customer favorite.",
                ImagePath = "https://www.scottsflowers.com/images/flowerclique/FCRL-03lg.jpg"
            };
            Models.FlowerArrangement FreeSpiritRoses = new Models.FlowerArrangement
            {
                FlowerArrangementName = "Free Spirit Roses",
                Category = "Rose",
                costPerArrangement = 75.95,
                Description = "Free Spirit roses know no bounds! They are a long-lasting treat for the senses. Their unique tones of color range from orange, peach, persimmon, and pink, often all in one bloom! Their scent will fill and brighten any room. This design features half a dozen Free Spirit Roses, accented with complementing green foliage. This design is perfect for any occasion!",
                ImagePath = "https://www.scottsflowers.com/images/flowerclique/FCFS-01lg.jpg"
            };

            if ((await GetFlowerArrangementByName(LoveStory.FlowerArrangementName)) == null)
                await SaveFlowerArrangement(LoveStory);
            if ((await GetFlowerArrangementByName(EndlessLoveStory.FlowerArrangementName)) == null)
                await SaveFlowerArrangement(EndlessLoveStory);
            if ((await GetFlowerArrangementByName(FreeSpiritRoses.FlowerArrangementName)) == null)
                await SaveFlowerArrangement(FreeSpiritRoses);

            //Flower arrangement Lavender data
            Models.FlowerArrangement GraciousLavenderBasket = new Models.FlowerArrangement
            {
                FlowerArrangementName = "Gracious Lavender Basket",
                Category = "Lavender",
                costPerArrangement = 124.95,
                Description = "Soothing lavender, respectful purple and compassionate pinks are combined beautifully in this basket overflowing with pretty flowers, sincerity and sympathy. A lovely way to share your thoughts and pay tribute to someone special.",
                ImagePath = "https://www.scottsflowers.com/images/telsg10/T235-1^1lg.jpg"
            };
            Models.FlowerArrangement VibrantLavenderRoses = new Models.FlowerArrangement
            {
                FlowerArrangementName = "Vibrant Lavender Roses",
                Category = "Lavender",
                costPerArrangement = 109.95,
                Description = "While lavender roses signify love at first sight, they are also the perfect gift for anyone who loves purple! This bouquet contains 12 lavender roses mixed with a variety of fresh foliage in a tall rectangular vase. Vibrant Lavender Roses will make a beautiful anniversary or just because gift for that special someone.",
                ImagePath = "https://www.scottsflowers.com/images/flowerclique/FC-38xg.jpg"
            };
            Models.FlowerArrangement TeleflorasSweetSachet = new Models.FlowerArrangement
            {
                FlowerArrangementName = "Telefloras Sweet Sachet",
                Category = "Lavender",
                costPerArrangement = 79.95,
                Description = "Sweet as can be! In a chic lavender cube, this marvelous mix of jewel toned blooms is a touching way to celebrate someone special on their birthday or any day.",
                ImagePath = "https://www.scottsflowers.com/images/telsg10/T600-9^1lg.jpg"
            };
            if ((await GetFlowerArrangementByName(GraciousLavenderBasket.FlowerArrangementName)) == null)
                await SaveFlowerArrangement(GraciousLavenderBasket);
            if ((await GetFlowerArrangementByName(VibrantLavenderRoses.FlowerArrangementName)) == null)
                await SaveFlowerArrangement(VibrantLavenderRoses);
            if ((await GetFlowerArrangementByName(TeleflorasSweetSachet.FlowerArrangementName)) == null)
                await SaveFlowerArrangement(TeleflorasSweetSachet);

            //Flower arrangement Best Seller data
            Models.FlowerArrangement MangoSunrise = new Models.FlowerArrangement
            {
                FlowerArrangementName = "Mango Sunrise",
                Category = "BestSeller",
                costPerArrangement = 69.95,
                Description = "Mango Sunrise may look good enough to eat but it's even more beautiful to display! This vibrant collection contains Myra and orange roses, carnations, alstroemeria, and dianthus accented with a variety of foliage in a clear cylinder container. This colorful arrangement would be perfect on a side table or desk.",
                ImagePath = "https://www.scottsflowers.com/images/flowerclique/FCOP-01lg.jpg"
            };
            Models.FlowerArrangement ThatDarling = new Models.FlowerArrangement
            {
                FlowerArrangementName = "That Darling",
                Category = "BestSeller",
                costPerArrangement = 59.95,
                Description = "Send your love with this beautiful design, perfect for a birthday or romantic gift. That's Darling features pink Myra roses, soft pastel hydrangea, Matsumoto asters, pink alstroemeria, lavender Limonium, and bupleurum for a long-lasting floral experience perfect for the darling in your life!",
                ImagePath = "https://www.scottsflowers.com/images/flowerclique/FCPL-03lg.jpg"
            };
            Models.FlowerArrangement BeHappyBouquet = new Models.FlowerArrangement
            {
                FlowerArrangementName = "Be Happy Bouquet",
                Category = "BestSeller",
                costPerArrangement = 39.95,
                Description = "They can't help but feel a little better when a bright yellow happy face carrying a cheerful bouquet arrives. Smiles guaranteed",
                ImagePath = "https://www.scottsflowers.com/images/telwhite03/tf109-2lg.jpg"
            };
            if ((await GetFlowerArrangementByName(MangoSunrise.FlowerArrangementName)) == null)
                await SaveFlowerArrangement(MangoSunrise);
            if ((await GetFlowerArrangementByName(ThatDarling.FlowerArrangementName)) == null)
                await SaveFlowerArrangement(ThatDarling);
            if ((await GetFlowerArrangementByName(BeHappyBouquet.FlowerArrangementName)) == null)
                await SaveFlowerArrangement(BeHappyBouquet);

            //Flower arrangement Modern data
            Models.FlowerArrangement HelloHydrangea = new Models.FlowerArrangement
            {
                FlowerArrangementName = "Hello Hydrangea",
                Category = "Modern",
                costPerArrangement = 139.95,
                Description = "Say it with Flowers! Hello, Hydrangea! is the perfect design to warm up any home or office space. Blue and white hydrangea and curly willow, artfully designed in a clear vase, will make the perfect accent to any room. You can't go wrong with this timeless look!",
                ImagePath = "https://www.scottsflowers.com/images/flowerclique/FCHY-07lg.jpg"
            };
            Models.FlowerArrangement BirdsOfParadise = new Models.FlowerArrangement
            {
                FlowerArrangementName = "Birds Of Paradise",
                Category = "Modern",
                costPerArrangement = 89.95,
                Description = "If you're looking for a touch of the tropics, this bird of paradise arrangement will heat up any home or office.",
                ImagePath = "https://www.scottsflowers.com/images/telwhite03/tf148-1lg.jpg"
            };
            Models.FlowerArrangement SunshineAndSmiles = new Models.FlowerArrangement
            {
                FlowerArrangementName = "Sunshine And Smiles",
                Category = "Modern",
                costPerArrangement = 199.95,
                Description = "Someone special makes you smile? Send this impressive array of colorful flowers, and they'll smile right back.",
                ImagePath = "https://www.scottsflowers.com/images/telwhite03/tf5-1xg.jpg"
            };
            if ((await GetFlowerArrangementByName(HelloHydrangea.FlowerArrangementName)) == null)
                await SaveFlowerArrangement(HelloHydrangea);
            if ((await GetFlowerArrangementByName(BirdsOfParadise.FlowerArrangementName)) == null)
                await SaveFlowerArrangement(BirdsOfParadise);
            if ((await GetFlowerArrangementByName(SunshineAndSmiles.FlowerArrangementName)) == null)
                await SaveFlowerArrangement(SunshineAndSmiles);

        }

        public Task<Order> GetOrderAsync(int orderID)
        {
            return database.Table<Order>().Where(i => i.OrderID == orderID).FirstOrDefaultAsync();
        }

        public async Task<List<FlowerArrangement>> GetOrderArrangementsAsync(int orderID)
        {
            List<OrderItem> orderItems = await database.Table<OrderItem>().Where(i => i.OrderID == orderID).ToListAsync();
            List<FlowerArrangement> flowerArrangements = new List<FlowerArrangement>();
            foreach (OrderItem item in orderItems)
            {
                FlowerArrangement flowerArrangement = await GetFlowerArrangementAsync(item.FlowerArrangementID);
                flowerArrangements.Add(flowerArrangement);
            }
            return flowerArrangements;
        }
        public Task<Cart> GetCartAsync(int cartID)
        {
            return database.Table<Cart>().Where(i => i.CartID == cartID).FirstOrDefaultAsync();
        }
        public Task<int> SaveCartAsync(Cart cart)
        {
            return database.InsertAsync(cart);
        }

        public Task<int> DeleteCartItemAsync(CartItem cartItem)
        {
            return database.DeleteAsync(cartItem);
        }

        public Task<CartItem> GetCartItemAsync(int cartItemID)
        {
            return database.Table<CartItem>()
                           .Where(i => i.CartItemID == cartItemID)
                           .FirstOrDefaultAsync();
        }

        public Task<List<CartItem>> GetCartItemsAsync(int cartID)
        {
            return database.Table<CartItem>().Where(i => i.CartID == cartID).ToListAsync();
        }

        public async Task<List<FlowerArrangement>> GetCartArrangementsAsync(int cartID)
        {
            List<CartItem> cartItems = await database.Table<CartItem>().Where(i => i.CartID == cartID).ToListAsync();
            List<FlowerArrangement> flowerArrangements = new List<FlowerArrangement>();
            foreach (CartItem cartItem in cartItems)
            {
                FlowerArrangement flowerArrangement = await GetFlowerArrangementAsync(cartItem.FlowerArrangementID);
                flowerArrangements.Add(flowerArrangement);
            }
            return flowerArrangements;
        }

        public Task<List<CartQueryResult>> GetCartArrangementsAsync2(int cartID)
        {
            return database.QueryAsync<CartQueryResult>($"SELECT c.CartItemID, c.FlowerArrangementID, f.FlowerArrangementName, f.IsOccasion, f.FlowerID, f.costPerArrangement FROM FlowerArrangement f INNER JOIN CartItem c ON f.FlowerArrangementID = c.FlowerArrangementID WHERE c.CartID = {cartID}");
        }

        public Task<List<CartQueryResult2>> GetCartOccasionsAsync(int cartID)
        {
            return database.QueryAsync<CartQueryResult2>($"SELECT c.CartItemID, c.OccasionID, f.OccasionName, f.CostPerOccasion FROM Occasions f INNER JOIN CartItem c ON f.OccasionID = c.OccasionID WHERE c.CartID = {cartID}");

        }

        public Task<int> SaveAdminAsyn(Admin admin)
        {
            if (admin.AdminID != 0)
            {
                return database.UpdateAsync(admin);
            }
            return database.InsertAsync(admin);
        }
        public Task<Admin> GetAdminAsync(string username)
        {
            return database.Table<Admin>().Where(i => i.AdminUsername == username).FirstOrDefaultAsync();
        }
        public Task<Admin> GetAdminAsync(string username, string password)
        {
            return database.Table<Admin>().Where(i => i.AdminUsername == username && i.AdminPassword == password).FirstOrDefaultAsync();
        }
        public Task<Admin> GetAdminAsync(int id)
        {
            return database.Table<Admin>().Where(i => i.AdminID == id).FirstOrDefaultAsync();
        }

        /* ** ** ** ** User ** ** ** **  */
        public Task<List<User>> GetUsersAsync()
        {
            return database.Table<User>().ToListAsync();
        }
        public Task<User> GetUserAsync(int id)
        {
            return database.Table<User>()
                            .Where(i => i.UserID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<User> GetUserAsync(string username)
        {
            return database.Table<User>().Where(i => i.UserName == username).FirstOrDefaultAsync();
        }
        public Task<User> GetUserAsync(string username, string password)
        {
            return database.Table<User>()
                            .Where(i => i.UserName == username && i.UserPassword == password)
                            .FirstOrDefaultAsync();
        }

        public Task<User> GetUserFnameLnameAsync(string fname, string lname)
        {
            return database.Table<User>().Where(i => i.FirstName == fname && i.LastName == lname).FirstOrDefaultAsync();
        }

        public Task<int> SaveOrderAsync(Order order)
        {
            return database.InsertAsync(order);
        }

        public Task<List<Order>> GetOrdersAsync()
        {
            return database.Table<Order>().ToListAsync();
        }

        public Task<int> SaveOrderItemAsync(OrderItem orderItem)
        {
            if (orderItem.OrderItemID != 0)
            {
                return database.UpdateAsync(orderItem);
            }
            else
            {
                return database.InsertAsync(orderItem);
            }
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.UserID != 0)
            {
                return database.UpdateAsync(user);
            }
            else
            {
                return database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return database.DeleteAsync(user);
        }


       /* ** ** ** ** Occasions Arrangment ** ** ** **  */
        public Task<List<Occasions>> GetOccasionsAsync()
        {
            return database.Table<Occasions>().ToListAsync();
        }
        public Task<Occasions> GetOccasionAsync(string OccName)
        {
            return database.Table<Occasions>()
                           .Where(i => i.OccasionName == OccName)
                           .FirstOrDefaultAsync();
        }
        
        public Task<Occasions> GetOccasionAsync(int OccId)
        {
            return database.Table<Occasions>()
                           .Where(i => i.OccasionID == OccId)
                           .FirstOrDefaultAsync();
        }

        public Task<List<Occasions>> GetOccasionByCategory(string category)
        {
            return database.Table<Occasions>()
                           .Where(i => i.OccasionCategory == category)
                           .ToListAsync();
        }
        public Task<int> SaveOccasionAsync(Occasions o)
        {
            if (o.OccasionID != 0)
            {
                return database.UpdateAsync(o);
            }
            else
            {
                return database.InsertAsync(o);
            }
        }
        public Task<int> DeleteOccasionAsyn(Occasions o)
        {
            return database.DeleteAsync(o);
        }

        /* ** ** ** ** Arrangements ** ** ** **  */
        public Task<List<FlowerArrangement>> GetFlowerArrangementsAsync()
        {
            return database.Table<FlowerArrangement>().ToListAsync();
        }
        public Task<FlowerArrangement> GetFlowerArrangementByName(string fname)
        {
            return database.Table<FlowerArrangement>()
                            .Where(i => i.FlowerArrangementName == fname).FirstOrDefaultAsync();
        }
        public Task<List<FlowerArrangement>> GetFlowerArrangementsByFlowerID(int ID)
        {
            return database.Table<FlowerArrangement>()
                           .Where(i => i.FlowerID == ID)
                           .ToListAsync();
        }
        public Task<List<FlowerArrangement>> GetFlowerArrangementsByCategory(string cat)
        {
            return database.Table<FlowerArrangement>().Where(i => i.Category == cat).ToListAsync();
        }
            public Task<int> DeleteFlowerArrangement(FlowerArrangement flower)
        {
            return database.DeleteAsync(flower);
        }
        public Task<int> SaveFlowerArrangement(FlowerArrangement flower)
        {
            if (flower.FlowerArrangementID != 0)
            {
                return database.UpdateAsync(flower);
            }
            else
            {
                return database.InsertAsync(flower);
            }
        }


        /* ** ** ** ** Payment ** ** ** **  */
        public Task<List<Payment>> GetPaymentsAsync()
        {
            return database.Table<Payment>().ToListAsync();
        }

        public Task<Payment> GetPaymentAsync(int id)
        {
            return database.Table<Payment>()
                            .Where(i => i.PaymentID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SavePaymentAsync(Payment p)
        {
            if (p.PaymentID != 0)
            {
                return database.UpdateAsync(p);
            }
            else
            {
                return database.InsertAsync(p);
            }
        }

        public Task<int> DeletePaymentAsync(Payment p)
        {
            return database.DeleteAsync(p);
        }

        /* ** ** ** ** Categories ** ** ** **  */
        public Task<List<Flower>> GetFlowersAsync()
        {
            return database.Table<Flower>().ToListAsync();
        }

        public Task<Flower> GetFlowerAsync(int id)
        {
            return database.Table<Flower>()
                            .Where(i => i.FlowerID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<Flower> GetFlowerAsync(string name)
        {
            return database.Table<Flower>()
                            .Where(i => i.FlowerName == name)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveFlowerAsync(Flower flower)
        {
            if (flower.FlowerID != 0)
            {
                return database.UpdateAsync(flower);
            }
            else
            {
                return database.InsertAsync(flower);
            }
        }

        public Task<int> DeleteFlowerAsync(Flower flower)
        {
            return database.DeleteAsync(flower);
        }

        public Task<FlowerArrangement> GetFlowerArrangementAsync(int id)
        {
            return database.Table<FlowerArrangement>()
                            .Where(i => i.FlowerArrangementID == id)
                            .FirstOrDefaultAsync();
        }

        //public Task<List<FlowerArrangement>> GetFlowerArrangementsByCategory(int flowerID)
        //{
        //    return database.Table<FlowerArrangement>().Where(i => i.FlowerID == flowerID).ToListAsync();
        //}

        //public Task<int> SaveFlowerArrangementAsync(FlowerArrangement flowerArrangement)
        //{
        //    if (flowerArrangement.FlowerArrangementID != 0)
        //    {
        //        // Update an existing note.
        //        return database.UpdateAsync(flowerArrangement);
        //    }
        //    else
        //    {
        //        // Save a new note.
        //        return database.InsertAsync(flowerArrangement);
        //    }
        //}

        //* ** ** ** ** CART ITEM ** ** ** *** ** *//
        public Task<int> SaveCartItemAsync(CartItem cartItem)
        {
            if (cartItem.CartItemID != 0)
            {
                return database.UpdateAsync(cartItem);
            }
            else
            {
                return database.InsertAsync(cartItem);
            }
        }
    }
}
