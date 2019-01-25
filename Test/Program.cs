using System;
using System.IO;
using CollegeCostAPI;
using CsvHelper;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            String collegeName;
            Boolean addRoom;
            decimal cost;

            Console.WriteLine("Enter the name of the college to find its annual cost: ");
            collegeName = Console.ReadLine();
            Console.WriteLine("Add room and board to the total cost (true or false): ");
            addRoom = Console.ReadLine().CompareTo("false") != 0;

            cost = CostCalculator.determineCost(collegeName, "college_costs.csv", addRoom);

            Console.WriteLine("Total cost: $" + cost + " dollars. Press any key to exit.");
            Console.ReadKey();

            
        }
    }
}
