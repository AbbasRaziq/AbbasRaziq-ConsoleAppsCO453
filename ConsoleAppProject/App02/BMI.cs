using System;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This programme measures the user's BMI by 
    /// inputting imperial or metric units, displays 
    /// their BMI Index and BMI Status, and displays
    /// a message describing the extra risks to BAME classes.
    /// </summary>
    /// <author>
    /// Abbas Raziq version 0.1
    /// </author>
    /// 
    public class BMI_Calculator
    {
        public const string IMPERIAL = "Imperial";
        public const string METRIC = "Metric";

        public const string FEET = "Feet";
        public const string INCHES = "Inches";

        public const int INCHES_IN_FEET = 12;
        public const int POUNDS_IN_STONE = 14;
        public const int IMPERIAL_FACTOR = 703;

        public double BMI_Index { get; set; }
        public BMI_Categories_Category  { get; set; }

        public double Height { get; set; }
        public double Weight { get; set; }


        private string unitChoice;

        /// <summary>
        /// This method will run the program, outputting a
        /// heading, closing the program if the user does
        /// not wish to run it again
        /// </summary>
        public void Run()
        {
            bool repeat = true;
            while (repeat)
            {
                ConsoleHelper.OutputHeading("BMI Calculator");
                ConvertBMI();
                repeat = ConsoleHelper.WantToRepeat();
            }
        }

        /// <summary>
        /// This method offers the user the unit choices
        /// imeperial or metric. Whichever is chosen,
        /// it will calculate the result from the user
        /// input and output the BMI Index result.
        /// </summary>
        public void ConvertBMI()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Selecting units");

            string[] choices = new string[]
            {
                IMPERIAL, METRIC
            };

            Console.WriteLine($"\n Please select a unit to convert from\n");
            int choice = ConsoleHelper.SelectChoice(choices);
            unitChoice = choices[choice - 1];

            Console.WriteLine($"\n You have selected {unitChoice}! ");

            if (unitChoice == IMPERIAL)
            {
                ImperialInput();
                CalculateImperial();
            }
            else if (unitChoice == METRIC)
            {
                MetricInput();
                CalculateMetric();
            }

            OutputBMI_Index();
            string input = Console.ReadLine();
        }

        /// <summary>
        /// Prompts user to enter height in feet and inches
        /// and their weight in stones and pounds. Converts
        /// feet to inches and stones to pounds to calculate
        /// single unit results for both height and weight
        /// </summary>
        private void ImperialInput()
        {
            Console.WriteLine($"\n Enter your height" +
                " to the nearest feet & inches");

            Height = ConsoleHelper.InputNumberDouble($"\n Enter your height in feet > ");
            int inches = (int)ConsoleHelper.InputNumber($" Enter your height in inches > ", 0, INCHES_IN_FEET);
            Height = Height * INCHES_IN_FEET + inches;

            Console.WriteLine($"\n Enter your weight" +
                " to the nearest stones & pounds");

            Weight = ConsoleHelper.InputNumberDouble($"\n Enter your weight in stone > ");
            int pounds = (int)ConsoleHelper.InputNumber($" Enter your weight in pounds > ", 0, POUNDS_IN_STONE);
            Weight = Weight * POUNDS_IN_STONE + pounds;
        }

        /// <summary>
        /// Prompts user to enter height in metres and weight
        /// in kilograms
        /// </summary>
        private void MetricInput()
        {
            Console.WriteLine($"\n Enter your height " +
                "in metres");

            Height = ConsoleHelper.InputNumberDouble($"\n Enter your height in metres > ");

            Console.WriteLine($"\n Enter your weight " +
            "to the nearest kilogram");

            Weight = ConsoleHelper.InputNumberDouble($"\n Enter your weight in kilograms > ");
        }

        /// <summary>
        /// Calculates BMI using following sum for imperial units
        /// BMI = (weight in pounds) x 703 / (height in inches)2
        /// </summary>
        public void CalculateImperial()
        {
            BMI_Index = (Weight * IMPERIAL_FACTOR) / (Height * Height);
        }

        /// <summary>
        /// Calculates BMI using following sum for metric units
        /// BMI = (weight in kg) / (height in metres)2
        /// </summary>
        public void CalculateMetric()
        {
            BMI_Index = Weight / (Height * Height);
        }

        /// <summary>
        /// This method uses more and less thans to classify the BMI
        /// status through the BMI Index and the BMI_Status Enumeration
        /// class
        /// </summary>
        private void OutputBMI_Index()
        {
            if (BMI_Index < 18.50)
            {
                Category = BMI_Categories.UnderWeight;
            }
            else if (BMI_Index > 18.5 && BMI_Index < 24.9)
            {
                Category = BMI_Categories.NormalWeight;
            }
            else if (BMI_Index > 25.0 && BMI_Index < 29.9)
            {
                Category = BMI_Categories.OverWeight;
            }
            else if (BMI_Index > 30.00 && BMI_Index < 34.9)
            {
                Category = BMI_Categories.ObeseI;
            }
            else if (BMI_Index > 35.0 && BMI_Index < 39.9)
            {
                Category = BMI_Categories.ObeseII;
            }
            else if (BMI_Index >= 40.0)
            {
                Category = BMI_Categories.ObeseIII;
            }

            ConsoleHelper.OutputBlue($"\n Your BMI index is {BMI_Index: 0.00}");
            ConsoleHelper.OutputBlue($"Your BMI status is {Status}");

            ConsoleHelper.OutputGreen("\n If you are Black, Asian, or other minority " +
                "\n ethnic groups, you have a higher risk have a " +
                "\n higher risk of developing some long-term " +
                "\n conditions, such as type 2 diabetes. " +
                "\n These adults with a BMI of:");

            ConsoleHelper.OutputBlue("\n 23.0 or more are at increased risk " +
                "\n 27.5 or more are at high risk");
        }

        /// <summary>
        /// This method shows a list of Imperial and metric 
        /// unit options for them to select from.
        /// </summary>
        /// 
        private static string DisplayChoices(string prompt)
        {
            Console.WriteLine("\n");
            Console.WriteLine($" 1. {IMPERIAL}");
            Console.WriteLine($" 2. {METRIC}");
            Console.WriteLine();

            Console.Write(prompt);
            string choice = Console.ReadLine();
            return choice;
        }
    }
}
