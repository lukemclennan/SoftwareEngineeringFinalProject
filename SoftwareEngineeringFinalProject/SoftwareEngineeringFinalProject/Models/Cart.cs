using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringFinalProject.Models
{
    public class Cart
    {
        [PrimaryKey, AutoIncrement]
        public int CartID { get; set; }
        public async Task<double> GetTotalCost() {
            double cost = 0.0;
            //get cart arrangements
            List<CartQueryResult> items = await App.DB.GetCartArrangementsAsync2(CartID);
            //sum up prices of each arrangement
            foreach (CartQueryResult item in items)
            {
                cost += item.costPerArrangement;
            }
            //get cart occasions
            List<CartQueryResult2> occasions = await App.DB.GetCartOccasionsAsync(CartID);
            //sum up prices of each occasion
            foreach (CartQueryResult2 occasion in occasions)
            {
                cost += occasion.CostPerOccasion;
            }
            return cost;
        }
    }
}
