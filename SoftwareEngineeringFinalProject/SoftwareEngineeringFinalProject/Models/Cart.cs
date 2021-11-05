using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareEngineeringFinalProject.Models
{
    public class Cart
    {
        [PrimaryKey, AutoIncrement]
        public int CartID { get; set; }
        
        public void AddToCart(CartItem item)
        {

        }
    }
}
