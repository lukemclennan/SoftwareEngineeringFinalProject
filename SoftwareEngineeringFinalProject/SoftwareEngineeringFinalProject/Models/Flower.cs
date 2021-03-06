using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareEngineeringFinalProject.Models
{
    public class Flower
    {
        [PrimaryKey, AutoIncrement]
        public int FlowerID { get; set; }
        public string FlowerName { get; set; }
        public double CostPerFlower { get; set; }
        public string ImagePath { get; set; }
    }
}
