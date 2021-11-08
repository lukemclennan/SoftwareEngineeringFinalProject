using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareEngineeringFinalProject.Models
{
    public class CartItem
    {
        [PrimaryKey, AutoIncrement]
        public int CartItemID { get; set; }
        public int CartID { get; set; }
        public int FlowerArrangementID { get; set; }

    }
}
