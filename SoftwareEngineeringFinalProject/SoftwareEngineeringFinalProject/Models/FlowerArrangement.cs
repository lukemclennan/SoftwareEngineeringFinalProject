using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareEngineeringFinalProject.Models
{
    class FlowerArrangement
    {
        [PrimaryKey, AutoIncrement]
        public int FlowerArrangementID { get; set; }
        public string FlowerArrangementName { get; set; }
        public int FlowerID { get; set; }
        public int Quantity { get; set; }
        public bool IsOccasion { get; set; }
        public string Occasion { get; set; }
        public bool IsVase { get; set; }
        public double GetPrice()
        {
            return 0.0;
        }
    }
}
