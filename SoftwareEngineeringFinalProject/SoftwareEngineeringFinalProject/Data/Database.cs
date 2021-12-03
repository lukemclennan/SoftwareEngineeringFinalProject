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
            database.CreateTableAsync<Occasions>().Wait();
            database.CreateTableAsync<Cart>().Wait();
            database.CreateTableAsync<CartItem>().Wait();
        }
        /* ** ** ** ** Admin ** ** ** **  */
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
