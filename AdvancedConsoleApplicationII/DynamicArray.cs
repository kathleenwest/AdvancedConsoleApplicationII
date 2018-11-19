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
    /// DynamicArray is a class which will behave like a standard array 
    /// but contain members to allow dynamic resizing of its contents.
    /// DynamicArray is a generic class that works with a generic type called T.
    /// </summary>
    /// <typeparam name="T">Generic type called T</typeparam>
    public class DynamicArray<T> : IDisposable, IEnumerable<T> where T : new()
    {
        #region fields

        // value indicating if this object has already been disposed 
        // and is awaiting garbage collection
        private bool _Disposed = false;

        // array of type T that will contain the array data for the class
        private T[] _Items;

        #endregion fields

        #region constructors

        /// <summary>
        /// Constructor: accepts the initial size of the array 
        /// as an int and initializes _Items to that size
        /// </summary>
        /// <param name="initialSize">int initial size of the array</param>
        public DynamicArray(int initialSize) 
        {
            _Items = new T[initialSize];
            Console.WriteLine($"Creating DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
        } // end of method

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public DynamicArray(IEnumerable<T> list)
        {
            _Items = new T[list.Count()];
            _Items = list.ToArray();
            Console.WriteLine($"Creating DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
        } // end of method

        #endregion constructors

        /// <summary>
        /// Creates a new array, called items, 
        /// of type T with the size supplied as this 
        /// method’s only parameter and copies the contents
        /// of the class array into this new array. The new
        /// array then becomes the replacement.
        /// </summary>
        /// <param name="newSize"></param>
        public void Resize(int newSize)
        {
            T[] items = new T[newSize];

            for (int i = 0; i < newSize; i++)
            {
                if (i < _Items.Length)
                {
                    items[i] = _Items[i];
                } // end of if
            } // end of for loop

            _Items = items;
        } // end of method

        /// <summary>
        /// Indexer property. 
        /// The data type for the property will be T since that is the 
        /// type of item stored in _Items. The accessor will return
        /// the value at the given index while the mutator will replace 
        /// the item at the given index with the supplied value
        /// </summary>
        /// <param name="index">int index for the array</param>
        /// <returns>value at the given index</returns>
        public T this[int index]
        {
            get
            {
                return _Items[index];
            }

            set
            {
                _Items[index] = value;
            }
        } //end of method

        #region interface implementation

        /// <summary>
        /// Implement the IEnumerable<T> interface
        /// </summary>
        /// <returns>IEnumerator<T></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return (_Items as IEnumerable<T>).GetEnumerator();
        } // end of method

        /// <summary>
        /// implement the IEnumerable<T> interface
        /// </summary>
        /// <returns>IEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Items.GetEnumerator();
        } // end of method

        /// <summary>
        /// Implements the IDisposable Interface
        /// Manually Called to Dispose of Memory
        /// </summary>
        public void Dispose()
        {
            Console.WriteLine($"Disposing DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
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
            // if _Disposed is already set to true that means 
            // the object has already been disposed and we 
            // should just exit the method with a return.
            if (_Disposed == true)
            {
                return;
            }

            // Clear managed data here
            // if the disposing parameter is true 
            // then this method was called via the 
            // other Dispose() overload
            if (disposing == true)
            {
                _Items = null;
            }

            // Any unmanaged Data would be cleared here

            _Disposed = true;
        } // end of method

        #endregion interface implementation

        /// <summary>
        /// Finalizer for the Class that gets called by the Garbage Collector
        /// </summary>
        ~DynamicArray()
        {
            Console.WriteLine($"Finalizing DynamicArray from thread {Thread.CurrentThread.ManagedThreadId}");
        } // end of method

    } // end of class

} // end of namespace
