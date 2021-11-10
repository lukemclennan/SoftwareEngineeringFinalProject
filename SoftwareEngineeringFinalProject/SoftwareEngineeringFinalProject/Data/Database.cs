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
            database.CreateTableAsync<Payment>().Wait();
            database.CreateTableAsync<User>().Wait();
            database.CreateTableAsync<Order>().Wait();
            database.CreateTableAsync<OrderItem>().Wait();
            database.CreateTableAsync<Flower>().Wait();
            database.CreateTableAsync<FlowerArrangement>().Wait();
            database.CreateTableAsync<Cart>().Wait();
            database.CreateTableAsync<CartItem>().Wait();
        }

        public Task<List<User>> GetUsersAsync()
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
    }
}