using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using SoftwareEngineeringFinalProject.Models;

namespace SoftwareEngineeringFinalProject.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

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
            database.CreateTableAsync<Cart>().Wait();
            database.CreateTableAsync<CartItem>().Wait();
        }

        public Task<List<CartItem>> GetCartItemsAsync(int cartID)
        {
            return database.Table<CartItem>().Where(i => i.CartID == cartID).ToListAsync();
        }
        //public async Task<List<CartItem>> GetCartArrangementsAsync(int cartID)
        //{
        //    List<CartItem> cartItems = await database.Table<CartItem>().Where(i => i.CartID == cartID).ToListAsync();
        //    foreach (CartItem cartItem in cartItems) { 
                
        //    }
        //}

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

        public Task<FlowerArrangement> GetFlowerArrangementAsync(int id)
        {
            // Get a specific note.
            return database.Table<FlowerArrangement>()
                            .Where(i => i.FlowerID == id)
                            .FirstOrDefaultAsync();
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
