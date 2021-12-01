using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareEngineeringFinalProject.Models
{
    public class Occasions
    {
        [PrimaryKey, AutoIncrement]
        public int OccasionID { get; set; }
        public string OccasionName { get; set; }
        public double CostPerOccasion { get; set; }
        public string ImagePath { get; set; }
    }
}