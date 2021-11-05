using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareEngineeringFinalProject.Models
{
    public class OrderItem
    {
        [PrimaryKey, AutoIncrement]
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int FlowerArrangementID { get; set; }

        public void AddToOrder(Order order)
        {

        }

    }
}
