using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace AdvancedConsoleApplicationII
{
    /// <summary>
    /// Represents a simple student object
    /// </summary>
    public class Student : IDisposable
    {
        #region Fields and Properties

        // Tracks if the object has been disposed
        private bool _Disposed = false;
        
        // first and last names for student
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Stores list of student's test scores
        public DynamicArray<int> Scores { get; set; }

        #endregion Fields and Properties

        /// <summary>
        /// Constructor for Student object
        /// </summary>
        /// <param name="lastName">Last name of the student (string)</param>
        /// <param name="firstName">First name of the student (string)</param>
        /// <param name="numScores">List of student's test scores (dynamic array)</param>
        public Student(string lastName, string firstName, int numScores)
        {
            FirstName = firstName;
            LastName = lastName;
            Scores = new DynamicArray<int>(numScores);
        } // end of method

        /// <summary>
        /// Override the ToString() method and output the student’s 
        /// LastName, FirstName, number of Scores and the average of Scores
        /// </summary>
        /// <returns>Formatted String</returns>
        public override string ToString()
        {
            return $"{LastName, -10} {FirstName, -10} Number of Scores: {Scores.Count(), 3} Average: {Scores.Average(),4:00.000}";
        } // end of method

        #region interface implementation

        /// <summary>
        /// Implements the IDisposable Interface
        /// Manually Called to Dispose of Memory
        /// </summary>
        public void Dispose()
        {
            Console.WriteLine($"Disposing Student from thread {Thread.CurrentThread.ManagedThreadId}");
            Dispose(true);
            GC.SuppressFinalize(this);
        } // end of method

        /// <summary>
        /// This method is responsible for cleaning up its 
        /// memory, both managed and unmanaged.
        /// </summary>
        /// <param name="disposing">boolean to indicate if this method was called 
        /// via the other Dispose() overload: true means we need to manually 
        /// dispose of managed resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_Disposed == true)
            {
                return;
            }

            // Clear managed data here
            if (disposing == true)
            {
                Scores?.Dispose();
                Scores = null;
            }

            // Any unmanaged Data would be cleared here

            _Disposed = true;

        } // end of method

        #endregion interface implementation

        /// <summary>
        /// Finalizer for the class object
        /// </summary>
        ~Student()
        {
            Console.WriteLine($"Finalizing Student from thread {Thread.CurrentThread.ManagedThreadId}");
        } // end of method

    } // end of class
} // end of namespace
