using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// At the moment this class just tests the
    /// Grades enumeration names and descriptions
    /// Abbas Raziq
    /// 27/07/2021
    /// </summary>
    public class StudentGrades
    {
        
        //The grade values
        public const int LowestGradeF = 0;
        public const int LowestGradeD = 40;
        public const int LowestGradeC = 50;
        public const int LowestGradeB = 60;
        public const int LowestGradeA = 70;
        public const int HighestMark = 100;

        //The arrays and properties
        public string[] Students { get; set; }
        public int[] GradeProfile { get; }
        public int[] Marks { get; set; }
        
        public double Mean { get; set; }

        public int Minimum { get; set; }
        public int Maximum { get; set; }
        
        /// <summary>
        /// The application will be run using this method. 
        /// It will display the heading and allow the user 
        /// to choose whether or not to continue.
        /// </summary>
        public void Run()
        {
            
            bool repeat = true;
            while (repeat)
            {
                ConsoleHelper.OutputHeading("Student Grades");
                repeat = ConsoleHelper.WantToRepeat();
            }
        }

        //Declares Students Names and the Lenght of the Marks Array
        /// <summary>
        /// The names of the pupils are stored in this method. 
        /// It executes the algorithms for each student to input, 
        /// output, calculate statistics, and determine the grade profile.
        /// </summary>
        public StudentGrades()
        {
            Students = new string[NoStudents]
            {
                "Lewie","Cody","Cormac","Keanu","Shanice",
                "Kirsty","Kaydee","Trent","Vicki", "Margaret"
            };
            
            GradeProfile = new int[(int)Grades.A + 1];
            Marks = new int[Students.Length];

            InputMarks();
            OutputMarks();
            CalculateStats();
            CalculateGradeProfile();

        }
    
        /// <summary>
        /// This method allows the user to input a mark for each student
        /// from 0 - 100 and store it in the method.
        /// </summary>
        public void InputMarks()
        {
            int mark, index = 0;

            Console.WriteLine();

            foreach (string student in Students)
            {
                Console.Write("Please enter the students mark {0} ", student);
                mark = Convert.ToInt32(Console.ReadLine());
                Marks[index] = mark;
                index++;
            }

            Console.WriteLine();
        }

        /// <summary>
        /// This method allows the user to display the names of all 
        /// the students and also displays their name and mark.
        /// </summary>
        public void OutputMarks()
        {
            {
                ConsoleHelper.OutputTitle(" Student Marks");

                for (int index = 0; index < Students.Length; index++)
                {
                    Grades grade = ConvertToGrade(Marks[index]);
                    string name = EnumHelper<Grades>.GetName(grade);

                    Console.WriteLine($" {Students[index]} {Marks[index]}% - Grade {grade} | {name}");
                }
            }
        }

        /// <summary>
        /// This method will allow the user to convert the students marks
        /// into a grade from F - A.
        /// </summary>
        public Grades ConvertToGrade(int mark)
        {
            if (mark >= LowestMark && mark < LowestGradeD)
            {
                return Grades.F;
            }
            else if (mark >= LowestGradeD && mark < LowestGradeC)
            {
                return Grades.D;
            }
            else if (mark >= LowestGradeC && mark < LowestGradeB)
            {
                return Grades.C;
            }
            else if (mark >= LowestGradeB && mark < LowestGradeA)
            {
                return Grades.B;
            }
            else if (mark >= LowestGradeA && mark <= HighestMark)
            {
                return Grades.A;
            }
            else
            {
                return Grades.None;
            }
        }

        /// <summary>
        /// This method calculates the mean, maximum and minimum marks
        /// for each student and will display them.
        /// </summary>
        public void CalculateStats()
        {
            double total = 0;

            Minimum = HighestMark;
            Maximum = 0;

            foreach (int mark in Marks)
            {
                total = total + mark;
                if (mark > Maximum) Maximum = mark;
                if (mark < Minimum) Minimum = mark;
            }
            Mean = total / Marks.Length;
            OutputStats();
        }

        /// <summary>
        /// This method outputs the stats of all the students and
        /// will show the user the mean, minimum and maximum marks of the class.
        /// </summary>
        private void OutputStats()
        {
            ConsoleHelper.OutputTitle(" Student Marks Statistics");
            Console.WriteLine($" No. of students marked = {Marks.Length}");
            Console.WriteLine($" Minimum mark = {Minimum}");
            Console.WriteLine($" Mean mark = {Mean}");
            Console.WriteLine($" Maximum mark = {Maximum}");
        }
        
        /// <summary>
        /// This method will calculate the grade profile for the user
        /// (the percentage of students obtaining each grade)
        /// </summary>
        
        public void CalculateGradeProfile()
        {
            for (int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = 0;
            }

            foreach (int mark in Marks)
            {
                Grades grade = ConvertToGrade(mark);
                GradeProfile[(int)grade]++;
            }

            OutputGradeProfile();
        }

        /// <summary>
        /// This method will output the grade profile for the user
        /// (the percentage of students obtaining each grade)
        /// </summary>
        private void OutputGradeProfile()
        {
            Grades grade = Grades.None;
            ConsoleHelper.OutputYellow("\n Number of students that achieved " +
                             "the following grades");

            foreach (int count in GradeProfile)
            {
                int percentage = count * 100 / Marks.Length;
                Console.WriteLine($" \n Grade {grade} - {percentage}% | Count {count}");
                grade++;
            }

            Console.WriteLine();
        }
    }
}
