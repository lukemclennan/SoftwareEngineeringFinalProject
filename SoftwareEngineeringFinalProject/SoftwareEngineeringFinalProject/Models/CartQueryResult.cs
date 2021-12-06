using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareEngineeringFinalProject.Models
{
    public class CartQueryResult
    {
        public int CartItemID { get; set; }
        public int FlowerArrangementID { get; set; }
        public string FlowerArrangementName { get; set; }
        public float costPerArrangement { get; set; }
        public bool IsOccasion { get; set; }
        public int FlowerID { get; set; }
        
    }
}
