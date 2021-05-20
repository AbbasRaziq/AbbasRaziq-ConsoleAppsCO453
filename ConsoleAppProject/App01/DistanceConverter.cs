using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This requires the user to enter their preferred distance conversion.
    /// It operates by selecting the measurement unit, then selecting the 
    /// desired unit result, inputting the value for conversion, performing
    /// the conversion, and finally providing the performance of the 
    /// conversion selected.
    /// </summary>
    /// <author>
    /// Abbas Raziq version 0.1
    /// </author>
    /// 
    public class DistanceConverter
    {
        public const int FEET_IN_MILES = 5280;

        public const double METRES_IN_MILES = 1609.34;

        public const double FEET_IN_METRES = 3.28084;

        public const string FEET = "Feet";
        public const string METRES = "Metres";
        public const string MILES = "Miles";

        public double FromDistance { get; set; }
        public double ToDistance { get; set; }

        public string FromUnit { get; set; }
        public string ToUnit { get; set; }

        /// <summary>
        /// If the user does not want to convert another distance, this method
        /// would run the programme, produce a heading, and exit the programme.
        /// </summary>
        /// 
        public void Run()
        {
            bool repeat = true;
            while (repeat)
            {
                ConsoleHelper.OutputHeading(" Distance Converter");
                ConvertDistance();
                repeat = ConsoleHelper.WantToRepeat();
            }
        }

        /// <summary>
        /// This method returns the heading and prompts the user to choose a 
        /// distance unit to convert from and convert to. It informs the user 
        /// that the distance is being transformed, measures the conversion, 
        /// and displays the outcome to the user.
        /// </summary>
        /// 
        public void ConvertDistance()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n Selecting units");
            string[] choices = new string[]
            {
                FEET, METRES, MILES
            };

            Console.WriteLine($"\n Please select a unit to convert from\n");
            int choice = ConsoleHelper.SelectChoice(choices);
            FromUnit = choices[choice - 1];
            Console.WriteLine($"\n You have selected {FromUnit}! ");

            Console.WriteLine($"\n Please select a unit to convert to\n");
            choice = ConsoleHelper.SelectChoice(choices);
            ToUnit = choices[choice - 1];
            Console.WriteLine($"\n You have selected {ToUnit}! ");

            FromDistance = ConsoleHelper.InputNumberDouble($"\n Please enter the number of" +
                $" {FromUnit} you wish to convert to {ToUnit} > ");

            ConsoleHelper.OutputTitle($"\n Converting {FromUnit} to {ToUnit} ");
            CalculateDistance();

            DistanceOutput();
        }
        /// <summary>
        /// This method performs the required calculations from the selected 
        /// input unit to the selected output unit.
        /// </summary>
        /// 
        public void CalculateDistance()
        {
            if (FromUnit == MILES && ToUnit == FEET)
            {
                ToDistance = FromDistance * FEET_IN_MILES;
            }
            else if (FromUnit == FEET && ToUnit == MILES)
            {
                ToDistance = FromDistance / FEET_IN_MILES;
            }
            else if (FromUnit == MILES && ToUnit == METRES)
            {
                ToDistance = FromDistance * METRES_IN_MILES;
            }
            else if (FromUnit == METRES && ToUnit == MILES)
            {
                ToDistance = FromDistance / METRES_IN_MILES;
            }
            else if (FromUnit == METRES && ToUnit == FEET)
            {
                ToDistance = FromDistance * FEET_IN_METRES;
            }
            else if (FromUnit == FEET && ToUnit == METRES)
            {
                ToDistance = FromDistance / FEET_IN_METRES;
            }
        }

        /// <summary>
        /// This method conducts the required calculations from the chosen 
        /// input unit to the chosen output unit.
        /// </summary>
        ///
        private static string DisplayChoices(string prompt)
        {
            Console.WriteLine("\n");
            Console.WriteLine($" 1. {FEET}");
            Console.WriteLine($" 2. {METRES}");
            Console.WriteLine($" 3. {MILES}");
            Console.WriteLine();

            Console.Write(prompt);
            string choice = Console.ReadLine();
            return choice;
        }

        /// <summary>
        /// This method reads the input unit and converts it to a 
        /// double-precision floating-point integer.
        /// </summary>
        /// 
        private double DistanceInput(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// This approach informs the consumer that the unit and measurement
        /// they selected have been translated to the desired unit and measurement.
        /// </summary>
        /// 
        private void DistanceOutput()
        {
            Console.WriteLine($"\n {FromDistance} {FromUnit}" +
                $" is {ToDistance} {ToUnit}!");
        }

    }






















































}



}
