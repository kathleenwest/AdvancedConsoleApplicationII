using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConsoleApplicationII
{
    /// <summary>
    /// Main Program to Test Swap, Dynamic Array, and Student Objects
    /// and their respective Garbage Collection
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main Program to Test Swap, Dynamic Array, and Student Objects
        /// and their respective Garbagae Collection
        /// </summary>
        /// <param name="args">No parameters</param>
        static void Main(string[] args)
        {
            // Testing Swap Feature
            int x = 12;
            int y = 34;
            Console.WriteLine($"x = {x}, y = {y}");
            Utilities.Swap(ref x, ref y);
            Console.WriteLine($"x = {x}, y = {y}");
            double d1 = 123.45;
            double d2 = 543.21;
            Console.WriteLine($"d1 = {d1}, d2 = {d2}");
            Utilities.Swap(ref d1, ref d2);
            Console.WriteLine($"d1 = {d1}, d2 = {d2}");

            // Test the Dynamic Array
            DynamicArrayTest();
            Console.WriteLine();
            // Test the Student 
            StudentTest();

            // Test the Garbage Collector
            Console.WriteLine("Press <ENTER> to start GC...");
            Console.ReadLine();
            GC.Collect();

            // Keeps the console open to see output
            Console.WriteLine("Press <ENTER> to quit...");
            Console.ReadLine();

        } // end of main method

        /// <summary>
        /// Method Test Driver for Dynamic Arrays
        /// </summary>
        static void DynamicArrayTest()
        {
            using (DynamicArray<int> a = new DynamicArray<int>(5))
            {
                a[0] = 123;
                foreach (int x in a)
                {
                    Console.WriteLine(x);
                }
            }

            DynamicArray<int> b = new DynamicArray<int>(5);
            b[0] = 123;
            foreach (int x in b)
            {
                Console.WriteLine(x);
            }
        } // end of method

        /// <summary>
        /// Test Driver for Student Objects
        /// </summary>
        private static void StudentTest()
        {
            List<Student> students = new List<Student>();
            Student s = new Student("Smith", "John", 3);
            s.Scores[0] = 90;
            s.Scores[1] = 85;
            s.Scores[2] = 97;
            students.Add(s);

            s = new Student("Williams", "Jane", 2);
            s.Scores[0] = 95;
            s.Scores[1] = 91;
            s.Scores.Resize(3);
            s.Scores[2] = 89;
            students.Add(s);

            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        } // end of method

    } // end of class
}// end of namespace
