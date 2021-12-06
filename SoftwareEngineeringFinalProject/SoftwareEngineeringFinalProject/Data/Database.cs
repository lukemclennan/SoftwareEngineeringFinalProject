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

        public Task<int> SaveAdminAsyn(Admin admin)
        {
            if(admin.AdminID != 0)
            {
                return database.UpdateAsync(admin);
            }
            return database.InsertAsync(admin);
        }
        public Task<Admin> GetAdminAsync(string username)
        {
            // Get a specific note.
            return database.Table<Admin>().Where(i => i.AdminUsername == username).FirstOrDefaultAsync();
        }
        public Task<Admin> GetAdminAsync(string username, string password)
        {
            // Get a specific note.
            return database.Table<Admin>().Where(i => i.AdminUsername == username && i.AdminPassword == password).FirstOrDefaultAsync();
        }
        public Task<Admin> GetAdminAsync(int id)
        {
            // Get a specific note.
            return database.Table<Admin>().Where(i => i.AdminID == id).FirstOrDefaultAsync();
        }

        /* ** ** ** ** User ** ** ** **  */
        public Task< List<User> > GetUsersAsync()
        {
            //Get all notes.
            return database.Table<User>().ToListAsync();
        }
        public Task<User> GetUserAsync(int id)
        {
            // Get a specific note.
            return database.Table<User>()
                            .Where(i => i.UserID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<User> GetUserAsync(string username)
        {
            // Get a specific note.
            return database.Table<User>().Where(i => i.UserName == username).FirstOrDefaultAsync();
        }
        public Task<User> GetUserAsync(string username, string password)
        {
            // Get a specific note.
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
                // Update an existing note.
                return database.UpdateAsync(user);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            // Delete a note.
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
        public Task<int> SaveOccasionAsync(Occasions o)
        {
            if(o.OccasionID != 0)
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

        /* ** ** ** ** Payment ** ** ** **  */
        public Task<List<Payment>> GetPaymentsAsync()
        {
            //Get all notes.
            return database.Table<Payment>().ToListAsync();
        }

        public Task<Payment> GetPaymentAsync(int id)
        {
            // Get a specific note.
            return database.Table<Payment>()
                            .Where(i => i.PaymentID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SavePaymentAsync(Payment p)
        {
            if (p.PaymentID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(p);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(p);
            }
        }

        public Task<int> DeletePaymentAsync(Payment p)
        {
            // Delete a note.
            return database.DeleteAsync(p);
        }

        /* ** ** ** ** Flowers ** ** ** **  */
        public Task<List<Flower>> GetFlowersAsync()
        {
            //Get all notes.
            return database.Table<Flower>().ToListAsync();
        }

        public Task<Flower> GetFlowerAsync(int id)
        {
            // Get a specific note.
            return database.Table<Flower>()
                            .Where(i => i.FlowerID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<Flower> GetFlowerAsync(string name)
        {
            // Get a specific note.
            return database.Table<Flower>()
                            .Where(i => i.FlowerName == name)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveFlowerAsync(Flower flower)
        {
            if (flower.FlowerID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(flower);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(flower);
            }
        }

        public Task<int> DeleteFlowerAsync(Flower flower)
        {
            // Delete a note.
            return database.DeleteAsync(flower);
        }

        public Task<List<FlowerArrangement>> GetFlowerArrangementsAsync()
        {
            return database.Table<FlowerArrangement>().ToListAsync();
        }

        public Task<FlowerArrangement> GetFlowerArrangementAsync(int id)
        {
            // Get a specific note.
            return database.Table<FlowerArrangement>()
                            .Where(i => i.FlowerArrangementID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<List<FlowerArrangement>> GetFlowerArrangementsByCategory(int flowerID)
        {
            return database.Table<FlowerArrangement>().Where(i => i.FlowerID == flowerID).ToListAsync();
        }

        public Task<int> SaveFlowerArrangementAsync(FlowerArrangement flowerArrangement)
        {
            if (flowerArrangement.FlowerArrangementID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(flowerArrangement);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(flowerArrangement);
            }
        }

        public Task<int> SaveCartItemAsync(CartItem cartItem)
        {
            if (cartItem.CartItemID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(cartItem);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(cartItem);
            }
        }
    }
}
