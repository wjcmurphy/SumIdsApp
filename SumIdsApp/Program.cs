using System;
using System.Collections.Generic;

namespace SumIdsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool valid = false;
            bool tryAgain = false;
            bool hasAnswer = false;
            string filePath = "";
            RootObject ro = new RootObject();
            List<int> sums = new List<int>();

            while (!valid)
            {
                //Ask for file input
                Console.WriteLine("Please enter a valid file path and press enter: ");
                //Read file path input and check that file exists
                filePath = Console.ReadLine();
                //Try to load the data from the file path given into the RootObject
                //If succesful break out
                if (HelperMethods.LoadData(filePath, ro))
                {
                    hasAnswer = true;
                    break;
                }
                //If file doesn't exist then prompt user to try another location
                Console.WriteLine("I'm sorry we couldn't find that file, would you like to try again?(Y/N)");
                string tryAgainAns = Console.ReadLine();
                if (tryAgainAns?.ToUpper() != "Y")
                {
                    break;
                }
            }
            //If Load data returned true then we allow calculate sums to process the file and print the result
            if (hasAnswer)
            {
                sums = HelperMethods.CalculateSums(ro);
                foreach (var sum in sums)
                {
                    Console.WriteLine(sum);
                }
            }
            Console.WriteLine("Thanks for stopping by press any key to quit...");
            Console.ReadLine();
        }
    }
}
