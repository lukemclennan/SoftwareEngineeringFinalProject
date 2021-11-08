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
    }
}
