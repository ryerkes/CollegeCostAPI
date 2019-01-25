using System;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace CollegeCostAPI
{
    public class College
    {
        [Index(0)]
        public String name { get; set; }
        [Index(1)]
        public decimal? inStateTuition { get; set; }
        [Index(2)]
        public decimal? outStateTuition { get; set; }
        [Index(3)]
        public decimal? roomCost { get; set; }

        /// <summary>
        /// Calculate the total cost for the selected college, including the room and board cost as long as the user did not type "false".
        /// </summary>
        /// <param name="addRoom">Takes boolean addRoom</param>
        /// <returns>Returns the decimal, total; if null, throws an error</returns>
        public decimal getCost(Boolean addRoom)
        {
            decimal? total;
            if (addRoom != false)
            {
                if (inStateTuition.Equals(null))  //Add room and board, and in-state tuition is null, so add out of state:
                {
                    total = outStateTuition + roomCost;
                }
                else  //Add room and board, and in-state tuition is not null so in-state tuition:
                {
                    total = inStateTuition + roomCost;
                }
            }
            else
            {
                if (inStateTuition.Equals(null))  //No room and board, and in-state tuition is null, so only out of state:
                {
                    total = outStateTuition;
                }
                else  //No room and board, and in-state tuition not null, so in-state tuition:
                {
                    total = inStateTuition;
                }
            }
            if (total.HasValue)   //Change decmial? to decimal as long as total is not null.
            {
                return total.Value;
            }
            
            else  //Error if there was a null value.
            {
                throw new Exception(string.Format("Error: No cost values found for {0}.", name));
            }
        }
    }
}
