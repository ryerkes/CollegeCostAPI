using System;
using CsvHelper;
using System.IO;

namespace CollegeCostAPI
{
    public class CostCalculator
    {
        /// <summary>
        /// Opens the csv file to be read, and checks for a college name match. If one found, calls to calculate the cost.
        /// </summary>
        /// <param name="collegeName">Checks the College column in the csv file for a match with String collegeName</param>
        /// <param name="filePath">Opens the csv from the file path provided.</param>
        /// <param name="addRoom">Passes the Boolean addRoom to the cost function if the college name was not blank, and a college name had a match.</param>
        /// <returns>decimal cost</returns>
        public static decimal determineCost(String collegeName, String filePath, Boolean addRoom = true)
        {
            decimal cost = 0;
            int count = 0;
            if (collegeName == "")
            {
                throw new Exception(string.Format("Error: College name required"));
            }

            else
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    using (CsvReader csv = new CsvReader(reader))
                    {
                        csv.Configuration.HasHeaderRecord = true;
                        College record = new College();
                        var records = csv.EnumerateRecords(record);
                        foreach (College r in records)
                        {
                            if (collegeName == r.name)
                            {
                                count++;
                                cost = r.getCost(addRoom);
                            }
                        }
                    }
                    if (count == 0)
                    {
                        throw new Exception(string.Format("Error: College not found"));
                    }
                }
            }
            return cost;
        }
    } 
}
