using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start Apps 01 to 05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Abbas Raziq 15/05/2021
    /// </summary>
    public static class Program
    {
        private static int choice;
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("BNU CO453 Applications Programming Jan start");
            Console.WriteLine("Abbas Raziq");
            Console.WriteLine();

            string[] choices = new string[]
            {
                "Distance Coverter",
                "BMI Calculator",
            };

            ConsoleHelper.OutputTitle("Please select the application you wish to use ");
            choice = ConsoleHelper.SelectChoice(choices);

            if (choice == 1)
            {
                DistanceConverter converter = new DistanceConverter();
                converter.Run();
            }
            else if (choice == 2)
            {
                BMI calculator = new BMI();
                calculator.Run();
            }
        }
    }
}