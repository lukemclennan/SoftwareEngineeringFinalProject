using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareEngineeringFinalProject.Models
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]
        public int OrderID { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }

        public double GetPrice()
        {
            return 0.0;
        }
    }
}
